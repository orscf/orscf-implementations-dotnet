﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MedicalResearch.VisitData.Model {

  public class VisitFilter {

    public Guid? StudyUid { get; set; } = null;

    public Guid? SiteUid { get; set; } = null;

    /// <summary> 
    /// identity of the patient which is usually a pseudonym from a corr. 'IdentiyManagementSystem'
    /// (the exact semantic is defined per study)
    /// *this field has a max length of 100
    /// </summary>
    [MaxLength(100)]
    public String SubjectIdentifier { get; set; }

    #region " Content "

    public String VisitProdecureName { get; set; }

    /// <summary> unique title of the visit execution as defined in the 'StudyWorkflowDefinition' (originated from the sponsor) </summary>
    [Required]
    public String VisitExecutionTitle { get; set; }

    /// <summary> 0=Unscheduled / 1=Sheduled / 2=Executed / 3=AbortDuringExecution / 4=Skipped / 5=Removed </summary>
    public Int32? ExecutionState { get; set; }

    public DateTime? MinScheduledDateUtc { get; set; }
    public DateTime? MaxScheduledDateUtc { get; set; }

    public DateTime? MinExecutionDateUtc { get; set; }
    public DateTime? MaxExecutionDateUtc { get; set; }


    #endregion

    /// <summary>
    /// Custom fields as defined by the Service.
    /// Call 'GetCustomFieldDescriptors' to get information about supported/required fields.
    /// Any passed values for undefined fields will be ignored.
    /// </summary>
    public Dictionary<string, string> CustomFields { get; set; } = null;

  }

  public abstract class VisitMetaRecord {

    [Required]
    public Guid VisitUid { get; set; } = Guid.Empty;

    #region " Principals & Scopes "

    [Required]
    public Guid StudyUid { get; set; } = Guid.Empty;

    [Required]
    public Guid SiteUid { get; set; } = Guid.Empty;

    /// <summary> 
    /// identity of the patient which is usually a pseudonym from a corr. 'IdentiyManagementSystem'
    /// (the exact semantic is defined per study)
    /// *this field has a max length of 100
    /// </summary>
    [FixedAfterCreation, MaxLength(100), Required]
    public String SubjectIdentifier { get; set; }

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

  public partial class BatchableVisitMutation { 
  
    /// <summary> unique invariant name of the visit-procedure as defined in the 'StudyWorkflowDefinition' (originated from the sponsor) </summary>
    public String VisitProdecureName { get; set; }

    /// <summary> unique title of the visit execution as defined in the 'StudyWorkflowDefinition' (originated from the sponsor) </summary>
    public String VisitExecutionTitle { get; set; }

    /// <summary> 0=Unscheduled / 1=Sheduled / 2=Executed / 3=AbortDuringExecution / 4=Skipped / 5=Removed </summary>
    public Int32? ExecutionState { get; set; }

    /// <summary> *this field is optional (use null as value) </summary>
    public String ExecutingPerson { get; set; }

    /// <summary>
    /// Custom fields as defined by the Service.
    /// Call 'GetCustomFieldDescriptors' to get information about supported/required fields.
    /// Any passed values for undefined fields will be ignored.
    /// </summary>
    public Dictionary<string, string> CustomFields { get; set; } = new Dictionary<string, string>();

  }

  public partial class VisitMutation : BatchableVisitMutation {

    /// <summary> the estimated date when the visit is scheduled for execution *this field is optional </summary>
    public DateTime? ScheduledDateUtc { get; set; }

    /// <summary> the real date, when the visits was executed *this field is optional </summary>
    public DateTime? ExecutionDateUtc { get; set; }

  }

  public partial class VisitFields : VisitMetaRecord {

    ///// <summary> a global unique id of a concrete study-visit execution which is usually originated at the primary CRF or study management system ('SMS') </summary>
    //[FixedAfterCreation, Required]
    //public Guid VisitGuid { get; set; } = Guid.NewGuid();


    ///// <summary> a global unique id of a concrete study execution (dedicated to a concrete institute) which is usually originated at the primary CRF or study management system ('SMS') </summary>
    //[Required]
    //public Guid StudyExecutionIdentifier { get; set; }

    /// <summary> unique invariant name of the visit-procedure as defined in the 'StudyWorkflowDefinition' (originated from the sponsor) </summary>
    [Required]
    public String VisitProdecureName { get; set; }

    /// <summary> unique title of the visit execution as defined in the 'StudyWorkflowDefinition' (originated from the sponsor) </summary>
    [Required]
    public String VisitExecutionTitle { get; set; }

    /// <summary> the estimated date when the visit is scheduled for execution *this field is optional </summary>
    public Nullable<DateTime> ScheduledDateUtc { get; set; }

    /// <summary> the real date, when the visits was executed *this field is optional </summary>
    public Nullable<DateTime> ExecutionDateUtc { get; set; }

    /// <summary> 0=Unscheduled / 1=Sheduled / 2=Executed / 3=AbortDuringExecution / 4=Skipped / 5=Removed </summary>
    [Required]
    public Int32 ExecutionState { get; set; }

    ///// <summary> optional structure (in JSON-format) containing additional metadata regarding this record, which can be used by 'StudyExecutionSystems' to extend the schema *this field is optional (use null as value) </summary>
    //public String ExtendedMetaData { get; set; }

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
  public class VisitStructure : VisitFields {

    public DataRecordingStructure[] DataRecordings { get; set; } = new DataRecordingStructure[] {};

  }

  /// <summary>
  /// A structure containing HL7/FHIR-Ressources (JSON only) and
  /// the essential fields which are required to qualify a ORSCF record.
  /// </summary>
  public class VisitFhirRessourceContainer : VisitMetaRecord {

    /// <summary>a HL7 <see href="http://www.hl7.org/fhir/appointment.html">'Appointment'</see> resource in json format</summary>
    public Dictionary<string, Object> AppointmentRessource { get; set; } = null;

  }

}
