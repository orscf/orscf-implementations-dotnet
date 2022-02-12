using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using H7 = Hl7.Fhir.Model;
using MedicalResearch.SubjectData.Model;

namespace MedicalResearch.SubjectData {

  /// <summary> Provides an workflow-level API for interating with a 'SubjectDataRepository' (VDR) </summary>
  public partial interface ISubjectSubmissionService {

    /// <summary>
    /// 
    /// </summary>
    /// <param name="subjectUids"></param>
    /// <param name="archivedSubjectUids">also including the Uids of already archived records</param>
    /// <returns></returns>
    void ArchiveSubjects(
      Guid[] subjectUids,
      out Guid[] archivedSubjectUids
    );

    void UnarchiveSubjects(
      Guid[] subjectUids,
      out Guid[] unarchivedSubjectUids
    );

    void ApplySubjectMutations(
      Dictionary<Guid, SubjectMutation> mutationsBySubjecttUid,
      out Guid[] updatedSubjectUids
    );

    void ApplySubjectBatchMutation(
      Guid[] subjectUids,
      BatchableSubjectMutation mutation,
      out Guid[] updatedSubjectUids
    );

    //TODO: noch weitere Usecase optimiere funktionen UpdateState()

    void ImportSubjects(
      SubjectStructure[] subjects,
      out Guid[] createdSubjectUids,
      out Guid[] updatedSubjectUids
    );

  }

}
