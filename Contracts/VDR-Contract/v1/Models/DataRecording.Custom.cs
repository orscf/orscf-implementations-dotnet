using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MedicalResearch.VisitData.Model {


  public abstract class DataRecordingMetaRecord {

    [Required]
    public Guid DataRecordingUid { get; set; } = Guid.Empty;

    #region " Principals & Scopes "

    [Required]
    public Guid VisitUid { get; set; } = Guid.Empty;

    #endregion

    /// <summary>
    /// This is an internal managed field, which is related to the state of records dedicated to the database.
    /// It will be automatically set when a record is archived. A mapping during data import requires opt-in.
    /// </summary>
    [Required]
    public bool IsArchived { get; set; } = false;

    /// <summary>
    /// This is an internal managed field (UNIX-Timestamp), which is related to the state of records dedicated to the database.
    /// It will be automatically set to the current time when a record is created, updated, archived or unarchived,
    /// but cannot be updated from outside and must not be mapped during data imports.
    /// </summary>
    [Required]
    public long ModificationTimestampUtc { get; set; } = 0;

  }

  public partial class DataRecordingFields : DataRecordingMetaRecord {

    /// <summary> unique invariant name of ths task-procedure as defined in the 'StudyWorkflowDefinition' (originated from the sponsor) </summary>
    [Required]
    public String DataRecordingName { get; set; }

    /// <summary> title of the task execution as defined in the 'StudyWorkflowDefinition' (originated from the sponsor) </summary>
    [Required]
    public String TaskExecutionTitle { get; set; }

    /// <summary> the estimated date when the visit is scheduled *this field is optional </summary>
    public DateTime? ScheduledDateTimeUtc { get; set; }

    /// <summary> the real time, when the data was recorded *this field is optional </summary>
    public DateTime? ExecutionDateTimeUtc { get; set; }

    /// <summary> 0=Unscheduled / 1=Sheduled / 2=Executed / 3=AbortDuringExecution / 4=Skipped / 5=Removed </summary>
    [Required]
    public Int32 ExecutionState { get; set; }

    /// <summary> schema-url of the data which were stored inside of the 'RecordedData' field </summary>
    [Required]
    public String DataSchemaUrl { get; set; }

    /// <summary> additional notes regarding this dedcated execution (supplied by the execution person) *this field is optional (use null as value) </summary>
    public String NotesRegardingOutcome { get; set; }

    /// <summary> *this field is optional (use null as value) </summary>
    public String ExecutingPerson { get; set; }

    /// <summary>
    /// Custom fields as defined by the Service.
    /// Call 'GetCustomFieldDescriptors' to get information about supported/required fields.
    /// Any passed values for undefined fields will be ignored.
    /// </summary>
    public Dictionary<string, string> CustomFields { get; set; } = new Dictionary<string, string>();

  }

  /// The full structure of an ORSCF qualified 'Visit' containing all
  /// essential fields and the tree of dependend childs
  public class DataRecordingStructure : DataRecordingFields {

    /// <summary> RAW data, in the schema as defined at the 'DataSchemaUrl' </summary>
    [Required]
    public String RecordedData { get; set; }

  }

}
