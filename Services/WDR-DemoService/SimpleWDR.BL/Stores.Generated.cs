using MedicalResearch.Workflow;
using MedicalResearch.Workflow.Persistence;
using MedicalResearch.Workflow.Persistence.EF;
using MedicalResearch.Workflow.Model;
using System;
using System.Data;
using System.Data.AccessControl;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MedicalResearch.Workflow.StoreAccess {

/// <summary> Provides CRUD access to stored ResearchStudyDefinitions (based on schema version '1.5.0') </summary>
public partial class ResearchStudyDefinitionStore : IResearchStudyDefinitions {

  private ILogger _Logger = null;
  public ResearchStudyDefinitionStore(ILogger<ResearchStudyDefinitionStore> logger){
    _Logger = logger;
  }

  /// <summary> Loads a specific ResearchStudyDefinition addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.</summary>
  /// <param name="researchStudyDefinitionIdentity"> Composite Key, which represents the primary identity of a ResearchStudyDefinition </param>
  public ResearchStudyDefinition GetResearchStudyDefinitionByResearchStudyDefinitionIdentity(ResearchStudyDefinitionIdentity researchStudyDefinitionIdentity){
    var mac = AccessControlContext.Current;

    ResearchStudyDefinition result;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      //select models, bacause we dont want to return types with navigation-properties!
      var query = db.ResearchStudyDefinitions.AsNoTracking().AccessScopeFiltered().Select(ResearchStudyDefinitionEntity.ResearchStudyDefinitionSelector);

      query = query.Where((e)=> e.StudyWorkflowName == researchStudyDefinitionIdentity.StudyWorkflowName && e.StudyWorkflowVersion == researchStudyDefinitionIdentity.StudyWorkflowVersion);

      //materialization / load
      result = query.SingleOrDefault();

    }

    return result;
  }

  /// <summary> Loads ResearchStudyDefinitions. </summary>
  /// <param name="page">Number of the page, which should be returned </param>
  /// <param name="pageSize">Max count of ResearchStudyDefinitions which should be returned </param>
  public ResearchStudyDefinition[] GetResearchStudyDefinitions(int page = 1, int pageSize = 20){
    return this.SearchResearchStudyDefinitions(null, null, page, pageSize); 
  }

  private static String[] _ExactMatchPropNames = new String[] {"StudyWorkflowName", "StudyWorkflowVersion"};
  private static String[] _FreetextPropNames = new String[] {"OfficialLabel", "DefinitionOwner", "DocumentationUrl", "LogoImage", "Description", "VersionIdentity", "BillingCurrency", "StudyDocumentationUrl", "CaseReportFormUrl"};

  /// <summary> Loads ResearchStudyDefinitions where values matching to the given filterExpression</summary>
  /// <param name="filterExpression">a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' OR just '*' for all records</param>
  /// <param name="sortingExpression">one or more property names which are used as sort order (before pagination)</param>
  /// <param name="page">Number of the page, which should be returned</param>
  /// <param name="pageSize">Max count of ResearchStudyDefinitions which should be returned</param>
  public ResearchStudyDefinition[] SearchResearchStudyDefinitions(String filterExpression, String sortingExpression = null, int page = 1, int pageSize = 20){
    var mac = AccessControlContext.Current;

    if(page < 1){
      page = 1;
    }
    if(pageSize < 1 || pageSize > 10000){
      pageSize = 20;
    }

    ResearchStudyDefinition[] result;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      //select models, bacause we dont want to return types with navigation-properties!
      var query = db.ResearchStudyDefinitions
        .AsNoTracking()
        .AccessScopeFiltered()
        .Select(ResearchStudyDefinitionEntity.ResearchStudyDefinitionSelector)
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

  /// <summary> Adds a new ResearchStudyDefinition and returns success. </summary>
  /// <param name="researchStudyDefinition"> ResearchStudyDefinition containing the new values </param>
  public bool AddNewResearchStudyDefinition(ResearchStudyDefinition researchStudyDefinition){
    var mac = AccessControlContext.Current;

    ResearchStudyDefinitionEntity newEntity = new ResearchStudyDefinitionEntity();
    newEntity.CopyContentFrom(researchStudyDefinition);

    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      //checks, that the new values are within the access control scope
      if(!this.PreValidateAccessControlScope(newEntity, db)){
        if(_Logger != null){
          _Logger.LogInformation("Adding ResearchStudyDefinition failed: record would be out of access control scope!");
        }
        return false;
      }

      if (db.ResearchStudyDefinitions.Where((e)=> e.StudyWorkflowName == newEntity.StudyWorkflowName && e.StudyWorkflowVersion == newEntity.StudyWorkflowVersion).Any()) {
        if(_Logger != null){
          _Logger.LogInformation("Adding ResearchStudyDefinition failed: already existing record with this PK!");
        }
        return false;
      }

      db.ResearchStudyDefinitions.Add(newEntity);

      db.SaveChanges();
    }
    if(_Logger != null){
      _Logger.LogInformation("A ResearchStudyDefinition was added!");
    }

    return true;
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given ResearchStudyDefinition addressed by the primary identifier fields within the given ResearchStudyDefinition. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="researchStudyDefinition"> ResearchStudyDefinition containing the new values (the primary identifier fields within the given ResearchStudyDefinition will be used to address the target record) </param>
  public bool UpdateResearchStudyDefinition(ResearchStudyDefinition researchStudyDefinition){
    return this.UpdateResearchStudyDefinitionByResearchStudyDefinitionIdentity(new ResearchStudyDefinitionIdentity { StudyWorkflowName=researchStudyDefinition.StudyWorkflowName, StudyWorkflowVersion=researchStudyDefinition.StudyWorkflowVersion }, researchStudyDefinition);
  }

  /// <summary> Updates all values (which are not "FixedAfterCreation") of the given ResearchStudyDefinition addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="researchStudyDefinitionIdentity"> Composite Key, which represents the primary identity of a ResearchStudyDefinition </param>
  /// <param name="researchStudyDefinition"> ResearchStudyDefinition containing the new values (the primary identifier fields within the given ResearchStudyDefinition will be ignored) </param>
  public bool UpdateResearchStudyDefinitionByResearchStudyDefinitionIdentity(ResearchStudyDefinitionIdentity researchStudyDefinitionIdentity, ResearchStudyDefinition researchStudyDefinition){
    var mac = AccessControlContext.Current;

    ResearchStudyDefinitionEntity existingEntity;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      IQueryable<ResearchStudyDefinitionEntity> query = db.ResearchStudyDefinitions;

      query = query.Where((e)=> e.StudyWorkflowName == researchStudyDefinitionIdentity.StudyWorkflowName && e.StudyWorkflowVersion == researchStudyDefinitionIdentity.StudyWorkflowVersion).AccessScopeFiltered();

      //materialization / load
      existingEntity = query.SingleOrDefault();

      if(existingEntity == null) {
        if(_Logger != null){
          _Logger.LogInformation("Updating ResearchStudyDefinition failed: no record with this PK!");
        }
        return false;
      }

      bool changeAttemptOnFixedField = false;
      existingEntity.CopyContentFrom(researchStudyDefinition, (name) => changeAttemptOnFixedField = true);

      if (changeAttemptOnFixedField) {
        if(_Logger != null){
          _Logger.LogInformation("Updating ResearchStudyDefinition failed: change attempt on FIXED field!");
        }
        return false;
      }

      //checks, that the new values are within the access control scope
      if(!this.PreValidateAccessControlScope(existingEntity, db)){
        if(_Logger != null){
          _Logger.LogInformation("Updating ResearchStudyDefinition failed: record would be out of access control scope!");
        }
        return false;
      }

      db.SaveChanges();
    }
    if(_Logger != null){
      _Logger.LogInformation("A ResearchStudyDefinition was updated!");
    }

    return true;
  }

  /// <summary> Deletes a specific ResearchStudyDefinition addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.</summary>
  /// <param name="researchStudyDefinitionIdentity"> Composite Key, which represents the primary identity of a ResearchStudyDefinition </param>
  public bool DeleteResearchStudyDefinitionByResearchStudyDefinitionIdentity(ResearchStudyDefinitionIdentity researchStudyDefinitionIdentity){
    var mac = AccessControlContext.Current;

    ResearchStudyDefinitionEntity existingEntity;
    using (WorkflowDefinitionDbContext db = new WorkflowDefinitionDbContext()) {

      IQueryable<ResearchStudyDefinitionEntity> query = db.ResearchStudyDefinitions.AccessScopeFiltered();

      query = query.Where((e)=> e.StudyWorkflowName == researchStudyDefinitionIdentity.StudyWorkflowName && e.StudyWorkflowVersion == researchStudyDefinitionIdentity.StudyWorkflowVersion);

      //materialization / load
      existingEntity = query.SingleOrDefault();

      if (existingEntity == null) {
        if(_Logger != null){
          _Logger.LogInformation("Updating ResearchStudyDefinition failed: no record with this PK!");
        }
        return false;
      }

      db.ResearchStudyDefinitions.Remove(existingEntity);

      db.SaveChanges();
    }
    if(_Logger != null){
      _Logger.LogInformation("A ResearchStudyDefinition was deleted!");
    }

    return true;
  }

  private bool PreValidateAccessControlScope(ResearchStudyDefinitionEntity entity, WorkflowDefinitionDbContext db){

    var filterExpression = EntityAccessControl.BuildExpressionForLocalEntity<ResearchStudyDefinitionEntity>(AccessControlContext.Current);
    if(!filterExpression.Compile().Invoke(entity)) {
      return false;
    }

    return true;
  }

}

}
