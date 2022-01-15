/* WARNING: THIS IS GENERATED CODE - PLEASE DONT EDIT DIRECTLY - YOUR CHANGES WILL BE LOST! */

using MedicalResearch.BillingData.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MedicalResearch.BillingData.StoreAccess {
  
  /// <summary>
  /// Contains arguments for calling 'GetBillableTaskByTaskGuid'.
  /// Method: Loads a specific BillableTask addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.
  /// </summary>
  public class GetBillableTaskByTaskGuidRequest {
    
    /// <summary> Required Argument for 'GetBillableTaskByTaskGuid' (Guid): a global unique id of a concrete study-task execution which is usually originated at the primary CRF or study management system ('SMS') </summary>
    [Required]
    public Guid taskGuid { get; set; }
    
  }
  
  /// <summary>
  /// Contains results from calling 'GetBillableTaskByTaskGuid'.
  /// Method: Loads a specific BillableTask addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.
  /// </summary>
  public class GetBillableTaskByTaskGuidResponse {
    
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
    public string fault { get; set; } = null;
    
    /// <summary> Return-Value of 'GetBillableTaskByTaskGuid' (BillableTask) </summary>
    public BillableTask @return { get; set; }
    
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetBillableTasks'.
  /// Method: Loads BillableTasks.
  /// </summary>
  public class GetBillableTasksRequest {
    
    /// <summary> Optional Argument for 'GetBillableTasks' (Int32?): Number of the page, which should be returned </summary>
    public Int32? page { get; set; } = null;
    
    /// <summary> Optional Argument for 'GetBillableTasks' (Int32?): Max count of BillableTasks which should be returned </summary>
    public Int32? pageSize { get; set; } = null;
    
  }
  
  /// <summary>
  /// Contains results from calling 'GetBillableTasks'.
  /// Method: Loads BillableTasks.
  /// </summary>
  public class GetBillableTasksResponse {
    
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
    public string fault { get; set; } = null;
    
    /// <summary> Return-Value of 'GetBillableTasks' (BillableTask[]) </summary>
    public BillableTask[] @return { get; set; }
    
  }
  
  /// <summary>
  /// Contains arguments for calling 'SearchBillableTasks'.
  /// Method: Loads BillableTasks where values matching to the given filterExpression
  /// </summary>
  public class SearchBillableTasksRequest {
    
    /// <summary> Required Argument for 'SearchBillableTasks' (string): a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </summary>
    [Required]
    public string filterExpression { get; set; }
    
    /// <summary> Optional Argument for 'SearchBillableTasks' (string): one or more property names which are used as sort order (before pagination) </summary>
    public string sortingExpression { get; set; }
    
    /// <summary> Optional Argument for 'SearchBillableTasks' (Int32?): Number of the page, which should be returned </summary>
    public Int32? page { get; set; } = null;
    
    /// <summary> Optional Argument for 'SearchBillableTasks' (Int32?): Max count of BillableTasks which should be returned </summary>
    public Int32? pageSize { get; set; } = null;
    
  }
  
  /// <summary>
  /// Contains results from calling 'SearchBillableTasks'.
  /// Method: Loads BillableTasks where values matching to the given filterExpression
  /// </summary>
  public class SearchBillableTasksResponse {
    
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
    public string fault { get; set; } = null;
    
    /// <summary> Return-Value of 'SearchBillableTasks' (BillableTask[]) </summary>
    public BillableTask[] @return { get; set; }
    
  }
  
  /// <summary>
  /// Contains arguments for calling 'AddNewBillableTask'.
  /// Method: Adds a new BillableTask and returns its primary identifier (or null on failure).
  /// </summary>
  public class AddNewBillableTaskRequest {
    
    /// <summary> Required Argument for 'AddNewBillableTask' (BillableTask): BillableTask containing the new values </summary>
    [Required]
    public BillableTask billableTask { get; set; }
    
  }
  
  /// <summary>
  /// Contains results from calling 'AddNewBillableTask'.
  /// Method: Adds a new BillableTask and returns its primary identifier (or null on failure).
  /// </summary>
  public class AddNewBillableTaskResponse {
    
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
    public string fault { get; set; } = null;
    
    /// <summary> Return-Value of 'AddNewBillableTask' (Boolean) </summary>
    public bool @return { get; set; }
    
  }
  
  /// <summary>
  /// Contains arguments for calling 'UpdateBillableTask'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given BillableTask addressed by the primary identifier fields within the given BillableTask. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateBillableTaskRequest {
    
    /// <summary> Required Argument for 'UpdateBillableTask' (BillableTask): BillableTask containing the new values (the primary identifier fields within the given BillableTask will be used to address the target record) </summary>
    [Required]
    public BillableTask billableTask { get; set; }
    
  }
  
  /// <summary>
  /// Contains results from calling 'UpdateBillableTask'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given BillableTask addressed by the primary identifier fields within the given BillableTask. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateBillableTaskResponse {
    
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
    public string fault { get; set; } = null;
    
    /// <summary> Return-Value of 'UpdateBillableTask' (Boolean) </summary>
    public bool @return { get; set; }
    
  }
  
  /// <summary>
  /// Contains arguments for calling 'UpdateBillableTaskByTaskGuid'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given BillableTask addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateBillableTaskByTaskGuidRequest {
    
    /// <summary> Required Argument for 'UpdateBillableTaskByTaskGuid' (Guid): a global unique id of a concrete study-task execution which is usually originated at the primary CRF or study management system ('SMS') </summary>
    [Required]
    public Guid taskGuid { get; set; }
    
    /// <summary> Required Argument for 'UpdateBillableTaskByTaskGuid' (BillableTask): BillableTask containing the new values (the primary identifier fields within the given BillableTask will be ignored) </summary>
    [Required]
    public BillableTask billableTask { get; set; }
    
  }
  
  /// <summary>
  /// Contains results from calling 'UpdateBillableTaskByTaskGuid'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given BillableTask addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateBillableTaskByTaskGuidResponse {
    
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
    public string fault { get; set; } = null;
    
    /// <summary> Return-Value of 'UpdateBillableTaskByTaskGuid' (Boolean) </summary>
    public bool @return { get; set; }
    
  }
  
  /// <summary>
  /// Contains arguments for calling 'DeleteBillableTaskByTaskGuid'.
  /// Method: Deletes a specific BillableTask addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class DeleteBillableTaskByTaskGuidRequest {
    
    /// <summary> Required Argument for 'DeleteBillableTaskByTaskGuid' (Guid): a global unique id of a concrete study-task execution which is usually originated at the primary CRF or study management system ('SMS') </summary>
    [Required]
    public Guid taskGuid { get; set; }
    
  }
  
  /// <summary>
  /// Contains results from calling 'DeleteBillableTaskByTaskGuid'.
  /// Method: Deletes a specific BillableTask addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class DeleteBillableTaskByTaskGuidResponse {
    
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
    public string fault { get; set; } = null;
    
    /// <summary> Return-Value of 'DeleteBillableTaskByTaskGuid' (Boolean) </summary>
    public bool @return { get; set; }
    
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetBillableVisitByVisitGuid'.
  /// Method: Loads a specific BillableVisit addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.
  /// </summary>
  public class GetBillableVisitByVisitGuidRequest {
    
    /// <summary> Required Argument for 'GetBillableVisitByVisitGuid' (Guid): a global unique id of a concrete study-visit execution which is usually originated at the primary CRF or study management system ('SMS') </summary>
    [Required]
    public Guid visitGuid { get; set; }
    
  }
  
  /// <summary>
  /// Contains results from calling 'GetBillableVisitByVisitGuid'.
  /// Method: Loads a specific BillableVisit addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.
  /// </summary>
  public class GetBillableVisitByVisitGuidResponse {
    
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
    public string fault { get; set; } = null;
    
    /// <summary> Return-Value of 'GetBillableVisitByVisitGuid' (BillableVisit) </summary>
    public BillableVisit @return { get; set; }
    
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetBillableVisits'.
  /// Method: Loads BillableVisits.
  /// </summary>
  public class GetBillableVisitsRequest {
    
    /// <summary> Optional Argument for 'GetBillableVisits' (Int32?): Number of the page, which should be returned </summary>
    public Int32? page { get; set; } = null;
    
    /// <summary> Optional Argument for 'GetBillableVisits' (Int32?): Max count of BillableVisits which should be returned </summary>
    public Int32? pageSize { get; set; } = null;
    
  }
  
  /// <summary>
  /// Contains results from calling 'GetBillableVisits'.
  /// Method: Loads BillableVisits.
  /// </summary>
  public class GetBillableVisitsResponse {
    
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
    public string fault { get; set; } = null;
    
    /// <summary> Return-Value of 'GetBillableVisits' (BillableVisit[]) </summary>
    public BillableVisit[] @return { get; set; }
    
  }
  
  /// <summary>
  /// Contains arguments for calling 'SearchBillableVisits'.
  /// Method: Loads BillableVisits where values matching to the given filterExpression
  /// </summary>
  public class SearchBillableVisitsRequest {
    
    /// <summary> Required Argument for 'SearchBillableVisits' (string): a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </summary>
    [Required]
    public string filterExpression { get; set; }
    
    /// <summary> Optional Argument for 'SearchBillableVisits' (string): one or more property names which are used as sort order (before pagination) </summary>
    public string sortingExpression { get; set; }
    
    /// <summary> Optional Argument for 'SearchBillableVisits' (Int32?): Number of the page, which should be returned </summary>
    public Int32? page { get; set; } = null;
    
    /// <summary> Optional Argument for 'SearchBillableVisits' (Int32?): Max count of BillableVisits which should be returned </summary>
    public Int32? pageSize { get; set; } = null;
    
  }
  
  /// <summary>
  /// Contains results from calling 'SearchBillableVisits'.
  /// Method: Loads BillableVisits where values matching to the given filterExpression
  /// </summary>
  public class SearchBillableVisitsResponse {
    
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
    public string fault { get; set; } = null;
    
    /// <summary> Return-Value of 'SearchBillableVisits' (BillableVisit[]) </summary>
    public BillableVisit[] @return { get; set; }
    
  }
  
  /// <summary>
  /// Contains arguments for calling 'AddNewBillableVisit'.
  /// Method: Adds a new BillableVisit and returns its primary identifier (or null on failure).
  /// </summary>
  public class AddNewBillableVisitRequest {
    
    /// <summary> Required Argument for 'AddNewBillableVisit' (BillableVisit): BillableVisit containing the new values </summary>
    [Required]
    public BillableVisit billableVisit { get; set; }
    
  }
  
  /// <summary>
  /// Contains results from calling 'AddNewBillableVisit'.
  /// Method: Adds a new BillableVisit and returns its primary identifier (or null on failure).
  /// </summary>
  public class AddNewBillableVisitResponse {
    
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
    public string fault { get; set; } = null;
    
    /// <summary> Return-Value of 'AddNewBillableVisit' (Boolean) </summary>
    public bool @return { get; set; }
    
  }
  
  /// <summary>
  /// Contains arguments for calling 'UpdateBillableVisit'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given BillableVisit addressed by the primary identifier fields within the given BillableVisit. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateBillableVisitRequest {
    
    /// <summary> Required Argument for 'UpdateBillableVisit' (BillableVisit): BillableVisit containing the new values (the primary identifier fields within the given BillableVisit will be used to address the target record) </summary>
    [Required]
    public BillableVisit billableVisit { get; set; }
    
  }
  
  /// <summary>
  /// Contains results from calling 'UpdateBillableVisit'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given BillableVisit addressed by the primary identifier fields within the given BillableVisit. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateBillableVisitResponse {
    
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
    public string fault { get; set; } = null;
    
    /// <summary> Return-Value of 'UpdateBillableVisit' (Boolean) </summary>
    public bool @return { get; set; }
    
  }
  
  /// <summary>
  /// Contains arguments for calling 'UpdateBillableVisitByVisitGuid'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given BillableVisit addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateBillableVisitByVisitGuidRequest {
    
    /// <summary> Required Argument for 'UpdateBillableVisitByVisitGuid' (Guid): a global unique id of a concrete study-visit execution which is usually originated at the primary CRF or study management system ('SMS') </summary>
    [Required]
    public Guid visitGuid { get; set; }
    
    /// <summary> Required Argument for 'UpdateBillableVisitByVisitGuid' (BillableVisit): BillableVisit containing the new values (the primary identifier fields within the given BillableVisit will be ignored) </summary>
    [Required]
    public BillableVisit billableVisit { get; set; }
    
  }
  
  /// <summary>
  /// Contains results from calling 'UpdateBillableVisitByVisitGuid'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given BillableVisit addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateBillableVisitByVisitGuidResponse {
    
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
    public string fault { get; set; } = null;
    
    /// <summary> Return-Value of 'UpdateBillableVisitByVisitGuid' (Boolean) </summary>
    public bool @return { get; set; }
    
  }
  
  /// <summary>
  /// Contains arguments for calling 'DeleteBillableVisitByVisitGuid'.
  /// Method: Deletes a specific BillableVisit addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class DeleteBillableVisitByVisitGuidRequest {
    
    /// <summary> Required Argument for 'DeleteBillableVisitByVisitGuid' (Guid): a global unique id of a concrete study-visit execution which is usually originated at the primary CRF or study management system ('SMS') </summary>
    [Required]
    public Guid visitGuid { get; set; }
    
  }
  
  /// <summary>
  /// Contains results from calling 'DeleteBillableVisitByVisitGuid'.
  /// Method: Deletes a specific BillableVisit addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class DeleteBillableVisitByVisitGuidResponse {
    
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
    public string fault { get; set; } = null;
    
    /// <summary> Return-Value of 'DeleteBillableVisitByVisitGuid' (Boolean) </summary>
    public bool @return { get; set; }
    
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetStudyExecutionScopeByStudyExecutionIdentifier'.
  /// Method: Loads a specific StudyExecutionScope addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.
  /// </summary>
  public class GetStudyExecutionScopeByStudyExecutionIdentifierRequest {
    
    /// <summary> Required Argument for 'GetStudyExecutionScopeByStudyExecutionIdentifier' (Guid): a global unique id of a concrete study execution (dedicated to a concrete institute) which is usually originated at the primary CRF or study management system ('SMS') </summary>
    [Required]
    public Guid studyExecutionIdentifier { get; set; }
    
  }
  
  /// <summary>
  /// Contains results from calling 'GetStudyExecutionScopeByStudyExecutionIdentifier'.
  /// Method: Loads a specific StudyExecutionScope addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.
  /// </summary>
  public class GetStudyExecutionScopeByStudyExecutionIdentifierResponse {
    
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
    public string fault { get; set; } = null;
    
    /// <summary> Return-Value of 'GetStudyExecutionScopeByStudyExecutionIdentifier' (StudyExecutionScope) </summary>
    public StudyExecutionScope @return { get; set; }
    
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetStudyExecutionScopes'.
  /// Method: Loads StudyExecutionScopes.
  /// </summary>
  public class GetStudyExecutionScopesRequest {
    
    /// <summary> Optional Argument for 'GetStudyExecutionScopes' (Int32?): Number of the page, which should be returned </summary>
    public Int32? page { get; set; } = null;
    
    /// <summary> Optional Argument for 'GetStudyExecutionScopes' (Int32?): Max count of StudyExecutionScopes which should be returned </summary>
    public Int32? pageSize { get; set; } = null;
    
  }
  
  /// <summary>
  /// Contains results from calling 'GetStudyExecutionScopes'.
  /// Method: Loads StudyExecutionScopes.
  /// </summary>
  public class GetStudyExecutionScopesResponse {
    
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
    public string fault { get; set; } = null;
    
    /// <summary> Return-Value of 'GetStudyExecutionScopes' (StudyExecutionScope[]) </summary>
    public StudyExecutionScope[] @return { get; set; }
    
  }
  
  /// <summary>
  /// Contains arguments for calling 'SearchStudyExecutionScopes'.
  /// Method: Loads StudyExecutionScopes where values matching to the given filterExpression
  /// </summary>
  public class SearchStudyExecutionScopesRequest {
    
    /// <summary> Required Argument for 'SearchStudyExecutionScopes' (string): a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </summary>
    [Required]
    public string filterExpression { get; set; }
    
    /// <summary> Optional Argument for 'SearchStudyExecutionScopes' (string): one or more property names which are used as sort order (before pagination) </summary>
    public string sortingExpression { get; set; }
    
    /// <summary> Optional Argument for 'SearchStudyExecutionScopes' (Int32?): Number of the page, which should be returned </summary>
    public Int32? page { get; set; } = null;
    
    /// <summary> Optional Argument for 'SearchStudyExecutionScopes' (Int32?): Max count of StudyExecutionScopes which should be returned </summary>
    public Int32? pageSize { get; set; } = null;
    
  }
  
  /// <summary>
  /// Contains results from calling 'SearchStudyExecutionScopes'.
  /// Method: Loads StudyExecutionScopes where values matching to the given filterExpression
  /// </summary>
  public class SearchStudyExecutionScopesResponse {
    
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
    public string fault { get; set; } = null;
    
    /// <summary> Return-Value of 'SearchStudyExecutionScopes' (StudyExecutionScope[]) </summary>
    public StudyExecutionScope[] @return { get; set; }
    
  }
  
  /// <summary>
  /// Contains arguments for calling 'AddNewStudyExecutionScope'.
  /// Method: Adds a new StudyExecutionScope and returns its primary identifier (or null on failure).
  /// </summary>
  public class AddNewStudyExecutionScopeRequest {
    
    /// <summary> Required Argument for 'AddNewStudyExecutionScope' (StudyExecutionScope): StudyExecutionScope containing the new values </summary>
    [Required]
    public StudyExecutionScope studyExecutionScope { get; set; }
    
  }
  
  /// <summary>
  /// Contains results from calling 'AddNewStudyExecutionScope'.
  /// Method: Adds a new StudyExecutionScope and returns its primary identifier (or null on failure).
  /// </summary>
  public class AddNewStudyExecutionScopeResponse {
    
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
    public string fault { get; set; } = null;
    
    /// <summary> Return-Value of 'AddNewStudyExecutionScope' (Boolean) </summary>
    public bool @return { get; set; }
    
  }
  
  /// <summary>
  /// Contains arguments for calling 'UpdateStudyExecutionScope'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given StudyExecutionScope addressed by the primary identifier fields within the given StudyExecutionScope. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateStudyExecutionScopeRequest {
    
    /// <summary> Required Argument for 'UpdateStudyExecutionScope' (StudyExecutionScope): StudyExecutionScope containing the new values (the primary identifier fields within the given StudyExecutionScope will be used to address the target record) </summary>
    [Required]
    public StudyExecutionScope studyExecutionScope { get; set; }
    
  }
  
  /// <summary>
  /// Contains results from calling 'UpdateStudyExecutionScope'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given StudyExecutionScope addressed by the primary identifier fields within the given StudyExecutionScope. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateStudyExecutionScopeResponse {
    
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
    public string fault { get; set; } = null;
    
    /// <summary> Return-Value of 'UpdateStudyExecutionScope' (Boolean) </summary>
    public bool @return { get; set; }
    
  }
  
  /// <summary>
  /// Contains arguments for calling 'UpdateStudyExecutionScopeByStudyExecutionIdentifier'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given StudyExecutionScope addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateStudyExecutionScopeByStudyExecutionIdentifierRequest {
    
    /// <summary> Required Argument for 'UpdateStudyExecutionScopeByStudyExecutionIdentifier' (Guid): a global unique id of a concrete study execution (dedicated to a concrete institute) which is usually originated at the primary CRF or study management system ('SMS') </summary>
    [Required]
    public Guid studyExecutionIdentifier { get; set; }
    
    /// <summary> Required Argument for 'UpdateStudyExecutionScopeByStudyExecutionIdentifier' (StudyExecutionScope): StudyExecutionScope containing the new values (the primary identifier fields within the given StudyExecutionScope will be ignored) </summary>
    [Required]
    public StudyExecutionScope studyExecutionScope { get; set; }
    
  }
  
  /// <summary>
  /// Contains results from calling 'UpdateStudyExecutionScopeByStudyExecutionIdentifier'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given StudyExecutionScope addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateStudyExecutionScopeByStudyExecutionIdentifierResponse {
    
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
    public string fault { get; set; } = null;
    
    /// <summary> Return-Value of 'UpdateStudyExecutionScopeByStudyExecutionIdentifier' (Boolean) </summary>
    public bool @return { get; set; }
    
  }
  
  /// <summary>
  /// Contains arguments for calling 'DeleteStudyExecutionScopeByStudyExecutionIdentifier'.
  /// Method: Deletes a specific StudyExecutionScope addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class DeleteStudyExecutionScopeByStudyExecutionIdentifierRequest {
    
    /// <summary> Required Argument for 'DeleteStudyExecutionScopeByStudyExecutionIdentifier' (Guid): a global unique id of a concrete study execution (dedicated to a concrete institute) which is usually originated at the primary CRF or study management system ('SMS') </summary>
    [Required]
    public Guid studyExecutionIdentifier { get; set; }
    
  }
  
  /// <summary>
  /// Contains results from calling 'DeleteStudyExecutionScopeByStudyExecutionIdentifier'.
  /// Method: Deletes a specific StudyExecutionScope addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class DeleteStudyExecutionScopeByStudyExecutionIdentifierResponse {
    
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
    public string fault { get; set; } = null;
    
    /// <summary> Return-Value of 'DeleteStudyExecutionScopeByStudyExecutionIdentifier' (Boolean) </summary>
    public bool @return { get; set; }
    
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetBillingDemandById'.
  /// Method: Loads a specific BillingDemand addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.
  /// </summary>
  public class GetBillingDemandByIdRequest {
    
    /// <summary> Required Argument for 'GetBillingDemandById' (Guid): Represents the primary identity of a BillingDemand </summary>
    [Required]
    public Guid id { get; set; }
    
  }
  
  /// <summary>
  /// Contains results from calling 'GetBillingDemandById'.
  /// Method: Loads a specific BillingDemand addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.
  /// </summary>
  public class GetBillingDemandByIdResponse {
    
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
    public string fault { get; set; } = null;
    
    /// <summary> Return-Value of 'GetBillingDemandById' (BillingDemand): created by the sponsor </summary>
    public BillingDemand @return { get; set; }
    
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetBillingDemands'.
  /// Method: Loads BillingDemands.
  /// </summary>
  public class GetBillingDemandsRequest {
    
    /// <summary> Optional Argument for 'GetBillingDemands' (Int32?): Number of the page, which should be returned </summary>
    public Int32? page { get; set; } = null;
    
    /// <summary> Optional Argument for 'GetBillingDemands' (Int32?): Max count of BillingDemands which should be returned </summary>
    public Int32? pageSize { get; set; } = null;
    
  }
  
  /// <summary>
  /// Contains results from calling 'GetBillingDemands'.
  /// Method: Loads BillingDemands.
  /// </summary>
  public class GetBillingDemandsResponse {
    
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
    public string fault { get; set; } = null;
    
    /// <summary> Return-Value of 'GetBillingDemands' (BillingDemand[]): created by the sponsor </summary>
    public BillingDemand[] @return { get; set; }
    
  }
  
  /// <summary>
  /// Contains arguments for calling 'SearchBillingDemands'.
  /// Method: Loads BillingDemands where values matching to the given filterExpression
  /// </summary>
  public class SearchBillingDemandsRequest {
    
    /// <summary> Required Argument for 'SearchBillingDemands' (string): a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </summary>
    [Required]
    public string filterExpression { get; set; }
    
    /// <summary> Optional Argument for 'SearchBillingDemands' (string): one or more property names which are used as sort order (before pagination) </summary>
    public string sortingExpression { get; set; }
    
    /// <summary> Optional Argument for 'SearchBillingDemands' (Int32?): Number of the page, which should be returned </summary>
    public Int32? page { get; set; } = null;
    
    /// <summary> Optional Argument for 'SearchBillingDemands' (Int32?): Max count of BillingDemands which should be returned </summary>
    public Int32? pageSize { get; set; } = null;
    
  }
  
  /// <summary>
  /// Contains results from calling 'SearchBillingDemands'.
  /// Method: Loads BillingDemands where values matching to the given filterExpression
  /// </summary>
  public class SearchBillingDemandsResponse {
    
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
    public string fault { get; set; } = null;
    
    /// <summary> Return-Value of 'SearchBillingDemands' (BillingDemand[]): created by the sponsor </summary>
    public BillingDemand[] @return { get; set; }
    
  }
  
  /// <summary>
  /// Contains arguments for calling 'AddNewBillingDemand'.
  /// Method: Adds a new BillingDemand and returns its primary identifier (or null on failure).
  /// </summary>
  public class AddNewBillingDemandRequest {
    
    /// <summary> Required Argument for 'AddNewBillingDemand' (BillingDemand): BillingDemand containing the new values </summary>
    [Required]
    public BillingDemand billingDemand { get; set; }
    
  }
  
  /// <summary>
  /// Contains results from calling 'AddNewBillingDemand'.
  /// Method: Adds a new BillingDemand and returns its primary identifier (or null on failure).
  /// </summary>
  public class AddNewBillingDemandResponse {
    
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
    public string fault { get; set; } = null;
    
    /// <summary> Return-Value of 'AddNewBillingDemand' (Boolean) </summary>
    public bool @return { get; set; }
    
  }
  
  /// <summary>
  /// Contains arguments for calling 'UpdateBillingDemand'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given BillingDemand addressed by the primary identifier fields within the given BillingDemand. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateBillingDemandRequest {
    
    /// <summary> Required Argument for 'UpdateBillingDemand' (BillingDemand): BillingDemand containing the new values (the primary identifier fields within the given BillingDemand will be used to address the target record) </summary>
    [Required]
    public BillingDemand billingDemand { get; set; }
    
  }
  
  /// <summary>
  /// Contains results from calling 'UpdateBillingDemand'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given BillingDemand addressed by the primary identifier fields within the given BillingDemand. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateBillingDemandResponse {
    
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
    public string fault { get; set; } = null;
    
    /// <summary> Return-Value of 'UpdateBillingDemand' (Boolean) </summary>
    public bool @return { get; set; }
    
  }
  
  /// <summary>
  /// Contains arguments for calling 'UpdateBillingDemandById'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given BillingDemand addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateBillingDemandByIdRequest {
    
    /// <summary> Required Argument for 'UpdateBillingDemandById' (Guid): Represents the primary identity of a BillingDemand </summary>
    [Required]
    public Guid id { get; set; }
    
    /// <summary> Required Argument for 'UpdateBillingDemandById' (BillingDemand): BillingDemand containing the new values (the primary identifier fields within the given BillingDemand will be ignored) </summary>
    [Required]
    public BillingDemand billingDemand { get; set; }
    
  }
  
  /// <summary>
  /// Contains results from calling 'UpdateBillingDemandById'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given BillingDemand addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateBillingDemandByIdResponse {
    
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
    public string fault { get; set; } = null;
    
    /// <summary> Return-Value of 'UpdateBillingDemandById' (Boolean) </summary>
    public bool @return { get; set; }
    
  }
  
  /// <summary>
  /// Contains arguments for calling 'DeleteBillingDemandById'.
  /// Method: Deletes a specific BillingDemand addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class DeleteBillingDemandByIdRequest {
    
    /// <summary> Required Argument for 'DeleteBillingDemandById' (Guid): Represents the primary identity of a BillingDemand </summary>
    [Required]
    public Guid id { get; set; }
    
  }
  
  /// <summary>
  /// Contains results from calling 'DeleteBillingDemandById'.
  /// Method: Deletes a specific BillingDemand addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class DeleteBillingDemandByIdResponse {
    
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
    public string fault { get; set; } = null;
    
    /// <summary> Return-Value of 'DeleteBillingDemandById' (Boolean) </summary>
    public bool @return { get; set; }
    
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetInvoiceById'.
  /// Method: Loads a specific Invoice addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.
  /// </summary>
  public class GetInvoiceByIdRequest {
    
    /// <summary> Required Argument for 'GetInvoiceById' (Guid): Represents the primary identity of a Invoice </summary>
    [Required]
    public Guid id { get; set; }
    
  }
  
  /// <summary>
  /// Contains results from calling 'GetInvoiceById'.
  /// Method: Loads a specific Invoice addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.
  /// </summary>
  public class GetInvoiceByIdResponse {
    
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
    public string fault { get; set; } = null;
    
    /// <summary> Return-Value of 'GetInvoiceById' (Invoice): created by the executor-company </summary>
    public Invoice @return { get; set; }
    
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetInvoices'.
  /// Method: Loads Invoices.
  /// </summary>
  public class GetInvoicesRequest {
    
    /// <summary> Optional Argument for 'GetInvoices' (Int32?): Number of the page, which should be returned </summary>
    public Int32? page { get; set; } = null;
    
    /// <summary> Optional Argument for 'GetInvoices' (Int32?): Max count of Invoices which should be returned </summary>
    public Int32? pageSize { get; set; } = null;
    
  }
  
  /// <summary>
  /// Contains results from calling 'GetInvoices'.
  /// Method: Loads Invoices.
  /// </summary>
  public class GetInvoicesResponse {
    
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
    public string fault { get; set; } = null;
    
    /// <summary> Return-Value of 'GetInvoices' (Invoice[]): created by the executor-company </summary>
    public Invoice[] @return { get; set; }
    
  }
  
  /// <summary>
  /// Contains arguments for calling 'SearchInvoices'.
  /// Method: Loads Invoices where values matching to the given filterExpression
  /// </summary>
  public class SearchInvoicesRequest {
    
    /// <summary> Required Argument for 'SearchInvoices' (string): a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </summary>
    [Required]
    public string filterExpression { get; set; }
    
    /// <summary> Optional Argument for 'SearchInvoices' (string): one or more property names which are used as sort order (before pagination) </summary>
    public string sortingExpression { get; set; }
    
    /// <summary> Optional Argument for 'SearchInvoices' (Int32?): Number of the page, which should be returned </summary>
    public Int32? page { get; set; } = null;
    
    /// <summary> Optional Argument for 'SearchInvoices' (Int32?): Max count of Invoices which should be returned </summary>
    public Int32? pageSize { get; set; } = null;
    
  }
  
  /// <summary>
  /// Contains results from calling 'SearchInvoices'.
  /// Method: Loads Invoices where values matching to the given filterExpression
  /// </summary>
  public class SearchInvoicesResponse {
    
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
    public string fault { get; set; } = null;
    
    /// <summary> Return-Value of 'SearchInvoices' (Invoice[]): created by the executor-company </summary>
    public Invoice[] @return { get; set; }
    
  }
  
  /// <summary>
  /// Contains arguments for calling 'AddNewInvoice'.
  /// Method: Adds a new Invoice and returns its primary identifier (or null on failure).
  /// </summary>
  public class AddNewInvoiceRequest {
    
    /// <summary> Required Argument for 'AddNewInvoice' (Invoice): Invoice containing the new values </summary>
    [Required]
    public Invoice invoice { get; set; }
    
  }
  
  /// <summary>
  /// Contains results from calling 'AddNewInvoice'.
  /// Method: Adds a new Invoice and returns its primary identifier (or null on failure).
  /// </summary>
  public class AddNewInvoiceResponse {
    
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
    public string fault { get; set; } = null;
    
    /// <summary> Return-Value of 'AddNewInvoice' (Boolean) </summary>
    public bool @return { get; set; }
    
  }
  
  /// <summary>
  /// Contains arguments for calling 'UpdateInvoice'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given Invoice addressed by the primary identifier fields within the given Invoice. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateInvoiceRequest {
    
    /// <summary> Required Argument for 'UpdateInvoice' (Invoice): Invoice containing the new values (the primary identifier fields within the given Invoice will be used to address the target record) </summary>
    [Required]
    public Invoice invoice { get; set; }
    
  }
  
  /// <summary>
  /// Contains results from calling 'UpdateInvoice'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given Invoice addressed by the primary identifier fields within the given Invoice. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateInvoiceResponse {
    
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
    public string fault { get; set; } = null;
    
    /// <summary> Return-Value of 'UpdateInvoice' (Boolean) </summary>
    public bool @return { get; set; }
    
  }
  
  /// <summary>
  /// Contains arguments for calling 'UpdateInvoiceById'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given Invoice addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateInvoiceByIdRequest {
    
    /// <summary> Required Argument for 'UpdateInvoiceById' (Guid): Represents the primary identity of a Invoice </summary>
    [Required]
    public Guid id { get; set; }
    
    /// <summary> Required Argument for 'UpdateInvoiceById' (Invoice): Invoice containing the new values (the primary identifier fields within the given Invoice will be ignored) </summary>
    [Required]
    public Invoice invoice { get; set; }
    
  }
  
  /// <summary>
  /// Contains results from calling 'UpdateInvoiceById'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given Invoice addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateInvoiceByIdResponse {
    
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
    public string fault { get; set; } = null;
    
    /// <summary> Return-Value of 'UpdateInvoiceById' (Boolean) </summary>
    public bool @return { get; set; }
    
  }
  
  /// <summary>
  /// Contains arguments for calling 'DeleteInvoiceById'.
  /// Method: Deletes a specific Invoice addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class DeleteInvoiceByIdRequest {
    
    /// <summary> Required Argument for 'DeleteInvoiceById' (Guid): Represents the primary identity of a Invoice </summary>
    [Required]
    public Guid id { get; set; }
    
  }
  
  /// <summary>
  /// Contains results from calling 'DeleteInvoiceById'.
  /// Method: Deletes a specific Invoice addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class DeleteInvoiceByIdResponse {
    
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null) </summary>
    public string fault { get; set; } = null;
    
    /// <summary> Return-Value of 'DeleteInvoiceById' (Boolean) </summary>
    public bool @return { get; set; }
    
  }
  
}
