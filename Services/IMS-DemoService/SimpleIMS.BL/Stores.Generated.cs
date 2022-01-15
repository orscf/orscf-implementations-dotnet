using MedicalResearch.IdentityManagement;
using MedicalResearch.IdentityManagement.Persistence;
using MedicalResearch.IdentityManagement.Persistence.EF;
using MedicalResearch.IdentityManagement.Model;
using System;
using System.Data;
using System.Data.AccessControl;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MedicalResearch.IdentityManagement.StoreAccess {

/// <summary> Provides CRUD access to stored AdditionalSubjectParticipationIdentifiers (based on schema version '1.5.0') </summary>
public partial class AdditionalSubjectParticipationIdentifierStore : IAdditionalSubjectParticipationIdentifiers {

  private ILogger _Logger = null;
  public AdditionalSubjectParticipationIdentifierStore(ILogger<AdditionalSubjectParticipationIdentifierStore> logger){
    _Logger = logger;
  }

  /// <summary> Loads a specific AdditionalSubjectParticipationIdentifier addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="additionalSubjectParticipationIdentifierIdentity"> Composite Key, which represents the primary identity of a AdditionalSubjectParticipationIdentifier </param>
  public AdditionalSubjectParticipationIdentifier GetAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentity(AdditionalSubjectParticipationIdentifierIdentity additionalSubjectParticipationIdentifierIdentity){
    var mac = AccessControlContext.Current;

    AdditionalSubjectParticipationIdentifier result;
    using (IdentityManagementDbContext db = new IdentityManagementDbContext()) {

      //select models, bacause we dont want to return types with navigation-properties!
      var query = db.AdditionalSubjectParticipationIdentifiers.AsNoTracking().AccessScopeFiltered().Select(AdditionalSubjectParticipationIdentifierEntity.AdditionalSubjectParticipationIdentifierSelector);

      query = query.Where((e)=> e.ParticipantIdentifier == additionalSubjectParticipationIdentifierIdentity.ParticipantIdentifier && e.IdentifierName == additionalSubjectParticipationIdentifierIdentity.IdentifierName && e.ResearchStudyUid == additionalSubjectParticipationIdentifierIdentity.ResearchStudyUid);

      //materialization / load
      result = query.SingleOrDefault();

    }

    return result;
  }

  /// <summary> Loads AdditionalSubjectParticipationIdentifiers. </summary>
  /// <param name="page">Number of the page, which should be returned </param>
  /// <param name="pageSize">Max count of AdditionalSubjectParticipationIdentifiers which should be returned </param>
  public AdditionalSubjectParticipationIdentifier[] GetAdditionalSubjectParticipationIdentifiers(int page = 1, int pageSize = 20){
    return this.SearchAdditionalSubjectParticipationIdentifiers(null, null, page, pageSize); 
  }

  private static String[] _ExactMatchPropNames = new String[] {"ParticipantIdentifier", "IdentifierName", "ParticipantIdentifier"};
  private static String[] _FreetextPropNames = new String[] {"IdentifierValue"};

  /// <summary> Loads AdditionalSubjectParticipationIdentifiers where values matching to the given filterExpression</summary>
  /// <param name="filterExpression">a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' OR just '*' for all records</param>
  /// <param name="sortingExpression">one or more property names which are used as sort order (before pagination)</param>
  /// <param name="page">Number of the page, which should be returned</param>
  /// <param name="pageSize">Max count of AdditionalSubjectParticipationIdentifiers which should be returned</param>
  public AdditionalSubjectParticipationIdentifier[] SearchAdditionalSubjectParticipationIdentifiers(String filterExpression, String sortingExpression = null, int page = 1, int pageSize = 20){
    var mac = AccessControlContext.Current;

    if(page < 1){
      page = 1;
    }
    if(pageSize < 1 || pageSize > 10000){
      pageSize = 20;
    }

    AdditionalSubjectParticipationIdentifier[] result;
    using (IdentityManagementDbContext db = new IdentityManagementDbContext()) {

      //select models, bacause we dont want to return types with navigation-properties!
      var query = db.AdditionalSubjectParticipationIdentifiers
        .AsNoTracking()
        .AccessScopeFiltered()
        .Select(AdditionalSubjectParticipationIdentifierEntity.AdditionalSubjectParticipationIdentifierSelector)
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
        query = query.DynamicallySorted("ParticipantIdentifier, IdentifierName, ResearchStudyUid");
      }
      else{
        query = query.DynamicallySorted(sortingExpression + ", ParticipantIdentifier, IdentifierName, ResearchStudyUid");
      }

      //apply pagination
      query = query.Skip(pageSize * (page - 1)).Take(pageSize);

      //materialization / load
      result = query.ToArray();

    }

    return result;
  }

  /// <summary> Adds a new AdditionalSubjectParticipationIdentifier and returns success. </summary>
  /// <param name="additionalSubjectParticipationIdentifier"> AdditionalSubjectParticipationIdentifier containing the new values </param>
  public bool AddNewAdditionalSubjectParticipationIdentifier(AdditionalSubjectParticipationIdentifier additionalSubjectParticipationIdentifier){
    var mac = AccessControlContext.Current;

    AdditionalSubjectParticipationIdentifierEntity newEntity = new AdditionalSubjectParticipationIdentifierEntity();
    newEntity.CopyContentFrom(additionalSubjectParticipationIdentifier);

    using (IdentityManagementDbContext db = new IdentityManagementDbContext()) {

      //checks, that the new values are within the access control scope
      if(!this.PreValidateAccessControlScope(newEntity, db)){
        if(_Logger != null){
          _Logger.LogInformation("Adding AdditionalSubjectParticipationIdentifier failed: record would be out of access control scope!");
        }
        return false;
      }

      if (db.AdditionalSubjectParticipationIdentifiers.Where((e)=> e.ParticipantIdentifier == newEntity.ParticipantIdentifier && e.IdentifierName == newEntity.IdentifierName && e.ResearchStudyUid == newEntity.ResearchStudyUid).Any()) {
        if(_Logger != null){
          _Logger.LogInformation("Adding AdditionalSubjectParticipationIdentifier failed: already existing record with this PK!");
        }
        return false;
      }

      db.AdditionalSubjectParticipationIdentifiers.Add(newEntity);

      db.SaveChanges();
    }
    if(_Logger != null){
      _Logger.LogInformation("A AdditionalSubjectParticipationIdentifier was added!");
    }

    return true;
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given AdditionalSubjectParticipationIdentifier addressed by the primary identifier fields within the given AdditionalSubjectParticipationIdentifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="additionalSubjectParticipationIdentifier"> AdditionalSubjectParticipationIdentifier containing the new values (the primary identifier fields within the given AdditionalSubjectParticipationIdentifier will be used to address the target record) </param>
  public bool UpdateAdditionalSubjectParticipationIdentifier(AdditionalSubjectParticipationIdentifier additionalSubjectParticipationIdentifier){
    return this.UpdateAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentity(new AdditionalSubjectParticipationIdentifierIdentity { ParticipantIdentifier=additionalSubjectParticipationIdentifier.ParticipantIdentifier, IdentifierName=additionalSubjectParticipationIdentifier.IdentifierName, ResearchStudyUid=additionalSubjectParticipationIdentifier.ResearchStudyUid }, additionalSubjectParticipationIdentifier);
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given AdditionalSubjectParticipationIdentifier addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="additionalSubjectParticipationIdentifierIdentity"> Composite Key, which represents the primary identity of a AdditionalSubjectParticipationIdentifier </param>
  /// <param name="additionalSubjectParticipationIdentifier"> AdditionalSubjectParticipationIdentifier containing the new values (the primary identifier fields within the given AdditionalSubjectParticipationIdentifier will be ignored) </param>
  public bool UpdateAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentity(AdditionalSubjectParticipationIdentifierIdentity additionalSubjectParticipationIdentifierIdentity, AdditionalSubjectParticipationIdentifier additionalSubjectParticipationIdentifier){
    var mac = AccessControlContext.Current;

    AdditionalSubjectParticipationIdentifierEntity existingEntity;
    using (IdentityManagementDbContext db = new IdentityManagementDbContext()) {

      IQueryable<AdditionalSubjectParticipationIdentifierEntity> query = db.AdditionalSubjectParticipationIdentifiers;

      query = query.Where((e)=> e.ParticipantIdentifier == additionalSubjectParticipationIdentifierIdentity.ParticipantIdentifier && e.IdentifierName == additionalSubjectParticipationIdentifierIdentity.IdentifierName && e.ResearchStudyUid == additionalSubjectParticipationIdentifierIdentity.ResearchStudyUid).AccessScopeFiltered();

      //materialization / load
      existingEntity = query.SingleOrDefault();

      if(existingEntity == null) {
        if(_Logger != null){
          _Logger.LogInformation("Updating AdditionalSubjectParticipationIdentifier failed: no record with this PK!");
        }
        return false;
      }

      bool changeAttemptOnFixedField = false;
      existingEntity.CopyContentFrom(additionalSubjectParticipationIdentifier, (name) => changeAttemptOnFixedField = true);

      if (changeAttemptOnFixedField) {
        if(_Logger != null){
          _Logger.LogInformation("Updating AdditionalSubjectParticipationIdentifier failed: change attempt on FIXED field!");
        }
        return false;
      }

      //checks, that the new values are within the access control scope
      if(!this.PreValidateAccessControlScope(existingEntity, db)){
        if(_Logger != null){
          _Logger.LogInformation("Updating AdditionalSubjectParticipationIdentifier failed: record would be out of access control scope!");
        }
        return false;
      }

      db.SaveChanges();
    }
    if(_Logger != null){
      _Logger.LogInformation("A AdditionalSubjectParticipationIdentifier was updated!");
    }

    return true;
  }

  /// <summary> Deletes a specific AdditionalSubjectParticipationIdentifier addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="additionalSubjectParticipationIdentifierIdentity"> Composite Key, which represents the primary identity of a AdditionalSubjectParticipationIdentifier </param>
  public bool DeleteAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentity(AdditionalSubjectParticipationIdentifierIdentity additionalSubjectParticipationIdentifierIdentity){
    var mac = AccessControlContext.Current;

    AdditionalSubjectParticipationIdentifierEntity existingEntity;
    using (IdentityManagementDbContext db = new IdentityManagementDbContext()) {

      IQueryable<AdditionalSubjectParticipationIdentifierEntity> query = db.AdditionalSubjectParticipationIdentifiers.AccessScopeFiltered();

      query = query.Where((e)=> e.ParticipantIdentifier == additionalSubjectParticipationIdentifierIdentity.ParticipantIdentifier && e.IdentifierName == additionalSubjectParticipationIdentifierIdentity.IdentifierName && e.ResearchStudyUid == additionalSubjectParticipationIdentifierIdentity.ResearchStudyUid);

      //materialization / load
      existingEntity = query.SingleOrDefault();

      if (existingEntity == null) {
        if(_Logger != null){
          _Logger.LogInformation("Updating AdditionalSubjectParticipationIdentifier failed: no record with this PK!");
        }
        return false;
      }

      db.AdditionalSubjectParticipationIdentifiers.Remove(existingEntity);

      db.SaveChanges();
    }
    if(_Logger != null){
      _Logger.LogInformation("A AdditionalSubjectParticipationIdentifier was deleted!");
    }

    return true;
  }

  private bool PreValidateAccessControlScope(AdditionalSubjectParticipationIdentifierEntity entity, IdentityManagementDbContext db){

    var filterExpression = EntityAccessControl.BuildExpressionForLocalEntity<AdditionalSubjectParticipationIdentifierEntity>(AccessControlContext.Current);
    if(!filterExpression.Compile().Invoke(entity)) {
      return false;
    }

    if(!db.SubjectParticipations.Where((tgt)=> tgt.ParticipantIdentifier==entity.ParticipantIdentifier && tgt.ResearchStudyUid==entity.ResearchStudyUid ).AccessScopeFiltered().Any()) {
      return false;
    }
    return true;
  }

}

/// <summary> Provides CRUD access to stored SubjectParticipations (based on schema version '1.5.0') </summary>
public partial class SubjectParticipationStore : ISubjectParticipations {

  private ILogger _Logger = null;
  public SubjectParticipationStore(ILogger<SubjectParticipationStore> logger){
    _Logger = logger;
  }

  /// <summary> Loads a specific SubjectParticipation addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="subjectParticipationIdentity"> Composite Key, which represents the primary identity of a SubjectParticipation </param>
  public SubjectParticipation GetSubjectParticipationBySubjectParticipationIdentity(SubjectParticipationIdentity subjectParticipationIdentity){
    var mac = AccessControlContext.Current;

    SubjectParticipation result;
    using (IdentityManagementDbContext db = new IdentityManagementDbContext()) {

      //select models, bacause we dont want to return types with navigation-properties!
      var query = db.SubjectParticipations.AsNoTracking().AccessScopeFiltered().Select(SubjectParticipationEntity.SubjectParticipationSelector);

      query = query.Where((e)=> e.ParticipantIdentifier == subjectParticipationIdentity.ParticipantIdentifier && e.ResearchStudyUid == subjectParticipationIdentity.ResearchStudyUid);

      //materialization / load
      result = query.SingleOrDefault();

    }

    return result;
  }

  /// <summary> Loads SubjectParticipations. </summary>
  /// <param name="page">Number of the page, which should be returned </param>
  /// <param name="pageSize">Max count of SubjectParticipations which should be returned </param>
  public SubjectParticipation[] GetSubjectParticipations(int page = 1, int pageSize = 20){
    return this.SearchSubjectParticipations(null, null, page, pageSize); 
  }

  private static String[] _ExactMatchPropNames = new String[] {"ParticipantIdentifier"};
  private static String[] _FreetextPropNames = new String[] {};

  /// <summary> Loads SubjectParticipations where values matching to the given filterExpression</summary>
  /// <param name="filterExpression">a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' OR just '*' for all records</param>
  /// <param name="sortingExpression">one or more property names which are used as sort order (before pagination)</param>
  /// <param name="page">Number of the page, which should be returned</param>
  /// <param name="pageSize">Max count of SubjectParticipations which should be returned</param>
  public SubjectParticipation[] SearchSubjectParticipations(String filterExpression, String sortingExpression = null, int page = 1, int pageSize = 20){
    var mac = AccessControlContext.Current;

    if(page < 1){
      page = 1;
    }
    if(pageSize < 1 || pageSize > 10000){
      pageSize = 20;
    }

    SubjectParticipation[] result;
    using (IdentityManagementDbContext db = new IdentityManagementDbContext()) {

      //select models, bacause we dont want to return types with navigation-properties!
      var query = db.SubjectParticipations
        .AsNoTracking()
        .AccessScopeFiltered()
        .Select(SubjectParticipationEntity.SubjectParticipationSelector)
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
        query = query.DynamicallySorted("ParticipantIdentifier, ResearchStudyUid");
      }
      else{
        query = query.DynamicallySorted(sortingExpression + ", ParticipantIdentifier, ResearchStudyUid");
      }

      //apply pagination
      query = query.Skip(pageSize * (page - 1)).Take(pageSize);

      //materialization / load
      result = query.ToArray();

    }

    return result;
  }

  /// <summary> Adds a new SubjectParticipation and returns success. </summary>
  /// <param name="subjectParticipation"> SubjectParticipation containing the new values </param>
  public bool AddNewSubjectParticipation(SubjectParticipation subjectParticipation){
    var mac = AccessControlContext.Current;

    SubjectParticipationEntity newEntity = new SubjectParticipationEntity();
    newEntity.CopyContentFrom(subjectParticipation);

    using (IdentityManagementDbContext db = new IdentityManagementDbContext()) {

      //checks, that the new values are within the access control scope
      if(!this.PreValidateAccessControlScope(newEntity, db)){
        if(_Logger != null){
          _Logger.LogInformation("Adding SubjectParticipation failed: record would be out of access control scope!");
        }
        return false;
      }

      if (db.SubjectParticipations.Where((e)=> e.ParticipantIdentifier == newEntity.ParticipantIdentifier && e.ResearchStudyUid == newEntity.ResearchStudyUid).Any()) {
        if(_Logger != null){
          _Logger.LogInformation("Adding SubjectParticipation failed: already existing record with this PK!");
        }
        return false;
      }

      db.SubjectParticipations.Add(newEntity);

      db.SaveChanges();
    }
    if(_Logger != null){
      _Logger.LogInformation("A SubjectParticipation was added!");
    }

    return true;
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given SubjectParticipation addressed by the primary identifier fields within the given SubjectParticipation. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="subjectParticipation"> SubjectParticipation containing the new values (the primary identifier fields within the given SubjectParticipation will be used to address the target record) </param>
  public bool UpdateSubjectParticipation(SubjectParticipation subjectParticipation){
    return this.UpdateSubjectParticipationBySubjectParticipationIdentity(new SubjectParticipationIdentity { ParticipantIdentifier=subjectParticipation.ParticipantIdentifier, ResearchStudyUid=subjectParticipation.ResearchStudyUid }, subjectParticipation);
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given SubjectParticipation addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="subjectParticipationIdentity"> Composite Key, which represents the primary identity of a SubjectParticipation </param>
  /// <param name="subjectParticipation"> SubjectParticipation containing the new values (the primary identifier fields within the given SubjectParticipation will be ignored) </param>
  public bool UpdateSubjectParticipationBySubjectParticipationIdentity(SubjectParticipationIdentity subjectParticipationIdentity, SubjectParticipation subjectParticipation){
    var mac = AccessControlContext.Current;

    SubjectParticipationEntity existingEntity;
    using (IdentityManagementDbContext db = new IdentityManagementDbContext()) {

      IQueryable<SubjectParticipationEntity> query = db.SubjectParticipations;

      query = query.Where((e)=> e.ParticipantIdentifier == subjectParticipationIdentity.ParticipantIdentifier && e.ResearchStudyUid == subjectParticipationIdentity.ResearchStudyUid).AccessScopeFiltered();

      //materialization / load
      existingEntity = query.SingleOrDefault();

      if(existingEntity == null) {
        if(_Logger != null){
          _Logger.LogInformation("Updating SubjectParticipation failed: no record with this PK!");
        }
        return false;
      }

      bool changeAttemptOnFixedField = false;
      existingEntity.CopyContentFrom(subjectParticipation, (name) => changeAttemptOnFixedField = true);

      if (changeAttemptOnFixedField) {
        if(_Logger != null){
          _Logger.LogInformation("Updating SubjectParticipation failed: change attempt on FIXED field!");
        }
        return false;
      }

      //checks, that the new values are within the access control scope
      if(!this.PreValidateAccessControlScope(existingEntity, db)){
        if(_Logger != null){
          _Logger.LogInformation("Updating SubjectParticipation failed: record would be out of access control scope!");
        }
        return false;
      }

      db.SaveChanges();
    }
    if(_Logger != null){
      _Logger.LogInformation("A SubjectParticipation was updated!");
    }

    return true;
  }

  /// <summary> Deletes a specific SubjectParticipation addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="subjectParticipationIdentity"> Composite Key, which represents the primary identity of a SubjectParticipation </param>
  public bool DeleteSubjectParticipationBySubjectParticipationIdentity(SubjectParticipationIdentity subjectParticipationIdentity){
    var mac = AccessControlContext.Current;

    SubjectParticipationEntity existingEntity;
    using (IdentityManagementDbContext db = new IdentityManagementDbContext()) {

      IQueryable<SubjectParticipationEntity> query = db.SubjectParticipations.AccessScopeFiltered();

      query = query.Where((e)=> e.ParticipantIdentifier == subjectParticipationIdentity.ParticipantIdentifier && e.ResearchStudyUid == subjectParticipationIdentity.ResearchStudyUid);

      //materialization / load
      existingEntity = query.SingleOrDefault();

      if (existingEntity == null) {
        if(_Logger != null){
          _Logger.LogInformation("Updating SubjectParticipation failed: no record with this PK!");
        }
        return false;
      }

      db.SubjectParticipations.Remove(existingEntity);

      db.SaveChanges();
    }
    if(_Logger != null){
      _Logger.LogInformation("A SubjectParticipation was deleted!");
    }

    return true;
  }

  private bool PreValidateAccessControlScope(SubjectParticipationEntity entity, IdentityManagementDbContext db){

    var filterExpression = EntityAccessControl.BuildExpressionForLocalEntity<SubjectParticipationEntity>(AccessControlContext.Current);
    if(!filterExpression.Compile().Invoke(entity)) {
      return false;
    }

    if(!db.StudyExecutionScopes.Where((tgt)=> tgt.StudyExecutionIdentifier==entity.CreatedForStudyExecutionIdentifier ).AccessScopeFiltered().Any()) {
      return false;
    }
    if(!db.StudyScopes.Where((tgt)=> tgt.ResearchStudyUid==entity.ResearchStudyUid ).AccessScopeFiltered().Any()) {
      return false;
    }
    if(!db.SubjectIdentities.Where((tgt)=> tgt.RecordId==entity.SubjectIdentityRecordId ).AccessScopeFiltered().Any()) {
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
    using (IdentityManagementDbContext db = new IdentityManagementDbContext()) {

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
  private static String[] _FreetextPropNames = new String[] {};

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
    using (IdentityManagementDbContext db = new IdentityManagementDbContext()) {

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

    using (IdentityManagementDbContext db = new IdentityManagementDbContext()) {

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
    using (IdentityManagementDbContext db = new IdentityManagementDbContext()) {

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
    using (IdentityManagementDbContext db = new IdentityManagementDbContext()) {

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

  private bool PreValidateAccessControlScope(StudyExecutionScopeEntity entity, IdentityManagementDbContext db){

    var filterExpression = EntityAccessControl.BuildExpressionForLocalEntity<StudyExecutionScopeEntity>(AccessControlContext.Current);
    if(!filterExpression.Compile().Invoke(entity)) {
      return false;
    }

    if(!db.StudyScopes.Where((tgt)=> tgt.ResearchStudyUid==entity.ResearchStudyUid ).AccessScopeFiltered().Any()) {
      return false;
    }
    return true;
  }

}

/// <summary> Provides CRUD access to stored StudyScopes (based on schema version '1.5.0') </summary>
public partial class StudyScopeStore : IStudyScopes {

  private ILogger _Logger = null;
  public StudyScopeStore(ILogger<StudyScopeStore> logger){
    _Logger = logger;
  }

  /// <summary> Loads a specific StudyScope addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="researchStudyUid"> the official invariant name of the study as given by the sponsor </param>
  public StudyScope GetStudyScopeByResearchStudyUid(Guid researchStudyUid){
    var mac = AccessControlContext.Current;

    StudyScope result;
    using (IdentityManagementDbContext db = new IdentityManagementDbContext()) {

      //select models, bacause we dont want to return types with navigation-properties!
      var query = db.StudyScopes.AsNoTracking().AccessScopeFiltered().Select(StudyScopeEntity.StudyScopeSelector);

      query = query.Where((e)=>e.ResearchStudyUid == researchStudyUid);

      //materialization / load
      result = query.SingleOrDefault();

    }

    return result;
  }

  /// <summary> Loads StudyScopes. </summary>
  /// <param name="page">Number of the page, which should be returned </param>
  /// <param name="pageSize">Max count of StudyScopes which should be returned </param>
  public StudyScope[] GetStudyScopes(int page = 1, int pageSize = 20){
    return this.SearchStudyScopes(null, null, page, pageSize); 
  }

  private static String[] _ExactMatchPropNames = new String[] {};
  private static String[] _FreetextPropNames = new String[] {"ParticipantIdentifierSemantic", "StudyWorkflowName", "StudyWorkflowVersion"};

  /// <summary> Loads StudyScopes where values matching to the given filterExpression</summary>
  /// <param name="filterExpression">a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' OR just '*' for all records</param>
  /// <param name="sortingExpression">one or more property names which are used as sort order (before pagination)</param>
  /// <param name="page">Number of the page, which should be returned</param>
  /// <param name="pageSize">Max count of StudyScopes which should be returned</param>
  public StudyScope[] SearchStudyScopes(String filterExpression, String sortingExpression = null, int page = 1, int pageSize = 20){
    var mac = AccessControlContext.Current;

    if(page < 1){
      page = 1;
    }
    if(pageSize < 1 || pageSize > 10000){
      pageSize = 20;
    }

    StudyScope[] result;
    using (IdentityManagementDbContext db = new IdentityManagementDbContext()) {

      //select models, bacause we dont want to return types with navigation-properties!
      var query = db.StudyScopes
        .AsNoTracking()
        .AccessScopeFiltered()
        .Select(StudyScopeEntity.StudyScopeSelector)
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
        query = query.DynamicallySorted("ResearchStudyUid");
      }
      else{
        query = query.DynamicallySorted(sortingExpression + ", ResearchStudyUid");
      }

      //apply pagination
      query = query.Skip(pageSize * (page - 1)).Take(pageSize);

      //materialization / load
      result = query.ToArray();

    }

    return result;
  }

  /// <summary> Adds a new StudyScope and returns success. </summary>
  /// <param name="studyScope"> StudyScope containing the new values </param>
  public bool AddNewStudyScope(StudyScope studyScope){
    var mac = AccessControlContext.Current;

    StudyScopeEntity newEntity = new StudyScopeEntity();
    newEntity.CopyContentFrom(studyScope);

    using (IdentityManagementDbContext db = new IdentityManagementDbContext()) {

      //checks, that the new values are within the access control scope
      if(!this.PreValidateAccessControlScope(newEntity, db)){
        if(_Logger != null){
          _Logger.LogInformation("Adding StudyScope failed: record would be out of access control scope!");
        }
        return false;
      }

      if (db.StudyScopes.Where((e)=>e.ResearchStudyUid == newEntity.ResearchStudyUid).Any()) {
        if(_Logger != null){
          _Logger.LogInformation("Adding StudyScope failed: already existing record with this PK!");
        }
        return false;
      }

      db.StudyScopes.Add(newEntity);

      db.SaveChanges();
    }
    if(_Logger != null){
      _Logger.LogInformation("A StudyScope was added!");
    }

    return true;
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given StudyScope addressed by the primary identifier fields within the given StudyScope. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="studyScope"> StudyScope containing the new values (the primary identifier fields within the given StudyScope will be used to address the target record) </param>
  public bool UpdateStudyScope(StudyScope studyScope){
    return this.UpdateStudyScopeByResearchStudyUid(studyScope.ResearchStudyUid, studyScope);
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given StudyScope addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="researchStudyUid"> the official invariant name of the study as given by the sponsor </param>
  /// <param name="studyScope"> StudyScope containing the new values (the primary identifier fields within the given StudyScope will be ignored) </param>
  public bool UpdateStudyScopeByResearchStudyUid(Guid researchStudyUid, StudyScope studyScope){
    var mac = AccessControlContext.Current;

    StudyScopeEntity existingEntity;
    using (IdentityManagementDbContext db = new IdentityManagementDbContext()) {

      IQueryable<StudyScopeEntity> query = db.StudyScopes;

      query = query.Where((e)=>e.ResearchStudyUid == researchStudyUid).AccessScopeFiltered();

      //materialization / load
      existingEntity = query.SingleOrDefault();

      if(existingEntity == null) {
        if(_Logger != null){
          _Logger.LogInformation("Updating StudyScope failed: no record with this PK!");
        }
        return false;
      }

      bool changeAttemptOnFixedField = false;
      existingEntity.CopyContentFrom(studyScope, (name) => changeAttemptOnFixedField = true);

      if (changeAttemptOnFixedField) {
        if(_Logger != null){
          _Logger.LogInformation("Updating StudyScope failed: change attempt on FIXED field!");
        }
        return false;
      }

      //checks, that the new values are within the access control scope
      if(!this.PreValidateAccessControlScope(existingEntity, db)){
        if(_Logger != null){
          _Logger.LogInformation("Updating StudyScope failed: record would be out of access control scope!");
        }
        return false;
      }

      db.SaveChanges();
    }
    if(_Logger != null){
      _Logger.LogInformation("A StudyScope was updated!");
    }

    return true;
  }

  /// <summary> Deletes a specific StudyScope addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="researchStudyUid"> the official invariant name of the study as given by the sponsor </param>
  public bool DeleteStudyScopeByResearchStudyUid(Guid researchStudyUid){
    var mac = AccessControlContext.Current;

    StudyScopeEntity existingEntity;
    using (IdentityManagementDbContext db = new IdentityManagementDbContext()) {

      IQueryable<StudyScopeEntity> query = db.StudyScopes.AccessScopeFiltered();

      query = query.Where((e)=>e.ResearchStudyUid == researchStudyUid);

      //materialization / load
      existingEntity = query.SingleOrDefault();

      if (existingEntity == null) {
        if(_Logger != null){
          _Logger.LogInformation("Updating StudyScope failed: no record with this PK!");
        }
        return false;
      }

      db.StudyScopes.Remove(existingEntity);

      db.SaveChanges();
    }
    if(_Logger != null){
      _Logger.LogInformation("A StudyScope was deleted!");
    }

    return true;
  }

  private bool PreValidateAccessControlScope(StudyScopeEntity entity, IdentityManagementDbContext db){

    var filterExpression = EntityAccessControl.BuildExpressionForLocalEntity<StudyScopeEntity>(AccessControlContext.Current);
    if(!filterExpression.Compile().Invoke(entity)) {
      return false;
    }

    return true;
  }

}

/// <summary> Provides CRUD access to stored SubjectAddresses (based on schema version '1.5.0') </summary>
public partial class SubjectAddressStore : ISubjectAddresses {

  private ILogger _Logger = null;
  public SubjectAddressStore(ILogger<SubjectAddressStore> logger){
    _Logger = logger;
  }

  /// <summary> Loads a specific SubjectAddress addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="internalRecordId"> Represents the primary identity of a SubjectAddress </param>
  public SubjectAddress GetSubjectAddressByInternalRecordId(Guid internalRecordId){
    var mac = AccessControlContext.Current;

    SubjectAddress result;
    using (IdentityManagementDbContext db = new IdentityManagementDbContext()) {

      //select models, bacause we dont want to return types with navigation-properties!
      var query = db.SubjectAddresses.AsNoTracking().AccessScopeFiltered().Select(SubjectAddressEntity.SubjectAddressSelector);

      query = query.Where((e)=>e.InternalRecordId == internalRecordId);

      //materialization / load
      result = query.SingleOrDefault();

    }

    return result;
  }

  /// <summary> Loads SubjectAddresses. </summary>
  /// <param name="page">Number of the page, which should be returned </param>
  /// <param name="pageSize">Max count of SubjectAddresses which should be returned </param>
  public SubjectAddress[] GetSubjectAddresses(int page = 1, int pageSize = 20){
    return this.SearchSubjectAddresses(null, null, page, pageSize); 
  }

  private static String[] _ExactMatchPropNames = new String[] {"Street", "HouseNumber", "PostCode", "City", "State", "Country"};
  private static String[] _FreetextPropNames = new String[] {"PhoneNumber"};

  /// <summary> Loads SubjectAddresses where values matching to the given filterExpression</summary>
  /// <param name="filterExpression">a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' OR just '*' for all records</param>
  /// <param name="sortingExpression">one or more property names which are used as sort order (before pagination)</param>
  /// <param name="page">Number of the page, which should be returned</param>
  /// <param name="pageSize">Max count of SubjectAddresses which should be returned</param>
  public SubjectAddress[] SearchSubjectAddresses(String filterExpression, String sortingExpression = null, int page = 1, int pageSize = 20){
    var mac = AccessControlContext.Current;

    if(page < 1){
      page = 1;
    }
    if(pageSize < 1 || pageSize > 10000){
      pageSize = 20;
    }

    SubjectAddress[] result;
    using (IdentityManagementDbContext db = new IdentityManagementDbContext()) {

      //select models, bacause we dont want to return types with navigation-properties!
      var query = db.SubjectAddresses
        .AsNoTracking()
        .AccessScopeFiltered()
        .Select(SubjectAddressEntity.SubjectAddressSelector)
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
        query = query.DynamicallySorted("InternalRecordId");
      }
      else{
        query = query.DynamicallySorted(sortingExpression + ", InternalRecordId");
      }

      //apply pagination
      query = query.Skip(pageSize * (page - 1)).Take(pageSize);

      //materialization / load
      result = query.ToArray();

    }

    return result;
  }

  /// <summary> Adds a new SubjectAddress and returns success. </summary>
  /// <param name="subjectAddress"> SubjectAddress containing the new values </param>
  public bool AddNewSubjectAddress(SubjectAddress subjectAddress){
    var mac = AccessControlContext.Current;

    SubjectAddressEntity newEntity = new SubjectAddressEntity();
    newEntity.CopyContentFrom(subjectAddress);

    using (IdentityManagementDbContext db = new IdentityManagementDbContext()) {

      //checks, that the new values are within the access control scope
      if(!this.PreValidateAccessControlScope(newEntity, db)){
        if(_Logger != null){
          _Logger.LogInformation("Adding SubjectAddress failed: record would be out of access control scope!");
        }
        return false;
      }

      if (db.SubjectAddresses.Where((e)=>e.InternalRecordId == newEntity.InternalRecordId).Any()) {
        if(_Logger != null){
          _Logger.LogInformation("Adding SubjectAddress failed: already existing record with this PK!");
        }
        return false;
      }

      db.SubjectAddresses.Add(newEntity);

      db.SaveChanges();
    }
    if(_Logger != null){
      _Logger.LogInformation("A SubjectAddress was added!");
    }

    return true;
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given SubjectAddress addressed by the primary identifier fields within the given SubjectAddress. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="subjectAddress"> SubjectAddress containing the new values (the primary identifier fields within the given SubjectAddress will be used to address the target record) </param>
  public bool UpdateSubjectAddress(SubjectAddress subjectAddress){
    return this.UpdateSubjectAddressByInternalRecordId(subjectAddress.InternalRecordId, subjectAddress);
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given SubjectAddress addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="internalRecordId"> Represents the primary identity of a SubjectAddress </param>
  /// <param name="subjectAddress"> SubjectAddress containing the new values (the primary identifier fields within the given SubjectAddress will be ignored) </param>
  public bool UpdateSubjectAddressByInternalRecordId(Guid internalRecordId, SubjectAddress subjectAddress){
    var mac = AccessControlContext.Current;

    SubjectAddressEntity existingEntity;
    using (IdentityManagementDbContext db = new IdentityManagementDbContext()) {

      IQueryable<SubjectAddressEntity> query = db.SubjectAddresses;

      query = query.Where((e)=>e.InternalRecordId == internalRecordId).AccessScopeFiltered();

      //materialization / load
      existingEntity = query.SingleOrDefault();

      if(existingEntity == null) {
        if(_Logger != null){
          _Logger.LogInformation("Updating SubjectAddress failed: no record with this PK!");
        }
        return false;
      }

      bool changeAttemptOnFixedField = false;
      existingEntity.CopyContentFrom(subjectAddress, (name) => changeAttemptOnFixedField = true);

      if (changeAttemptOnFixedField) {
        if(_Logger != null){
          _Logger.LogInformation("Updating SubjectAddress failed: change attempt on FIXED field!");
        }
        return false;
      }

      //checks, that the new values are within the access control scope
      if(!this.PreValidateAccessControlScope(existingEntity, db)){
        if(_Logger != null){
          _Logger.LogInformation("Updating SubjectAddress failed: record would be out of access control scope!");
        }
        return false;
      }

      db.SaveChanges();
    }
    if(_Logger != null){
      _Logger.LogInformation("A SubjectAddress was updated!");
    }

    return true;
  }

  /// <summary> Deletes a specific SubjectAddress addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="internalRecordId"> Represents the primary identity of a SubjectAddress </param>
  public bool DeleteSubjectAddressByInternalRecordId(Guid internalRecordId){
    var mac = AccessControlContext.Current;

    SubjectAddressEntity existingEntity;
    using (IdentityManagementDbContext db = new IdentityManagementDbContext()) {

      IQueryable<SubjectAddressEntity> query = db.SubjectAddresses.AccessScopeFiltered();

      query = query.Where((e)=>e.InternalRecordId == internalRecordId);

      //materialization / load
      existingEntity = query.SingleOrDefault();

      if (existingEntity == null) {
        if(_Logger != null){
          _Logger.LogInformation("Updating SubjectAddress failed: no record with this PK!");
        }
        return false;
      }

      db.SubjectAddresses.Remove(existingEntity);

      db.SaveChanges();
    }
    if(_Logger != null){
      _Logger.LogInformation("A SubjectAddress was deleted!");
    }

    return true;
  }

  private bool PreValidateAccessControlScope(SubjectAddressEntity entity, IdentityManagementDbContext db){

    var filterExpression = EntityAccessControl.BuildExpressionForLocalEntity<SubjectAddressEntity>(AccessControlContext.Current);
    if(!filterExpression.Compile().Invoke(entity)) {
      return false;
    }

    return true;
  }

}

/// <summary> Provides CRUD access to stored SubjectIdentities (based on schema version '1.5.0') </summary>
public partial class SubjectIdentityStore : ISubjectIdentities {

  private ILogger _Logger = null;
  public SubjectIdentityStore(ILogger<SubjectIdentityStore> logger){
    _Logger = logger;
  }

  /// <summary> Loads a specific SubjectIdentity addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="recordId"> Represents the primary identity of a SubjectIdentity </param>
  public SubjectIdentity GetSubjectIdentityByRecordId(Guid recordId){
    var mac = AccessControlContext.Current;

    SubjectIdentity result;
    using (IdentityManagementDbContext db = new IdentityManagementDbContext()) {

      //select models, bacause we dont want to return types with navigation-properties!
      var query = db.SubjectIdentities.AsNoTracking().AccessScopeFiltered().Select(SubjectIdentityEntity.SubjectIdentitySelector);

      query = query.Where((e)=>e.RecordId == recordId);

      //materialization / load
      result = query.SingleOrDefault();

    }

    return result;
  }

  /// <summary> Loads SubjectIdentities. </summary>
  /// <param name="page">Number of the page, which should be returned </param>
  /// <param name="pageSize">Max count of SubjectIdentities which should be returned </param>
  public SubjectIdentity[] GetSubjectIdentities(int page = 1, int pageSize = 20){
    return this.SearchSubjectIdentities(null, null, page, pageSize); 
  }

  private static String[] _ExactMatchPropNames = new String[] {"FirstName", "LastName"};
  private static String[] _FreetextPropNames = new String[] {"FullNamePattern", "Language", "Notes", "Email", "MobileNumber"};

  /// <summary> Loads SubjectIdentities where values matching to the given filterExpression</summary>
  /// <param name="filterExpression">a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' OR just '*' for all records</param>
  /// <param name="sortingExpression">one or more property names which are used as sort order (before pagination)</param>
  /// <param name="page">Number of the page, which should be returned</param>
  /// <param name="pageSize">Max count of SubjectIdentities which should be returned</param>
  public SubjectIdentity[] SearchSubjectIdentities(String filterExpression, String sortingExpression = null, int page = 1, int pageSize = 20){
    var mac = AccessControlContext.Current;

    if(page < 1){
      page = 1;
    }
    if(pageSize < 1 || pageSize > 10000){
      pageSize = 20;
    }

    SubjectIdentity[] result;
    using (IdentityManagementDbContext db = new IdentityManagementDbContext()) {

      //select models, bacause we dont want to return types with navigation-properties!
      var query = db.SubjectIdentities
        .AsNoTracking()
        .AccessScopeFiltered()
        .Select(SubjectIdentityEntity.SubjectIdentitySelector)
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
        query = query.DynamicallySorted("RecordId");
      }
      else{
        query = query.DynamicallySorted(sortingExpression + ", RecordId");
      }

      //apply pagination
      query = query.Skip(pageSize * (page - 1)).Take(pageSize);

      //materialization / load
      result = query.ToArray();

    }

    return result;
  }

  /// <summary> Adds a new SubjectIdentity and returns success. </summary>
  /// <param name="subjectIdentity"> SubjectIdentity containing the new values </param>
  public bool AddNewSubjectIdentity(SubjectIdentity subjectIdentity){
    var mac = AccessControlContext.Current;

    SubjectIdentityEntity newEntity = new SubjectIdentityEntity();
    newEntity.CopyContentFrom(subjectIdentity);

    using (IdentityManagementDbContext db = new IdentityManagementDbContext()) {

      //checks, that the new values are within the access control scope
      if(!this.PreValidateAccessControlScope(newEntity, db)){
        if(_Logger != null){
          _Logger.LogInformation("Adding SubjectIdentity failed: record would be out of access control scope!");
        }
        return false;
      }

      if (db.SubjectIdentities.Where((e)=>e.RecordId == newEntity.RecordId).Any()) {
        if(_Logger != null){
          _Logger.LogInformation("Adding SubjectIdentity failed: already existing record with this PK!");
        }
        return false;
      }

      db.SubjectIdentities.Add(newEntity);

      db.SaveChanges();
    }
    if(_Logger != null){
      _Logger.LogInformation("A SubjectIdentity was added!");
    }

    return true;
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given SubjectIdentity addressed by the primary identifier fields within the given SubjectIdentity. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="subjectIdentity"> SubjectIdentity containing the new values (the primary identifier fields within the given SubjectIdentity will be used to address the target record) </param>
  public bool UpdateSubjectIdentity(SubjectIdentity subjectIdentity){
    return this.UpdateSubjectIdentityByRecordId(subjectIdentity.RecordId, subjectIdentity);
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given SubjectIdentity addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="recordId"> Represents the primary identity of a SubjectIdentity </param>
  /// <param name="subjectIdentity"> SubjectIdentity containing the new values (the primary identifier fields within the given SubjectIdentity will be ignored) </param>
  public bool UpdateSubjectIdentityByRecordId(Guid recordId, SubjectIdentity subjectIdentity){
    var mac = AccessControlContext.Current;

    SubjectIdentityEntity existingEntity;
    using (IdentityManagementDbContext db = new IdentityManagementDbContext()) {

      IQueryable<SubjectIdentityEntity> query = db.SubjectIdentities;

      query = query.Where((e)=>e.RecordId == recordId).AccessScopeFiltered();

      //materialization / load
      existingEntity = query.SingleOrDefault();

      if(existingEntity == null) {
        if(_Logger != null){
          _Logger.LogInformation("Updating SubjectIdentity failed: no record with this PK!");
        }
        return false;
      }

      bool changeAttemptOnFixedField = false;
      existingEntity.CopyContentFrom(subjectIdentity, (name) => changeAttemptOnFixedField = true);

      if (changeAttemptOnFixedField) {
        if(_Logger != null){
          _Logger.LogInformation("Updating SubjectIdentity failed: change attempt on FIXED field!");
        }
        return false;
      }

      //checks, that the new values are within the access control scope
      if(!this.PreValidateAccessControlScope(existingEntity, db)){
        if(_Logger != null){
          _Logger.LogInformation("Updating SubjectIdentity failed: record would be out of access control scope!");
        }
        return false;
      }

      db.SaveChanges();
    }
    if(_Logger != null){
      _Logger.LogInformation("A SubjectIdentity was updated!");
    }

    return true;
  }

  /// <summary> Deletes a specific SubjectIdentity addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="recordId"> Represents the primary identity of a SubjectIdentity </param>
  public bool DeleteSubjectIdentityByRecordId(Guid recordId){
    var mac = AccessControlContext.Current;

    SubjectIdentityEntity existingEntity;
    using (IdentityManagementDbContext db = new IdentityManagementDbContext()) {

      IQueryable<SubjectIdentityEntity> query = db.SubjectIdentities.AccessScopeFiltered();

      query = query.Where((e)=>e.RecordId == recordId);

      //materialization / load
      existingEntity = query.SingleOrDefault();

      if (existingEntity == null) {
        if(_Logger != null){
          _Logger.LogInformation("Updating SubjectIdentity failed: no record with this PK!");
        }
        return false;
      }

      db.SubjectIdentities.Remove(existingEntity);

      db.SaveChanges();
    }
    if(_Logger != null){
      _Logger.LogInformation("A SubjectIdentity was deleted!");
    }

    return true;
  }

  private bool PreValidateAccessControlScope(SubjectIdentityEntity entity, IdentityManagementDbContext db){

    var filterExpression = EntityAccessControl.BuildExpressionForLocalEntity<SubjectIdentityEntity>(AccessControlContext.Current);
    if(!filterExpression.Compile().Invoke(entity)) {
      return false;
    }

    if(!db.SubjectAddresses.Where((tgt)=> tgt.InternalRecordId==entity.ResidentAddressId ).AccessScopeFiltered().Any()) {
      return false;
    }
    return true;
  }

}

}
