using MedicalResearch.VisitData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MedicalResearch.VisitData.WebAPI {
  
  /// <summary>
  /// Contains arguments for calling 'GetDataRecordingByTaskGuid'.
  /// Method: Loads a specific DataRecording addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.
  /// </summary>
  public class GetDataRecordingByTaskGuidRequest {
  
    /// <summary> Required Argument for 'GetDataRecordingByTaskGuid' (Guid): a global unique id of a concrete study-task execution which is usually originated at the primary CRF or study management system ('SMS') </summary>
    [Required]
    public Guid taskGuid { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'GetDataRecordingByTaskGuid'.
  /// Method: Loads a specific DataRecording addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.
  /// </summary>
  public class GetDataRecordingByTaskGuidResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'GetDataRecordingByTaskGuid' (DataRecording) </summary>
    public DataRecording @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetDataRecordings'.
  /// Method: Loads DataRecordings.
  /// </summary>
  public class GetDataRecordingsRequest {
  
    /// <summary> Optional Argument for 'GetDataRecordings' (Int32?): Number of the page, which should be returned </summary>
    public Int32? page { get; set; } = null;
  
    /// <summary> Optional Argument for 'GetDataRecordings' (Int32?): Max count of DataRecordings which should be returned </summary>
    public Int32? pageSize { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains results from calling 'GetDataRecordings'.
  /// Method: Loads DataRecordings.
  /// </summary>
  public class GetDataRecordingsResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'GetDataRecordings' (DataRecording[]) </summary>
    public DataRecording[] @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'SearchDataRecordings'.
  /// Method: Loads DataRecordings where values matching to the given filterExpression
  /// </summary>
  public class SearchDataRecordingsRequest {
  
    /// <summary> Required Argument for 'SearchDataRecordings' (String): a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </summary>
    [Required]
    public String filterExpression { get; set; }
  
    /// <summary> Optional Argument for 'SearchDataRecordings' (String): one or more property names which are used as sort order (before pagination) </summary>
    public String sortingExpression { get; set; }
  
    /// <summary> Optional Argument for 'SearchDataRecordings' (Int32?): Number of the page, which should be returned </summary>
    public Int32? page { get; set; } = null;
  
    /// <summary> Optional Argument for 'SearchDataRecordings' (Int32?): Max count of DataRecordings which should be returned </summary>
    public Int32? pageSize { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains results from calling 'SearchDataRecordings'.
  /// Method: Loads DataRecordings where values matching to the given filterExpression
  /// </summary>
  public class SearchDataRecordingsResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'SearchDataRecordings' (DataRecording[]) </summary>
    public DataRecording[] @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'AddNewDataRecording'.
  /// Method: Adds a new DataRecording and returns its primary identifier (or null on failure).
  /// </summary>
  public class AddNewDataRecordingRequest {
  
    /// <summary> Required Argument for 'AddNewDataRecording' (DataRecording): DataRecording containing the new values </summary>
    [Required]
    public DataRecording dataRecording { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'AddNewDataRecording'.
  /// Method: Adds a new DataRecording and returns its primary identifier (or null on failure).
  /// </summary>
  public class AddNewDataRecordingResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'AddNewDataRecording' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'UpdateDataRecording'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given DataRecording addressed by the primary identifier fields within the given DataRecording. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateDataRecordingRequest {
  
    /// <summary> Required Argument for 'UpdateDataRecording' (DataRecording): DataRecording containing the new values (the primary identifier fields within the given DataRecording will be used to address the target record) </summary>
    [Required]
    public DataRecording dataRecording { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'UpdateDataRecording'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given DataRecording addressed by the primary identifier fields within the given DataRecording. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateDataRecordingResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'UpdateDataRecording' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'UpdateDataRecordingByTaskGuid'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given DataRecording addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateDataRecordingByTaskGuidRequest {
  
    /// <summary> Required Argument for 'UpdateDataRecordingByTaskGuid' (Guid): a global unique id of a concrete study-task execution which is usually originated at the primary CRF or study management system ('SMS') </summary>
    [Required]
    public Guid taskGuid { get; set; }
  
    /// <summary> Required Argument for 'UpdateDataRecordingByTaskGuid' (DataRecording): DataRecording containing the new values (the primary identifier fields within the given DataRecording will be ignored) </summary>
    [Required]
    public DataRecording dataRecording { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'UpdateDataRecordingByTaskGuid'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given DataRecording addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateDataRecordingByTaskGuidResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'UpdateDataRecordingByTaskGuid' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'DeleteDataRecordingByTaskGuid'.
  /// Method: Deletes a specific DataRecording addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class DeleteDataRecordingByTaskGuidRequest {
  
    /// <summary> Required Argument for 'DeleteDataRecordingByTaskGuid' (Guid): a global unique id of a concrete study-task execution which is usually originated at the primary CRF or study management system ('SMS') </summary>
    [Required]
    public Guid taskGuid { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'DeleteDataRecordingByTaskGuid'.
  /// Method: Deletes a specific DataRecording addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class DeleteDataRecordingByTaskGuidResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'DeleteDataRecordingByTaskGuid' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetVisitByVisitGuid'.
  /// Method: Loads a specific Visit addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.
  /// </summary>
  public class GetVisitByVisitGuidRequest {
  
    /// <summary> Required Argument for 'GetVisitByVisitGuid' (Guid): a global unique id of a concrete study-visit execution which is usually originated at the primary CRF or study management system ('SMS') </summary>
    [Required]
    public Guid visitGuid { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'GetVisitByVisitGuid'.
  /// Method: Loads a specific Visit addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.
  /// </summary>
  public class GetVisitByVisitGuidResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'GetVisitByVisitGuid' (Visit) </summary>
    public Visit @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetVisits'.
  /// Method: Loads Visits.
  /// </summary>
  public class GetVisitsRequest {
  
    /// <summary> Optional Argument for 'GetVisits' (Int32?): Number of the page, which should be returned </summary>
    public Int32? page { get; set; } = null;
  
    /// <summary> Optional Argument for 'GetVisits' (Int32?): Max count of Visits which should be returned </summary>
    public Int32? pageSize { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains results from calling 'GetVisits'.
  /// Method: Loads Visits.
  /// </summary>
  public class GetVisitsResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'GetVisits' (Visit[]) </summary>
    public Visit[] @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'SearchVisits'.
  /// Method: Loads Visits where values matching to the given filterExpression
  /// </summary>
  public class SearchVisitsRequest {
  
    /// <summary> Required Argument for 'SearchVisits' (String): a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </summary>
    [Required]
    public String filterExpression { get; set; }
  
    /// <summary> Optional Argument for 'SearchVisits' (String): one or more property names which are used as sort order (before pagination) </summary>
    public String sortingExpression { get; set; }
  
    /// <summary> Optional Argument for 'SearchVisits' (Int32?): Number of the page, which should be returned </summary>
    public Int32? page { get; set; } = null;
  
    /// <summary> Optional Argument for 'SearchVisits' (Int32?): Max count of Visits which should be returned </summary>
    public Int32? pageSize { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains results from calling 'SearchVisits'.
  /// Method: Loads Visits where values matching to the given filterExpression
  /// </summary>
  public class SearchVisitsResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'SearchVisits' (Visit[]) </summary>
    public Visit[] @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'AddNewVisit'.
  /// Method: Adds a new Visit and returns its primary identifier (or null on failure).
  /// </summary>
  public class AddNewVisitRequest {
  
    /// <summary> Required Argument for 'AddNewVisit' (Visit): Visit containing the new values </summary>
    [Required]
    public Visit visit { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'AddNewVisit'.
  /// Method: Adds a new Visit and returns its primary identifier (or null on failure).
  /// </summary>
  public class AddNewVisitResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'AddNewVisit' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'UpdateVisit'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given Visit addressed by the primary identifier fields within the given Visit. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateVisitRequest {
  
    /// <summary> Required Argument for 'UpdateVisit' (Visit): Visit containing the new values (the primary identifier fields within the given Visit will be used to address the target record) </summary>
    [Required]
    public Visit visit { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'UpdateVisit'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given Visit addressed by the primary identifier fields within the given Visit. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateVisitResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'UpdateVisit' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'UpdateVisitByVisitGuid'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given Visit addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateVisitByVisitGuidRequest {
  
    /// <summary> Required Argument for 'UpdateVisitByVisitGuid' (Guid): a global unique id of a concrete study-visit execution which is usually originated at the primary CRF or study management system ('SMS') </summary>
    [Required]
    public Guid visitGuid { get; set; }
  
    /// <summary> Required Argument for 'UpdateVisitByVisitGuid' (Visit): Visit containing the new values (the primary identifier fields within the given Visit will be ignored) </summary>
    [Required]
    public Visit visit { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'UpdateVisitByVisitGuid'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given Visit addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateVisitByVisitGuidResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'UpdateVisitByVisitGuid' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'DeleteVisitByVisitGuid'.
  /// Method: Deletes a specific Visit addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class DeleteVisitByVisitGuidRequest {
  
    /// <summary> Required Argument for 'DeleteVisitByVisitGuid' (Guid): a global unique id of a concrete study-visit execution which is usually originated at the primary CRF or study management system ('SMS') </summary>
    [Required]
    public Guid visitGuid { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'DeleteVisitByVisitGuid'.
  /// Method: Deletes a specific Visit addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class DeleteVisitByVisitGuidResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'DeleteVisitByVisitGuid' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetDrugApplymentByTaskGuid'.
  /// Method: Loads a specific DrugApplyment addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.
  /// </summary>
  public class GetDrugApplymentByTaskGuidRequest {
  
    /// <summary> Required Argument for 'GetDrugApplymentByTaskGuid' (Guid): a global unique id of a concrete study-task execution which is usually originated at the primary CRF or study management system ('SMS') </summary>
    [Required]
    public Guid taskGuid { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'GetDrugApplymentByTaskGuid'.
  /// Method: Loads a specific DrugApplyment addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.
  /// </summary>
  public class GetDrugApplymentByTaskGuidResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'GetDrugApplymentByTaskGuid' (DrugApplyment) </summary>
    public DrugApplyment @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetDrugApplyments'.
  /// Method: Loads DrugApplyments.
  /// </summary>
  public class GetDrugApplymentsRequest {
  
    /// <summary> Optional Argument for 'GetDrugApplyments' (Int32?): Number of the page, which should be returned </summary>
    public Int32? page { get; set; } = null;
  
    /// <summary> Optional Argument for 'GetDrugApplyments' (Int32?): Max count of DrugApplyments which should be returned </summary>
    public Int32? pageSize { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains results from calling 'GetDrugApplyments'.
  /// Method: Loads DrugApplyments.
  /// </summary>
  public class GetDrugApplymentsResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'GetDrugApplyments' (DrugApplyment[]) </summary>
    public DrugApplyment[] @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'SearchDrugApplyments'.
  /// Method: Loads DrugApplyments where values matching to the given filterExpression
  /// </summary>
  public class SearchDrugApplymentsRequest {
  
    /// <summary> Required Argument for 'SearchDrugApplyments' (String): a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </summary>
    [Required]
    public String filterExpression { get; set; }
  
    /// <summary> Optional Argument for 'SearchDrugApplyments' (String): one or more property names which are used as sort order (before pagination) </summary>
    public String sortingExpression { get; set; }
  
    /// <summary> Optional Argument for 'SearchDrugApplyments' (Int32?): Number of the page, which should be returned </summary>
    public Int32? page { get; set; } = null;
  
    /// <summary> Optional Argument for 'SearchDrugApplyments' (Int32?): Max count of DrugApplyments which should be returned </summary>
    public Int32? pageSize { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains results from calling 'SearchDrugApplyments'.
  /// Method: Loads DrugApplyments where values matching to the given filterExpression
  /// </summary>
  public class SearchDrugApplymentsResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'SearchDrugApplyments' (DrugApplyment[]) </summary>
    public DrugApplyment[] @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'AddNewDrugApplyment'.
  /// Method: Adds a new DrugApplyment and returns its primary identifier (or null on failure).
  /// </summary>
  public class AddNewDrugApplymentRequest {
  
    /// <summary> Required Argument for 'AddNewDrugApplyment' (DrugApplyment): DrugApplyment containing the new values </summary>
    [Required]
    public DrugApplyment drugApplyment { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'AddNewDrugApplyment'.
  /// Method: Adds a new DrugApplyment and returns its primary identifier (or null on failure).
  /// </summary>
  public class AddNewDrugApplymentResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'AddNewDrugApplyment' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'UpdateDrugApplyment'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given DrugApplyment addressed by the primary identifier fields within the given DrugApplyment. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateDrugApplymentRequest {
  
    /// <summary> Required Argument for 'UpdateDrugApplyment' (DrugApplyment): DrugApplyment containing the new values (the primary identifier fields within the given DrugApplyment will be used to address the target record) </summary>
    [Required]
    public DrugApplyment drugApplyment { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'UpdateDrugApplyment'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given DrugApplyment addressed by the primary identifier fields within the given DrugApplyment. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateDrugApplymentResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'UpdateDrugApplyment' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'UpdateDrugApplymentByTaskGuid'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given DrugApplyment addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateDrugApplymentByTaskGuidRequest {
  
    /// <summary> Required Argument for 'UpdateDrugApplymentByTaskGuid' (Guid): a global unique id of a concrete study-task execution which is usually originated at the primary CRF or study management system ('SMS') </summary>
    [Required]
    public Guid taskGuid { get; set; }
  
    /// <summary> Required Argument for 'UpdateDrugApplymentByTaskGuid' (DrugApplyment): DrugApplyment containing the new values (the primary identifier fields within the given DrugApplyment will be ignored) </summary>
    [Required]
    public DrugApplyment drugApplyment { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'UpdateDrugApplymentByTaskGuid'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given DrugApplyment addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateDrugApplymentByTaskGuidResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'UpdateDrugApplymentByTaskGuid' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'DeleteDrugApplymentByTaskGuid'.
  /// Method: Deletes a specific DrugApplyment addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class DeleteDrugApplymentByTaskGuidRequest {
  
    /// <summary> Required Argument for 'DeleteDrugApplymentByTaskGuid' (Guid): a global unique id of a concrete study-task execution which is usually originated at the primary CRF or study management system ('SMS') </summary>
    [Required]
    public Guid taskGuid { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'DeleteDrugApplymentByTaskGuid'.
  /// Method: Deletes a specific DrugApplyment addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class DeleteDrugApplymentByTaskGuidResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'DeleteDrugApplymentByTaskGuid' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetStudyEventByEventGuid'.
  /// Method: Loads a specific StudyEvent addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.
  /// </summary>
  public class GetStudyEventByEventGuidRequest {
  
    /// <summary> Required Argument for 'GetStudyEventByEventGuid' (Guid): a global unique id of a concrete study-event occurrence which is usually originated at the primary CRF or study management system ('SMS') </summary>
    [Required]
    public Guid eventGuid { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'GetStudyEventByEventGuid'.
  /// Method: Loads a specific StudyEvent addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.
  /// </summary>
  public class GetStudyEventByEventGuidResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'GetStudyEventByEventGuid' (StudyEvent) </summary>
    public StudyEvent @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetStudyEvents'.
  /// Method: Loads StudyEvents.
  /// </summary>
  public class GetStudyEventsRequest {
  
    /// <summary> Optional Argument for 'GetStudyEvents' (Int32?): Number of the page, which should be returned </summary>
    public Int32? page { get; set; } = null;
  
    /// <summary> Optional Argument for 'GetStudyEvents' (Int32?): Max count of StudyEvents which should be returned </summary>
    public Int32? pageSize { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains results from calling 'GetStudyEvents'.
  /// Method: Loads StudyEvents.
  /// </summary>
  public class GetStudyEventsResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'GetStudyEvents' (StudyEvent[]) </summary>
    public StudyEvent[] @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'SearchStudyEvents'.
  /// Method: Loads StudyEvents where values matching to the given filterExpression
  /// </summary>
  public class SearchStudyEventsRequest {
  
    /// <summary> Required Argument for 'SearchStudyEvents' (String): a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </summary>
    [Required]
    public String filterExpression { get; set; }
  
    /// <summary> Optional Argument for 'SearchStudyEvents' (String): one or more property names which are used as sort order (before pagination) </summary>
    public String sortingExpression { get; set; }
  
    /// <summary> Optional Argument for 'SearchStudyEvents' (Int32?): Number of the page, which should be returned </summary>
    public Int32? page { get; set; } = null;
  
    /// <summary> Optional Argument for 'SearchStudyEvents' (Int32?): Max count of StudyEvents which should be returned </summary>
    public Int32? pageSize { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains results from calling 'SearchStudyEvents'.
  /// Method: Loads StudyEvents where values matching to the given filterExpression
  /// </summary>
  public class SearchStudyEventsResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'SearchStudyEvents' (StudyEvent[]) </summary>
    public StudyEvent[] @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'AddNewStudyEvent'.
  /// Method: Adds a new StudyEvent and returns its primary identifier (or null on failure).
  /// </summary>
  public class AddNewStudyEventRequest {
  
    /// <summary> Required Argument for 'AddNewStudyEvent' (StudyEvent): StudyEvent containing the new values </summary>
    [Required]
    public StudyEvent studyEvent { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'AddNewStudyEvent'.
  /// Method: Adds a new StudyEvent and returns its primary identifier (or null on failure).
  /// </summary>
  public class AddNewStudyEventResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'AddNewStudyEvent' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'UpdateStudyEvent'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given StudyEvent addressed by the primary identifier fields within the given StudyEvent. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateStudyEventRequest {
  
    /// <summary> Required Argument for 'UpdateStudyEvent' (StudyEvent): StudyEvent containing the new values (the primary identifier fields within the given StudyEvent will be used to address the target record) </summary>
    [Required]
    public StudyEvent studyEvent { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'UpdateStudyEvent'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given StudyEvent addressed by the primary identifier fields within the given StudyEvent. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateStudyEventResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'UpdateStudyEvent' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'UpdateStudyEventByEventGuid'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given StudyEvent addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateStudyEventByEventGuidRequest {
  
    /// <summary> Required Argument for 'UpdateStudyEventByEventGuid' (Guid): a global unique id of a concrete study-event occurrence which is usually originated at the primary CRF or study management system ('SMS') </summary>
    [Required]
    public Guid eventGuid { get; set; }
  
    /// <summary> Required Argument for 'UpdateStudyEventByEventGuid' (StudyEvent): StudyEvent containing the new values (the primary identifier fields within the given StudyEvent will be ignored) </summary>
    [Required]
    public StudyEvent studyEvent { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'UpdateStudyEventByEventGuid'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given StudyEvent addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateStudyEventByEventGuidResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'UpdateStudyEventByEventGuid' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'DeleteStudyEventByEventGuid'.
  /// Method: Deletes a specific StudyEvent addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class DeleteStudyEventByEventGuidRequest {
  
    /// <summary> Required Argument for 'DeleteStudyEventByEventGuid' (Guid): a global unique id of a concrete study-event occurrence which is usually originated at the primary CRF or study management system ('SMS') </summary>
    [Required]
    public Guid eventGuid { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'DeleteStudyEventByEventGuid'.
  /// Method: Deletes a specific StudyEvent addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class DeleteStudyEventByEventGuidResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'DeleteStudyEventByEventGuid' (Boolean) </summary>
    public Boolean @return { get; set; }
  
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
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
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
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'GetStudyExecutionScopes' (StudyExecutionScope[]) </summary>
    public StudyExecutionScope[] @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'SearchStudyExecutionScopes'.
  /// Method: Loads StudyExecutionScopes where values matching to the given filterExpression
  /// </summary>
  public class SearchStudyExecutionScopesRequest {
  
    /// <summary> Required Argument for 'SearchStudyExecutionScopes' (String): a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </summary>
    [Required]
    public String filterExpression { get; set; }
  
    /// <summary> Optional Argument for 'SearchStudyExecutionScopes' (String): one or more property names which are used as sort order (before pagination) </summary>
    public String sortingExpression { get; set; }
  
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
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
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
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'AddNewStudyExecutionScope' (Boolean) </summary>
    public Boolean @return { get; set; }
  
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
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'UpdateStudyExecutionScope' (Boolean) </summary>
    public Boolean @return { get; set; }
  
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
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'UpdateStudyExecutionScopeByStudyExecutionIdentifier' (Boolean) </summary>
    public Boolean @return { get; set; }
  
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
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'DeleteStudyExecutionScopeByStudyExecutionIdentifier' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetTreatmentByTaskGuid'.
  /// Method: Loads a specific Treatment addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.
  /// </summary>
  public class GetTreatmentByTaskGuidRequest {
  
    /// <summary> Required Argument for 'GetTreatmentByTaskGuid' (Guid): a global unique id of a concrete study-task execution which is usually originated at the primary CRF or study management system ('SMS') </summary>
    [Required]
    public Guid taskGuid { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'GetTreatmentByTaskGuid'.
  /// Method: Loads a specific Treatment addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.
  /// </summary>
  public class GetTreatmentByTaskGuidResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'GetTreatmentByTaskGuid' (Treatment) </summary>
    public Treatment @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetTreatments'.
  /// Method: Loads Treatments.
  /// </summary>
  public class GetTreatmentsRequest {
  
    /// <summary> Optional Argument for 'GetTreatments' (Int32?): Number of the page, which should be returned </summary>
    public Int32? page { get; set; } = null;
  
    /// <summary> Optional Argument for 'GetTreatments' (Int32?): Max count of Treatments which should be returned </summary>
    public Int32? pageSize { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains results from calling 'GetTreatments'.
  /// Method: Loads Treatments.
  /// </summary>
  public class GetTreatmentsResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'GetTreatments' (Treatment[]) </summary>
    public Treatment[] @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'SearchTreatments'.
  /// Method: Loads Treatments where values matching to the given filterExpression
  /// </summary>
  public class SearchTreatmentsRequest {
  
    /// <summary> Required Argument for 'SearchTreatments' (String): a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </summary>
    [Required]
    public String filterExpression { get; set; }
  
    /// <summary> Optional Argument for 'SearchTreatments' (String): one or more property names which are used as sort order (before pagination) </summary>
    public String sortingExpression { get; set; }
  
    /// <summary> Optional Argument for 'SearchTreatments' (Int32?): Number of the page, which should be returned </summary>
    public Int32? page { get; set; } = null;
  
    /// <summary> Optional Argument for 'SearchTreatments' (Int32?): Max count of Treatments which should be returned </summary>
    public Int32? pageSize { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains results from calling 'SearchTreatments'.
  /// Method: Loads Treatments where values matching to the given filterExpression
  /// </summary>
  public class SearchTreatmentsResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'SearchTreatments' (Treatment[]) </summary>
    public Treatment[] @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'AddNewTreatment'.
  /// Method: Adds a new Treatment and returns its primary identifier (or null on failure).
  /// </summary>
  public class AddNewTreatmentRequest {
  
    /// <summary> Required Argument for 'AddNewTreatment' (Treatment): Treatment containing the new values </summary>
    [Required]
    public Treatment treatment { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'AddNewTreatment'.
  /// Method: Adds a new Treatment and returns its primary identifier (or null on failure).
  /// </summary>
  public class AddNewTreatmentResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'AddNewTreatment' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'UpdateTreatment'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given Treatment addressed by the primary identifier fields within the given Treatment. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateTreatmentRequest {
  
    /// <summary> Required Argument for 'UpdateTreatment' (Treatment): Treatment containing the new values (the primary identifier fields within the given Treatment will be used to address the target record) </summary>
    [Required]
    public Treatment treatment { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'UpdateTreatment'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given Treatment addressed by the primary identifier fields within the given Treatment. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateTreatmentResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'UpdateTreatment' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'UpdateTreatmentByTaskGuid'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given Treatment addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateTreatmentByTaskGuidRequest {
  
    /// <summary> Required Argument for 'UpdateTreatmentByTaskGuid' (Guid): a global unique id of a concrete study-task execution which is usually originated at the primary CRF or study management system ('SMS') </summary>
    [Required]
    public Guid taskGuid { get; set; }
  
    /// <summary> Required Argument for 'UpdateTreatmentByTaskGuid' (Treatment): Treatment containing the new values (the primary identifier fields within the given Treatment will be ignored) </summary>
    [Required]
    public Treatment treatment { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'UpdateTreatmentByTaskGuid'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given Treatment addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateTreatmentByTaskGuidResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'UpdateTreatmentByTaskGuid' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'DeleteTreatmentByTaskGuid'.
  /// Method: Deletes a specific Treatment addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class DeleteTreatmentByTaskGuidRequest {
  
    /// <summary> Required Argument for 'DeleteTreatmentByTaskGuid' (Guid): a global unique id of a concrete study-task execution which is usually originated at the primary CRF or study management system ('SMS') </summary>
    [Required]
    public Guid taskGuid { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'DeleteTreatmentByTaskGuid'.
  /// Method: Deletes a specific Treatment addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class DeleteTreatmentByTaskGuidResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'DeleteTreatmentByTaskGuid' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
}
