using MedicalResearch.VisitData.Model;
using System;
using System.Data.AccessControl;
using System.Linq;

namespace MedicalResearch.VisitData {

  public partial class ApiService : IDataRecordingSubmissionService {

    public void ImportDataRecordings(
      DataRecordingStructure[] dataRecordings,
      out Guid[] createdDataRecordingUids,
      out Guid[] updatedDataRecordingUids
    ) {

      throw new NotImplementedException();
    }

  }

}
