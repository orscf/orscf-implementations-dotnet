using MedicalResearch.BillingData;
using MedicalResearch.BillingData.Persistence;
using MedicalResearch.BillingData.Persistence.EF;
using MedicalResearch.BillingData.Model;
using System;
using System.Data;
using System.Data.AccessControl;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MedicalResearch.BillingData.StoreAccess {

/// <summary> Provides CRUD access to stored BillableTasks (based on schema version '1.5.0') </summary>
public partial class BillableTaskStore : IBillableTasks {

  private ILogger _Logger = null;
  public BillableTaskStore(ILogger<BillableTaskStore> logger){
    _Logger = logger;
  }

  /// <summary> Loads a specific BillableTask addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="taskGuid"> a global unique id of a concrete study-task execution which is usually originated at the primary CRF or study management system ('SMS') </param>
  public BillableTask GetBillableTaskByTaskGuid(Guid taskGuid){
    var mac = AccessControlContext.Current;

    BillableTask result;
    using (BillingDataDbContext db = new BillingDataDbContext()) {

      //select models, bacause we dont want to return types with navigation-properties!
      var query = db.BillableTasks.AsNoTracking().AccessScopeFiltered().Select(BillableTaskEntity.BillableTaskSelector);

      query = query.Where((e)=>e.TaskGuid == taskGuid);

      //materialization / load
      result = query.SingleOrDefault();

    }

    return result;
  }

  /// <summary> Loads BillableTasks. </summary>
  /// <param name="page">Number of the page, which should be returned </param>
  /// <param name="pageSize">Max count of BillableTasks which should be returned </param>
  public BillableTask[] GetBillableTasks(int page = 1, int pageSize = 20){
    return this.SearchBillableTasks(null, null, page, pageSize); 
  }

  private static String[] _ExactMatchPropNames = new String[] {};
  private static String[] _FreetextPropNames = new String[] {"TaskName", "TaskExecutionTitle"};

  /// <summary> Loads BillableTasks where values matching to the given filterExpression</summary>
  /// <param name="filterExpression">a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' OR just '*' for all records</param>
  /// <param name="sortingExpression">one or more property names which are used as sort order (before pagination)</param>
  /// <param name="page">Number of the page, which should be returned</param>
  /// <param name="pageSize">Max count of BillableTasks which should be returned</param>
  public BillableTask[] SearchBillableTasks(String filterExpression, String sortingExpression = null, int page = 1, int pageSize = 20){
    var mac = AccessControlContext.Current;

    if(page < 1){
      page = 1;
    }
    if(pageSize < 1 || pageSize > 10000){
      pageSize = 20;
    }

    BillableTask[] result;
    using (BillingDataDbContext db = new BillingDataDbContext()) {

      //select models, bacause we dont want to return types with navigation-properties!
      var query = db.BillableTasks
        .AsNoTracking()
        .AccessScopeFiltered()
        .Select(BillableTaskEntity.BillableTaskSelector)
      ;
      
      //apply filter (if given)
      if(!String.IsNullOrWhiteSpace(filterExpression) && filterExpression != "*") {
        //just if the filterExpression isnt already a valid expression, treat it as a freetext seach string and transform it to a valid expression
        filterExpression = DynamicLinqExtensions.FreetextSearchStringToFilterExpression(filterExpression, _ExactMatchPropNames, _FreetextPropNames);
        if(filterExpression != null) {
          query = query.DynamicallyFiltered(filterExpression);
        }
      }

      //apply sorting
      if(String.IsNullOrWhiteSpace(sortingExpression)) {
        query = query.DynamicallySorted("TaskGuid");
      }
      else{
        query = query.DynamicallySorted(sortingExpression + ", TaskGuid");
      }

      //apply pagination
      query = query.Skip(pageSize * (page - 1)).Take(pageSize);

      //materialization / load
      result = query.ToArray();

    }

    return result;
  }

  /// <summary> Adds a new BillableTask and returns success. </summary>
  /// <param name="billableTask"> BillableTask containing the new values </param>
  public bool AddNewBillableTask(BillableTask billableTask){
    var mac = AccessControlContext.Current;

    BillableTaskEntity newEntity = new BillableTaskEntity();
    newEntity.CopyContentFrom(billableTask);

    using (BillingDataDbContext db = new BillingDataDbContext()) {

      //checks, that the new values are within the access control scope
      if(!this.PreValidateAccessControlScope(newEntity, db)){
        if(_Logger != null){
          _Logger.LogInformation("Adding BillableTask failed: record would be out of access control scope!");
        }
        return false;
      }

      if (db.BillableTasks.Where((e)=>e.TaskGuid == newEntity.TaskGuid).Any()) {
        if(_Logger != null){
          _Logger.LogInformation("Adding BillableTask failed: already existing record with this PK!");
        }
        return false;
      }

      db.BillableTasks.Add(newEntity);

      db.SaveChanges();
    }
    if(_Logger != null){
      _Logger.LogInformation("A BillableTask was added!");
    }

    return true;
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given BillableTask addressed by the primary identifier fields within the given BillableTask. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="billableTask"> BillableTask containing the new values (the primary identifier fields within the given BillableTask will be used to address the target record) </param>
  public bool UpdateBillableTask(BillableTask billableTask){
    return this.UpdateBillableTaskByTaskGuid(billableTask.TaskGuid, billableTask);
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given BillableTask addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="taskGuid"> a global unique id of a concrete study-task execution which is usually originated at the primary CRF or study management system ('SMS') </param>
  /// <param name="billableTask"> BillableTask containing the new values (the primary identifier fields within the given BillableTask will be ignored) </param>
  public bool UpdateBillableTaskByTaskGuid(Guid taskGuid, BillableTask billableTask){
    var mac = AccessControlContext.Current;

    BillableTaskEntity existingEntity;
    using (BillingDataDbContext db = new BillingDataDbContext()) {

      IQueryable<BillableTaskEntity> query = db.BillableTasks;

      query = query.Where((e)=>e.TaskGuid == taskGuid).AccessScopeFiltered();

      //materialization / load
      existingEntity = query.SingleOrDefault();

      if(existingEntity == null) {
        if(_Logger != null){
          _Logger.LogInformation("Updating BillableTask failed: no record with this PK!");
        }
        return false;
      }

      bool changeAttemptOnFixedField = false;
      existingEntity.CopyContentFrom(billableTask, (name) => changeAttemptOnFixedField = true);

      if (changeAttemptOnFixedField) {
        if(_Logger != null){
          _Logger.LogInformation("Updating BillableTask failed: change attempt on FIXED field!");
        }
        return false;
      }

      //checks, that the new values are within the access control scope
      if(!this.PreValidateAccessControlScope(existingEntity, db)){
        if(_Logger != null){
          _Logger.LogInformation("Updating BillableTask failed: record would be out of access control scope!");
        }
        return false;
      }

      db.SaveChanges();
    }
    if(_Logger != null){
      _Logger.LogInformation("A BillableTask was updated!");
    }

    return true;
  }

  /// <summary> Deletes a specific BillableTask addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="taskGuid"> a global unique id of a concrete study-task execution which is usually originated at the primary CRF or study management system ('SMS') </param>
  public bool DeleteBillableTaskByTaskGuid(Guid taskGuid){
    var mac = AccessControlContext.Current;

    BillableTaskEntity existingEntity;
    using (BillingDataDbContext db = new BillingDataDbContext()) {

      IQueryable<BillableTaskEntity> query = db.BillableTasks.AccessScopeFiltered();

      query = query.Where((e)=>e.TaskGuid == taskGuid);

      //materialization / load
      existingEntity = query.SingleOrDefault();

      if (existingEntity == null) {
        if(_Logger != null){
          _Logger.LogInformation("Updating BillableTask failed: no record with this PK!");
        }
        return false;
      }

      db.BillableTasks.Remove(existingEntity);

      db.SaveChanges();
    }
    if(_Logger != null){
      _Logger.LogInformation("A BillableTask was deleted!");
    }

    return true;
  }

  private bool PreValidateAccessControlScope(BillableTaskEntity entity, BillingDataDbContext db){

    var filterExpression = EntityAccessControl.BuildExpressionForLocalEntity<BillableTaskEntity>(AccessControlContext.Current);
    if(!filterExpression.Compile().Invoke(entity)) {
      return false;
    }

    if(!db.BillableVisits.Where((tgt)=> tgt.VisitGuid==entity.VisitGuid ).AccessScopeFiltered().Any()) {
      return false;
    }
    return true;
  }

}

/// <summary> Provides CRUD access to stored BillableVisits (based on schema version '1.5.0') </summary>
public partial class BillableVisitStore : IBillableVisits {

  private ILogger _Logger = null;
  public BillableVisitStore(ILogger<BillableVisitStore> logger){
    _Logger = logger;
  }

  /// <summary> Loads a specific BillableVisit addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="visitGuid"> a global unique id of a concrete study-visit execution which is usually originated at the primary CRF or study management system ('SMS') </param>
  public BillableVisit GetBillableVisitByVisitGuid(Guid visitGuid){
    var mac = AccessControlContext.Current;

    BillableVisit result;
    using (BillingDataDbContext db = new BillingDataDbContext()) {

      //select models, bacause we dont want to return types with navigation-properties!
      var query = db.BillableVisits.AsNoTracking().AccessScopeFiltered().Select(BillableVisitEntity.BillableVisitSelector);

      query = query.Where((e)=>e.VisitGuid == visitGuid);

      //materialization / load
      result = query.SingleOrDefault();

    }

    return result;
  }

  /// <summary> Loads BillableVisits. </summary>
  /// <param name="page">Number of the page, which should be returned </param>
  /// <param name="pageSize">Max count of BillableVisits which should be returned </param>
  public BillableVisit[] GetBillableVisits(int page = 1, int pageSize = 20){
    return this.SearchBillableVisits(null, null, page, pageSize); 
  }

  private static String[] _ExactMatchPropNames = new String[] {};
  private static String[] _FreetextPropNames = new String[] {"ParticipantIdentifier", "VisitProdecureName", "VisitExecutionTitle"};

  /// <summary> Loads BillableVisits where values matching to the given filterExpression</summary>
  /// <param name="filterExpression">a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' OR just '*' for all records</param>
  /// <param name="sortingExpression">one or more property names which are used as sort order (before pagination)</param>
  /// <param name="page">Number of the page, which should be returned</param>
  /// <param name="pageSize">Max count of BillableVisits which should be returned</param>
  public BillableVisit[] SearchBillableVisits(String filterExpression, String sortingExpression = null, int page = 1, int pageSize = 20){
    var mac = AccessControlContext.Current;

    if(page < 1){
      page = 1;
    }
    if(pageSize < 1 || pageSize > 10000){
      pageSize = 20;
    }

    BillableVisit[] result;
    using (BillingDataDbContext db = new BillingDataDbContext()) {

      //select models, bacause we dont want to return types with navigation-properties!
      var query = db.BillableVisits
        .AsNoTracking()
        .AccessScopeFiltered()
        .Select(BillableVisitEntity.BillableVisitSelector)
      ;
      
      //apply filter (if given)
      if(!String.IsNullOrWhiteSpace(filterExpression) && filterExpression != "*") {
        //just if the filterExpression isnt already a valid expression, treat it as a freetext seach string and transform it to a valid expression
        filterExpression = DynamicLinqExtensions.FreetextSearchStringToFilterExpression(filterExpression, _ExactMatchPropNames, _FreetextPropNames);
        if(filterExpression != null) {
          query = query.DynamicallyFiltered(filterExpression);
        }
      }

      //apply sorting
      if(String.IsNullOrWhiteSpace(sortingExpression)) {
        query = query.DynamicallySorted("VisitGuid");
      }
      else{
        query = query.DynamicallySorted(sortingExpression + ", VisitGuid");
      }

      //apply pagination
      query = query.Skip(pageSize * (page - 1)).Take(pageSize);

      //materialization / load
      result = query.ToArray();

    }

    return result;
  }

  /// <summary> Adds a new BillableVisit and returns success. </summary>
  /// <param name="billableVisit"> BillableVisit containing the new values </param>
  public bool AddNewBillableVisit(BillableVisit billableVisit){
    var mac = AccessControlContext.Current;

    BillableVisitEntity newEntity = new BillableVisitEntity();
    newEntity.CopyContentFrom(billableVisit);

    using (BillingDataDbContext db = new BillingDataDbContext()) {

      //checks, that the new values are within the access control scope
      if(!this.PreValidateAccessControlScope(newEntity, db)){
        if(_Logger != null){
          _Logger.LogInformation("Adding BillableVisit failed: record would be out of access control scope!");
        }
        return false;
      }

      if (db.BillableVisits.Where((e)=>e.VisitGuid == newEntity.VisitGuid).Any()) {
        if(_Logger != null){
          _Logger.LogInformation("Adding BillableVisit failed: already existing record with this PK!");
        }
        return false;
      }

      db.BillableVisits.Add(newEntity);

      db.SaveChanges();
    }
    if(_Logger != null){
      _Logger.LogInformation("A BillableVisit was added!");
    }

    return true;
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given BillableVisit addressed by the primary identifier fields within the given BillableVisit. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="billableVisit"> BillableVisit containing the new values (the primary identifier fields within the given BillableVisit will be used to address the target record) </param>
  public bool UpdateBillableVisit(BillableVisit billableVisit){
    return this.UpdateBillableVisitByVisitGuid(billableVisit.VisitGuid, billableVisit);
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given BillableVisit addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="visitGuid"> a global unique id of a concrete study-visit execution which is usually originated at the primary CRF or study management system ('SMS') </param>
  /// <param name="billableVisit"> BillableVisit containing the new values (the primary identifier fields within the given BillableVisit will be ignored) </param>
  public bool UpdateBillableVisitByVisitGuid(Guid visitGuid, BillableVisit billableVisit){
    var mac = AccessControlContext.Current;

    BillableVisitEntity existingEntity;
    using (BillingDataDbContext db = new BillingDataDbContext()) {

      IQueryable<BillableVisitEntity> query = db.BillableVisits;

      query = query.Where((e)=>e.VisitGuid == visitGuid).AccessScopeFiltered();

      //materialization / load
      existingEntity = query.SingleOrDefault();

      if(existingEntity == null) {
        if(_Logger != null){
          _Logger.LogInformation("Updating BillableVisit failed: no record with this PK!");
        }
        return false;
      }

      bool changeAttemptOnFixedField = false;
      existingEntity.CopyContentFrom(billableVisit, (name) => changeAttemptOnFixedField = true);

      if (changeAttemptOnFixedField) {
        if(_Logger != null){
          _Logger.LogInformation("Updating BillableVisit failed: change attempt on FIXED field!");
        }
        return false;
      }

      //checks, that the new values are within the access control scope
      if(!this.PreValidateAccessControlScope(existingEntity, db)){
        if(_Logger != null){
          _Logger.LogInformation("Updating BillableVisit failed: record would be out of access control scope!");
        }
        return false;
      }

      db.SaveChanges();
    }
    if(_Logger != null){
      _Logger.LogInformation("A BillableVisit was updated!");
    }

    return true;
  }

  /// <summary> Deletes a specific BillableVisit addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="visitGuid"> a global unique id of a concrete study-visit execution which is usually originated at the primary CRF or study management system ('SMS') </param>
  public bool DeleteBillableVisitByVisitGuid(Guid visitGuid){
    var mac = AccessControlContext.Current;

    BillableVisitEntity existingEntity;
    using (BillingDataDbContext db = new BillingDataDbContext()) {

      IQueryable<BillableVisitEntity> query = db.BillableVisits.AccessScopeFiltered();

      query = query.Where((e)=>e.VisitGuid == visitGuid);

      //materialization / load
      existingEntity = query.SingleOrDefault();

      if (existingEntity == null) {
        if(_Logger != null){
          _Logger.LogInformation("Updating BillableVisit failed: no record with this PK!");
        }
        return false;
      }

      db.BillableVisits.Remove(existingEntity);

      db.SaveChanges();
    }
    if(_Logger != null){
      _Logger.LogInformation("A BillableVisit was deleted!");
    }

    return true;
  }

  private bool PreValidateAccessControlScope(BillableVisitEntity entity, BillingDataDbContext db){

    var filterExpression = EntityAccessControl.BuildExpressionForLocalEntity<BillableVisitEntity>(AccessControlContext.Current);
    if(!filterExpression.Compile().Invoke(entity)) {
      return false;
    }

    if(!db.StudyExecutionScopes.Where((tgt)=> tgt.StudyExecutionIdentifier==entity.StudyExecutionIdentifier ).AccessScopeFiltered().Any()) {
      return false;
    }
    if(!db.BillingDemands.Where((tgt)=> tgt.Id==entity.BillingDemandId ).AccessScopeFiltered().Any()) {
      return false;
    }
    if(!db.Invoices.Where((tgt)=> tgt.Id==entity.InvoiceId ).AccessScopeFiltered().Any()) {
      return false;
    }
    return true;
  }

}

/// <summary> Provides CRUD access to stored StudyExecutionScopes (based on schema version '1.5.0') </summary>
public partial class StudyExecutionScopeStore : IStudyExecutionScopes {

  private ILogger _Logger = null;
  public StudyExecutionScopeStore(ILogger<StudyExecutionScopeStore> logger){
    _Logger = logger;
  }

  /// <summary> Loads a specific StudyExecutionScope addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="studyExecutionIdentifier"> a global unique id of a concrete study execution (dedicated to a concrete institute) which is usually originated at the primary CRF or study management system ('SMS') </param>
  public StudyExecutionScope GetStudyExecutionScopeByStudyExecutionIdentifier(Guid studyExecutionIdentifier){
    var mac = AccessControlContext.Current;

    StudyExecutionScope result;
    using (BillingDataDbContext db = new BillingDataDbContext()) {

      //select models, bacause we dont want to return types with navigation-properties!
      var query = db.StudyExecutionScopes.AsNoTracking().AccessScopeFiltered().Select(StudyExecutionScopeEntity.StudyExecutionScopeSelector);

      query = query.Where((e)=>e.StudyExecutionIdentifier == studyExecutionIdentifier);

      //materialization / load
      result = query.SingleOrDefault();

    }

    return result;
  }

  /// <summary> Loads StudyExecutionScopes. </summary>
  /// <param name="page">Number of the page, which should be returned </param>
  /// <param name="pageSize">Max count of StudyExecutionScopes which should be returned </param>
  public StudyExecutionScope[] GetStudyExecutionScopes(int page = 1, int pageSize = 20){
    return this.SearchStudyExecutionScopes(null, null, page, pageSize); 
  }

  private static String[] _ExactMatchPropNames = new String[] {};
  private static String[] _FreetextPropNames = new String[] {"ExecutingInstituteIdentifier", "StudyWorkflowName", "StudyWorkflowVersion", "ExtendedMetaData"};

  /// <summary> Loads StudyExecutionScopes where values matching to the given filterExpression</summary>
  /// <param name="filterExpression">a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' OR just '*' for all records</param>
  /// <param name="sortingExpression">one or more property names which are used as sort order (before pagination)</param>
  /// <param name="page">Number of the page, which should be returned</param>
  /// <param name="pageSize">Max count of StudyExecutionScopes which should be returned</param>
  public StudyExecutionScope[] SearchStudyExecutionScopes(String filterExpression, String sortingExpression = null, int page = 1, int pageSize = 20){
    var mac = AccessControlContext.Current;

    if(page < 1){
      page = 1;
    }
    if(pageSize < 1 || pageSize > 10000){
      pageSize = 20;
    }

    StudyExecutionScope[] result;
    using (BillingDataDbContext db = new BillingDataDbContext()) {

      //select models, bacause we dont want to return types with navigation-properties!
      var query = db.StudyExecutionScopes
        .AsNoTracking()
        .AccessScopeFiltered()
        .Select(StudyExecutionScopeEntity.StudyExecutionScopeSelector)
      ;
      
      //apply filter (if given)
      if(!String.IsNullOrWhiteSpace(filterExpression) && filterExpression != "*") {
        //just if the filterExpression isnt already a valid expression, treat it as a freetext seach string and transform it to a valid expression
        filterExpression = DynamicLinqExtensions.FreetextSearchStringToFilterExpression(filterExpression, _ExactMatchPropNames, _FreetextPropNames);
        if(filterExpression != null) {
          query = query.DynamicallyFiltered(filterExpression);
        }
      }

      //apply sorting
      if(String.IsNullOrWhiteSpace(sortingExpression)) {
        query = query.DynamicallySorted("StudyExecutionIdentifier");
      }
      else{
        query = query.DynamicallySorted(sortingExpression + ", StudyExecutionIdentifier");
      }

      //apply pagination
      query = query.Skip(pageSize * (page - 1)).Take(pageSize);

      //materialization / load
      result = query.ToArray();

    }

    return result;
  }

  /// <summary> Adds a new StudyExecutionScope and returns success. </summary>
  /// <param name="studyExecutionScope"> StudyExecutionScope containing the new values </param>
  public bool AddNewStudyExecutionScope(StudyExecutionScope studyExecutionScope){
    var mac = AccessControlContext.Current;

    StudyExecutionScopeEntity newEntity = new StudyExecutionScopeEntity();
    newEntity.CopyContentFrom(studyExecutionScope);

    using (BillingDataDbContext db = new BillingDataDbContext()) {

      //checks, that the new values are within the access control scope
      if(!this.PreValidateAccessControlScope(newEntity, db)){
        if(_Logger != null){
          _Logger.LogInformation("Adding StudyExecutionScope failed: record would be out of access control scope!");
        }
        return false;
      }

      if (db.StudyExecutionScopes.Where((e)=>e.StudyExecutionIdentifier == newEntity.StudyExecutionIdentifier).Any()) {
        if(_Logger != null){
          _Logger.LogInformation("Adding StudyExecutionScope failed: already existing record with this PK!");
        }
        return false;
      }

      db.StudyExecutionScopes.Add(newEntity);

      db.SaveChanges();
    }
    if(_Logger != null){
      _Logger.LogInformation("A StudyExecutionScope was added!");
    }

    return true;
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given StudyExecutionScope addressed by the primary identifier fields within the given StudyExecutionScope. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="studyExecutionScope"> StudyExecutionScope containing the new values (the primary identifier fields within the given StudyExecutionScope will be used to address the target record) </param>
  public bool UpdateStudyExecutionScope(StudyExecutionScope studyExecutionScope){
    return this.UpdateStudyExecutionScopeByStudyExecutionIdentifier(studyExecutionScope.StudyExecutionIdentifier, studyExecutionScope);
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given StudyExecutionScope addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="studyExecutionIdentifier"> a global unique id of a concrete study execution (dedicated to a concrete institute) which is usually originated at the primary CRF or study management system ('SMS') </param>
  /// <param name="studyExecutionScope"> StudyExecutionScope containing the new values (the primary identifier fields within the given StudyExecutionScope will be ignored) </param>
  public bool UpdateStudyExecutionScopeByStudyExecutionIdentifier(Guid studyExecutionIdentifier, StudyExecutionScope studyExecutionScope){
    var mac = AccessControlContext.Current;

    StudyExecutionScopeEntity existingEntity;
    using (BillingDataDbContext db = new BillingDataDbContext()) {

      IQueryable<StudyExecutionScopeEntity> query = db.StudyExecutionScopes;

      query = query.Where((e)=>e.StudyExecutionIdentifier == studyExecutionIdentifier).AccessScopeFiltered();

      //materialization / load
      existingEntity = query.SingleOrDefault();

      if(existingEntity == null) {
        if(_Logger != null){
          _Logger.LogInformation("Updating StudyExecutionScope failed: no record with this PK!");
        }
        return false;
      }

      bool changeAttemptOnFixedField = false;
      existingEntity.CopyContentFrom(studyExecutionScope, (name) => changeAttemptOnFixedField = true);

      if (changeAttemptOnFixedField) {
        if(_Logger != null){
          _Logger.LogInformation("Updating StudyExecutionScope failed: change attempt on FIXED field!");
        }
        return false;
      }

      //checks, that the new values are within the access control scope
      if(!this.PreValidateAccessControlScope(existingEntity, db)){
        if(_Logger != null){
          _Logger.LogInformation("Updating StudyExecutionScope failed: record would be out of access control scope!");
        }
        return false;
      }

      db.SaveChanges();
    }
    if(_Logger != null){
      _Logger.LogInformation("A StudyExecutionScope was updated!");
    }

    return true;
  }

  /// <summary> Deletes a specific StudyExecutionScope addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="studyExecutionIdentifier"> a global unique id of a concrete study execution (dedicated to a concrete institute) which is usually originated at the primary CRF or study management system ('SMS') </param>
  public bool DeleteStudyExecutionScopeByStudyExecutionIdentifier(Guid studyExecutionIdentifier){
    var mac = AccessControlContext.Current;

    StudyExecutionScopeEntity existingEntity;
    using (BillingDataDbContext db = new BillingDataDbContext()) {

      IQueryable<StudyExecutionScopeEntity> query = db.StudyExecutionScopes.AccessScopeFiltered();

      query = query.Where((e)=>e.StudyExecutionIdentifier == studyExecutionIdentifier);

      //materialization / load
      existingEntity = query.SingleOrDefault();

      if (existingEntity == null) {
        if(_Logger != null){
          _Logger.LogInformation("Updating StudyExecutionScope failed: no record with this PK!");
        }
        return false;
      }

      db.StudyExecutionScopes.Remove(existingEntity);

      db.SaveChanges();
    }
    if(_Logger != null){
      _Logger.LogInformation("A StudyExecutionScope was deleted!");
    }

    return true;
  }

  private bool PreValidateAccessControlScope(StudyExecutionScopeEntity entity, BillingDataDbContext db){

    var filterExpression = EntityAccessControl.BuildExpressionForLocalEntity<StudyExecutionScopeEntity>(AccessControlContext.Current);
    if(!filterExpression.Compile().Invoke(entity)) {
      return false;
    }

    return true;
  }

}

/// <summary> Provides CRUD access to stored BillingDemands (based on schema version '1.5.0') </summary>
public partial class BillingDemandStore : IBillingDemands {

  private ILogger _Logger = null;
  public BillingDemandStore(ILogger<BillingDemandStore> logger){
    _Logger = logger;
  }

  /// <summary> Loads a specific BillingDemand addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="id"> Represents the primary identity of a BillingDemand </param>
  public BillingDemand GetBillingDemandById(Guid id){
    var mac = AccessControlContext.Current;

    BillingDemand result;
    using (BillingDataDbContext db = new BillingDataDbContext()) {

      //select models, bacause we dont want to return types with navigation-properties!
      var query = db.BillingDemands.AsNoTracking().AccessScopeFiltered().Select(BillingDemandEntity.BillingDemandSelector);

      query = query.Where((e)=>e.Id == id);

      //materialization / load
      result = query.SingleOrDefault();

    }

    return result;
  }

  /// <summary> Loads BillingDemands. </summary>
  /// <param name="page">Number of the page, which should be returned </param>
  /// <param name="pageSize">Max count of BillingDemands which should be returned </param>
  public BillingDemand[] GetBillingDemands(int page = 1, int pageSize = 20){
    return this.SearchBillingDemands(null, null, page, pageSize); 
  }

  private static String[] _ExactMatchPropNames = new String[] {};
  private static String[] _FreetextPropNames = new String[] {"OfficialNumber", "CreatedByPerson"};

  /// <summary> Loads BillingDemands where values matching to the given filterExpression</summary>
  /// <param name="filterExpression">a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' OR just '*' for all records</param>
  /// <param name="sortingExpression">one or more property names which are used as sort order (before pagination)</param>
  /// <param name="page">Number of the page, which should be returned</param>
  /// <param name="pageSize">Max count of BillingDemands which should be returned</param>
  public BillingDemand[] SearchBillingDemands(String filterExpression, String sortingExpression = null, int page = 1, int pageSize = 20){
    var mac = AccessControlContext.Current;

    if(page < 1){
      page = 1;
    }
    if(pageSize < 1 || pageSize > 10000){
      pageSize = 20;
    }

    BillingDemand[] result;
    using (BillingDataDbContext db = new BillingDataDbContext()) {

      //select models, bacause we dont want to return types with navigation-properties!
      var query = db.BillingDemands
        .AsNoTracking()
        .AccessScopeFiltered()
        .Select(BillingDemandEntity.BillingDemandSelector)
      ;
      
      //apply filter (if given)
      if(!String.IsNullOrWhiteSpace(filterExpression) && filterExpression != "*") {
        //just if the filterExpression isnt already a valid expression, treat it as a freetext seach string and transform it to a valid expression
        filterExpression = DynamicLinqExtensions.FreetextSearchStringToFilterExpression(filterExpression, _ExactMatchPropNames, _FreetextPropNames);
        if(filterExpression != null) {
          query = query.DynamicallyFiltered(filterExpression);
        }
      }

      //apply sorting
      if(String.IsNullOrWhiteSpace(sortingExpression)) {
        query = query.DynamicallySorted("Id");
      }
      else{
        query = query.DynamicallySorted(sortingExpression + ", Id");
      }

      //apply pagination
      query = query.Skip(pageSize * (page - 1)).Take(pageSize);

      //materialization / load
      result = query.ToArray();

    }

    return result;
  }

  /// <summary> Adds a new BillingDemand and returns success. </summary>
  /// <param name="billingDemand"> BillingDemand containing the new values </param>
  public bool AddNewBillingDemand(BillingDemand billingDemand){
    var mac = AccessControlContext.Current;

    BillingDemandEntity newEntity = new BillingDemandEntity();
    newEntity.CopyContentFrom(billingDemand);

    using (BillingDataDbContext db = new BillingDataDbContext()) {

      //checks, that the new values are within the access control scope
      if(!this.PreValidateAccessControlScope(newEntity, db)){
        if(_Logger != null){
          _Logger.LogInformation("Adding BillingDemand failed: record would be out of access control scope!");
        }
        return false;
      }

      if (db.BillingDemands.Where((e)=>e.Id == newEntity.Id).Any()) {
        if(_Logger != null){
          _Logger.LogInformation("Adding BillingDemand failed: already existing record with this PK!");
        }
        return false;
      }

      db.BillingDemands.Add(newEntity);

      db.SaveChanges();
    }
    if(_Logger != null){
      _Logger.LogInformation("A BillingDemand was added!");
    }

    return true;
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given BillingDemand addressed by the primary identifier fields within the given BillingDemand. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="billingDemand"> BillingDemand containing the new values (the primary identifier fields within the given BillingDemand will be used to address the target record) </param>
  public bool UpdateBillingDemand(BillingDemand billingDemand){
    return this.UpdateBillingDemandById(billingDemand.Id, billingDemand);
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given BillingDemand addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="id"> Represents the primary identity of a BillingDemand </param>
  /// <param name="billingDemand"> BillingDemand containing the new values (the primary identifier fields within the given BillingDemand will be ignored) </param>
  public bool UpdateBillingDemandById(Guid id, BillingDemand billingDemand){
    var mac = AccessControlContext.Current;

    BillingDemandEntity existingEntity;
    using (BillingDataDbContext db = new BillingDataDbContext()) {

      IQueryable<BillingDemandEntity> query = db.BillingDemands;

      query = query.Where((e)=>e.Id == id).AccessScopeFiltered();

      //materialization / load
      existingEntity = query.SingleOrDefault();

      if(existingEntity == null) {
        if(_Logger != null){
          _Logger.LogInformation("Updating BillingDemand failed: no record with this PK!");
        }
        return false;
      }

      bool changeAttemptOnFixedField = false;
      existingEntity.CopyContentFrom(billingDemand, (name) => changeAttemptOnFixedField = true);

      if (changeAttemptOnFixedField) {
        if(_Logger != null){
          _Logger.LogInformation("Updating BillingDemand failed: change attempt on FIXED field!");
        }
        return false;
      }

      //checks, that the new values are within the access control scope
      if(!this.PreValidateAccessControlScope(existingEntity, db)){
        if(_Logger != null){
          _Logger.LogInformation("Updating BillingDemand failed: record would be out of access control scope!");
        }
        return false;
      }

      db.SaveChanges();
    }
    if(_Logger != null){
      _Logger.LogInformation("A BillingDemand was updated!");
    }

    return true;
  }

  /// <summary> Deletes a specific BillingDemand addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="id"> Represents the primary identity of a BillingDemand </param>
  public bool DeleteBillingDemandById(Guid id){
    var mac = AccessControlContext.Current;

    BillingDemandEntity existingEntity;
    using (BillingDataDbContext db = new BillingDataDbContext()) {

      IQueryable<BillingDemandEntity> query = db.BillingDemands.AccessScopeFiltered();

      query = query.Where((e)=>e.Id == id);

      //materialization / load
      existingEntity = query.SingleOrDefault();

      if (existingEntity == null) {
        if(_Logger != null){
          _Logger.LogInformation("Updating BillingDemand failed: no record with this PK!");
        }
        return false;
      }

      db.BillingDemands.Remove(existingEntity);

      db.SaveChanges();
    }
    if(_Logger != null){
      _Logger.LogInformation("A BillingDemand was deleted!");
    }

    return true;
  }

  private bool PreValidateAccessControlScope(BillingDemandEntity entity, BillingDataDbContext db){

    var filterExpression = EntityAccessControl.BuildExpressionForLocalEntity<BillingDemandEntity>(AccessControlContext.Current);
    if(!filterExpression.Compile().Invoke(entity)) {
      return false;
    }

    if(!db.StudyExecutionScopes.Where((tgt)=> tgt.StudyExecutionIdentifier==entity.StudyExecutionIdentifier ).AccessScopeFiltered().Any()) {
      return false;
    }
    return true;
  }

}

/// <summary> Provides CRUD access to stored Invoices (based on schema version '1.5.0') </summary>
public partial class InvoiceStore : IInvoices {

  private ILogger _Logger = null;
  public InvoiceStore(ILogger<InvoiceStore> logger){
    _Logger = logger;
  }

  /// <summary> Loads a specific Invoice addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="id"> Represents the primary identity of a Invoice </param>
  public Invoice GetInvoiceById(Guid id){
    var mac = AccessControlContext.Current;

    Invoice result;
    using (BillingDataDbContext db = new BillingDataDbContext()) {

      //select models, bacause we dont want to return types with navigation-properties!
      var query = db.Invoices.AsNoTracking().AccessScopeFiltered().Select(InvoiceEntity.InvoiceSelector);

      query = query.Where((e)=>e.Id == id);

      //materialization / load
      result = query.SingleOrDefault();

    }

    return result;
  }

  /// <summary> Loads Invoices. </summary>
  /// <param name="page">Number of the page, which should be returned </param>
  /// <param name="pageSize">Max count of Invoices which should be returned </param>
  public Invoice[] GetInvoices(int page = 1, int pageSize = 20){
    return this.SearchInvoices(null, null, page, pageSize); 
  }

  private static String[] _ExactMatchPropNames = new String[] {};
  private static String[] _FreetextPropNames = new String[] {"OfficialNumber", "CreatedByPerson"};

  /// <summary> Loads Invoices where values matching to the given filterExpression</summary>
  /// <param name="filterExpression">a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' OR just '*' for all records</param>
  /// <param name="sortingExpression">one or more property names which are used as sort order (before pagination)</param>
  /// <param name="page">Number of the page, which should be returned</param>
  /// <param name="pageSize">Max count of Invoices which should be returned</param>
  public Invoice[] SearchInvoices(String filterExpression, String sortingExpression = null, int page = 1, int pageSize = 20){
    var mac = AccessControlContext.Current;

    if(page < 1){
      page = 1;
    }
    if(pageSize < 1 || pageSize > 10000){
      pageSize = 20;
    }

    Invoice[] result;
    using (BillingDataDbContext db = new BillingDataDbContext()) {

      //select models, bacause we dont want to return types with navigation-properties!
      var query = db.Invoices
        .AsNoTracking()
        .AccessScopeFiltered()
        .Select(InvoiceEntity.InvoiceSelector)
      ;
      
      //apply filter (if given)
      if(!String.IsNullOrWhiteSpace(filterExpression) && filterExpression != "*") {
        //just if the filterExpression isnt already a valid expression, treat it as a freetext seach string and transform it to a valid expression
        filterExpression = DynamicLinqExtensions.FreetextSearchStringToFilterExpression(filterExpression, _ExactMatchPropNames, _FreetextPropNames);
        if(filterExpression != null) {
          query = query.DynamicallyFiltered(filterExpression);
        }
      }

      //apply sorting
      if(String.IsNullOrWhiteSpace(sortingExpression)) {
        query = query.DynamicallySorted("Id");
      }
      else{
        query = query.DynamicallySorted(sortingExpression + ", Id");
      }

      //apply pagination
      query = query.Skip(pageSize * (page - 1)).Take(pageSize);

      //materialization / load
      result = query.ToArray();

    }

    return result;
  }

  /// <summary> Adds a new Invoice and returns success. </summary>
  /// <param name="invoice"> Invoice containing the new values </param>
  public bool AddNewInvoice(Invoice invoice){
    var mac = AccessControlContext.Current;

    InvoiceEntity newEntity = new InvoiceEntity();
    newEntity.CopyContentFrom(invoice);

    using (BillingDataDbContext db = new BillingDataDbContext()) {

      //checks, that the new values are within the access control scope
      if(!this.PreValidateAccessControlScope(newEntity, db)){
        if(_Logger != null){
          _Logger.LogInformation("Adding Invoice failed: record would be out of access control scope!");
        }
        return false;
      }

      if (db.Invoices.Where((e)=>e.Id == newEntity.Id).Any()) {
        if(_Logger != null){
          _Logger.LogInformation("Adding Invoice failed: already existing record with this PK!");
        }
        return false;
      }

      db.Invoices.Add(newEntity);

      db.SaveChanges();
    }
    if(_Logger != null){
      _Logger.LogInformation("A Invoice was added!");
    }

    return true;
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given Invoice addressed by the primary identifier fields within the given Invoice. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="invoice"> Invoice containing the new values (the primary identifier fields within the given Invoice will be used to address the target record) </param>
  public bool UpdateInvoice(Invoice invoice){
    return this.UpdateInvoiceById(invoice.Id, invoice);
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given Invoice addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="id"> Represents the primary identity of a Invoice </param>
  /// <param name="invoice"> Invoice containing the new values (the primary identifier fields within the given Invoice will be ignored) </param>
  public bool UpdateInvoiceById(Guid id, Invoice invoice){
    var mac = AccessControlContext.Current;

    InvoiceEntity existingEntity;
    using (BillingDataDbContext db = new BillingDataDbContext()) {

      IQueryable<InvoiceEntity> query = db.Invoices;

      query = query.Where((e)=>e.Id == id).AccessScopeFiltered();

      //materialization / load
      existingEntity = query.SingleOrDefault();

      if(existingEntity == null) {
        if(_Logger != null){
          _Logger.LogInformation("Updating Invoice failed: no record with this PK!");
        }
        return false;
      }

      bool changeAttemptOnFixedField = false;
      existingEntity.CopyContentFrom(invoice, (name) => changeAttemptOnFixedField = true);

      if (changeAttemptOnFixedField) {
        if(_Logger != null){
          _Logger.LogInformation("Updating Invoice failed: change attempt on FIXED field!");
        }
        return false;
      }

      //checks, that the new values are within the access control scope
      if(!this.PreValidateAccessControlScope(existingEntity, db)){
        if(_Logger != null){
          _Logger.LogInformation("Updating Invoice failed: record would be out of access control scope!");
        }
        return false;
      }

      db.SaveChanges();
    }
    if(_Logger != null){
      _Logger.LogInformation("A Invoice was updated!");
    }

    return true;
  }

  /// <summary> Deletes a specific Invoice addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="id"> Represents the primary identity of a Invoice </param>
  public bool DeleteInvoiceById(Guid id){
    var mac = AccessControlContext.Current;

    InvoiceEntity existingEntity;
    using (BillingDataDbContext db = new BillingDataDbContext()) {

      IQueryable<InvoiceEntity> query = db.Invoices.AccessScopeFiltered();

      query = query.Where((e)=>e.Id == id);

      //materialization / load
      existingEntity = query.SingleOrDefault();

      if (existingEntity == null) {
        if(_Logger != null){
          _Logger.LogInformation("Updating Invoice failed: no record with this PK!");
        }
        return false;
      }

      db.Invoices.Remove(existingEntity);

      db.SaveChanges();
    }
    if(_Logger != null){
      _Logger.LogInformation("A Invoice was deleted!");
    }

    return true;
  }

  private bool PreValidateAccessControlScope(InvoiceEntity entity, BillingDataDbContext db){

    var filterExpression = EntityAccessControl.BuildExpressionForLocalEntity<InvoiceEntity>(AccessControlContext.Current);
    if(!filterExpression.Compile().Invoke(entity)) {
      return false;
    }

    if(!db.StudyExecutionScopes.Where((tgt)=> tgt.StudyExecutionIdentifier==entity.StudyExecutionIdentifier ).AccessScopeFiltered().Any()) {
      return false;
    }
    return true;
  }

}

}
