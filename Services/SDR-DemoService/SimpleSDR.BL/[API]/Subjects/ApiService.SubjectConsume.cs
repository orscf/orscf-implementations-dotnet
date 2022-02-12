using MedicalResearch.SubjectData.Model;
using System;
using System.Data.AccessControl;
using System.Linq;
using System.Linq.Expressions;

namespace MedicalResearch.SubjectData {

  public partial class ApiService : ISubjectConsumeService {


    public void CheckSubjectExisitence(Guid[] subjectUids, out Guid[] unavailableSubjectUids, out Guid[] availableSubjectUids) {
      throw new NotImplementedException();
    }

    public void ExportSubjects(Guid[] subjectUids, out Guid[] unavailableSubjectUids, out SubjectStructure[] result) {
      throw new NotImplementedException();
    }

    public CustomFieldDescriptor[] GetCustomFieldDescriptorsForSubject(string languagePref = "EN") {
      throw new NotImplementedException();
    }

    public void GetSubjectFields(Guid[] subjectUids, out Guid[] unavailableSubjectUids, out SubjectFields[] result) {
      throw new NotImplementedException();
    }

    public void SearchChangedSubjects(long minTimestampUtc, out long latestTimestampUtc, out SubjectMetaRecord[] createdRecords, out SubjectMetaRecord[] modifiedRecords, out SubjectMetaRecord[] archivedRecords, SubjectFilter filter = null) {
      throw new NotImplementedException();
    }

    public void SearchSubjects(out SubjectMetaRecord[] result, string sortingField = null, bool sortDescending = false, SubjectFilter filter = null, bool includeArchivedRecords = false, int limitResults = 0) {
      throw new NotImplementedException();
    }










  }

}
