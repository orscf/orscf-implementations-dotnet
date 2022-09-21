using MedicalResearch.VisitData.Model;
using MedicalResearch.VisitData.Persistence;
using MedicalResearch.VisitData.Persistence.EF;
using System;
using System.Data.AccessControl;
using System.Linq;

namespace MedicalResearch.VisitData {

  public partial class ApiService : IDataEnrollmentService {

    public Guid EnrollDataForVisitExplicit(Guid targetvisitUid, string taskExecutionTitle, DateTime executionDateTimeUtc, string dataSchemaKind, string dataSchemaUrl, string dataSchemaVersion, string dataLanguage, string recordedData) {

      var newRecordId = Guid.NewGuid();
      

      using (VisitDataDbContext db = new VisitDataDbContext()) {

        var targetVisit = db.Visits.Where(
          (v) => v.VisitGuid == targetvisitUid
        ).SingleOrDefault();

        if (targetVisit == null) {
          return Guid.Empty;
        }
        else {
          if (!targetVisit.ExecutionDateUtc.HasValue) {
            targetVisit.ExecutionDateUtc = executionDateTimeUtc.Date;
          }
          if (targetVisit.ExecutionState < 2) {
            targetVisit.ExecutionState = 2;
          }
        }

        var dr = new DataRecordingEntity();
        dr.TaskGuid = newRecordId;
        dr.VisitGuid = targetVisit.VisitGuid;
        dr.TaskExecutionTitle = taskExecutionTitle;
        dr.DataRecordingName = "??";
        dr.ExecutionState = 2;
        dr.ExecutionDateTimeUtc = executionDateTimeUtc;
        //dr.DataSchemaKind = dataSchemaKind;
        dr.DataSchemaUrl = dataSchemaUrl;
        //dr.DataSchemaVersion = dataSchemaVersion;
        //dr.DataLanguage = dataLanguage;
        dr.RecordedData = recordedData;
        db.DataRecordings.Add(dr);

        db.SaveChanges();
      };

      return newRecordId;
    }

    public Guid EnrollDataForVisitImplicit(
      Guid studyUid, string subjectIdentifier, string visitExecutionTitle,
      string taskExecutionTitle, DateTime executionDateTimeUtc,
      string dataSchemaKind, string dataSchemaUrl, string dataSchemaVersion,
      string dataLanguage, string recordedData
    ) {

      var newRecordId = Guid.NewGuid(); ;

      using (VisitDataDbContext db = new VisitDataDbContext()) {

        var targetVisit = db.Visits.Where(
          (v) => v.ParticipantIdentifier == subjectIdentifier && 
          v.StudyUid == studyUid && 
          v.VisitExecutionTitle == visitExecutionTitle
        ).SingleOrDefault();

        if (targetVisit == null) {
          targetVisit = new VisitEntity();
          targetVisit.VisitGuid = Guid.NewGuid();
          targetVisit.StudyUid = studyUid;
          targetVisit.ParticipantIdentifier = subjectIdentifier;
          targetVisit.VisitExecutionTitle = visitExecutionTitle;
          targetVisit.VisitProcedureName = "?";
          targetVisit.ExecutionDateUtc = executionDateTimeUtc.Date;
          targetVisit.ExecutionState = 2;
          db.Visits.Add(targetVisit);
        }
        else {
          if (!targetVisit.ExecutionDateUtc.HasValue) {
            targetVisit.ExecutionDateUtc = executionDateTimeUtc.Date;
          }
          if (targetVisit.ExecutionState < 2) {
            targetVisit.ExecutionState = 2;
          }
        }

        var dr = new DataRecordingEntity();
        dr.TaskGuid = newRecordId;
        dr.VisitGuid = targetVisit.VisitGuid;
        dr.TaskExecutionTitle = taskExecutionTitle;
        dr.DataRecordingName = "??";
        dr.ExecutionState = 2 ;
        dr.ExecutionDateTimeUtc = executionDateTimeUtc;
        //dr.DataSchemaKind = dataSchemaKind;
        dr.DataSchemaUrl = dataSchemaUrl;
        //dr.DataSchemaVersion = dataSchemaVersion;
        //dr.DataLanguage = dataLanguage;
        dr.RecordedData = recordedData;
        dr.ExtendedMetaData = "{}";//HTODO: MUSS OPTIONAL WERDEN!!!!!!!!!!!!!
        db.DataRecordings.Add(dr);

        db.SaveChanges();
      };

      return newRecordId;
    }

    public DataEnrollmentValidationState GetValidationState(Guid dataEnrollmentUid) {
       return DataEnrollmentValidationState.NotValidated;
    }

  }

}
