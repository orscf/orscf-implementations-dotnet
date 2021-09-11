using MedicalResearch.Workflow;
using MedicalResearch.Workflow.Persistence;
using System;
using System.Data;
using System.Data.AccessControl;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;

namespace MedicalResearch.Workflow.Persistence.EF {

/// <summary> Provides CRUD access to stored Arms (based on schema version '1.3.0') </summary>
public partial class ArmStore : IArmRepository {

  /// <summary> Loads a specific Arm addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="armIdentity"> Composite Key, which represents the primary identity of a Arm </param>
  public Arm GetArmByArmIdentity(ArmIdentity armIdentity){
    var mac = AccessControlContext.Current;

    Arm result;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      //select models, bacause we dont want to return types with navigation-properties!
      var query = db.Arms.AsNoTracking().AccessScopeFiltered().Select(ArmEntity.ArmSelector);

      query = query.Where((e)=> e.StudyArmName == armIdentity.StudyArmName && e.StudyWorkflowName == armIdentity.StudyWorkflowName && e.StudyWorkflowVersion == armIdentity.StudyWorkflowVersion);

      //materialization / load
      result = query.SingleOrDefault();

    }

    return result;
  }

  /// <summary> Loads Arms. </summary>
  /// <param name="page">Number of the page, which should be returned </param>
  /// <param name="pageSize">Max count of Arms which should be returned </param>
  public Arm[] GetArms(int page = 1, int pageSize = 20){
    return this.SearchArms(null, null, page, pageSize); 
  }

  private static String[] _ExactMatchPropNames = new String[] {"StudyArmName", "StudyWorkflowName", "StudyWorkflowVersion", "StudyWorkflowName", "StudyWorkflowVersion"};
  private static String[] _FreetextPropNames = new String[] {"ArmSpecificDocumentationUrl", "InclusionCriteria", "Substudy"};

  /// <summary> Loads Arms where values matching to the given filterExpression</summary>
  /// <param name="filterExpression">a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")'</param>
  /// <param name="sortingExpression">one or more property names which are used as sort order (before pagination)</param>
  /// <param name="page">Number of the page, which should be returned</param>
  /// <param name="pageSize">Max count of Arms which should be returned</param>
  public Arm[] SearchArms(String filterExpression, String sortingExpression = null, int page = 1, int pageSize = 20){
    var mac = AccessControlContext.Current;

    Arm[] result;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      //select models, bacause we dont want to return types with navigation-properties!
      var query = db.Arms
        .AsNoTracking()
        .AccessScopeFiltered()
        .Select(ArmEntity.ArmSelector)
      ;
      
      //apply filter (if given)
      if(filterExpression != null) {
        //just if the filterExpression isnt already a valid expression, treat it as a freetext seach string and transform it to a valid expression
        filterExpression = DynamicLinqExtensions.FreetextSearchStringToFilterExpression(filterExpression, _ExactMatchPropNames, _FreetextPropNames);
      }
      if(filterExpression != null) {
        query = query.DynamicallyFiltered(filterExpression);
      }

      //apply sorting
      if(String.IsNullOrWhiteSpace(sortingExpression)) {
        query = query.DynamicallySorted("StudyArmName, StudyWorkflowName, StudyWorkflowVersion");
      }
      else{
        query = query.DynamicallySorted(sortingExpression + ", StudyArmName, StudyWorkflowName, StudyWorkflowVersion");
      }

      //apply pagination
      query = query.Skip(pageSize * (page - 1)).Take(pageSize);

      //materialization / load
      result = query.ToArray();

    }

    return result;
  }

  /// <summary> Adds a new Arm and returns success. </summary>
  /// <param name="arm"> Arm containing the new values </param>
  public bool AddNewArm(Arm arm){
    var mac = AccessControlContext.Current;

    ArmEntity newEntity = new ArmEntity();
    newEntity.CopyContentFrom(arm);

    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      //checks, that the new values are within the access control scope
      if(!this.PreValidateAccessControlScope(newEntity, db)){
        return false;
      }

      if (db.Arms.Where((e)=> e.StudyArmName == newEntity.StudyArmName && e.StudyWorkflowName == newEntity.StudyWorkflowName && e.StudyWorkflowVersion == newEntity.StudyWorkflowVersion).Any()) {
        return false;
      }

      db.Arms.Add(newEntity);

      db.SaveChanges();
    }

    return true;
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given Arm addressed by the primary identifier fields within the given Arm. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="arm"> Arm containing the new values (the primary identifier fields within the given Arm will be used to address the target record) </param>
  public bool UpdateArm(Arm arm){
    return this.UpdateArmByArmIdentity(new ArmIdentity { StudyArmName=arm.StudyArmName, StudyWorkflowName=arm.StudyWorkflowName, StudyWorkflowVersion=arm.StudyWorkflowVersion }, arm);
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given Arm addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="armIdentity"> Composite Key, which represents the primary identity of a Arm </param>
  /// <param name="arm"> Arm containing the new values (the primary identifier fields within the given Arm will be ignored) </param>
  public bool UpdateArmByArmIdentity(ArmIdentity armIdentity, Arm arm){
    var mac = AccessControlContext.Current;

    ArmEntity existingEntity;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      var query = db.Arms.AsNoTracking();

      query = query.Where((e)=> e.StudyArmName == armIdentity.StudyArmName && e.StudyWorkflowName == armIdentity.StudyWorkflowName && e.StudyWorkflowVersion == armIdentity.StudyWorkflowVersion).AccessScopeFiltered();

      //materialization / load
      existingEntity = query.SingleOrDefault();

      if(existingEntity == null) {
        return false;
      }

      bool changeAttemptOnFixedField = false;
      existingEntity.CopyContentFrom(arm, (name) => changeAttemptOnFixedField = true);

      if (changeAttemptOnFixedField) {
        return false;
      }

      //checks, that the new values are within the access control scope
      if(!this.PreValidateAccessControlScope(existingEntity, db)){
        return false;
      }

      db.SaveChanges();
    }

    return true;
  }

  /// <summary> Deletes a specific Arm addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="armIdentity"> Composite Key, which represents the primary identity of a Arm </param>
  public bool DeleteArmByArmIdentity(ArmIdentity armIdentity){
    var mac = AccessControlContext.Current;

    ArmEntity existingEntity;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      var query = db.Arms.AsNoTracking().AccessScopeFiltered();

      query = query.Where((e)=> e.StudyArmName == armIdentity.StudyArmName && e.StudyWorkflowName == armIdentity.StudyWorkflowName && e.StudyWorkflowVersion == armIdentity.StudyWorkflowVersion);

      //materialization / load
      existingEntity = query.SingleOrDefault();

      if (existingEntity == null) {
        return false;
      }

      db.Arms.Remove(existingEntity);

      db.SaveChanges();
    }

    return true;
  }

  private bool PreValidateAccessControlScope(ArmEntity entity, WorkflowDefinitionDbContext db){

    var filterExpression = EntityAccessControl.BuildExpressionForLocalEntity<ArmEntity>(AccessControlContext.Current);
    if(!filterExpression.Compile().Invoke(entity)) {
      return false;
    }

    if(!db.ResearchStudies.Where((tgt)=> tgt.StudyWorkflowName==entity.StudyWorkflowName && tgt.StudyWorkflowVersion==entity.StudyWorkflowVersion ).AccessScopeFiltered().Any()) {
      return false;
    }
    if(!db.ProcedureSchedules.Where((tgt)=> tgt.ProcedureScheduleId==entity.RootProcedureScheduleId ).AccessScopeFiltered().Any()) {
      return false;
    }
    return true;
  }

}

/// <summary> Provides CRUD access to stored ResearchStudies (based on schema version '1.3.0') </summary>
public partial class ResearchStudyStore : IResearchStudyRepository {

  /// <summary> Loads a specific ResearchStudy addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="researchStudyIdentity"> Composite Key, which represents the primary identity of a ResearchStudy </param>
  public ResearchStudy GetResearchStudyByResearchStudyIdentity(ResearchStudyIdentity researchStudyIdentity){
    var mac = AccessControlContext.Current;

    ResearchStudy result;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      //select models, bacause we dont want to return types with navigation-properties!
      var query = db.ResearchStudies.AsNoTracking().AccessScopeFiltered().Select(ResearchStudyEntity.ResearchStudySelector);

      query = query.Where((e)=> e.StudyWorkflowName == researchStudyIdentity.StudyWorkflowName && e.StudyWorkflowVersion == researchStudyIdentity.StudyWorkflowVersion);

      //materialization / load
      result = query.SingleOrDefault();

    }

    return result;
  }

  /// <summary> Loads ResearchStudies. </summary>
  /// <param name="page">Number of the page, which should be returned </param>
  /// <param name="pageSize">Max count of ResearchStudies which should be returned </param>
  public ResearchStudy[] GetResearchStudies(int page = 1, int pageSize = 20){
    return this.SearchResearchStudies(null, null, page, pageSize); 
  }

  private static String[] _ExactMatchPropNames = new String[] {"StudyWorkflowName", "StudyWorkflowVersion"};
  private static String[] _FreetextPropNames = new String[] {"OfficialLabel", "DefinitionOwner", "DocumentationUrl", "LogoImage", "Description", "VersionIdentity", "BillingCurrency", "StudyDocumentationUrl", "CaseReportFormUrl"};

  /// <summary> Loads ResearchStudies where values matching to the given filterExpression</summary>
  /// <param name="filterExpression">a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")'</param>
  /// <param name="sortingExpression">one or more property names which are used as sort order (before pagination)</param>
  /// <param name="page">Number of the page, which should be returned</param>
  /// <param name="pageSize">Max count of ResearchStudies which should be returned</param>
  public ResearchStudy[] SearchResearchStudies(String filterExpression, String sortingExpression = null, int page = 1, int pageSize = 20){
    var mac = AccessControlContext.Current;

    ResearchStudy[] result;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      //select models, bacause we dont want to return types with navigation-properties!
      var query = db.ResearchStudies
        .AsNoTracking()
        .AccessScopeFiltered()
        .Select(ResearchStudyEntity.ResearchStudySelector)
      ;
      
      //apply filter (if given)
      if(filterExpression != null) {
        //just if the filterExpression isnt already a valid expression, treat it as a freetext seach string and transform it to a valid expression
        filterExpression = DynamicLinqExtensions.FreetextSearchStringToFilterExpression(filterExpression, _ExactMatchPropNames, _FreetextPropNames);
      }
      if(filterExpression != null) {
        query = query.DynamicallyFiltered(filterExpression);
      }

      //apply sorting
      if(String.IsNullOrWhiteSpace(sortingExpression)) {
        query = query.DynamicallySorted("StudyWorkflowName, StudyWorkflowVersion");
      }
      else{
        query = query.DynamicallySorted(sortingExpression + ", StudyWorkflowName, StudyWorkflowVersion");
      }

      //apply pagination
      query = query.Skip(pageSize * (page - 1)).Take(pageSize);

      //materialization / load
      result = query.ToArray();

    }

    return result;
  }

  /// <summary> Adds a new ResearchStudy and returns success. </summary>
  /// <param name="researchStudy"> ResearchStudy containing the new values </param>
  public bool AddNewResearchStudy(ResearchStudy researchStudy){
    var mac = AccessControlContext.Current;

    ResearchStudyEntity newEntity = new ResearchStudyEntity();
    newEntity.CopyContentFrom(researchStudy);

    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      //checks, that the new values are within the access control scope
      if(!this.PreValidateAccessControlScope(newEntity, db)){
        return false;
      }

      if (db.ResearchStudies.Where((e)=> e.StudyWorkflowName == newEntity.StudyWorkflowName && e.StudyWorkflowVersion == newEntity.StudyWorkflowVersion).Any()) {
        return false;
      }

      db.ResearchStudies.Add(newEntity);

      db.SaveChanges();
    }

    return true;
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given ResearchStudy addressed by the primary identifier fields within the given ResearchStudy. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="researchStudy"> ResearchStudy containing the new values (the primary identifier fields within the given ResearchStudy will be used to address the target record) </param>
  public bool UpdateResearchStudy(ResearchStudy researchStudy){
    return this.UpdateResearchStudyByResearchStudyIdentity(new ResearchStudyIdentity { StudyWorkflowName=researchStudy.StudyWorkflowName, StudyWorkflowVersion=researchStudy.StudyWorkflowVersion }, researchStudy);
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given ResearchStudy addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="researchStudyIdentity"> Composite Key, which represents the primary identity of a ResearchStudy </param>
  /// <param name="researchStudy"> ResearchStudy containing the new values (the primary identifier fields within the given ResearchStudy will be ignored) </param>
  public bool UpdateResearchStudyByResearchStudyIdentity(ResearchStudyIdentity researchStudyIdentity, ResearchStudy researchStudy){
    var mac = AccessControlContext.Current;

    ResearchStudyEntity existingEntity;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      var query = db.ResearchStudies.AsNoTracking();

      query = query.Where((e)=> e.StudyWorkflowName == researchStudyIdentity.StudyWorkflowName && e.StudyWorkflowVersion == researchStudyIdentity.StudyWorkflowVersion).AccessScopeFiltered();

      //materialization / load
      existingEntity = query.SingleOrDefault();

      if(existingEntity == null) {
        return false;
      }

      bool changeAttemptOnFixedField = false;
      existingEntity.CopyContentFrom(researchStudy, (name) => changeAttemptOnFixedField = true);

      if (changeAttemptOnFixedField) {
        return false;
      }

      //checks, that the new values are within the access control scope
      if(!this.PreValidateAccessControlScope(existingEntity, db)){
        return false;
      }

      db.SaveChanges();
    }

    return true;
  }

  /// <summary> Deletes a specific ResearchStudy addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="researchStudyIdentity"> Composite Key, which represents the primary identity of a ResearchStudy </param>
  public bool DeleteResearchStudyByResearchStudyIdentity(ResearchStudyIdentity researchStudyIdentity){
    var mac = AccessControlContext.Current;

    ResearchStudyEntity existingEntity;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      var query = db.ResearchStudies.AsNoTracking().AccessScopeFiltered();

      query = query.Where((e)=> e.StudyWorkflowName == researchStudyIdentity.StudyWorkflowName && e.StudyWorkflowVersion == researchStudyIdentity.StudyWorkflowVersion);

      //materialization / load
      existingEntity = query.SingleOrDefault();

      if (existingEntity == null) {
        return false;
      }

      db.ResearchStudies.Remove(existingEntity);

      db.SaveChanges();
    }

    return true;
  }

  private bool PreValidateAccessControlScope(ResearchStudyEntity entity, WorkflowDefinitionDbContext db){

    var filterExpression = EntityAccessControl.BuildExpressionForLocalEntity<ResearchStudyEntity>(AccessControlContext.Current);
    if(!filterExpression.Compile().Invoke(entity)) {
      return false;
    }

    return true;
  }

}

/// <summary> Provides CRUD access to stored ProcedureSchedules (based on schema version '1.3.0') </summary>
public partial class ProcedureScheduleStore : IProcedureScheduleRepository {

  /// <summary> Loads a specific ProcedureSchedule addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="procedureScheduleId"> Represents the primary identity of a ProcedureSchedule </param>
  public ProcedureSchedule GetProcedureScheduleByProcedureScheduleId(Guid procedureScheduleId){
    var mac = AccessControlContext.Current;

    ProcedureSchedule result;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      //select models, bacause we dont want to return types with navigation-properties!
      var query = db.ProcedureSchedules.AsNoTracking().AccessScopeFiltered().Select(ProcedureScheduleEntity.ProcedureScheduleSelector);

      query = query.Where((e)=>e.ProcedureScheduleId == procedureScheduleId);

      //materialization / load
      result = query.SingleOrDefault();

    }

    return result;
  }

  /// <summary> Loads ProcedureSchedules. </summary>
  /// <param name="page">Number of the page, which should be returned </param>
  /// <param name="pageSize">Max count of ProcedureSchedules which should be returned </param>
  public ProcedureSchedule[] GetProcedureSchedules(int page = 1, int pageSize = 20){
    return this.SearchProcedureSchedules(null, null, page, pageSize); 
  }

  private static String[] _ExactMatchPropNames = new String[] {"StudyWorkflowName", "StudyWorkflowVersion"};
  private static String[] _FreetextPropNames = new String[] {"Title", "MaxSkipsBeforeLost", "MaxSubsequentSkipsBeforeLost", "MaxLostsBeforeLtfuAbort", "MaxSubsequentLostsBeforeLtfuAbort", "EventOnLtfuAbort", "EventOnCycleEnded", "EventOnAllCyclesEnded", "InducingEvents", "AbortCausingEvents"};

  /// <summary> Loads ProcedureSchedules where values matching to the given filterExpression</summary>
  /// <param name="filterExpression">a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")'</param>
  /// <param name="sortingExpression">one or more property names which are used as sort order (before pagination)</param>
  /// <param name="page">Number of the page, which should be returned</param>
  /// <param name="pageSize">Max count of ProcedureSchedules which should be returned</param>
  public ProcedureSchedule[] SearchProcedureSchedules(String filterExpression, String sortingExpression = null, int page = 1, int pageSize = 20){
    var mac = AccessControlContext.Current;

    ProcedureSchedule[] result;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      //select models, bacause we dont want to return types with navigation-properties!
      var query = db.ProcedureSchedules
        .AsNoTracking()
        .AccessScopeFiltered()
        .Select(ProcedureScheduleEntity.ProcedureScheduleSelector)
      ;
      
      //apply filter (if given)
      if(filterExpression != null) {
        //just if the filterExpression isnt already a valid expression, treat it as a freetext seach string and transform it to a valid expression
        filterExpression = DynamicLinqExtensions.FreetextSearchStringToFilterExpression(filterExpression, _ExactMatchPropNames, _FreetextPropNames);
      }
      if(filterExpression != null) {
        query = query.DynamicallyFiltered(filterExpression);
      }

      //apply sorting
      if(String.IsNullOrWhiteSpace(sortingExpression)) {
        query = query.DynamicallySorted("ProcedureScheduleId");
      }
      else{
        query = query.DynamicallySorted(sortingExpression + ", ProcedureScheduleId");
      }

      //apply pagination
      query = query.Skip(pageSize * (page - 1)).Take(pageSize);

      //materialization / load
      result = query.ToArray();

    }

    return result;
  }

  /// <summary> Adds a new ProcedureSchedule and returns success. </summary>
  /// <param name="procedureSchedule"> ProcedureSchedule containing the new values </param>
  public bool AddNewProcedureSchedule(ProcedureSchedule procedureSchedule){
    var mac = AccessControlContext.Current;

    ProcedureScheduleEntity newEntity = new ProcedureScheduleEntity();
    newEntity.CopyContentFrom(procedureSchedule);

    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      //checks, that the new values are within the access control scope
      if(!this.PreValidateAccessControlScope(newEntity, db)){
        return false;
      }

      if (db.ProcedureSchedules.Where((e)=>e.ProcedureScheduleId == newEntity.ProcedureScheduleId).Any()) {
        return false;
      }

      db.ProcedureSchedules.Add(newEntity);

      db.SaveChanges();
    }

    return true;
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given ProcedureSchedule addressed by the primary identifier fields within the given ProcedureSchedule. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="procedureSchedule"> ProcedureSchedule containing the new values (the primary identifier fields within the given ProcedureSchedule will be used to address the target record) </param>
  public bool UpdateProcedureSchedule(ProcedureSchedule procedureSchedule){
    return this.UpdateProcedureScheduleByProcedureScheduleId(procedureSchedule.ProcedureScheduleId, procedureSchedule);
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given ProcedureSchedule addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="procedureScheduleId"> Represents the primary identity of a ProcedureSchedule </param>
  /// <param name="procedureSchedule"> ProcedureSchedule containing the new values (the primary identifier fields within the given ProcedureSchedule will be ignored) </param>
  public bool UpdateProcedureScheduleByProcedureScheduleId(Guid procedureScheduleId, ProcedureSchedule procedureSchedule){
    var mac = AccessControlContext.Current;

    ProcedureScheduleEntity existingEntity;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      var query = db.ProcedureSchedules.AsNoTracking();

      query = query.Where((e)=>e.ProcedureScheduleId == procedureScheduleId).AccessScopeFiltered();

      //materialization / load
      existingEntity = query.SingleOrDefault();

      if(existingEntity == null) {
        return false;
      }

      bool changeAttemptOnFixedField = false;
      existingEntity.CopyContentFrom(procedureSchedule, (name) => changeAttemptOnFixedField = true);

      if (changeAttemptOnFixedField) {
        return false;
      }

      //checks, that the new values are within the access control scope
      if(!this.PreValidateAccessControlScope(existingEntity, db)){
        return false;
      }

      db.SaveChanges();
    }

    return true;
  }

  /// <summary> Deletes a specific ProcedureSchedule addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="procedureScheduleId"> Represents the primary identity of a ProcedureSchedule </param>
  public bool DeleteProcedureScheduleByProcedureScheduleId(Guid procedureScheduleId){
    var mac = AccessControlContext.Current;

    ProcedureScheduleEntity existingEntity;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      var query = db.ProcedureSchedules.AsNoTracking().AccessScopeFiltered();

      query = query.Where((e)=>e.ProcedureScheduleId == procedureScheduleId);

      //materialization / load
      existingEntity = query.SingleOrDefault();

      if (existingEntity == null) {
        return false;
      }

      db.ProcedureSchedules.Remove(existingEntity);

      db.SaveChanges();
    }

    return true;
  }

  private bool PreValidateAccessControlScope(ProcedureScheduleEntity entity, WorkflowDefinitionDbContext db){

    var filterExpression = EntityAccessControl.BuildExpressionForLocalEntity<ProcedureScheduleEntity>(AccessControlContext.Current);
    if(!filterExpression.Compile().Invoke(entity)) {
      return false;
    }

    if(!db.ResearchStudies.Where((tgt)=> tgt.StudyWorkflowName==entity.StudyWorkflowName && tgt.StudyWorkflowVersion==entity.StudyWorkflowVersion ).AccessScopeFiltered().Any()) {
      return false;
    }
    return true;
  }

}

/// <summary> Provides CRUD access to stored DataRecordingTasks (based on schema version '1.3.0') </summary>
public partial class DataRecordingTaskStore : IDataRecordingTaskRepository {

  /// <summary> Loads a specific DataRecordingTask addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="dataRecordingName"> Represents the primary identity of a DataRecordingTask </param>
  public DataRecordingTask GetDataRecordingTaskByDataRecordingName(String dataRecordingName){
    var mac = AccessControlContext.Current;

    DataRecordingTask result;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      //select models, bacause we dont want to return types with navigation-properties!
      var query = db.DataRecordingTasks.AsNoTracking().AccessScopeFiltered().Select(DataRecordingTaskEntity.DataRecordingTaskSelector);

      query = query.Where((e)=>e.DataRecordingName == dataRecordingName);

      //materialization / load
      result = query.SingleOrDefault();

    }

    return result;
  }

  /// <summary> Loads DataRecordingTasks. </summary>
  /// <param name="page">Number of the page, which should be returned </param>
  /// <param name="pageSize">Max count of DataRecordingTasks which should be returned </param>
  public DataRecordingTask[] GetDataRecordingTasks(int page = 1, int pageSize = 20){
    return this.SearchDataRecordingTasks(null, null, page, pageSize); 
  }

  private static String[] _ExactMatchPropNames = new String[] {"DataRecordingName", "StudyWorkflowName", "StudyWorkflowVersion"};
  private static String[] _FreetextPropNames = new String[] {"ShortDescription", "TaskSpecificDocumentationUrl", "ImportantNotices", "DataSchemaUrl", "DefaultData"};

  /// <summary> Loads DataRecordingTasks where values matching to the given filterExpression</summary>
  /// <param name="filterExpression">a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")'</param>
  /// <param name="sortingExpression">one or more property names which are used as sort order (before pagination)</param>
  /// <param name="page">Number of the page, which should be returned</param>
  /// <param name="pageSize">Max count of DataRecordingTasks which should be returned</param>
  public DataRecordingTask[] SearchDataRecordingTasks(String filterExpression, String sortingExpression = null, int page = 1, int pageSize = 20){
    var mac = AccessControlContext.Current;

    DataRecordingTask[] result;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      //select models, bacause we dont want to return types with navigation-properties!
      var query = db.DataRecordingTasks
        .AsNoTracking()
        .AccessScopeFiltered()
        .Select(DataRecordingTaskEntity.DataRecordingTaskSelector)
      ;
      
      //apply filter (if given)
      if(filterExpression != null) {
        //just if the filterExpression isnt already a valid expression, treat it as a freetext seach string and transform it to a valid expression
        filterExpression = DynamicLinqExtensions.FreetextSearchStringToFilterExpression(filterExpression, _ExactMatchPropNames, _FreetextPropNames);
      }
      if(filterExpression != null) {
        query = query.DynamicallyFiltered(filterExpression);
      }

      //apply sorting
      if(String.IsNullOrWhiteSpace(sortingExpression)) {
        query = query.DynamicallySorted("DataRecordingName");
      }
      else{
        query = query.DynamicallySorted(sortingExpression + ", DataRecordingName");
      }

      //apply pagination
      query = query.Skip(pageSize * (page - 1)).Take(pageSize);

      //materialization / load
      result = query.ToArray();

    }

    return result;
  }

  /// <summary> Adds a new DataRecordingTask and returns success. </summary>
  /// <param name="dataRecordingTask"> DataRecordingTask containing the new values </param>
  public bool AddNewDataRecordingTask(DataRecordingTask dataRecordingTask){
    var mac = AccessControlContext.Current;

    DataRecordingTaskEntity newEntity = new DataRecordingTaskEntity();
    newEntity.CopyContentFrom(dataRecordingTask);

    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      //checks, that the new values are within the access control scope
      if(!this.PreValidateAccessControlScope(newEntity, db)){
        return false;
      }

      if (db.DataRecordingTasks.Where((e)=>e.DataRecordingName == newEntity.DataRecordingName).Any()) {
        return false;
      }

      db.DataRecordingTasks.Add(newEntity);

      db.SaveChanges();
    }

    return true;
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given DataRecordingTask addressed by the primary identifier fields within the given DataRecordingTask. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="dataRecordingTask"> DataRecordingTask containing the new values (the primary identifier fields within the given DataRecordingTask will be used to address the target record) </param>
  public bool UpdateDataRecordingTask(DataRecordingTask dataRecordingTask){
    return this.UpdateDataRecordingTaskByDataRecordingName(dataRecordingTask.DataRecordingName, dataRecordingTask);
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given DataRecordingTask addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="dataRecordingName"> Represents the primary identity of a DataRecordingTask </param>
  /// <param name="dataRecordingTask"> DataRecordingTask containing the new values (the primary identifier fields within the given DataRecordingTask will be ignored) </param>
  public bool UpdateDataRecordingTaskByDataRecordingName(String dataRecordingName, DataRecordingTask dataRecordingTask){
    var mac = AccessControlContext.Current;

    DataRecordingTaskEntity existingEntity;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      var query = db.DataRecordingTasks.AsNoTracking();

      query = query.Where((e)=>e.DataRecordingName == dataRecordingName).AccessScopeFiltered();

      //materialization / load
      existingEntity = query.SingleOrDefault();

      if(existingEntity == null) {
        return false;
      }

      bool changeAttemptOnFixedField = false;
      existingEntity.CopyContentFrom(dataRecordingTask, (name) => changeAttemptOnFixedField = true);

      if (changeAttemptOnFixedField) {
        return false;
      }

      //checks, that the new values are within the access control scope
      if(!this.PreValidateAccessControlScope(existingEntity, db)){
        return false;
      }

      db.SaveChanges();
    }

    return true;
  }

  /// <summary> Deletes a specific DataRecordingTask addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="dataRecordingName"> Represents the primary identity of a DataRecordingTask </param>
  public bool DeleteDataRecordingTaskByDataRecordingName(String dataRecordingName){
    var mac = AccessControlContext.Current;

    DataRecordingTaskEntity existingEntity;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      var query = db.DataRecordingTasks.AsNoTracking().AccessScopeFiltered();

      query = query.Where((e)=>e.DataRecordingName == dataRecordingName);

      //materialization / load
      existingEntity = query.SingleOrDefault();

      if (existingEntity == null) {
        return false;
      }

      db.DataRecordingTasks.Remove(existingEntity);

      db.SaveChanges();
    }

    return true;
  }

  private bool PreValidateAccessControlScope(DataRecordingTaskEntity entity, WorkflowDefinitionDbContext db){

    var filterExpression = EntityAccessControl.BuildExpressionForLocalEntity<DataRecordingTaskEntity>(AccessControlContext.Current);
    if(!filterExpression.Compile().Invoke(entity)) {
      return false;
    }

    if(!db.ResearchStudies.Where((tgt)=> tgt.StudyWorkflowName==entity.StudyWorkflowName && tgt.StudyWorkflowVersion==entity.StudyWorkflowVersion ).AccessScopeFiltered().Any()) {
      return false;
    }
    return true;
  }

}

/// <summary> Provides CRUD access to stored InducedDataRecordingTasks (based on schema version '1.3.0') </summary>
public partial class InducedDataRecordingTaskStore : IInducedDataRecordingTaskRepository {

  /// <summary> Loads a specific InducedDataRecordingTask addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="id"> Represents the primary identity of a InducedDataRecordingTask </param>
  public InducedDataRecordingTask GetInducedDataRecordingTaskById(Guid id){
    var mac = AccessControlContext.Current;

    InducedDataRecordingTask result;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      //select models, bacause we dont want to return types with navigation-properties!
      var query = db.InducedDataRecordingTasks.AsNoTracking().AccessScopeFiltered().Select(InducedDataRecordingTaskEntity.InducedDataRecordingTaskSelector);

      query = query.Where((e)=>e.Id == id);

      //materialization / load
      result = query.SingleOrDefault();

    }

    return result;
  }

  /// <summary> Loads InducedDataRecordingTasks. </summary>
  /// <param name="page">Number of the page, which should be returned </param>
  /// <param name="pageSize">Max count of InducedDataRecordingTasks which should be returned </param>
  public InducedDataRecordingTask[] GetInducedDataRecordingTasks(int page = 1, int pageSize = 20){
    return this.SearchInducedDataRecordingTasks(null, null, page, pageSize); 
  }

  private static String[] _ExactMatchPropNames = new String[] {"InducedDataRecordingName"};
  private static String[] _FreetextPropNames = new String[] {"OffsetUnit", "SchedulingVariabilityBefore", "SchedulingVariabilityAfter", "SchedulingVariabilityUnit", "InducedTaskExecutionTitle", "EventOnSkip", "EventOnLost"};

  /// <summary> Loads InducedDataRecordingTasks where values matching to the given filterExpression</summary>
  /// <param name="filterExpression">a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")'</param>
  /// <param name="sortingExpression">one or more property names which are used as sort order (before pagination)</param>
  /// <param name="page">Number of the page, which should be returned</param>
  /// <param name="pageSize">Max count of InducedDataRecordingTasks which should be returned</param>
  public InducedDataRecordingTask[] SearchInducedDataRecordingTasks(String filterExpression, String sortingExpression = null, int page = 1, int pageSize = 20){
    var mac = AccessControlContext.Current;

    InducedDataRecordingTask[] result;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      //select models, bacause we dont want to return types with navigation-properties!
      var query = db.InducedDataRecordingTasks
        .AsNoTracking()
        .AccessScopeFiltered()
        .Select(InducedDataRecordingTaskEntity.InducedDataRecordingTaskSelector)
      ;
      
      //apply filter (if given)
      if(filterExpression != null) {
        //just if the filterExpression isnt already a valid expression, treat it as a freetext seach string and transform it to a valid expression
        filterExpression = DynamicLinqExtensions.FreetextSearchStringToFilterExpression(filterExpression, _ExactMatchPropNames, _FreetextPropNames);
      }
      if(filterExpression != null) {
        query = query.DynamicallyFiltered(filterExpression);
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

  /// <summary> Adds a new InducedDataRecordingTask and returns success. </summary>
  /// <param name="inducedDataRecordingTask"> InducedDataRecordingTask containing the new values </param>
  public bool AddNewInducedDataRecordingTask(InducedDataRecordingTask inducedDataRecordingTask){
    var mac = AccessControlContext.Current;

    InducedDataRecordingTaskEntity newEntity = new InducedDataRecordingTaskEntity();
    newEntity.CopyContentFrom(inducedDataRecordingTask);

    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      //checks, that the new values are within the access control scope
      if(!this.PreValidateAccessControlScope(newEntity, db)){
        return false;
      }

      if (db.InducedDataRecordingTasks.Where((e)=>e.Id == newEntity.Id).Any()) {
        return false;
      }

      db.InducedDataRecordingTasks.Add(newEntity);

      db.SaveChanges();
    }

    return true;
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given InducedDataRecordingTask addressed by the primary identifier fields within the given InducedDataRecordingTask. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="inducedDataRecordingTask"> InducedDataRecordingTask containing the new values (the primary identifier fields within the given InducedDataRecordingTask will be used to address the target record) </param>
  public bool UpdateInducedDataRecordingTask(InducedDataRecordingTask inducedDataRecordingTask){
    return this.UpdateInducedDataRecordingTaskById(inducedDataRecordingTask.Id, inducedDataRecordingTask);
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given InducedDataRecordingTask addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="id"> Represents the primary identity of a InducedDataRecordingTask </param>
  /// <param name="inducedDataRecordingTask"> InducedDataRecordingTask containing the new values (the primary identifier fields within the given InducedDataRecordingTask will be ignored) </param>
  public bool UpdateInducedDataRecordingTaskById(Guid id, InducedDataRecordingTask inducedDataRecordingTask){
    var mac = AccessControlContext.Current;

    InducedDataRecordingTaskEntity existingEntity;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      var query = db.InducedDataRecordingTasks.AsNoTracking();

      query = query.Where((e)=>e.Id == id).AccessScopeFiltered();

      //materialization / load
      existingEntity = query.SingleOrDefault();

      if(existingEntity == null) {
        return false;
      }

      bool changeAttemptOnFixedField = false;
      existingEntity.CopyContentFrom(inducedDataRecordingTask, (name) => changeAttemptOnFixedField = true);

      if (changeAttemptOnFixedField) {
        return false;
      }

      //checks, that the new values are within the access control scope
      if(!this.PreValidateAccessControlScope(existingEntity, db)){
        return false;
      }

      db.SaveChanges();
    }

    return true;
  }

  /// <summary> Deletes a specific InducedDataRecordingTask addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="id"> Represents the primary identity of a InducedDataRecordingTask </param>
  public bool DeleteInducedDataRecordingTaskById(Guid id){
    var mac = AccessControlContext.Current;

    InducedDataRecordingTaskEntity existingEntity;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      var query = db.InducedDataRecordingTasks.AsNoTracking().AccessScopeFiltered();

      query = query.Where((e)=>e.Id == id);

      //materialization / load
      existingEntity = query.SingleOrDefault();

      if (existingEntity == null) {
        return false;
      }

      db.InducedDataRecordingTasks.Remove(existingEntity);

      db.SaveChanges();
    }

    return true;
  }

  private bool PreValidateAccessControlScope(InducedDataRecordingTaskEntity entity, WorkflowDefinitionDbContext db){

    var filterExpression = EntityAccessControl.BuildExpressionForLocalEntity<InducedDataRecordingTaskEntity>(AccessControlContext.Current);
    if(!filterExpression.Compile().Invoke(entity)) {
      return false;
    }

    if(!db.DataRecordingTasks.Where((tgt)=> tgt.DataRecordingName==entity.InducedDataRecordingName ).AccessScopeFiltered().Any()) {
      return false;
    }
    if(!db.TaskSchedules.Where((tgt)=> tgt.TaskScheduleId==entity.TaskScheduleId ).AccessScopeFiltered().Any()) {
      return false;
    }
    return true;
  }

}

/// <summary> Provides CRUD access to stored DrugAppliymentTasks (based on schema version '1.3.0') </summary>
public partial class DrugApplymentTaskStore : IDrugApplymentTaskRepository {

  /// <summary> Loads a specific DrugApplymentTask addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="drugApplymentName"> Represents the primary identity of a DrugApplymentTask </param>
  public DrugApplymentTask GetDrugApplymentTaskByDrugApplymentName(String drugApplymentName){
    var mac = AccessControlContext.Current;

    DrugApplymentTask result;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      //select models, bacause we dont want to return types with navigation-properties!
      var query = db.DrugAppliymentTasks.AsNoTracking().AccessScopeFiltered().Select(DrugApplymentTaskEntity.DrugApplymentTaskSelector);

      query = query.Where((e)=>e.DrugApplymentName == drugApplymentName);

      //materialization / load
      result = query.SingleOrDefault();

    }

    return result;
  }

  /// <summary> Loads DrugAppliymentTasks. </summary>
  /// <param name="page">Number of the page, which should be returned </param>
  /// <param name="pageSize">Max count of DrugAppliymentTasks which should be returned </param>
  public DrugApplymentTask[] GetDrugAppliymentTasks(int page = 1, int pageSize = 20){
    return this.SearchDrugAppliymentTasks(null, null, page, pageSize); 
  }

  private static String[] _ExactMatchPropNames = new String[] {"DrugApplymentName", "StudyWorkflowName", "StudyWorkflowVersion"};
  private static String[] _FreetextPropNames = new String[] {"ShortDescription", "TaskSpecificDocumentationUrl", "DrugName", "ApplymentRoute", "ImportantNotices"};

  /// <summary> Loads DrugAppliymentTasks where values matching to the given filterExpression</summary>
  /// <param name="filterExpression">a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")'</param>
  /// <param name="sortingExpression">one or more property names which are used as sort order (before pagination)</param>
  /// <param name="page">Number of the page, which should be returned</param>
  /// <param name="pageSize">Max count of DrugAppliymentTasks which should be returned</param>
  public DrugApplymentTask[] SearchDrugAppliymentTasks(String filterExpression, String sortingExpression = null, int page = 1, int pageSize = 20){
    var mac = AccessControlContext.Current;

    DrugApplymentTask[] result;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      //select models, bacause we dont want to return types with navigation-properties!
      var query = db.DrugAppliymentTasks
        .AsNoTracking()
        .AccessScopeFiltered()
        .Select(DrugApplymentTaskEntity.DrugApplymentTaskSelector)
      ;
      
      //apply filter (if given)
      if(filterExpression != null) {
        //just if the filterExpression isnt already a valid expression, treat it as a freetext seach string and transform it to a valid expression
        filterExpression = DynamicLinqExtensions.FreetextSearchStringToFilterExpression(filterExpression, _ExactMatchPropNames, _FreetextPropNames);
      }
      if(filterExpression != null) {
        query = query.DynamicallyFiltered(filterExpression);
      }

      //apply sorting
      if(String.IsNullOrWhiteSpace(sortingExpression)) {
        query = query.DynamicallySorted("DrugApplymentName");
      }
      else{
        query = query.DynamicallySorted(sortingExpression + ", DrugApplymentName");
      }

      //apply pagination
      query = query.Skip(pageSize * (page - 1)).Take(pageSize);

      //materialization / load
      result = query.ToArray();

    }

    return result;
  }

  /// <summary> Adds a new DrugApplymentTask and returns success. </summary>
  /// <param name="drugApplymentTask"> DrugApplymentTask containing the new values </param>
  public bool AddNewDrugApplymentTask(DrugApplymentTask drugApplymentTask){
    var mac = AccessControlContext.Current;

    DrugApplymentTaskEntity newEntity = new DrugApplymentTaskEntity();
    newEntity.CopyContentFrom(drugApplymentTask);

    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      //checks, that the new values are within the access control scope
      if(!this.PreValidateAccessControlScope(newEntity, db)){
        return false;
      }

      if (db.DrugAppliymentTasks.Where((e)=>e.DrugApplymentName == newEntity.DrugApplymentName).Any()) {
        return false;
      }

      db.DrugAppliymentTasks.Add(newEntity);

      db.SaveChanges();
    }

    return true;
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given DrugApplymentTask addressed by the primary identifier fields within the given DrugApplymentTask. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="drugApplymentTask"> DrugApplymentTask containing the new values (the primary identifier fields within the given DrugApplymentTask will be used to address the target record) </param>
  public bool UpdateDrugApplymentTask(DrugApplymentTask drugApplymentTask){
    return this.UpdateDrugApplymentTaskByDrugApplymentName(drugApplymentTask.DrugApplymentName, drugApplymentTask);
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given DrugApplymentTask addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="drugApplymentName"> Represents the primary identity of a DrugApplymentTask </param>
  /// <param name="drugApplymentTask"> DrugApplymentTask containing the new values (the primary identifier fields within the given DrugApplymentTask will be ignored) </param>
  public bool UpdateDrugApplymentTaskByDrugApplymentName(String drugApplymentName, DrugApplymentTask drugApplymentTask){
    var mac = AccessControlContext.Current;

    DrugApplymentTaskEntity existingEntity;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      var query = db.DrugAppliymentTasks.AsNoTracking();

      query = query.Where((e)=>e.DrugApplymentName == drugApplymentName).AccessScopeFiltered();

      //materialization / load
      existingEntity = query.SingleOrDefault();

      if(existingEntity == null) {
        return false;
      }

      bool changeAttemptOnFixedField = false;
      existingEntity.CopyContentFrom(drugApplymentTask, (name) => changeAttemptOnFixedField = true);

      if (changeAttemptOnFixedField) {
        return false;
      }

      //checks, that the new values are within the access control scope
      if(!this.PreValidateAccessControlScope(existingEntity, db)){
        return false;
      }

      db.SaveChanges();
    }

    return true;
  }

  /// <summary> Deletes a specific DrugApplymentTask addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="drugApplymentName"> Represents the primary identity of a DrugApplymentTask </param>
  public bool DeleteDrugApplymentTaskByDrugApplymentName(String drugApplymentName){
    var mac = AccessControlContext.Current;

    DrugApplymentTaskEntity existingEntity;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      var query = db.DrugAppliymentTasks.AsNoTracking().AccessScopeFiltered();

      query = query.Where((e)=>e.DrugApplymentName == drugApplymentName);

      //materialization / load
      existingEntity = query.SingleOrDefault();

      if (existingEntity == null) {
        return false;
      }

      db.DrugAppliymentTasks.Remove(existingEntity);

      db.SaveChanges();
    }

    return true;
  }

  private bool PreValidateAccessControlScope(DrugApplymentTaskEntity entity, WorkflowDefinitionDbContext db){

    var filterExpression = EntityAccessControl.BuildExpressionForLocalEntity<DrugApplymentTaskEntity>(AccessControlContext.Current);
    if(!filterExpression.Compile().Invoke(entity)) {
      return false;
    }

    if(!db.ResearchStudies.Where((tgt)=> tgt.StudyWorkflowName==entity.StudyWorkflowName && tgt.StudyWorkflowVersion==entity.StudyWorkflowVersion ).AccessScopeFiltered().Any()) {
      return false;
    }
    return true;
  }

}

/// <summary> Provides CRUD access to stored InducedDrugApplymentTasks (based on schema version '1.3.0') </summary>
public partial class InducedDrugApplymentTaskStore : IInducedDrugApplymentTaskRepository {

  /// <summary> Loads a specific InducedDrugApplymentTask addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="id"> Represents the primary identity of a InducedDrugApplymentTask </param>
  public InducedDrugApplymentTask GetInducedDrugApplymentTaskById(Guid id){
    var mac = AccessControlContext.Current;

    InducedDrugApplymentTask result;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      //select models, bacause we dont want to return types with navigation-properties!
      var query = db.InducedDrugApplymentTasks.AsNoTracking().AccessScopeFiltered().Select(InducedDrugApplymentTaskEntity.InducedDrugApplymentTaskSelector);

      query = query.Where((e)=>e.Id == id);

      //materialization / load
      result = query.SingleOrDefault();

    }

    return result;
  }

  /// <summary> Loads InducedDrugApplymentTasks. </summary>
  /// <param name="page">Number of the page, which should be returned </param>
  /// <param name="pageSize">Max count of InducedDrugApplymentTasks which should be returned </param>
  public InducedDrugApplymentTask[] GetInducedDrugApplymentTasks(int page = 1, int pageSize = 20){
    return this.SearchInducedDrugApplymentTasks(null, null, page, pageSize); 
  }

  private static String[] _ExactMatchPropNames = new String[] {"InducedDrugApplymentName"};
  private static String[] _FreetextPropNames = new String[] {"OffsetUnit", "SchedulingVariabilityBefore", "SchedulingVariabilityAfter", "SchedulingVariabilityUnit", "InducedTaskExecutionTitle", "EventOnSkip", "EventOnLost"};

  /// <summary> Loads InducedDrugApplymentTasks where values matching to the given filterExpression</summary>
  /// <param name="filterExpression">a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")'</param>
  /// <param name="sortingExpression">one or more property names which are used as sort order (before pagination)</param>
  /// <param name="page">Number of the page, which should be returned</param>
  /// <param name="pageSize">Max count of InducedDrugApplymentTasks which should be returned</param>
  public InducedDrugApplymentTask[] SearchInducedDrugApplymentTasks(String filterExpression, String sortingExpression = null, int page = 1, int pageSize = 20){
    var mac = AccessControlContext.Current;

    InducedDrugApplymentTask[] result;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      //select models, bacause we dont want to return types with navigation-properties!
      var query = db.InducedDrugApplymentTasks
        .AsNoTracking()
        .AccessScopeFiltered()
        .Select(InducedDrugApplymentTaskEntity.InducedDrugApplymentTaskSelector)
      ;
      
      //apply filter (if given)
      if(filterExpression != null) {
        //just if the filterExpression isnt already a valid expression, treat it as a freetext seach string and transform it to a valid expression
        filterExpression = DynamicLinqExtensions.FreetextSearchStringToFilterExpression(filterExpression, _ExactMatchPropNames, _FreetextPropNames);
      }
      if(filterExpression != null) {
        query = query.DynamicallyFiltered(filterExpression);
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

  /// <summary> Adds a new InducedDrugApplymentTask and returns success. </summary>
  /// <param name="inducedDrugApplymentTask"> InducedDrugApplymentTask containing the new values </param>
  public bool AddNewInducedDrugApplymentTask(InducedDrugApplymentTask inducedDrugApplymentTask){
    var mac = AccessControlContext.Current;

    InducedDrugApplymentTaskEntity newEntity = new InducedDrugApplymentTaskEntity();
    newEntity.CopyContentFrom(inducedDrugApplymentTask);

    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      //checks, that the new values are within the access control scope
      if(!this.PreValidateAccessControlScope(newEntity, db)){
        return false;
      }

      if (db.InducedDrugApplymentTasks.Where((e)=>e.Id == newEntity.Id).Any()) {
        return false;
      }

      db.InducedDrugApplymentTasks.Add(newEntity);

      db.SaveChanges();
    }

    return true;
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given InducedDrugApplymentTask addressed by the primary identifier fields within the given InducedDrugApplymentTask. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="inducedDrugApplymentTask"> InducedDrugApplymentTask containing the new values (the primary identifier fields within the given InducedDrugApplymentTask will be used to address the target record) </param>
  public bool UpdateInducedDrugApplymentTask(InducedDrugApplymentTask inducedDrugApplymentTask){
    return this.UpdateInducedDrugApplymentTaskById(inducedDrugApplymentTask.Id, inducedDrugApplymentTask);
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given InducedDrugApplymentTask addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="id"> Represents the primary identity of a InducedDrugApplymentTask </param>
  /// <param name="inducedDrugApplymentTask"> InducedDrugApplymentTask containing the new values (the primary identifier fields within the given InducedDrugApplymentTask will be ignored) </param>
  public bool UpdateInducedDrugApplymentTaskById(Guid id, InducedDrugApplymentTask inducedDrugApplymentTask){
    var mac = AccessControlContext.Current;

    InducedDrugApplymentTaskEntity existingEntity;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      var query = db.InducedDrugApplymentTasks.AsNoTracking();

      query = query.Where((e)=>e.Id == id).AccessScopeFiltered();

      //materialization / load
      existingEntity = query.SingleOrDefault();

      if(existingEntity == null) {
        return false;
      }

      bool changeAttemptOnFixedField = false;
      existingEntity.CopyContentFrom(inducedDrugApplymentTask, (name) => changeAttemptOnFixedField = true);

      if (changeAttemptOnFixedField) {
        return false;
      }

      //checks, that the new values are within the access control scope
      if(!this.PreValidateAccessControlScope(existingEntity, db)){
        return false;
      }

      db.SaveChanges();
    }

    return true;
  }

  /// <summary> Deletes a specific InducedDrugApplymentTask addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="id"> Represents the primary identity of a InducedDrugApplymentTask </param>
  public bool DeleteInducedDrugApplymentTaskById(Guid id){
    var mac = AccessControlContext.Current;

    InducedDrugApplymentTaskEntity existingEntity;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      var query = db.InducedDrugApplymentTasks.AsNoTracking().AccessScopeFiltered();

      query = query.Where((e)=>e.Id == id);

      //materialization / load
      existingEntity = query.SingleOrDefault();

      if (existingEntity == null) {
        return false;
      }

      db.InducedDrugApplymentTasks.Remove(existingEntity);

      db.SaveChanges();
    }

    return true;
  }

  private bool PreValidateAccessControlScope(InducedDrugApplymentTaskEntity entity, WorkflowDefinitionDbContext db){

    var filterExpression = EntityAccessControl.BuildExpressionForLocalEntity<InducedDrugApplymentTaskEntity>(AccessControlContext.Current);
    if(!filterExpression.Compile().Invoke(entity)) {
      return false;
    }

    if(!db.DrugAppliymentTasks.Where((tgt)=> tgt.DrugApplymentName==entity.InducedDrugApplymentName ).AccessScopeFiltered().Any()) {
      return false;
    }
    if(!db.TaskSchedules.Where((tgt)=> tgt.TaskScheduleId==entity.TaskScheduleId ).AccessScopeFiltered().Any()) {
      return false;
    }
    return true;
  }

}

/// <summary> Provides CRUD access to stored TaskSchedules (based on schema version '1.3.0') </summary>
public partial class TaskScheduleStore : ITaskScheduleRepository {

  /// <summary> Loads a specific TaskSchedule addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="taskScheduleId"> Represents the primary identity of a TaskSchedule </param>
  public TaskSchedule GetTaskScheduleByTaskScheduleId(Guid taskScheduleId){
    var mac = AccessControlContext.Current;

    TaskSchedule result;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      //select models, bacause we dont want to return types with navigation-properties!
      var query = db.TaskSchedules.AsNoTracking().AccessScopeFiltered().Select(TaskScheduleEntity.TaskScheduleSelector);

      query = query.Where((e)=>e.TaskScheduleId == taskScheduleId);

      //materialization / load
      result = query.SingleOrDefault();

    }

    return result;
  }

  /// <summary> Loads TaskSchedules. </summary>
  /// <param name="page">Number of the page, which should be returned </param>
  /// <param name="pageSize">Max count of TaskSchedules which should be returned </param>
  public TaskSchedule[] GetTaskSchedules(int page = 1, int pageSize = 20){
    return this.SearchTaskSchedules(null, null, page, pageSize); 
  }

  private static String[] _ExactMatchPropNames = new String[] {"StudyWorkflowName", "StudyWorkflowVersion"};
  private static String[] _FreetextPropNames = new String[] {"Title", "MaxSkipsBeforeLost", "MaxSubsequentSkipsBeforeLost", "MaxLostsBeforeLtfuAbort", "MaxSubsequentLostsBeforeLtfuAbort", "EventOnLtfuAbort", "EventOnCycleEnded", "EventOnAllCyclesEnded", "InducingEvents", "AbortCausingEvents"};

  /// <summary> Loads TaskSchedules where values matching to the given filterExpression</summary>
  /// <param name="filterExpression">a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")'</param>
  /// <param name="sortingExpression">one or more property names which are used as sort order (before pagination)</param>
  /// <param name="page">Number of the page, which should be returned</param>
  /// <param name="pageSize">Max count of TaskSchedules which should be returned</param>
  public TaskSchedule[] SearchTaskSchedules(String filterExpression, String sortingExpression = null, int page = 1, int pageSize = 20){
    var mac = AccessControlContext.Current;

    TaskSchedule[] result;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      //select models, bacause we dont want to return types with navigation-properties!
      var query = db.TaskSchedules
        .AsNoTracking()
        .AccessScopeFiltered()
        .Select(TaskScheduleEntity.TaskScheduleSelector)
      ;
      
      //apply filter (if given)
      if(filterExpression != null) {
        //just if the filterExpression isnt already a valid expression, treat it as a freetext seach string and transform it to a valid expression
        filterExpression = DynamicLinqExtensions.FreetextSearchStringToFilterExpression(filterExpression, _ExactMatchPropNames, _FreetextPropNames);
      }
      if(filterExpression != null) {
        query = query.DynamicallyFiltered(filterExpression);
      }

      //apply sorting
      if(String.IsNullOrWhiteSpace(sortingExpression)) {
        query = query.DynamicallySorted("TaskScheduleId");
      }
      else{
        query = query.DynamicallySorted(sortingExpression + ", TaskScheduleId");
      }

      //apply pagination
      query = query.Skip(pageSize * (page - 1)).Take(pageSize);

      //materialization / load
      result = query.ToArray();

    }

    return result;
  }

  /// <summary> Adds a new TaskSchedule and returns success. </summary>
  /// <param name="taskSchedule"> TaskSchedule containing the new values </param>
  public bool AddNewTaskSchedule(TaskSchedule taskSchedule){
    var mac = AccessControlContext.Current;

    TaskScheduleEntity newEntity = new TaskScheduleEntity();
    newEntity.CopyContentFrom(taskSchedule);

    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      //checks, that the new values are within the access control scope
      if(!this.PreValidateAccessControlScope(newEntity, db)){
        return false;
      }

      if (db.TaskSchedules.Where((e)=>e.TaskScheduleId == newEntity.TaskScheduleId).Any()) {
        return false;
      }

      db.TaskSchedules.Add(newEntity);

      db.SaveChanges();
    }

    return true;
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given TaskSchedule addressed by the primary identifier fields within the given TaskSchedule. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="taskSchedule"> TaskSchedule containing the new values (the primary identifier fields within the given TaskSchedule will be used to address the target record) </param>
  public bool UpdateTaskSchedule(TaskSchedule taskSchedule){
    return this.UpdateTaskScheduleByTaskScheduleId(taskSchedule.TaskScheduleId, taskSchedule);
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given TaskSchedule addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="taskScheduleId"> Represents the primary identity of a TaskSchedule </param>
  /// <param name="taskSchedule"> TaskSchedule containing the new values (the primary identifier fields within the given TaskSchedule will be ignored) </param>
  public bool UpdateTaskScheduleByTaskScheduleId(Guid taskScheduleId, TaskSchedule taskSchedule){
    var mac = AccessControlContext.Current;

    TaskScheduleEntity existingEntity;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      var query = db.TaskSchedules.AsNoTracking();

      query = query.Where((e)=>e.TaskScheduleId == taskScheduleId).AccessScopeFiltered();

      //materialization / load
      existingEntity = query.SingleOrDefault();

      if(existingEntity == null) {
        return false;
      }

      bool changeAttemptOnFixedField = false;
      existingEntity.CopyContentFrom(taskSchedule, (name) => changeAttemptOnFixedField = true);

      if (changeAttemptOnFixedField) {
        return false;
      }

      //checks, that the new values are within the access control scope
      if(!this.PreValidateAccessControlScope(existingEntity, db)){
        return false;
      }

      db.SaveChanges();
    }

    return true;
  }

  /// <summary> Deletes a specific TaskSchedule addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="taskScheduleId"> Represents the primary identity of a TaskSchedule </param>
  public bool DeleteTaskScheduleByTaskScheduleId(Guid taskScheduleId){
    var mac = AccessControlContext.Current;

    TaskScheduleEntity existingEntity;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      var query = db.TaskSchedules.AsNoTracking().AccessScopeFiltered();

      query = query.Where((e)=>e.TaskScheduleId == taskScheduleId);

      //materialization / load
      existingEntity = query.SingleOrDefault();

      if (existingEntity == null) {
        return false;
      }

      db.TaskSchedules.Remove(existingEntity);

      db.SaveChanges();
    }

    return true;
  }

  private bool PreValidateAccessControlScope(TaskScheduleEntity entity, WorkflowDefinitionDbContext db){

    var filterExpression = EntityAccessControl.BuildExpressionForLocalEntity<TaskScheduleEntity>(AccessControlContext.Current);
    if(!filterExpression.Compile().Invoke(entity)) {
      return false;
    }

    if(!db.ResearchStudies.Where((tgt)=> tgt.StudyWorkflowName==entity.StudyWorkflowName && tgt.StudyWorkflowVersion==entity.StudyWorkflowVersion ).AccessScopeFiltered().Any()) {
      return false;
    }
    return true;
  }

}

/// <summary> Provides CRUD access to stored InducedSubProcedureSchedules (based on schema version '1.3.0') </summary>
public partial class InducedSubProcedureScheduleStore : IInducedSubProcedureScheduleRepository {

  /// <summary> Loads a specific InducedSubProcedureSchedule addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="id"> Represents the primary identity of a InducedSubProcedureSchedule </param>
  public InducedSubProcedureSchedule GetInducedSubProcedureScheduleById(Guid id){
    var mac = AccessControlContext.Current;

    InducedSubProcedureSchedule result;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      //select models, bacause we dont want to return types with navigation-properties!
      var query = db.InducedSubProcedureSchedules.AsNoTracking().AccessScopeFiltered().Select(InducedSubProcedureScheduleEntity.InducedSubProcedureScheduleSelector);

      query = query.Where((e)=>e.Id == id);

      //materialization / load
      result = query.SingleOrDefault();

    }

    return result;
  }

  /// <summary> Loads InducedSubProcedureSchedules. </summary>
  /// <param name="page">Number of the page, which should be returned </param>
  /// <param name="pageSize">Max count of InducedSubProcedureSchedules which should be returned </param>
  public InducedSubProcedureSchedule[] GetInducedSubProcedureSchedules(int page = 1, int pageSize = 20){
    return this.SearchInducedSubProcedureSchedules(null, null, page, pageSize); 
  }

  private static String[] _ExactMatchPropNames = new String[] {};
  private static String[] _FreetextPropNames = new String[] {"OffsetUnit", "SchedulingVariabilityBefore", "SchedulingVariabilityAfter", "SchedulingVariabilityUnit"};

  /// <summary> Loads InducedSubProcedureSchedules where values matching to the given filterExpression</summary>
  /// <param name="filterExpression">a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")'</param>
  /// <param name="sortingExpression">one or more property names which are used as sort order (before pagination)</param>
  /// <param name="page">Number of the page, which should be returned</param>
  /// <param name="pageSize">Max count of InducedSubProcedureSchedules which should be returned</param>
  public InducedSubProcedureSchedule[] SearchInducedSubProcedureSchedules(String filterExpression, String sortingExpression = null, int page = 1, int pageSize = 20){
    var mac = AccessControlContext.Current;

    InducedSubProcedureSchedule[] result;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      //select models, bacause we dont want to return types with navigation-properties!
      var query = db.InducedSubProcedureSchedules
        .AsNoTracking()
        .AccessScopeFiltered()
        .Select(InducedSubProcedureScheduleEntity.InducedSubProcedureScheduleSelector)
      ;
      
      //apply filter (if given)
      if(filterExpression != null) {
        //just if the filterExpression isnt already a valid expression, treat it as a freetext seach string and transform it to a valid expression
        filterExpression = DynamicLinqExtensions.FreetextSearchStringToFilterExpression(filterExpression, _ExactMatchPropNames, _FreetextPropNames);
      }
      if(filterExpression != null) {
        query = query.DynamicallyFiltered(filterExpression);
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

  /// <summary> Adds a new InducedSubProcedureSchedule and returns success. </summary>
  /// <param name="inducedSubProcedureSchedule"> InducedSubProcedureSchedule containing the new values </param>
  public bool AddNewInducedSubProcedureSchedule(InducedSubProcedureSchedule inducedSubProcedureSchedule){
    var mac = AccessControlContext.Current;

    InducedSubProcedureScheduleEntity newEntity = new InducedSubProcedureScheduleEntity();
    newEntity.CopyContentFrom(inducedSubProcedureSchedule);

    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      //checks, that the new values are within the access control scope
      if(!this.PreValidateAccessControlScope(newEntity, db)){
        return false;
      }

      if (db.InducedSubProcedureSchedules.Where((e)=>e.Id == newEntity.Id).Any()) {
        return false;
      }

      db.InducedSubProcedureSchedules.Add(newEntity);

      db.SaveChanges();
    }

    return true;
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given InducedSubProcedureSchedule addressed by the primary identifier fields within the given InducedSubProcedureSchedule. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="inducedSubProcedureSchedule"> InducedSubProcedureSchedule containing the new values (the primary identifier fields within the given InducedSubProcedureSchedule will be used to address the target record) </param>
  public bool UpdateInducedSubProcedureSchedule(InducedSubProcedureSchedule inducedSubProcedureSchedule){
    return this.UpdateInducedSubProcedureScheduleById(inducedSubProcedureSchedule.Id, inducedSubProcedureSchedule);
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given InducedSubProcedureSchedule addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="id"> Represents the primary identity of a InducedSubProcedureSchedule </param>
  /// <param name="inducedSubProcedureSchedule"> InducedSubProcedureSchedule containing the new values (the primary identifier fields within the given InducedSubProcedureSchedule will be ignored) </param>
  public bool UpdateInducedSubProcedureScheduleById(Guid id, InducedSubProcedureSchedule inducedSubProcedureSchedule){
    var mac = AccessControlContext.Current;

    InducedSubProcedureScheduleEntity existingEntity;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      var query = db.InducedSubProcedureSchedules.AsNoTracking();

      query = query.Where((e)=>e.Id == id).AccessScopeFiltered();

      //materialization / load
      existingEntity = query.SingleOrDefault();

      if(existingEntity == null) {
        return false;
      }

      bool changeAttemptOnFixedField = false;
      existingEntity.CopyContentFrom(inducedSubProcedureSchedule, (name) => changeAttemptOnFixedField = true);

      if (changeAttemptOnFixedField) {
        return false;
      }

      //checks, that the new values are within the access control scope
      if(!this.PreValidateAccessControlScope(existingEntity, db)){
        return false;
      }

      db.SaveChanges();
    }

    return true;
  }

  /// <summary> Deletes a specific InducedSubProcedureSchedule addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="id"> Represents the primary identity of a InducedSubProcedureSchedule </param>
  public bool DeleteInducedSubProcedureScheduleById(Guid id){
    var mac = AccessControlContext.Current;

    InducedSubProcedureScheduleEntity existingEntity;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      var query = db.InducedSubProcedureSchedules.AsNoTracking().AccessScopeFiltered();

      query = query.Where((e)=>e.Id == id);

      //materialization / load
      existingEntity = query.SingleOrDefault();

      if (existingEntity == null) {
        return false;
      }

      db.InducedSubProcedureSchedules.Remove(existingEntity);

      db.SaveChanges();
    }

    return true;
  }

  private bool PreValidateAccessControlScope(InducedSubProcedureScheduleEntity entity, WorkflowDefinitionDbContext db){

    var filterExpression = EntityAccessControl.BuildExpressionForLocalEntity<InducedSubProcedureScheduleEntity>(AccessControlContext.Current);
    if(!filterExpression.Compile().Invoke(entity)) {
      return false;
    }

    if(!db.ProcedureSchedules.Where((tgt)=> tgt.ProcedureScheduleId==entity.ParentProcedureScheduleId ).AccessScopeFiltered().Any()) {
      return false;
    }
    if(!db.ProcedureSchedules.Where((tgt)=> tgt.ProcedureScheduleId==entity.InducedProcedureScheduleId ).AccessScopeFiltered().Any()) {
      return false;
    }
    return true;
  }

}

/// <summary> Provides CRUD access to stored InducedSubTaskSchedules (based on schema version '1.3.0') </summary>
public partial class InducedSubTaskScheduleStore : IInducedSubTaskScheduleRepository {

  /// <summary> Loads a specific InducedSubTaskSchedule addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="id"> Represents the primary identity of a InducedSubTaskSchedule </param>
  public InducedSubTaskSchedule GetInducedSubTaskScheduleById(Guid id){
    var mac = AccessControlContext.Current;

    InducedSubTaskSchedule result;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      //select models, bacause we dont want to return types with navigation-properties!
      var query = db.InducedSubTaskSchedules.AsNoTracking().AccessScopeFiltered().Select(InducedSubTaskScheduleEntity.InducedSubTaskScheduleSelector);

      query = query.Where((e)=>e.Id == id);

      //materialization / load
      result = query.SingleOrDefault();

    }

    return result;
  }

  /// <summary> Loads InducedSubTaskSchedules. </summary>
  /// <param name="page">Number of the page, which should be returned </param>
  /// <param name="pageSize">Max count of InducedSubTaskSchedules which should be returned </param>
  public InducedSubTaskSchedule[] GetInducedSubTaskSchedules(int page = 1, int pageSize = 20){
    return this.SearchInducedSubTaskSchedules(null, null, page, pageSize); 
  }

  private static String[] _ExactMatchPropNames = new String[] {};
  private static String[] _FreetextPropNames = new String[] {"OffsetUnit", "SchedulingVariabilityBefore", "SchedulingVariabilityAfter", "SchedulingVariabilityUnit"};

  /// <summary> Loads InducedSubTaskSchedules where values matching to the given filterExpression</summary>
  /// <param name="filterExpression">a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")'</param>
  /// <param name="sortingExpression">one or more property names which are used as sort order (before pagination)</param>
  /// <param name="page">Number of the page, which should be returned</param>
  /// <param name="pageSize">Max count of InducedSubTaskSchedules which should be returned</param>
  public InducedSubTaskSchedule[] SearchInducedSubTaskSchedules(String filterExpression, String sortingExpression = null, int page = 1, int pageSize = 20){
    var mac = AccessControlContext.Current;

    InducedSubTaskSchedule[] result;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      //select models, bacause we dont want to return types with navigation-properties!
      var query = db.InducedSubTaskSchedules
        .AsNoTracking()
        .AccessScopeFiltered()
        .Select(InducedSubTaskScheduleEntity.InducedSubTaskScheduleSelector)
      ;
      
      //apply filter (if given)
      if(filterExpression != null) {
        //just if the filterExpression isnt already a valid expression, treat it as a freetext seach string and transform it to a valid expression
        filterExpression = DynamicLinqExtensions.FreetextSearchStringToFilterExpression(filterExpression, _ExactMatchPropNames, _FreetextPropNames);
      }
      if(filterExpression != null) {
        query = query.DynamicallyFiltered(filterExpression);
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

  /// <summary> Adds a new InducedSubTaskSchedule and returns success. </summary>
  /// <param name="inducedSubTaskSchedule"> InducedSubTaskSchedule containing the new values </param>
  public bool AddNewInducedSubTaskSchedule(InducedSubTaskSchedule inducedSubTaskSchedule){
    var mac = AccessControlContext.Current;

    InducedSubTaskScheduleEntity newEntity = new InducedSubTaskScheduleEntity();
    newEntity.CopyContentFrom(inducedSubTaskSchedule);

    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      //checks, that the new values are within the access control scope
      if(!this.PreValidateAccessControlScope(newEntity, db)){
        return false;
      }

      if (db.InducedSubTaskSchedules.Where((e)=>e.Id == newEntity.Id).Any()) {
        return false;
      }

      db.InducedSubTaskSchedules.Add(newEntity);

      db.SaveChanges();
    }

    return true;
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given InducedSubTaskSchedule addressed by the primary identifier fields within the given InducedSubTaskSchedule. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="inducedSubTaskSchedule"> InducedSubTaskSchedule containing the new values (the primary identifier fields within the given InducedSubTaskSchedule will be used to address the target record) </param>
  public bool UpdateInducedSubTaskSchedule(InducedSubTaskSchedule inducedSubTaskSchedule){
    return this.UpdateInducedSubTaskScheduleById(inducedSubTaskSchedule.Id, inducedSubTaskSchedule);
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given InducedSubTaskSchedule addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="id"> Represents the primary identity of a InducedSubTaskSchedule </param>
  /// <param name="inducedSubTaskSchedule"> InducedSubTaskSchedule containing the new values (the primary identifier fields within the given InducedSubTaskSchedule will be ignored) </param>
  public bool UpdateInducedSubTaskScheduleById(Guid id, InducedSubTaskSchedule inducedSubTaskSchedule){
    var mac = AccessControlContext.Current;

    InducedSubTaskScheduleEntity existingEntity;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      var query = db.InducedSubTaskSchedules.AsNoTracking();

      query = query.Where((e)=>e.Id == id).AccessScopeFiltered();

      //materialization / load
      existingEntity = query.SingleOrDefault();

      if(existingEntity == null) {
        return false;
      }

      bool changeAttemptOnFixedField = false;
      existingEntity.CopyContentFrom(inducedSubTaskSchedule, (name) => changeAttemptOnFixedField = true);

      if (changeAttemptOnFixedField) {
        return false;
      }

      //checks, that the new values are within the access control scope
      if(!this.PreValidateAccessControlScope(existingEntity, db)){
        return false;
      }

      db.SaveChanges();
    }

    return true;
  }

  /// <summary> Deletes a specific InducedSubTaskSchedule addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="id"> Represents the primary identity of a InducedSubTaskSchedule </param>
  public bool DeleteInducedSubTaskScheduleById(Guid id){
    var mac = AccessControlContext.Current;

    InducedSubTaskScheduleEntity existingEntity;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      var query = db.InducedSubTaskSchedules.AsNoTracking().AccessScopeFiltered();

      query = query.Where((e)=>e.Id == id);

      //materialization / load
      existingEntity = query.SingleOrDefault();

      if (existingEntity == null) {
        return false;
      }

      db.InducedSubTaskSchedules.Remove(existingEntity);

      db.SaveChanges();
    }

    return true;
  }

  private bool PreValidateAccessControlScope(InducedSubTaskScheduleEntity entity, WorkflowDefinitionDbContext db){

    var filterExpression = EntityAccessControl.BuildExpressionForLocalEntity<InducedSubTaskScheduleEntity>(AccessControlContext.Current);
    if(!filterExpression.Compile().Invoke(entity)) {
      return false;
    }

    if(!db.TaskSchedules.Where((tgt)=> tgt.TaskScheduleId==entity.ParentTaskScheduleId ).AccessScopeFiltered().Any()) {
      return false;
    }
    if(!db.TaskSchedules.Where((tgt)=> tgt.TaskScheduleId==entity.InducedTaskScheduleId ).AccessScopeFiltered().Any()) {
      return false;
    }
    return true;
  }

}

/// <summary> Provides CRUD access to stored InducedTreatmentTasks (based on schema version '1.3.0') </summary>
public partial class InducedTreatmentTaskStore : IInducedTreatmentTaskRepository {

  /// <summary> Loads a specific InducedTreatmentTask addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="id"> Represents the primary identity of a InducedTreatmentTask </param>
  public InducedTreatmentTask GetInducedTreatmentTaskById(Guid id){
    var mac = AccessControlContext.Current;

    InducedTreatmentTask result;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      //select models, bacause we dont want to return types with navigation-properties!
      var query = db.InducedTreatmentTasks.AsNoTracking().AccessScopeFiltered().Select(InducedTreatmentTaskEntity.InducedTreatmentTaskSelector);

      query = query.Where((e)=>e.Id == id);

      //materialization / load
      result = query.SingleOrDefault();

    }

    return result;
  }

  /// <summary> Loads InducedTreatmentTasks. </summary>
  /// <param name="page">Number of the page, which should be returned </param>
  /// <param name="pageSize">Max count of InducedTreatmentTasks which should be returned </param>
  public InducedTreatmentTask[] GetInducedTreatmentTasks(int page = 1, int pageSize = 20){
    return this.SearchInducedTreatmentTasks(null, null, page, pageSize); 
  }

  private static String[] _ExactMatchPropNames = new String[] {"InducedTreatmentName"};
  private static String[] _FreetextPropNames = new String[] {"OffsetUnit", "SchedulingVariabilityBefore", "SchedulingVariabilityAfter", "SchedulingVariabilityUnit", "InducedTaskExecutionTitle", "EventOnSkip", "EventOnLost"};

  /// <summary> Loads InducedTreatmentTasks where values matching to the given filterExpression</summary>
  /// <param name="filterExpression">a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")'</param>
  /// <param name="sortingExpression">one or more property names which are used as sort order (before pagination)</param>
  /// <param name="page">Number of the page, which should be returned</param>
  /// <param name="pageSize">Max count of InducedTreatmentTasks which should be returned</param>
  public InducedTreatmentTask[] SearchInducedTreatmentTasks(String filterExpression, String sortingExpression = null, int page = 1, int pageSize = 20){
    var mac = AccessControlContext.Current;

    InducedTreatmentTask[] result;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      //select models, bacause we dont want to return types with navigation-properties!
      var query = db.InducedTreatmentTasks
        .AsNoTracking()
        .AccessScopeFiltered()
        .Select(InducedTreatmentTaskEntity.InducedTreatmentTaskSelector)
      ;
      
      //apply filter (if given)
      if(filterExpression != null) {
        //just if the filterExpression isnt already a valid expression, treat it as a freetext seach string and transform it to a valid expression
        filterExpression = DynamicLinqExtensions.FreetextSearchStringToFilterExpression(filterExpression, _ExactMatchPropNames, _FreetextPropNames);
      }
      if(filterExpression != null) {
        query = query.DynamicallyFiltered(filterExpression);
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

  /// <summary> Adds a new InducedTreatmentTask and returns success. </summary>
  /// <param name="inducedTreatmentTask"> InducedTreatmentTask containing the new values </param>
  public bool AddNewInducedTreatmentTask(InducedTreatmentTask inducedTreatmentTask){
    var mac = AccessControlContext.Current;

    InducedTreatmentTaskEntity newEntity = new InducedTreatmentTaskEntity();
    newEntity.CopyContentFrom(inducedTreatmentTask);

    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      //checks, that the new values are within the access control scope
      if(!this.PreValidateAccessControlScope(newEntity, db)){
        return false;
      }

      if (db.InducedTreatmentTasks.Where((e)=>e.Id == newEntity.Id).Any()) {
        return false;
      }

      db.InducedTreatmentTasks.Add(newEntity);

      db.SaveChanges();
    }

    return true;
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given InducedTreatmentTask addressed by the primary identifier fields within the given InducedTreatmentTask. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="inducedTreatmentTask"> InducedTreatmentTask containing the new values (the primary identifier fields within the given InducedTreatmentTask will be used to address the target record) </param>
  public bool UpdateInducedTreatmentTask(InducedTreatmentTask inducedTreatmentTask){
    return this.UpdateInducedTreatmentTaskById(inducedTreatmentTask.Id, inducedTreatmentTask);
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given InducedTreatmentTask addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="id"> Represents the primary identity of a InducedTreatmentTask </param>
  /// <param name="inducedTreatmentTask"> InducedTreatmentTask containing the new values (the primary identifier fields within the given InducedTreatmentTask will be ignored) </param>
  public bool UpdateInducedTreatmentTaskById(Guid id, InducedTreatmentTask inducedTreatmentTask){
    var mac = AccessControlContext.Current;

    InducedTreatmentTaskEntity existingEntity;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      var query = db.InducedTreatmentTasks.AsNoTracking();

      query = query.Where((e)=>e.Id == id).AccessScopeFiltered();

      //materialization / load
      existingEntity = query.SingleOrDefault();

      if(existingEntity == null) {
        return false;
      }

      bool changeAttemptOnFixedField = false;
      existingEntity.CopyContentFrom(inducedTreatmentTask, (name) => changeAttemptOnFixedField = true);

      if (changeAttemptOnFixedField) {
        return false;
      }

      //checks, that the new values are within the access control scope
      if(!this.PreValidateAccessControlScope(existingEntity, db)){
        return false;
      }

      db.SaveChanges();
    }

    return true;
  }

  /// <summary> Deletes a specific InducedTreatmentTask addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="id"> Represents the primary identity of a InducedTreatmentTask </param>
  public bool DeleteInducedTreatmentTaskById(Guid id){
    var mac = AccessControlContext.Current;

    InducedTreatmentTaskEntity existingEntity;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      var query = db.InducedTreatmentTasks.AsNoTracking().AccessScopeFiltered();

      query = query.Where((e)=>e.Id == id);

      //materialization / load
      existingEntity = query.SingleOrDefault();

      if (existingEntity == null) {
        return false;
      }

      db.InducedTreatmentTasks.Remove(existingEntity);

      db.SaveChanges();
    }

    return true;
  }

  private bool PreValidateAccessControlScope(InducedTreatmentTaskEntity entity, WorkflowDefinitionDbContext db){

    var filterExpression = EntityAccessControl.BuildExpressionForLocalEntity<InducedTreatmentTaskEntity>(AccessControlContext.Current);
    if(!filterExpression.Compile().Invoke(entity)) {
      return false;
    }

    if(!db.TaskSchedules.Where((tgt)=> tgt.TaskScheduleId==entity.TaskScheduleId ).AccessScopeFiltered().Any()) {
      return false;
    }
    if(!db.TreatmentTasks.Where((tgt)=> tgt.TreatmentName==entity.InducedTreatmentName ).AccessScopeFiltered().Any()) {
      return false;
    }
    return true;
  }

}

/// <summary> Provides CRUD access to stored TreatmentTasks (based on schema version '1.3.0') </summary>
public partial class TreatmentTaskStore : ITreatmentTaskRepository {

  /// <summary> Loads a specific TreatmentTask addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="treatmentName"> Represents the primary identity of a TreatmentTask </param>
  public TreatmentTask GetTreatmentTaskByTreatmentName(String treatmentName){
    var mac = AccessControlContext.Current;

    TreatmentTask result;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      //select models, bacause we dont want to return types with navigation-properties!
      var query = db.TreatmentTasks.AsNoTracking().AccessScopeFiltered().Select(TreatmentTaskEntity.TreatmentTaskSelector);

      query = query.Where((e)=>e.TreatmentName == treatmentName);

      //materialization / load
      result = query.SingleOrDefault();

    }

    return result;
  }

  /// <summary> Loads TreatmentTasks. </summary>
  /// <param name="page">Number of the page, which should be returned </param>
  /// <param name="pageSize">Max count of TreatmentTasks which should be returned </param>
  public TreatmentTask[] GetTreatmentTasks(int page = 1, int pageSize = 20){
    return this.SearchTreatmentTasks(null, null, page, pageSize); 
  }

  private static String[] _ExactMatchPropNames = new String[] {"StudyWorkflowName", "StudyWorkflowVersion", "TreatmentName"};
  private static String[] _FreetextPropNames = new String[] {"ShortDescription", "TaskSpecificDocumentationUrl", "TreatmentDescription", "ImportantNotices"};

  /// <summary> Loads TreatmentTasks where values matching to the given filterExpression</summary>
  /// <param name="filterExpression">a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")'</param>
  /// <param name="sortingExpression">one or more property names which are used as sort order (before pagination)</param>
  /// <param name="page">Number of the page, which should be returned</param>
  /// <param name="pageSize">Max count of TreatmentTasks which should be returned</param>
  public TreatmentTask[] SearchTreatmentTasks(String filterExpression, String sortingExpression = null, int page = 1, int pageSize = 20){
    var mac = AccessControlContext.Current;

    TreatmentTask[] result;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      //select models, bacause we dont want to return types with navigation-properties!
      var query = db.TreatmentTasks
        .AsNoTracking()
        .AccessScopeFiltered()
        .Select(TreatmentTaskEntity.TreatmentTaskSelector)
      ;
      
      //apply filter (if given)
      if(filterExpression != null) {
        //just if the filterExpression isnt already a valid expression, treat it as a freetext seach string and transform it to a valid expression
        filterExpression = DynamicLinqExtensions.FreetextSearchStringToFilterExpression(filterExpression, _ExactMatchPropNames, _FreetextPropNames);
      }
      if(filterExpression != null) {
        query = query.DynamicallyFiltered(filterExpression);
      }

      //apply sorting
      if(String.IsNullOrWhiteSpace(sortingExpression)) {
        query = query.DynamicallySorted("TreatmentName");
      }
      else{
        query = query.DynamicallySorted(sortingExpression + ", TreatmentName");
      }

      //apply pagination
      query = query.Skip(pageSize * (page - 1)).Take(pageSize);

      //materialization / load
      result = query.ToArray();

    }

    return result;
  }

  /// <summary> Adds a new TreatmentTask and returns success. </summary>
  /// <param name="treatmentTask"> TreatmentTask containing the new values </param>
  public bool AddNewTreatmentTask(TreatmentTask treatmentTask){
    var mac = AccessControlContext.Current;

    TreatmentTaskEntity newEntity = new TreatmentTaskEntity();
    newEntity.CopyContentFrom(treatmentTask);

    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      //checks, that the new values are within the access control scope
      if(!this.PreValidateAccessControlScope(newEntity, db)){
        return false;
      }

      if (db.TreatmentTasks.Where((e)=>e.TreatmentName == newEntity.TreatmentName).Any()) {
        return false;
      }

      db.TreatmentTasks.Add(newEntity);

      db.SaveChanges();
    }

    return true;
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given TreatmentTask addressed by the primary identifier fields within the given TreatmentTask. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="treatmentTask"> TreatmentTask containing the new values (the primary identifier fields within the given TreatmentTask will be used to address the target record) </param>
  public bool UpdateTreatmentTask(TreatmentTask treatmentTask){
    return this.UpdateTreatmentTaskByTreatmentName(treatmentTask.TreatmentName, treatmentTask);
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given TreatmentTask addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="treatmentName"> Represents the primary identity of a TreatmentTask </param>
  /// <param name="treatmentTask"> TreatmentTask containing the new values (the primary identifier fields within the given TreatmentTask will be ignored) </param>
  public bool UpdateTreatmentTaskByTreatmentName(String treatmentName, TreatmentTask treatmentTask){
    var mac = AccessControlContext.Current;

    TreatmentTaskEntity existingEntity;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      var query = db.TreatmentTasks.AsNoTracking();

      query = query.Where((e)=>e.TreatmentName == treatmentName).AccessScopeFiltered();

      //materialization / load
      existingEntity = query.SingleOrDefault();

      if(existingEntity == null) {
        return false;
      }

      bool changeAttemptOnFixedField = false;
      existingEntity.CopyContentFrom(treatmentTask, (name) => changeAttemptOnFixedField = true);

      if (changeAttemptOnFixedField) {
        return false;
      }

      //checks, that the new values are within the access control scope
      if(!this.PreValidateAccessControlScope(existingEntity, db)){
        return false;
      }

      db.SaveChanges();
    }

    return true;
  }

  /// <summary> Deletes a specific TreatmentTask addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="treatmentName"> Represents the primary identity of a TreatmentTask </param>
  public bool DeleteTreatmentTaskByTreatmentName(String treatmentName){
    var mac = AccessControlContext.Current;

    TreatmentTaskEntity existingEntity;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      var query = db.TreatmentTasks.AsNoTracking().AccessScopeFiltered();

      query = query.Where((e)=>e.TreatmentName == treatmentName);

      //materialization / load
      existingEntity = query.SingleOrDefault();

      if (existingEntity == null) {
        return false;
      }

      db.TreatmentTasks.Remove(existingEntity);

      db.SaveChanges();
    }

    return true;
  }

  private bool PreValidateAccessControlScope(TreatmentTaskEntity entity, WorkflowDefinitionDbContext db){

    var filterExpression = EntityAccessControl.BuildExpressionForLocalEntity<TreatmentTaskEntity>(AccessControlContext.Current);
    if(!filterExpression.Compile().Invoke(entity)) {
      return false;
    }

    if(!db.ResearchStudies.Where((tgt)=> tgt.StudyWorkflowName==entity.StudyWorkflowName && tgt.StudyWorkflowVersion==entity.StudyWorkflowVersion ).AccessScopeFiltered().Any()) {
      return false;
    }
    return true;
  }

}

/// <summary> Provides CRUD access to stored InducedVisitProcedures (based on schema version '1.3.0') </summary>
public partial class InducedVisitProcedureStore : IInducedVisitProcedureRepository {

  /// <summary> Loads a specific InducedVisitProcedure addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="id"> Represents the primary identity of a InducedVisitProcedure </param>
  public InducedVisitProcedure GetInducedVisitProcedureById(Guid id){
    var mac = AccessControlContext.Current;

    InducedVisitProcedure result;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      //select models, bacause we dont want to return types with navigation-properties!
      var query = db.InducedVisitProcedures.AsNoTracking().AccessScopeFiltered().Select(InducedVisitProcedureEntity.InducedVisitProcedureSelector);

      query = query.Where((e)=>e.Id == id);

      //materialization / load
      result = query.SingleOrDefault();

    }

    return result;
  }

  /// <summary> Loads InducedVisitProcedures. </summary>
  /// <param name="page">Number of the page, which should be returned </param>
  /// <param name="pageSize">Max count of InducedVisitProcedures which should be returned </param>
  public InducedVisitProcedure[] GetInducedVisitProcedures(int page = 1, int pageSize = 20){
    return this.SearchInducedVisitProcedures(null, null, page, pageSize); 
  }

  private static String[] _ExactMatchPropNames = new String[] {"InducedVisitProdecureName"};
  private static String[] _FreetextPropNames = new String[] {"OffsetUnit", "SchedulingVariabilityBefore", "SchedulingVariabilityAfter", "SchedulingVariabilityUnit", "InducedVisitExecutionTitle", "EventOnSkip", "EventOnLost"};

  /// <summary> Loads InducedVisitProcedures where values matching to the given filterExpression</summary>
  /// <param name="filterExpression">a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")'</param>
  /// <param name="sortingExpression">one or more property names which are used as sort order (before pagination)</param>
  /// <param name="page">Number of the page, which should be returned</param>
  /// <param name="pageSize">Max count of InducedVisitProcedures which should be returned</param>
  public InducedVisitProcedure[] SearchInducedVisitProcedures(String filterExpression, String sortingExpression = null, int page = 1, int pageSize = 20){
    var mac = AccessControlContext.Current;

    InducedVisitProcedure[] result;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      //select models, bacause we dont want to return types with navigation-properties!
      var query = db.InducedVisitProcedures
        .AsNoTracking()
        .AccessScopeFiltered()
        .Select(InducedVisitProcedureEntity.InducedVisitProcedureSelector)
      ;
      
      //apply filter (if given)
      if(filterExpression != null) {
        //just if the filterExpression isnt already a valid expression, treat it as a freetext seach string and transform it to a valid expression
        filterExpression = DynamicLinqExtensions.FreetextSearchStringToFilterExpression(filterExpression, _ExactMatchPropNames, _FreetextPropNames);
      }
      if(filterExpression != null) {
        query = query.DynamicallyFiltered(filterExpression);
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

  /// <summary> Adds a new InducedVisitProcedure and returns success. </summary>
  /// <param name="inducedVisitProcedure"> InducedVisitProcedure containing the new values </param>
  public bool AddNewInducedVisitProcedure(InducedVisitProcedure inducedVisitProcedure){
    var mac = AccessControlContext.Current;

    InducedVisitProcedureEntity newEntity = new InducedVisitProcedureEntity();
    newEntity.CopyContentFrom(inducedVisitProcedure);

    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      //checks, that the new values are within the access control scope
      if(!this.PreValidateAccessControlScope(newEntity, db)){
        return false;
      }

      if (db.InducedVisitProcedures.Where((e)=>e.Id == newEntity.Id).Any()) {
        return false;
      }

      db.InducedVisitProcedures.Add(newEntity);

      db.SaveChanges();
    }

    return true;
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given InducedVisitProcedure addressed by the primary identifier fields within the given InducedVisitProcedure. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="inducedVisitProcedure"> InducedVisitProcedure containing the new values (the primary identifier fields within the given InducedVisitProcedure will be used to address the target record) </param>
  public bool UpdateInducedVisitProcedure(InducedVisitProcedure inducedVisitProcedure){
    return this.UpdateInducedVisitProcedureById(inducedVisitProcedure.Id, inducedVisitProcedure);
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given InducedVisitProcedure addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="id"> Represents the primary identity of a InducedVisitProcedure </param>
  /// <param name="inducedVisitProcedure"> InducedVisitProcedure containing the new values (the primary identifier fields within the given InducedVisitProcedure will be ignored) </param>
  public bool UpdateInducedVisitProcedureById(Guid id, InducedVisitProcedure inducedVisitProcedure){
    var mac = AccessControlContext.Current;

    InducedVisitProcedureEntity existingEntity;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      var query = db.InducedVisitProcedures.AsNoTracking();

      query = query.Where((e)=>e.Id == id).AccessScopeFiltered();

      //materialization / load
      existingEntity = query.SingleOrDefault();

      if(existingEntity == null) {
        return false;
      }

      bool changeAttemptOnFixedField = false;
      existingEntity.CopyContentFrom(inducedVisitProcedure, (name) => changeAttemptOnFixedField = true);

      if (changeAttemptOnFixedField) {
        return false;
      }

      //checks, that the new values are within the access control scope
      if(!this.PreValidateAccessControlScope(existingEntity, db)){
        return false;
      }

      db.SaveChanges();
    }

    return true;
  }

  /// <summary> Deletes a specific InducedVisitProcedure addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="id"> Represents the primary identity of a InducedVisitProcedure </param>
  public bool DeleteInducedVisitProcedureById(Guid id){
    var mac = AccessControlContext.Current;

    InducedVisitProcedureEntity existingEntity;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      var query = db.InducedVisitProcedures.AsNoTracking().AccessScopeFiltered();

      query = query.Where((e)=>e.Id == id);

      //materialization / load
      existingEntity = query.SingleOrDefault();

      if (existingEntity == null) {
        return false;
      }

      db.InducedVisitProcedures.Remove(existingEntity);

      db.SaveChanges();
    }

    return true;
  }

  private bool PreValidateAccessControlScope(InducedVisitProcedureEntity entity, WorkflowDefinitionDbContext db){

    var filterExpression = EntityAccessControl.BuildExpressionForLocalEntity<InducedVisitProcedureEntity>(AccessControlContext.Current);
    if(!filterExpression.Compile().Invoke(entity)) {
      return false;
    }

    if(!db.ProcedureSchedules.Where((tgt)=> tgt.ProcedureScheduleId==entity.ProcedureScheduleId ).AccessScopeFiltered().Any()) {
      return false;
    }
    if(!db.VisitProdecureDefinitions.Where((tgt)=> tgt.VisitProdecureName==entity.InducedVisitProdecureName ).AccessScopeFiltered().Any()) {
      return false;
    }
    return true;
  }

}

/// <summary> Provides CRUD access to stored VisitProdecureDefinitions (based on schema version '1.3.0') </summary>
public partial class VisitProdecureDefinitionStore : IVisitProdecureDefinitionRepository {

  /// <summary> Loads a specific VisitProdecureDefinition addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="visitProdecureName"> Represents the primary identity of a VisitProdecureDefinition </param>
  public VisitProdecureDefinition GetVisitProdecureDefinitionByVisitProdecureName(String visitProdecureName){
    var mac = AccessControlContext.Current;

    VisitProdecureDefinition result;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      //select models, bacause we dont want to return types with navigation-properties!
      var query = db.VisitProdecureDefinitions.AsNoTracking().AccessScopeFiltered().Select(VisitProdecureDefinitionEntity.VisitProdecureDefinitionSelector);

      query = query.Where((e)=>e.VisitProdecureName == visitProdecureName);

      //materialization / load
      result = query.SingleOrDefault();

    }

    return result;
  }

  /// <summary> Loads VisitProdecureDefinitions. </summary>
  /// <param name="page">Number of the page, which should be returned </param>
  /// <param name="pageSize">Max count of VisitProdecureDefinitions which should be returned </param>
  public VisitProdecureDefinition[] GetVisitProdecureDefinitions(int page = 1, int pageSize = 20){
    return this.SearchVisitProdecureDefinitions(null, null, page, pageSize); 
  }

  private static String[] _ExactMatchPropNames = new String[] {"StudyWorkflowName", "StudyWorkflowVersion", "VisitProdecureName"};
  private static String[] _FreetextPropNames = new String[] {"VisitSpecificDocumentationUrl"};

  /// <summary> Loads VisitProdecureDefinitions where values matching to the given filterExpression</summary>
  /// <param name="filterExpression">a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")'</param>
  /// <param name="sortingExpression">one or more property names which are used as sort order (before pagination)</param>
  /// <param name="page">Number of the page, which should be returned</param>
  /// <param name="pageSize">Max count of VisitProdecureDefinitions which should be returned</param>
  public VisitProdecureDefinition[] SearchVisitProdecureDefinitions(String filterExpression, String sortingExpression = null, int page = 1, int pageSize = 20){
    var mac = AccessControlContext.Current;

    VisitProdecureDefinition[] result;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      //select models, bacause we dont want to return types with navigation-properties!
      var query = db.VisitProdecureDefinitions
        .AsNoTracking()
        .AccessScopeFiltered()
        .Select(VisitProdecureDefinitionEntity.VisitProdecureDefinitionSelector)
      ;
      
      //apply filter (if given)
      if(filterExpression != null) {
        //just if the filterExpression isnt already a valid expression, treat it as a freetext seach string and transform it to a valid expression
        filterExpression = DynamicLinqExtensions.FreetextSearchStringToFilterExpression(filterExpression, _ExactMatchPropNames, _FreetextPropNames);
      }
      if(filterExpression != null) {
        query = query.DynamicallyFiltered(filterExpression);
      }

      //apply sorting
      if(String.IsNullOrWhiteSpace(sortingExpression)) {
        query = query.DynamicallySorted("VisitProdecureName");
      }
      else{
        query = query.DynamicallySorted(sortingExpression + ", VisitProdecureName");
      }

      //apply pagination
      query = query.Skip(pageSize * (page - 1)).Take(pageSize);

      //materialization / load
      result = query.ToArray();

    }

    return result;
  }

  /// <summary> Adds a new VisitProdecureDefinition and returns success. </summary>
  /// <param name="visitProdecureDefinition"> VisitProdecureDefinition containing the new values </param>
  public bool AddNewVisitProdecureDefinition(VisitProdecureDefinition visitProdecureDefinition){
    var mac = AccessControlContext.Current;

    VisitProdecureDefinitionEntity newEntity = new VisitProdecureDefinitionEntity();
    newEntity.CopyContentFrom(visitProdecureDefinition);

    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      //checks, that the new values are within the access control scope
      if(!this.PreValidateAccessControlScope(newEntity, db)){
        return false;
      }

      if (db.VisitProdecureDefinitions.Where((e)=>e.VisitProdecureName == newEntity.VisitProdecureName).Any()) {
        return false;
      }

      db.VisitProdecureDefinitions.Add(newEntity);

      db.SaveChanges();
    }

    return true;
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given VisitProdecureDefinition addressed by the primary identifier fields within the given VisitProdecureDefinition. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="visitProdecureDefinition"> VisitProdecureDefinition containing the new values (the primary identifier fields within the given VisitProdecureDefinition will be used to address the target record) </param>
  public bool UpdateVisitProdecureDefinition(VisitProdecureDefinition visitProdecureDefinition){
    return this.UpdateVisitProdecureDefinitionByVisitProdecureName(visitProdecureDefinition.VisitProdecureName, visitProdecureDefinition);
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given VisitProdecureDefinition addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="visitProdecureName"> Represents the primary identity of a VisitProdecureDefinition </param>
  /// <param name="visitProdecureDefinition"> VisitProdecureDefinition containing the new values (the primary identifier fields within the given VisitProdecureDefinition will be ignored) </param>
  public bool UpdateVisitProdecureDefinitionByVisitProdecureName(String visitProdecureName, VisitProdecureDefinition visitProdecureDefinition){
    var mac = AccessControlContext.Current;

    VisitProdecureDefinitionEntity existingEntity;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      var query = db.VisitProdecureDefinitions.AsNoTracking();

      query = query.Where((e)=>e.VisitProdecureName == visitProdecureName).AccessScopeFiltered();

      //materialization / load
      existingEntity = query.SingleOrDefault();

      if(existingEntity == null) {
        return false;
      }

      bool changeAttemptOnFixedField = false;
      existingEntity.CopyContentFrom(visitProdecureDefinition, (name) => changeAttemptOnFixedField = true);

      if (changeAttemptOnFixedField) {
        return false;
      }

      //checks, that the new values are within the access control scope
      if(!this.PreValidateAccessControlScope(existingEntity, db)){
        return false;
      }

      db.SaveChanges();
    }

    return true;
  }

  /// <summary> Deletes a specific VisitProdecureDefinition addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="visitProdecureName"> Represents the primary identity of a VisitProdecureDefinition </param>
  public bool DeleteVisitProdecureDefinitionByVisitProdecureName(String visitProdecureName){
    var mac = AccessControlContext.Current;

    VisitProdecureDefinitionEntity existingEntity;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      var query = db.VisitProdecureDefinitions.AsNoTracking().AccessScopeFiltered();

      query = query.Where((e)=>e.VisitProdecureName == visitProdecureName);

      //materialization / load
      existingEntity = query.SingleOrDefault();

      if (existingEntity == null) {
        return false;
      }

      db.VisitProdecureDefinitions.Remove(existingEntity);

      db.SaveChanges();
    }

    return true;
  }

  private bool PreValidateAccessControlScope(VisitProdecureDefinitionEntity entity, WorkflowDefinitionDbContext db){

    var filterExpression = EntityAccessControl.BuildExpressionForLocalEntity<VisitProdecureDefinitionEntity>(AccessControlContext.Current);
    if(!filterExpression.Compile().Invoke(entity)) {
      return false;
    }

    if(!db.ResearchStudies.Where((tgt)=> tgt.StudyWorkflowName==entity.StudyWorkflowName && tgt.StudyWorkflowVersion==entity.StudyWorkflowVersion ).AccessScopeFiltered().Any()) {
      return false;
    }
    if(!db.TaskSchedules.Where((tgt)=> tgt.TaskScheduleId==entity.RootTaskScheduleId ).AccessScopeFiltered().Any()) {
      return false;
    }
    return true;
  }

}

/// <summary> Provides CRUD access to stored ProcedureCycleDefinitions (based on schema version '1.3.0') </summary>
public partial class ProcedureCycleDefinitionStore : IProcedureCycleDefinitionRepository {

  /// <summary> Loads a specific ProcedureCycleDefinition addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="procedureScheduleId"> Represents the primary identity of a ProcedureCycleDefinition </param>
  public ProcedureCycleDefinition GetProcedureCycleDefinitionByProcedureScheduleId(Guid procedureScheduleId){
    var mac = AccessControlContext.Current;

    ProcedureCycleDefinition result;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      //select models, bacause we dont want to return types with navigation-properties!
      var query = db.ProcedureCycleDefinitions.AsNoTracking().AccessScopeFiltered().Select(ProcedureCycleDefinitionEntity.ProcedureCycleDefinitionSelector);

      query = query.Where((e)=>e.ProcedureScheduleId == procedureScheduleId);

      //materialization / load
      result = query.SingleOrDefault();

    }

    return result;
  }

  /// <summary> Loads ProcedureCycleDefinitions. </summary>
  /// <param name="page">Number of the page, which should be returned </param>
  /// <param name="pageSize">Max count of ProcedureCycleDefinitions which should be returned </param>
  public ProcedureCycleDefinition[] GetProcedureCycleDefinitions(int page = 1, int pageSize = 20){
    return this.SearchProcedureCycleDefinitions(null, null, page, pageSize); 
  }

  private static String[] _ExactMatchPropNames = new String[] {};
  private static String[] _FreetextPropNames = new String[] {"ReschedulingOffset", "ReschedulingOffsetUnit"};

  /// <summary> Loads ProcedureCycleDefinitions where values matching to the given filterExpression</summary>
  /// <param name="filterExpression">a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")'</param>
  /// <param name="sortingExpression">one or more property names which are used as sort order (before pagination)</param>
  /// <param name="page">Number of the page, which should be returned</param>
  /// <param name="pageSize">Max count of ProcedureCycleDefinitions which should be returned</param>
  public ProcedureCycleDefinition[] SearchProcedureCycleDefinitions(String filterExpression, String sortingExpression = null, int page = 1, int pageSize = 20){
    var mac = AccessControlContext.Current;

    ProcedureCycleDefinition[] result;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      //select models, bacause we dont want to return types with navigation-properties!
      var query = db.ProcedureCycleDefinitions
        .AsNoTracking()
        .AccessScopeFiltered()
        .Select(ProcedureCycleDefinitionEntity.ProcedureCycleDefinitionSelector)
      ;
      
      //apply filter (if given)
      if(filterExpression != null) {
        //just if the filterExpression isnt already a valid expression, treat it as a freetext seach string and transform it to a valid expression
        filterExpression = DynamicLinqExtensions.FreetextSearchStringToFilterExpression(filterExpression, _ExactMatchPropNames, _FreetextPropNames);
      }
      if(filterExpression != null) {
        query = query.DynamicallyFiltered(filterExpression);
      }

      //apply sorting
      if(String.IsNullOrWhiteSpace(sortingExpression)) {
        query = query.DynamicallySorted("ProcedureScheduleId");
      }
      else{
        query = query.DynamicallySorted(sortingExpression + ", ProcedureScheduleId");
      }

      //apply pagination
      query = query.Skip(pageSize * (page - 1)).Take(pageSize);

      //materialization / load
      result = query.ToArray();

    }

    return result;
  }

  /// <summary> Adds a new ProcedureCycleDefinition and returns success. </summary>
  /// <param name="procedureCycleDefinition"> ProcedureCycleDefinition containing the new values </param>
  public bool AddNewProcedureCycleDefinition(ProcedureCycleDefinition procedureCycleDefinition){
    var mac = AccessControlContext.Current;

    ProcedureCycleDefinitionEntity newEntity = new ProcedureCycleDefinitionEntity();
    newEntity.CopyContentFrom(procedureCycleDefinition);

    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      //checks, that the new values are within the access control scope
      if(!this.PreValidateAccessControlScope(newEntity, db)){
        return false;
      }

      if (db.ProcedureCycleDefinitions.Where((e)=>e.ProcedureScheduleId == newEntity.ProcedureScheduleId).Any()) {
        return false;
      }

      db.ProcedureCycleDefinitions.Add(newEntity);

      db.SaveChanges();
    }

    return true;
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given ProcedureCycleDefinition addressed by the primary identifier fields within the given ProcedureCycleDefinition. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="procedureCycleDefinition"> ProcedureCycleDefinition containing the new values (the primary identifier fields within the given ProcedureCycleDefinition will be used to address the target record) </param>
  public bool UpdateProcedureCycleDefinition(ProcedureCycleDefinition procedureCycleDefinition){
    return this.UpdateProcedureCycleDefinitionByProcedureScheduleId(procedureCycleDefinition.ProcedureScheduleId, procedureCycleDefinition);
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given ProcedureCycleDefinition addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="procedureScheduleId"> Represents the primary identity of a ProcedureCycleDefinition </param>
  /// <param name="procedureCycleDefinition"> ProcedureCycleDefinition containing the new values (the primary identifier fields within the given ProcedureCycleDefinition will be ignored) </param>
  public bool UpdateProcedureCycleDefinitionByProcedureScheduleId(Guid procedureScheduleId, ProcedureCycleDefinition procedureCycleDefinition){
    var mac = AccessControlContext.Current;

    ProcedureCycleDefinitionEntity existingEntity;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      var query = db.ProcedureCycleDefinitions.AsNoTracking();

      query = query.Where((e)=>e.ProcedureScheduleId == procedureScheduleId).AccessScopeFiltered();

      //materialization / load
      existingEntity = query.SingleOrDefault();

      if(existingEntity == null) {
        return false;
      }

      bool changeAttemptOnFixedField = false;
      existingEntity.CopyContentFrom(procedureCycleDefinition, (name) => changeAttemptOnFixedField = true);

      if (changeAttemptOnFixedField) {
        return false;
      }

      //checks, that the new values are within the access control scope
      if(!this.PreValidateAccessControlScope(existingEntity, db)){
        return false;
      }

      db.SaveChanges();
    }

    return true;
  }

  /// <summary> Deletes a specific ProcedureCycleDefinition addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="procedureScheduleId"> Represents the primary identity of a ProcedureCycleDefinition </param>
  public bool DeleteProcedureCycleDefinitionByProcedureScheduleId(Guid procedureScheduleId){
    var mac = AccessControlContext.Current;

    ProcedureCycleDefinitionEntity existingEntity;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      var query = db.ProcedureCycleDefinitions.AsNoTracking().AccessScopeFiltered();

      query = query.Where((e)=>e.ProcedureScheduleId == procedureScheduleId);

      //materialization / load
      existingEntity = query.SingleOrDefault();

      if (existingEntity == null) {
        return false;
      }

      db.ProcedureCycleDefinitions.Remove(existingEntity);

      db.SaveChanges();
    }

    return true;
  }

  private bool PreValidateAccessControlScope(ProcedureCycleDefinitionEntity entity, WorkflowDefinitionDbContext db){

    var filterExpression = EntityAccessControl.BuildExpressionForLocalEntity<ProcedureCycleDefinitionEntity>(AccessControlContext.Current);
    if(!filterExpression.Compile().Invoke(entity)) {
      return false;
    }

    if(!db.ProcedureSchedules.Where((tgt)=> tgt.ProcedureScheduleId==entity.ProcedureScheduleId ).AccessScopeFiltered().Any()) {
      return false;
    }
    return true;
  }

}

/// <summary> Provides CRUD access to stored StudyEvents (based on schema version '1.3.0') </summary>
public partial class StudyEventStore : IStudyEventRepository {

  /// <summary> Loads a specific StudyEvent addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="studyEventName"> Represents the primary identity of a StudyEvent </param>
  public StudyEvent GetStudyEventByStudyEventName(String studyEventName){
    var mac = AccessControlContext.Current;

    StudyEvent result;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      //select models, bacause we dont want to return types with navigation-properties!
      var query = db.StudyEvents.AsNoTracking().AccessScopeFiltered().Select(StudyEventEntity.StudyEventSelector);

      query = query.Where((e)=>e.StudyEventName == studyEventName);

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

  private static String[] _ExactMatchPropNames = new String[] {"StudyWorkflowName", "StudyWorkflowVersion", "StudyEventName"};
  private static String[] _FreetextPropNames = new String[] {"Description", "EvenSpecificDocumentationUrl"};

  /// <summary> Loads StudyEvents where values matching to the given filterExpression</summary>
  /// <param name="filterExpression">a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")'</param>
  /// <param name="sortingExpression">one or more property names which are used as sort order (before pagination)</param>
  /// <param name="page">Number of the page, which should be returned</param>
  /// <param name="pageSize">Max count of StudyEvents which should be returned</param>
  public StudyEvent[] SearchStudyEvents(String filterExpression, String sortingExpression = null, int page = 1, int pageSize = 20){
    var mac = AccessControlContext.Current;

    StudyEvent[] result;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      //select models, bacause we dont want to return types with navigation-properties!
      var query = db.StudyEvents
        .AsNoTracking()
        .AccessScopeFiltered()
        .Select(StudyEventEntity.StudyEventSelector)
      ;
      
      //apply filter (if given)
      if(filterExpression != null) {
        //just if the filterExpression isnt already a valid expression, treat it as a freetext seach string and transform it to a valid expression
        filterExpression = DynamicLinqExtensions.FreetextSearchStringToFilterExpression(filterExpression, _ExactMatchPropNames, _FreetextPropNames);
      }
      if(filterExpression != null) {
        query = query.DynamicallyFiltered(filterExpression);
      }

      //apply sorting
      if(String.IsNullOrWhiteSpace(sortingExpression)) {
        query = query.DynamicallySorted("StudyEventName");
      }
      else{
        query = query.DynamicallySorted(sortingExpression + ", StudyEventName");
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

    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      //checks, that the new values are within the access control scope
      if(!this.PreValidateAccessControlScope(newEntity, db)){
        return false;
      }

      if (db.StudyEvents.Where((e)=>e.StudyEventName == newEntity.StudyEventName).Any()) {
        return false;
      }

      db.StudyEvents.Add(newEntity);

      db.SaveChanges();
    }

    return true;
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given StudyEvent addressed by the primary identifier fields within the given StudyEvent. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="studyEvent"> StudyEvent containing the new values (the primary identifier fields within the given StudyEvent will be used to address the target record) </param>
  public bool UpdateStudyEvent(StudyEvent studyEvent){
    return this.UpdateStudyEventByStudyEventName(studyEvent.StudyEventName, studyEvent);
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given StudyEvent addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="studyEventName"> Represents the primary identity of a StudyEvent </param>
  /// <param name="studyEvent"> StudyEvent containing the new values (the primary identifier fields within the given StudyEvent will be ignored) </param>
  public bool UpdateStudyEventByStudyEventName(String studyEventName, StudyEvent studyEvent){
    var mac = AccessControlContext.Current;

    StudyEventEntity existingEntity;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      var query = db.StudyEvents.AsNoTracking();

      query = query.Where((e)=>e.StudyEventName == studyEventName).AccessScopeFiltered();

      //materialization / load
      existingEntity = query.SingleOrDefault();

      if(existingEntity == null) {
        return false;
      }

      bool changeAttemptOnFixedField = false;
      existingEntity.CopyContentFrom(studyEvent, (name) => changeAttemptOnFixedField = true);

      if (changeAttemptOnFixedField) {
        return false;
      }

      //checks, that the new values are within the access control scope
      if(!this.PreValidateAccessControlScope(existingEntity, db)){
        return false;
      }

      db.SaveChanges();
    }

    return true;
  }

  /// <summary> Deletes a specific StudyEvent addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="studyEventName"> Represents the primary identity of a StudyEvent </param>
  public bool DeleteStudyEventByStudyEventName(String studyEventName){
    var mac = AccessControlContext.Current;

    StudyEventEntity existingEntity;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      var query = db.StudyEvents.AsNoTracking().AccessScopeFiltered();

      query = query.Where((e)=>e.StudyEventName == studyEventName);

      //materialization / load
      existingEntity = query.SingleOrDefault();

      if (existingEntity == null) {
        return false;
      }

      db.StudyEvents.Remove(existingEntity);

      db.SaveChanges();
    }

    return true;
  }

  private bool PreValidateAccessControlScope(StudyEventEntity entity, WorkflowDefinitionDbContext db){

    var filterExpression = EntityAccessControl.BuildExpressionForLocalEntity<StudyEventEntity>(AccessControlContext.Current);
    if(!filterExpression.Compile().Invoke(entity)) {
      return false;
    }

    if(!db.ResearchStudies.Where((tgt)=> tgt.StudyWorkflowName==entity.StudyWorkflowName && tgt.StudyWorkflowVersion==entity.StudyWorkflowVersion ).AccessScopeFiltered().Any()) {
      return false;
    }
    return true;
  }

}

/// <summary> Provides CRUD access to stored TaskCycleDefinitions (based on schema version '1.3.0') </summary>
public partial class TaskCycleDefinitionStore : ITaskCycleDefinitionRepository {

  /// <summary> Loads a specific TaskCycleDefinition addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="taskScheduleId"> Represents the primary identity of a TaskCycleDefinition </param>
  public TaskCycleDefinition GetTaskCycleDefinitionByTaskScheduleId(Guid taskScheduleId){
    var mac = AccessControlContext.Current;

    TaskCycleDefinition result;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      //select models, bacause we dont want to return types with navigation-properties!
      var query = db.TaskCycleDefinitions.AsNoTracking().AccessScopeFiltered().Select(TaskCycleDefinitionEntity.TaskCycleDefinitionSelector);

      query = query.Where((e)=>e.TaskScheduleId == taskScheduleId);

      //materialization / load
      result = query.SingleOrDefault();

    }

    return result;
  }

  /// <summary> Loads TaskCycleDefinitions. </summary>
  /// <param name="page">Number of the page, which should be returned </param>
  /// <param name="pageSize">Max count of TaskCycleDefinitions which should be returned </param>
  public TaskCycleDefinition[] GetTaskCycleDefinitions(int page = 1, int pageSize = 20){
    return this.SearchTaskCycleDefinitions(null, null, page, pageSize); 
  }

  private static String[] _ExactMatchPropNames = new String[] {};
  private static String[] _FreetextPropNames = new String[] {"ReschedulingBase", "ReschedulingOffset", "ReschedulingOffsetUnit"};

  /// <summary> Loads TaskCycleDefinitions where values matching to the given filterExpression</summary>
  /// <param name="filterExpression">a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")'</param>
  /// <param name="sortingExpression">one or more property names which are used as sort order (before pagination)</param>
  /// <param name="page">Number of the page, which should be returned</param>
  /// <param name="pageSize">Max count of TaskCycleDefinitions which should be returned</param>
  public TaskCycleDefinition[] SearchTaskCycleDefinitions(String filterExpression, String sortingExpression = null, int page = 1, int pageSize = 20){
    var mac = AccessControlContext.Current;

    TaskCycleDefinition[] result;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      //select models, bacause we dont want to return types with navigation-properties!
      var query = db.TaskCycleDefinitions
        .AsNoTracking()
        .AccessScopeFiltered()
        .Select(TaskCycleDefinitionEntity.TaskCycleDefinitionSelector)
      ;
      
      //apply filter (if given)
      if(filterExpression != null) {
        //just if the filterExpression isnt already a valid expression, treat it as a freetext seach string and transform it to a valid expression
        filterExpression = DynamicLinqExtensions.FreetextSearchStringToFilterExpression(filterExpression, _ExactMatchPropNames, _FreetextPropNames);
      }
      if(filterExpression != null) {
        query = query.DynamicallyFiltered(filterExpression);
      }

      //apply sorting
      if(String.IsNullOrWhiteSpace(sortingExpression)) {
        query = query.DynamicallySorted("TaskScheduleId");
      }
      else{
        query = query.DynamicallySorted(sortingExpression + ", TaskScheduleId");
      }

      //apply pagination
      query = query.Skip(pageSize * (page - 1)).Take(pageSize);

      //materialization / load
      result = query.ToArray();

    }

    return result;
  }

  /// <summary> Adds a new TaskCycleDefinition and returns success. </summary>
  /// <param name="taskCycleDefinition"> TaskCycleDefinition containing the new values </param>
  public bool AddNewTaskCycleDefinition(TaskCycleDefinition taskCycleDefinition){
    var mac = AccessControlContext.Current;

    TaskCycleDefinitionEntity newEntity = new TaskCycleDefinitionEntity();
    newEntity.CopyContentFrom(taskCycleDefinition);

    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      //checks, that the new values are within the access control scope
      if(!this.PreValidateAccessControlScope(newEntity, db)){
        return false;
      }

      if (db.TaskCycleDefinitions.Where((e)=>e.TaskScheduleId == newEntity.TaskScheduleId).Any()) {
        return false;
      }

      db.TaskCycleDefinitions.Add(newEntity);

      db.SaveChanges();
    }

    return true;
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given TaskCycleDefinition addressed by the primary identifier fields within the given TaskCycleDefinition. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="taskCycleDefinition"> TaskCycleDefinition containing the new values (the primary identifier fields within the given TaskCycleDefinition will be used to address the target record) </param>
  public bool UpdateTaskCycleDefinition(TaskCycleDefinition taskCycleDefinition){
    return this.UpdateTaskCycleDefinitionByTaskScheduleId(taskCycleDefinition.TaskScheduleId, taskCycleDefinition);
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given TaskCycleDefinition addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="taskScheduleId"> Represents the primary identity of a TaskCycleDefinition </param>
  /// <param name="taskCycleDefinition"> TaskCycleDefinition containing the new values (the primary identifier fields within the given TaskCycleDefinition will be ignored) </param>
  public bool UpdateTaskCycleDefinitionByTaskScheduleId(Guid taskScheduleId, TaskCycleDefinition taskCycleDefinition){
    var mac = AccessControlContext.Current;

    TaskCycleDefinitionEntity existingEntity;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      var query = db.TaskCycleDefinitions.AsNoTracking();

      query = query.Where((e)=>e.TaskScheduleId == taskScheduleId).AccessScopeFiltered();

      //materialization / load
      existingEntity = query.SingleOrDefault();

      if(existingEntity == null) {
        return false;
      }

      bool changeAttemptOnFixedField = false;
      existingEntity.CopyContentFrom(taskCycleDefinition, (name) => changeAttemptOnFixedField = true);

      if (changeAttemptOnFixedField) {
        return false;
      }

      //checks, that the new values are within the access control scope
      if(!this.PreValidateAccessControlScope(existingEntity, db)){
        return false;
      }

      db.SaveChanges();
    }

    return true;
  }

  /// <summary> Deletes a specific TaskCycleDefinition addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="taskScheduleId"> Represents the primary identity of a TaskCycleDefinition </param>
  public bool DeleteTaskCycleDefinitionByTaskScheduleId(Guid taskScheduleId){
    var mac = AccessControlContext.Current;

    TaskCycleDefinitionEntity existingEntity;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      var query = db.TaskCycleDefinitions.AsNoTracking().AccessScopeFiltered();

      query = query.Where((e)=>e.TaskScheduleId == taskScheduleId);

      //materialization / load
      existingEntity = query.SingleOrDefault();

      if (existingEntity == null) {
        return false;
      }

      db.TaskCycleDefinitions.Remove(existingEntity);

      db.SaveChanges();
    }

    return true;
  }

  private bool PreValidateAccessControlScope(TaskCycleDefinitionEntity entity, WorkflowDefinitionDbContext db){

    var filterExpression = EntityAccessControl.BuildExpressionForLocalEntity<TaskCycleDefinitionEntity>(AccessControlContext.Current);
    if(!filterExpression.Compile().Invoke(entity)) {
      return false;
    }

    if(!db.TaskSchedules.Where((tgt)=> tgt.TaskScheduleId==entity.TaskScheduleId ).AccessScopeFiltered().Any()) {
      return false;
    }
    return true;
  }

}

}
