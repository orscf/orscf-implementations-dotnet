using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using H7 = Hl7.Fhir.Model;
using MedicalResearch.VisitData.Model;

namespace MedicalResearch.VisitData {

  /// <summary> Provides an workflow-level API for interating with a 'VisitDataRepository' (VDR) </summary>
  public partial interface IDataRecordingSubmissionService {

    ///// <summary>
    ///// 
    ///// </summary>
    ///// <param name="visitUids"></param>
    ///// <param name="archivedVisitUids">also including the Uids of already archived records</param>
    ///// <returns></returns>
    //void ArchiveVisits(
    //  Guid[] visitUids,
    //  out Guid[] archivedVisitUids
    //);

    //void UnarchiveVisits(
    //  Guid[] visitUids,
    //  out Guid[] unarchivedVisitUids
    //);

    //void ApplyVisitMutations(
    //  Dictionary<Guid, VisitMutation> mutationsByVisitUid,
    //  out Guid[] updatedVisitUids
    //);

    //void ApplyVisitBatchMutation(
    //  Guid[] visitUids,
    //  BatchableVisitMutation mutation,
    //  out Guid[] updatedVisitUids
    //);

    //TODO: noch weitere Usecase optimiere funktionen UpdateState()

    void ImportDataRecordings(
      DataRecordingStructure[] dataRecordings,
      out Guid[] createdDataRecordingUids,
      out Guid[] updatedDataRecordingUids
    );


  }

}
