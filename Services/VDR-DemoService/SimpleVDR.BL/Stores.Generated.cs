using MedicalResearch.VisitData;
using MedicalResearch.VisitData.Persistence;
using System;
using System.Data;
using System.Data.AccessControl;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MedicalResearch.VisitData.Persistence.EF {

/// <summary> Provides CRUD access to stored DataRecordings (based on schema version '1.3.0') </summary>
public partial class DataRecordingStore : IDataRecordings {

  private ILogger _Logger = null;
  public DataRecordingStore(ILogger<DataRecordingStore> logger){
    _Logger = logger;
  }

  /// <summary> Loads a specific DataRecording addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="taskGuid"> a global unique id of a concrete study-task execution which is usually originated at the primary CRF or study management system ('SMS') </param>
  public DataRecording GetDataRecordingByTaskGuid(Guid taskGuid){
    var mac = AccessControlContext.Current;

    DataRecording result;
    using (VisitDataDbContext db = new VisitDataDbContext()) {

      //select models, bacause we dont want to return types with navigation-properties!
      var query = db.DataRecordings.AsNoTracking().AccessScopeFiltered().Select(DataRecordingEntity.DataRecordingSelector);

      query = query.Where((e)=>e.TaskGuid == taskGuid);

      //materialization / load
      result = query.SingleOrDefault();

    }

    return result;
  }

  /// <summary> Loads DataRecordings. </summary>
  /// <param name="page">Number of the page, which should be returned </param>
  /// <param name="pageSize">Max count of DataRecordings which should be returned </param>
  public DataRecording[] GetDataRecordings(int page = 1, int pageSize = 20){
    return this.SearchDataRecordings(null, null, page, pageSize); 
  }

  private static String[] _ExactMatchPropNames = new String[] {"DataRecordingName", "TaskExecutionTitle"};
  private static String[] _FreetextPropNames = new String[] {"DataSchemaUrl", "RecordedData", "NotesRegardingOutcome", "ExtendedMetaData", "ExecutingPerson"};

  /// <summary> Loads DataRecordings where values matching to the given filterExpression</summary>
  /// <param name="filterExpression">a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' OR just '*' for all records</param>
  /// <param name="sortingExpression">one or more property names which are used as sort order (before pagination)</param>
  /// <param name="page">Number of the page, which should be returned</param>
  /// <param name="pageSize">Max count of DataRecordings which should be returned</param>
  public DataRecording[] SearchDataRecordings(String filterExpression, String sortingExpression = null, int page = 1, int pageSize = 20){
    var mac = AccessControlContext.Current;

    if(page < 1){
      page = 1;
    }
    if(pageSize < 1 || pageSize > 10000){
      pageSize = 20;
    }

    DataRecording[] result;
    using (VisitDataDbContext db = new VisitDataDbContext()) {

      //select models, bacause we dont want to return types with navigation-properties!
      var query = db.DataRecordings
        .AsNoTracking()
        .AccessScopeFiltered()
        .Select(DataRecordingEntity.DataRecordingSelector)
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

  /// <summary> Adds a new DataRecording and returns success. </summary>
  /// <param name="dataRecording"> DataRecording containing the new values </param>
  public bool AddNewDataRecording(DataRecording dataRecording){
    var mac = AccessControlContext.Current;

    DataRecordingEntity newEntity = new DataRecordingEntity();
    newEntity.CopyContentFrom(dataRecording);

    using (VisitDataDbContext db = new VisitDataDbContext()) {

      //checks, that the new values are within the access control scope
      if(!this.PreValidateAccessControlScope(newEntity, db)){
        if(_Logger != null){
          _Logger.LogInformation("Adding DataRecording failed: record would be out of access control scope!");
        }
        return false;
      }

      if (db.DataRecordings.Where((e)=>e.TaskGuid == newEntity.TaskGuid).Any()) {
        if(_Logger != null){
          _Logger.LogInformation("Adding DataRecording failed: already existing record with this PK!");
        }
        return false;
      }

      db.DataRecordings.Add(newEntity);

      db.SaveChanges();
    }
    if(_Logger != null){
      _Logger.LogInformation("A DataRecording was added!");
    }

    return true;
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given DataRecording addressed by the primary identifier fields within the given DataRecording. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="dataRecording"> DataRecording containing the new values (the primary identifier fields within the given DataRecording will be used to address the target record) </param>
  public bool UpdateDataRecording(DataRecording dataRecording){
    return this.UpdateDataRecordingByTaskGuid(dataRecording.TaskGuid, dataRecording);
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given DataRecording addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="taskGuid"> a global unique id of a concrete study-task execution which is usually originated at the primary CRF or study management system ('SMS') </param>
  /// <param name="dataRecording"> DataRecording containing the new values (the primary identifier fields within the given DataRecording will be ignored) </param>
  public bool UpdateDataRecordingByTaskGuid(Guid taskGuid, DataRecording dataRecording){
    var mac = AccessControlContext.Current;

    DataRecordingEntity existingEntity;
    using (VisitDataDbContext db = new VisitDataDbContext()) {

      IQueryable<DataRecordingEntity> query = db.DataRecordings;

      query = query.Where((e)=>e.TaskGuid == taskGuid).AccessScopeFiltered();

      //materialization / load
      existingEntity = query.SingleOrDefault();

      if(existingEntity == null) {
        if(_Logger != null){
          _Logger.LogInformation("Updating DataRecording failed: no record with this PK!");
        }
        return false;
      }

      bool changeAttemptOnFixedField = false;
      existingEntity.CopyContentFrom(dataRecording, (name) => changeAttemptOnFixedField = true);

      if (changeAttemptOnFixedField) {
        if(_Logger != null){
          _Logger.LogInformation("Updating DataRecording failed: change attempt on FIXED field!");
        }
        return false;
      }

      //checks, that the new values are within the access control scope
      if(!this.PreValidateAccessControlScope(existingEntity, db)){
        if(_Logger != null){
          _Logger.LogInformation("Updating DataRecording failed: record would be out of access control scope!");
        }
        return false;
      }

      db.SaveChanges();
    }
    if(_Logger != null){
      _Logger.LogInformation("A DataRecording was updated!");
    }

    return true;
  }

  /// <summary> Deletes a specific DataRecording addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="taskGuid"> a global unique id of a concrete study-task execution which is usually originated at the primary CRF or study management system ('SMS') </param>
  public bool DeleteDataRecordingByTaskGuid(Guid taskGuid){
    var mac = AccessControlContext.Current;

    DataRecordingEntity existingEntity;
    using (VisitDataDbContext db = new VisitDataDbContext()) {

      IQueryable<DataRecordingEntity> query = db.DataRecordings.AccessScopeFiltered();

      query = query.Where((e)=>e.TaskGuid == taskGuid);

      //materialization / load
      existingEntity = query.SingleOrDefault();

      if (existingEntity == null) {
        if(_Logger != null){
          _Logger.LogInformation("Updating DataRecording failed: no record with this PK!");
        }
        return false;
      }

      db.DataRecordings.Remove(existingEntity);

      db.SaveChanges();
    }
    if(_Logger != null){
      _Logger.LogInformation("A DataRecording was deleted!");
    }

    return true;
  }

  private bool PreValidateAccessControlScope(DataRecordingEntity entity, VisitDataDbContext db){

    var filterExpression = EntityAccessControl.BuildExpressionForLocalEntity<DataRecordingEntity>(AccessControlContext.Current);
    if(!filterExpression.Compile().Invoke(entity)) {
      return false;
    }

    if(!db.Visits.Where((tgt)=> tgt.VisitGuid==entity.VisitGuid ).AccessScopeFiltered().Any()) {
      return false;
    }
    return true;
  }

}

/// <summary> Provides CRUD access to stored Visits (based on schema version '1.3.0') </summary>
public partial class VisitStore : IVisits {

  private ILogger _Logger = null;
  public VisitStore(ILogger<VisitStore> logger){
    _Logger = logger;
  }

  /// <summary> Loads a specific Visit addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="visitGuid"> a global unique id of a concrete study-visit execution which is usually originated at the primary CRF or study management system ('SMS') </param>
  public Visit GetVisitByVisitGuid(Guid visitGuid){
    var mac = AccessControlContext.Current;

    Visit result;
    using (VisitDataDbContext db = new VisitDataDbContext()) {

      //select models, bacause we dont want to return types with navigation-properties!
      var query = db.Visits.AsNoTracking().AccessScopeFiltered().Select(VisitEntity.VisitSelector);

      query = query.Where((e)=>e.VisitGuid == visitGuid);

      //materialization / load
      result = query.SingleOrDefault();

    }

    return result;
  }

  /// <summary> Loads Visits. </summary>
  /// <param name="page">Number of the page, which should be returned </param>
  /// <param name="pageSize">Max count of Visits which should be returned </param>
  public Visit[] GetVisits(int page = 1, int pageSize = 20){
    return this.SearchVisits(null, null, page, pageSize); 
  }

  private static String[] _ExactMatchPropNames = new String[] {"ParticipantIdentifier", "ParticipantIdentifier", "VisitExecutionTitle", "VisitProdecureName", "VisitExecutionTitle"};
  private static String[] _FreetextPropNames = new String[] {"ExtendedMetaData", "ExecutingPerson"};

  /// <summary> Loads Visits where values matching to the given filterExpression</summary>
  /// <param name="filterExpression">a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' OR just '*' for all records</param>
  /// <param name="sortingExpression">one or more property names which are used as sort order (before pagination)</param>
  /// <param name="page">Number of the page, which should be returned</param>
  /// <param name="pageSize">Max count of Visits which should be returned</param>
  public Visit[] SearchVisits(String filterExpression, String sortingExpression = null, int page = 1, int pageSize = 20){
    var mac = AccessControlContext.Current;

    if(page < 1){
      page = 1;
    }
    if(pageSize < 1 || pageSize > 10000){
      pageSize = 20;
    }

    Visit[] result;
    using (VisitDataDbContext db = new VisitDataDbContext()) {

      //select models, bacause we dont want to return types with navigation-properties!
      var query = db.Visits
        .AsNoTracking()
        .AccessScopeFiltered()
        .Select(VisitEntity.VisitSelector)
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

  /// <summary> Adds a new Visit and returns success. </summary>
  /// <param name="visit"> Visit containing the new values </param>
  public bool AddNewVisit(Visit visit){
    var mac = AccessControlContext.Current;

    VisitEntity newEntity = new VisitEntity();
    newEntity.CopyContentFrom(visit);

    using (VisitDataDbContext db = new VisitDataDbContext()) {

      //checks, that the new values are within the access control scope
      if(!this.PreValidateAccessControlScope(newEntity, db)){
        if(_Logger != null){
          _Logger.LogInformation("Adding Visit failed: record would be out of access control scope!");
        }
        return false;
      }

      if (db.Visits.Where((e)=>e.VisitGuid == newEntity.VisitGuid).Any()) {
        if(_Logger != null){
          _Logger.LogInformation("Adding Visit failed: already existing record with this PK!");
        }
        return false;
      }

      db.Visits.Add(newEntity);

      db.SaveChanges();
    }
    if(_Logger != null){
      _Logger.LogInformation("A Visit was added!");
    }

    return true;
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given Visit addressed by the primary identifier fields within the given Visit. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="visit"> Visit containing the new values (the primary identifier fields within the given Visit will be used to address the target record) </param>
  public bool UpdateVisit(Visit visit){
    return this.UpdateVisitByVisitGuid(visit.VisitGuid, visit);
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given Visit addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="visitGuid"> a global unique id of a concrete study-visit execution which is usually originated at the primary CRF or study management system ('SMS') </param>
  /// <param name="visit"> Visit containing the new values (the primary identifier fields within the given Visit will be ignored) </param>
  public bool UpdateVisitByVisitGuid(Guid visitGuid, Visit visit){
    var mac = AccessControlContext.Current;

    VisitEntity existingEntity;
    using (VisitDataDbContext db = new VisitDataDbContext()) {

      IQueryable<VisitEntity> query = db.Visits;

      query = query.Where((e)=>e.VisitGuid == visitGuid).AccessScopeFiltered();

      //materialization / load
      existingEntity = query.SingleOrDefault();

      if(existingEntity == null) {
        if(_Logger != null){
          _Logger.LogInformation("Updating Visit failed: no record with this PK!");
        }
        return false;
      }

      bool changeAttemptOnFixedField = false;
      existingEntity.CopyContentFrom(visit, (name) => changeAttemptOnFixedField = true);

      if (changeAttemptOnFixedField) {
        if(_Logger != null){
          _Logger.LogInformation("Updating Visit failed: change attempt on FIXED field!");
        }
        return false;
      }

      //checks, that the new values are within the access control scope
      if(!this.PreValidateAccessControlScope(existingEntity, db)){
        if(_Logger != null){
          _Logger.LogInformation("Updating Visit failed: record would be out of access control scope!");
        }
        return false;
      }

      db.SaveChanges();
    }
    if(_Logger != null){
      _Logger.LogInformation("A Visit was updated!");
    }

    return true;
  }

  /// <summary> Deletes a specific Visit addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="visitGuid"> a global unique id of a concrete study-visit execution which is usually originated at the primary CRF or study management system ('SMS') </param>
  public bool DeleteVisitByVisitGuid(Guid visitGuid){
    var mac = AccessControlContext.Current;

    VisitEntity existingEntity;
    using (VisitDataDbContext db = new VisitDataDbContext()) {

      IQueryable<VisitEntity> query = db.Visits.AccessScopeFiltered();

      query = query.Where((e)=>e.VisitGuid == visitGuid);

      //materialization / load
      existingEntity = query.SingleOrDefault();

      if (existingEntity == null) {
        if(_Logger != null){
          _Logger.LogInformation("Updating Visit failed: no record with this PK!");
        }
        return false;
      }

      db.Visits.Remove(existingEntity);

      db.SaveChanges();
    }
    if(_Logger != null){
      _Logger.LogInformation("A Visit was deleted!");
    }

    return true;
  }

  private bool PreValidateAccessControlScope(VisitEntity entity, VisitDataDbContext db){

    var filterExpression = EntityAccessControl.BuildExpressionForLocalEntity<VisitEntity>(AccessControlContext.Current);
    if(!filterExpression.Compile().Invoke(entity)) {
      return false;
    }

    if(!db.StudyExecutionScopes.Where((tgt)=> tgt.StudyExecutionIdentifier==entity.StudyExecutionIdentifier ).AccessScopeFiltered().Any()) {
      return false;
    }
    return true;
  }

}

/// <summary> Provides CRUD access to stored DrugApplyments (based on schema version '1.3.0') </summary>
public partial class DrugApplymentStore : IDrugApplyments {

  private ILogger _Logger = null;
  public DrugApplymentStore(ILogger<DrugApplymentStore> logger){
    _Logger = logger;
  }

  /// <summary> Loads a specific DrugApplyment addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="taskGuid"> a global unique id of a concrete study-task execution which is usually originated at the primary CRF or study management system ('SMS') </param>
  public DrugApplyment GetDrugApplymentByTaskGuid(Guid taskGuid){
    var mac = AccessControlContext.Current;

    DrugApplyment result;
    using (VisitDataDbContext db = new VisitDataDbContext()) {

      //select models, bacause we dont want to return types with navigation-properties!
      var query = db.DrugApplyments.AsNoTracking().AccessScopeFiltered().Select(DrugApplymentEntity.DrugApplymentSelector);

      query = query.Where((e)=>e.TaskGuid == taskGuid);

      //materialization / load
      result = query.SingleOrDefault();

    }

    return result;
  }

  /// <summary> Loads DrugApplyments. </summary>
  /// <param name="page">Number of the page, which should be returned </param>
  /// <param name="pageSize">Max count of DrugApplyments which should be returned </param>
  public DrugApplyment[] GetDrugApplyments(int page = 1, int pageSize = 20){
    return this.SearchDrugApplyments(null, null, page, pageSize); 
  }

  private static String[] _ExactMatchPropNames = new String[] {"DrugApplymentName", "TaskExecutionTitle"};
  private static String[] _FreetextPropNames = new String[] {"DrugName", "NotesRegardingOutcome", "ExtendedMetaData", "ExecutingPerson"};

  /// <summary> Loads DrugApplyments where values matching to the given filterExpression</summary>
  /// <param name="filterExpression">a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' OR just '*' for all records</param>
  /// <param name="sortingExpression">one or more property names which are used as sort order (before pagination)</param>
  /// <param name="page">Number of the page, which should be returned</param>
  /// <param name="pageSize">Max count of DrugApplyments which should be returned</param>
  public DrugApplyment[] SearchDrugApplyments(String filterExpression, String sortingExpression = null, int page = 1, int pageSize = 20){
    var mac = AccessControlContext.Current;

    if(page < 1){
      page = 1;
    }
    if(pageSize < 1 || pageSize > 10000){
      pageSize = 20;
    }

    DrugApplyment[] result;
    using (VisitDataDbContext db = new VisitDataDbContext()) {

      //select models, bacause we dont want to return types with navigation-properties!
      var query = db.DrugApplyments
        .AsNoTracking()
        .AccessScopeFiltered()
        .Select(DrugApplymentEntity.DrugApplymentSelector)
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

  /// <summary> Adds a new DrugApplyment and returns success. </summary>
  /// <param name="drugApplyment"> DrugApplyment containing the new values </param>
  public bool AddNewDrugApplyment(DrugApplyment drugApplyment){
    var mac = AccessControlContext.Current;

    DrugApplymentEntity newEntity = new DrugApplymentEntity();
    newEntity.CopyContentFrom(drugApplyment);

    using (VisitDataDbContext db = new VisitDataDbContext()) {

      //checks, that the new values are within the access control scope
      if(!this.PreValidateAccessControlScope(newEntity, db)){
        if(_Logger != null){
          _Logger.LogInformation("Adding DrugApplyment failed: record would be out of access control scope!");
        }
        return false;
      }

      if (db.DrugApplyments.Where((e)=>e.TaskGuid == newEntity.TaskGuid).Any()) {
        if(_Logger != null){
          _Logger.LogInformation("Adding DrugApplyment failed: already existing record with this PK!");
        }
        return false;
      }

      db.DrugApplyments.Add(newEntity);

      db.SaveChanges();
    }
    if(_Logger != null){
      _Logger.LogInformation("A DrugApplyment was added!");
    }

    return true;
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given DrugApplyment addressed by the primary identifier fields within the given DrugApplyment. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="drugApplyment"> DrugApplyment containing the new values (the primary identifier fields within the given DrugApplyment will be used to address the target record) </param>
  public bool UpdateDrugApplyment(DrugApplyment drugApplyment){
    return this.UpdateDrugApplymentByTaskGuid(drugApplyment.TaskGuid, drugApplyment);
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given DrugApplyment addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="taskGuid"> a global unique id of a concrete study-task execution which is usually originated at the primary CRF or study management system ('SMS') </param>
  /// <param name="drugApplyment"> DrugApplyment containing the new values (the primary identifier fields within the given DrugApplyment will be ignored) </param>
  public bool UpdateDrugApplymentByTaskGuid(Guid taskGuid, DrugApplyment drugApplyment){
    var mac = AccessControlContext.Current;

    DrugApplymentEntity existingEntity;
    using (VisitDataDbContext db = new VisitDataDbContext()) {

      IQueryable<DrugApplymentEntity> query = db.DrugApplyments;

      query = query.Where((e)=>e.TaskGuid == taskGuid).AccessScopeFiltered();

      //materialization / load
      existingEntity = query.SingleOrDefault();

      if(existingEntity == null) {
        if(_Logger != null){
          _Logger.LogInformation("Updating DrugApplyment failed: no record with this PK!");
        }
        return false;
      }

      bool changeAttemptOnFixedField = false;
      existingEntity.CopyContentFrom(drugApplyment, (name) => changeAttemptOnFixedField = true);

      if (changeAttemptOnFixedField) {
        if(_Logger != null){
          _Logger.LogInformation("Updating DrugApplyment failed: change attempt on FIXED field!");
        }
        return false;
      }

      //checks, that the new values are within the access control scope
      if(!this.PreValidateAccessControlScope(existingEntity, db)){
        if(_Logger != null){
          _Logger.LogInformation("Updating DrugApplyment failed: record would be out of access control scope!");
        }
        return false;
      }

      db.SaveChanges();
    }
    if(_Logger != null){
      _Logger.LogInformation("A DrugApplyment was updated!");
    }

    return true;
  }

  /// <summary> Deletes a specific DrugApplyment addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="taskGuid"> a global unique id of a concrete study-task execution which is usually originated at the primary CRF or study management system ('SMS') </param>
  public bool DeleteDrugApplymentByTaskGuid(Guid taskGuid){
    var mac = AccessControlContext.Current;

    DrugApplymentEntity existingEntity;
    using (VisitDataDbContext db = new VisitDataDbContext()) {

      IQueryable<DrugApplymentEntity> query = db.DrugApplyments.AccessScopeFiltered();

      query = query.Where((e)=>e.TaskGuid == taskGuid);

      //materialization / load
      existingEntity = query.SingleOrDefault();

      if (existingEntity == null) {
        if(_Logger != null){
          _Logger.LogInformation("Updating DrugApplyment failed: no record with this PK!");
        }
        return false;
      }

      db.DrugApplyments.Remove(existingEntity);

      db.SaveChanges();
    }
    if(_Logger != null){
      _Logger.LogInformation("A DrugApplyment was deleted!");
    }

    return true;
  }

  private bool PreValidateAccessControlScope(DrugApplymentEntity entity, VisitDataDbContext db){

    var filterExpression = EntityAccessControl.BuildExpressionForLocalEntity<DrugApplymentEntity>(AccessControlContext.Current);
    if(!filterExpression.Compile().Invoke(entity)) {
      return false;
    }

    if(!db.Visits.Where((tgt)=> tgt.VisitGuid==entity.VisitGuid ).AccessScopeFiltered().Any()) {
      return false;
    }
    return true;
  }

}

/// <summary> Provides CRUD access to stored StudyEvents (based on schema version '1.3.0') </summary>
public partial class StudyEventStore : IStudyEvents {

  private ILogger _Logger = null;
  public StudyEventStore(ILogger<StudyEventStore> logger){
    _Logger = logger;
  }

  /// <summary> Loads a specific StudyEvent addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="eventGuid"> a global unique id of a concrete study-event occurrence which is usually originated at the primary CRF or study management system ('SMS') </param>
  public StudyEvent GetStudyEventByEventGuid(Guid eventGuid){
    var mac = AccessControlContext.Current;

    StudyEvent result;
    using (VisitDataDbContext db = new VisitDataDbContext()) {

      //select models, bacause we dont want to return types with navigation-properties!
      var query = db.StudyEvents.AsNoTracking().AccessScopeFiltered().Select(StudyEventEntity.StudyEventSelector);

      query = query.Where((e)=>e.EventGuid == eventGuid);

      //materialization / load
      result = query.SingleOrDefault();

    }

    return result;
  }

  /// <summary> Loads StudyEvents. </summary>
  /// <param name="page">Number of the page, which should be returned </param>
  /// <param name="pageSize">Max count of StudyEvents which should be returned </param>
  public StudyEvent[] GetStudyEvents(int page = 1, int pageSize = 20){
    return this.SearchStudyEvents(null, null, page, pageSize); 
  }

  private static String[] _ExactMatchPropNames = new String[] {"StudyEventName"};
  private static String[] _FreetextPropNames = new String[] {"ParticipantIdentifier", "ExtendedMetaData", "CauseInfo", "AdditionalNotes"};

  /// <summary> Loads StudyEvents where values matching to the given filterExpression</summary>
  /// <param name="filterExpression">a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' OR just '*' for all records</param>
  /// <param name="sortingExpression">one or more property names which are used as sort order (before pagination)</param>
  /// <param name="page">Number of the page, which should be returned</param>
  /// <param name="pageSize">Max count of StudyEvents which should be returned</param>
  public StudyEvent[] SearchStudyEvents(String filterExpression, String sortingExpression = null, int page = 1, int pageSize = 20){
    var mac = AccessControlContext.Current;

    if(page < 1){
      page = 1;
    }
    if(pageSize < 1 || pageSize > 10000){
      pageSize = 20;
    }

    StudyEvent[] result;
    using (VisitDataDbContext db = new VisitDataDbContext()) {

      //select models, bacause we dont want to return types with navigation-properties!
      var query = db.StudyEvents
        .AsNoTracking()
        .AccessScopeFiltered()
        .Select(StudyEventEntity.StudyEventSelector)
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
        query = query.DynamicallySorted("EventGuid");
      }
      else{
        query = query.DynamicallySorted(sortingExpression + ", EventGuid");
      }

      //apply pagination
      query = query.Skip(pageSize * (page - 1)).Take(pageSize);

      //materialization / load
      result = query.ToArray();

    }

    return result;
  }

  /// <summary> Adds a new StudyEvent and returns success. </summary>
  /// <param name="studyEvent"> StudyEvent containing the new values </param>
  public bool AddNewStudyEvent(StudyEvent studyEvent){
    var mac = AccessControlContext.Current;

    StudyEventEntity newEntity = new StudyEventEntity();
    newEntity.CopyContentFrom(studyEvent);

    using (VisitDataDbContext db = new VisitDataDbContext()) {

      //checks, that the new values are within the access control scope
      if(!this.PreValidateAccessControlScope(newEntity, db)){
        if(_Logger != null){
          _Logger.LogInformation("Adding StudyEvent failed: record would be out of access control scope!");
        }
        return false;
      }

      if (db.StudyEvents.Where((e)=>e.EventGuid == newEntity.EventGuid).Any()) {
        if(_Logger != null){
          _Logger.LogInformation("Adding StudyEvent failed: already existing record with this PK!");
        }
        return false;
      }

      db.StudyEvents.Add(newEntity);

      db.SaveChanges();
    }
    if(_Logger != null){
      _Logger.LogInformation("A StudyEvent was added!");
    }

    return true;
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given StudyEvent addressed by the primary identifier fields within the given StudyEvent. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="studyEvent"> StudyEvent containing the new values (the primary identifier fields within the given StudyEvent will be used to address the target record) </param>
  public bool UpdateStudyEvent(StudyEvent studyEvent){
    return this.UpdateStudyEventByEventGuid(studyEvent.EventGuid, studyEvent);
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given StudyEvent addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="eventGuid"> a global unique id of a concrete study-event occurrence which is usually originated at the primary CRF or study management system ('SMS') </param>
  /// <param name="studyEvent"> StudyEvent containing the new values (the primary identifier fields within the given StudyEvent will be ignored) </param>
  public bool UpdateStudyEventByEventGuid(Guid eventGuid, StudyEvent studyEvent){
    var mac = AccessControlContext.Current;

    StudyEventEntity existingEntity;
    using (VisitDataDbContext db = new VisitDataDbContext()) {

      IQueryable<StudyEventEntity> query = db.StudyEvents;

      query = query.Where((e)=>e.EventGuid == eventGuid).AccessScopeFiltered();

      //materialization / load
      existingEntity = query.SingleOrDefault();

      if(existingEntity == null) {
        if(_Logger != null){
          _Logger.LogInformation("Updating StudyEvent failed: no record with this PK!");
        }
        return false;
      }

      bool changeAttemptOnFixedField = false;
      existingEntity.CopyContentFrom(studyEvent, (name) => changeAttemptOnFixedField = true);

      if (changeAttemptOnFixedField) {
        if(_Logger != null){
          _Logger.LogInformation("Updating StudyEvent failed: change attempt on FIXED field!");
        }
        return false;
      }

      //checks, that the new values are within the access control scope
      if(!this.PreValidateAccessControlScope(existingEntity, db)){
        if(_Logger != null){
          _Logger.LogInformation("Updating StudyEvent failed: record would be out of access control scope!");
        }
        return false;
      }

      db.SaveChanges();
    }
    if(_Logger != null){
      _Logger.LogInformation("A StudyEvent was updated!");
    }

    return true;
  }

  /// <summary> Deletes a specific StudyEvent addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="eventGuid"> a global unique id of a concrete study-event occurrence which is usually originated at the primary CRF or study management system ('SMS') </param>
  public bool DeleteStudyEventByEventGuid(Guid eventGuid){
    var mac = AccessControlContext.Current;

    StudyEventEntity existingEntity;
    using (VisitDataDbContext db = new VisitDataDbContext()) {

      IQueryable<StudyEventEntity> query = db.StudyEvents.AccessScopeFiltered();

      query = query.Where((e)=>e.EventGuid == eventGuid);

      //materialization / load
      existingEntity = query.SingleOrDefault();

      if (existingEntity == null) {
        if(_Logger != null){
          _Logger.LogInformation("Updating StudyEvent failed: no record with this PK!");
        }
        return false;
      }

      db.StudyEvents.Remove(existingEntity);

      db.SaveChanges();
    }
    if(_Logger != null){
      _Logger.LogInformation("A StudyEvent was deleted!");
    }

    return true;
  }

  private bool PreValidateAccessControlScope(StudyEventEntity entity, VisitDataDbContext db){

    var filterExpression = EntityAccessControl.BuildExpressionForLocalEntity<StudyEventEntity>(AccessControlContext.Current);
    if(!filterExpression.Compile().Invoke(entity)) {
      return false;
    }

    if(!db.StudyExecutionScopes.Where((tgt)=> tgt.StudyExecutionIdentifier==entity.StudyExecutionIdentifier ).AccessScopeFiltered().Any()) {
      return false;
    }
    return true;
  }

}

/// <summary> Provides CRUD access to stored StudyExecutionScopes (based on schema version '1.3.0') </summary>
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
    using (VisitDataDbContext db = new VisitDataDbContext()) {

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

  private static String[] _ExactMatchPropNames = new String[] {"ExecutingInstituteIdentifier", "StudyWorkflowName", "StudyWorkflowVersion"};
  private static String[] _FreetextPropNames = new String[] {"ExtendedMetaData"};

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
    using (VisitDataDbContext db = new VisitDataDbContext()) {

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

    using (VisitDataDbContext db = new VisitDataDbContext()) {

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
    using (VisitDataDbContext db = new VisitDataDbContext()) {

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
    using (VisitDataDbContext db = new VisitDataDbContext()) {

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

  private bool PreValidateAccessControlScope(StudyExecutionScopeEntity entity, VisitDataDbContext db){

    var filterExpression = EntityAccessControl.BuildExpressionForLocalEntity<StudyExecutionScopeEntity>(AccessControlContext.Current);
    if(!filterExpression.Compile().Invoke(entity)) {
      return false;
    }

    return true;
  }

}

/// <summary> Provides CRUD access to stored Treatments (based on schema version '1.3.0') </summary>
public partial class TreatmentStore : ITreatments {

  private ILogger _Logger = null;
  public TreatmentStore(ILogger<TreatmentStore> logger){
    _Logger = logger;
  }

  /// <summary> Loads a specific Treatment addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="taskGuid"> a global unique id of a concrete study-task execution which is usually originated at the primary CRF or study management system ('SMS') </param>
  public Treatment GetTreatmentByTaskGuid(Guid taskGuid){
    var mac = AccessControlContext.Current;

    Treatment result;
    using (VisitDataDbContext db = new VisitDataDbContext()) {

      //select models, bacause we dont want to return types with navigation-properties!
      var query = db.Treatments.AsNoTracking().AccessScopeFiltered().Select(TreatmentEntity.TreatmentSelector);

      query = query.Where((e)=>e.TaskGuid == taskGuid);

      //materialization / load
      result = query.SingleOrDefault();

    }

    return result;
  }

  /// <summary> Loads Treatments. </summary>
  /// <param name="page">Number of the page, which should be returned </param>
  /// <param name="pageSize">Max count of Treatments which should be returned </param>
  public Treatment[] GetTreatments(int page = 1, int pageSize = 20){
    return this.SearchTreatments(null, null, page, pageSize); 
  }

  private static String[] _ExactMatchPropNames = new String[] {"TreatmentName", "TaskExecutionTitle"};
  private static String[] _FreetextPropNames = new String[] {"NotesRegardingOutcome", "ExtendedMetaData", "ExecutingPerson"};

  /// <summary> Loads Treatments where values matching to the given filterExpression</summary>
  /// <param name="filterExpression">a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' OR just '*' for all records</param>
  /// <param name="sortingExpression">one or more property names which are used as sort order (before pagination)</param>
  /// <param name="page">Number of the page, which should be returned</param>
  /// <param name="pageSize">Max count of Treatments which should be returned</param>
  public Treatment[] SearchTreatments(String filterExpression, String sortingExpression = null, int page = 1, int pageSize = 20){
    var mac = AccessControlContext.Current;

    if(page < 1){
      page = 1;
    }
    if(pageSize < 1 || pageSize > 10000){
      pageSize = 20;
    }

    Treatment[] result;
    using (VisitDataDbContext db = new VisitDataDbContext()) {

      //select models, bacause we dont want to return types with navigation-properties!
      var query = db.Treatments
        .AsNoTracking()
        .AccessScopeFiltered()
        .Select(TreatmentEntity.TreatmentSelector)
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

  /// <summary> Adds a new Treatment and returns success. </summary>
  /// <param name="treatment"> Treatment containing the new values </param>
  public bool AddNewTreatment(Treatment treatment){
    var mac = AccessControlContext.Current;

    TreatmentEntity newEntity = new TreatmentEntity();
    newEntity.CopyContentFrom(treatment);

    using (VisitDataDbContext db = new VisitDataDbContext()) {

      //checks, that the new values are within the access control scope
      if(!this.PreValidateAccessControlScope(newEntity, db)){
        if(_Logger != null){
          _Logger.LogInformation("Adding Treatment failed: record would be out of access control scope!");
        }
        return false;
      }

      if (db.Treatments.Where((e)=>e.TaskGuid == newEntity.TaskGuid).Any()) {
        if(_Logger != null){
          _Logger.LogInformation("Adding Treatment failed: already existing record with this PK!");
        }
        return false;
      }

      db.Treatments.Add(newEntity);

      db.SaveChanges();
    }
    if(_Logger != null){
      _Logger.LogInformation("A Treatment was added!");
    }

    return true;
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given Treatment addressed by the primary identifier fields within the given Treatment. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="treatment"> Treatment containing the new values (the primary identifier fields within the given Treatment will be used to address the target record) </param>
  public bool UpdateTreatment(Treatment treatment){
    return this.UpdateTreatmentByTaskGuid(treatment.TaskGuid, treatment);
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given Treatment addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="taskGuid"> a global unique id of a concrete study-task execution which is usually originated at the primary CRF or study management system ('SMS') </param>
  /// <param name="treatment"> Treatment containing the new values (the primary identifier fields within the given Treatment will be ignored) </param>
  public bool UpdateTreatmentByTaskGuid(Guid taskGuid, Treatment treatment){
    var mac = AccessControlContext.Current;

    TreatmentEntity existingEntity;
    using (VisitDataDbContext db = new VisitDataDbContext()) {

      IQueryable<TreatmentEntity> query = db.Treatments;

      query = query.Where((e)=>e.TaskGuid == taskGuid).AccessScopeFiltered();

      //materialization / load
      existingEntity = query.SingleOrDefault();

      if(existingEntity == null) {
        if(_Logger != null){
          _Logger.LogInformation("Updating Treatment failed: no record with this PK!");
        }
        return false;
      }

      bool changeAttemptOnFixedField = false;
      existingEntity.CopyContentFrom(treatment, (name) => changeAttemptOnFixedField = true);

      if (changeAttemptOnFixedField) {
        if(_Logger != null){
          _Logger.LogInformation("Updating Treatment failed: change attempt on FIXED field!");
        }
        return false;
      }

      //checks, that the new values are within the access control scope
      if(!this.PreValidateAccessControlScope(existingEntity, db)){
        if(_Logger != null){
          _Logger.LogInformation("Updating Treatment failed: record would be out of access control scope!");
        }
        return false;
      }

      db.SaveChanges();
    }
    if(_Logger != null){
      _Logger.LogInformation("A Treatment was updated!");
    }

    return true;
  }

  /// <summary> Deletes a specific Treatment addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="taskGuid"> a global unique id of a concrete study-task execution which is usually originated at the primary CRF or study management system ('SMS') </param>
  public bool DeleteTreatmentByTaskGuid(Guid taskGuid){
    var mac = AccessControlContext.Current;

    TreatmentEntity existingEntity;
    using (VisitDataDbContext db = new VisitDataDbContext()) {

      IQueryable<TreatmentEntity> query = db.Treatments.AccessScopeFiltered();

      query = query.Where((e)=>e.TaskGuid == taskGuid);

      //materialization / load
      existingEntity = query.SingleOrDefault();

      if (existingEntity == null) {
        if(_Logger != null){
          _Logger.LogInformation("Updating Treatment failed: no record with this PK!");
        }
        return false;
      }

      db.Treatments.Remove(existingEntity);

      db.SaveChanges();
    }
    if(_Logger != null){
      _Logger.LogInformation("A Treatment was deleted!");
    }

    return true;
  }

  private bool PreValidateAccessControlScope(TreatmentEntity entity, VisitDataDbContext db){

    var filterExpression = EntityAccessControl.BuildExpressionForLocalEntity<TreatmentEntity>(AccessControlContext.Current);
    if(!filterExpression.Compile().Invoke(entity)) {
      return false;
    }

    if(!db.Visits.Where((tgt)=> tgt.VisitGuid==entity.VisitGuid ).AccessScopeFiltered().Any()) {
      return false;
    }
    return true;
  }

}

}
