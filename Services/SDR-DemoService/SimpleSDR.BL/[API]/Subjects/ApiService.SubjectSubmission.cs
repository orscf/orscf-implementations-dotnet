using MedicalResearch.SubjectData.Model;
using System;
using System.Collections.Generic;
using System.Data.AccessControl;
using System.Linq;
using System.Linq.Expressions;

namespace MedicalResearch.SubjectData {

  public partial class ApiService : ISubjectSubmissionService {

    public void ApplySubjectBatchMutation(Guid[] subjectUids, BatchableSubjectMutation mutation, out Guid[] updatedSubjectUids) {
      throw new NotImplementedException();
    }

    public void ApplySubjectMutations(Dictionary<Guid, SubjectMutation> mutationsBySubjecttUid, out Guid[] updatedSubjectUids) {
      throw new NotImplementedException();
    }

    public void ArchiveSubjects(Guid[] subjectUids, out Guid[] archivedSubjectUids) {
      throw new NotImplementedException();
    }

    public void ImportSubjects(SubjectStructure[] subjects, out Guid[] createdSubjectUids, out Guid[] updatedSubjectUids) {
      throw new NotImplementedException();
    }

    public void UnarchiveSubjects(Guid[] subjectUids, out Guid[] unarchivedSubjectUids) {
      throw new NotImplementedException();
    }

  }

}
