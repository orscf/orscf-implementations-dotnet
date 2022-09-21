using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using H7 = Hl7.Fhir.Model;
using MedicalResearch.VisitData.Model;

namespace MedicalResearch.VisitData {

  /// <summary> Provides an workflow-level API for interating with a 'VisitDataRepository' (VDR) </summary>
  public partial interface IDataEnrollmentService {

    /// <summary>
    /// Enrolls recorded data to be stored as 'DataRecording'-Record related to a explicitly addressed Visit inside of this repository.
    /// This goes ahead with an validation process for each enrollment, therefore a dataEnrollmentUid will be returned
    /// which can be used to query the state of this process via 'GetValidationState'.
    /// </summary>
    /// <param name="targetvisitUid"> the ORSCF-Visit-UID to address the parent visit for which the given data should be submitted </param>
    /// <param name="taskExecutionTitle"> title of the task execution as defined in the 'StudyWorkflowDefinition' (originated from the sponsor) </param>
    /// <param name="executionDateTimeUtc"> the time, when the data was recorded </param>
    /// <param name="dataSchemaKind"> 'FhirQuestionaire' / 'XML' / 'CSV' / 'Custom' </param>
    /// <param name="dataSchemaUrl"> the schema-url of the data which were stored inside of the 'RecordedData' field </param>
    /// <param name="dataSchemaVersion"> version of schema, which is addressed by the 'DataSchemaUrl' </param>
    /// <param name="dataLanguage"> Language of free-text information inside of the data content </param>
    /// <param name="recordedData"> RAW data, in the schema as defined at the 'DataSchemaUrl' </param>
    /// <returns></returns>
    Guid EnrollDataForVisitExplicit(
      Guid targetvisitUid,
      String taskExecutionTitle,
      DateTime executionDateTimeUtc,
      String dataSchemaKind,
      String dataSchemaUrl,
      String dataSchemaVersion,
      String dataLanguage,
      String recordedData
    );

    /// <summary>
    /// Enrolls recorded data to be stored as 'DataRecording'-Record related to a visit inside of this repository
    /// (which is implicitely resolved using the given 'visitExecutionTitle' and 'subjectIdentifier') .
    /// This goes ahead with an validation process for each enrollment, therefore a dataEnrollmentUid will be returned
    /// which can be used to query the state of this process via 'GetValidationState'.
    /// </summary>
    /// <param name="studyUid"> the ORSCF-Study-UID which is used to lookup for the target visit for which the given data should be submitted </param>
    /// <param name="subjectIdentifier"> the study related identity of the patient (usually a pseudonym) which is used to lookup for the target visit for which the given data should be submitted </param>
    /// <param name="visitExecutionTitle">unique title of the visit execution as defined in the 'StudyWorkflowDefinition' which is used to lookup for the target visit for which the given data should be submitted </param>
    /// <param name="taskExecutionTitle"> title of the task execution as defined in the 'StudyWorkflowDefinition' (originated from the sponsor) </param>
    /// <param name="executionDateTimeUtc"> the time, when the data was recorded </param>
    /// <param name="dataSchemaKind"> 'FhirQuestionaire' / 'XML' / 'CSV' / 'Custom' </param>
    /// <param name="dataSchemaUrl"> the schema-url of the data which were stored inside of the 'RecordedData' field </param>
    /// <param name="dataSchemaVersion"> version of schema, which is addressed by the 'DataSchemaUrl' </param>
    /// <param name="dataLanguage"> Language of free-text information inside of the data content </param>
    /// <param name="recordedData"> RAW data, in the schema as defined at the 'DataSchemaUrl' </param>
    /// <returns></returns>
    Guid EnrollDataForVisitImplicit(
      Guid studyUid,
      String subjectIdentifier,
      String visitExecutionTitle,
      String taskExecutionTitle,
      DateTime executionDateTimeUtc,
      String dataSchemaKind,
      String dataSchemaUrl,
      String dataSchemaVersion,
      String dataLanguage,
      String recordedData
    );

    /// <summary>
    /// Providing the current validation state for a given data enrollment process
    /// </summary>
    /// <param name="dataEnrollmentUid"></param>
    /// <returns></returns>
    DataEnrollmentValidationState GetValidationState(Guid dataEnrollmentUid);

  }

}
