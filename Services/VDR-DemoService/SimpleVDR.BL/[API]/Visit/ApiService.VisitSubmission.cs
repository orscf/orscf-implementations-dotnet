using MedicalResearch.VisitData.Model;
using System;
using System.Collections.Generic;
using System.Data.AccessControl;
using System.Linq;

namespace MedicalResearch.VisitData {

  public partial class ApiService : IVisitSubmissionService {

    public void ApplyVisitBatchMutation(Guid[] visitUids, BatchableVisitMutation mutation, out Guid[] updatedVisitUids) {
      throw new NotImplementedException();
    }

    public void ApplyVisitMutations(Dictionary<Guid, VisitMutation> mutationsByVisitUid, out Guid[] updatedVisitUids) {
      throw new NotImplementedException();
    }

    public void ArchiveVisits(Guid[] visitUids, out Guid[] archivedVisitUids) {
      throw new NotImplementedException();
    }

    public void ImportVisits(VisitStructure[] visits, out Guid[] importedVisitUids, out Guid[] updatedVisitUids) {
      throw new NotImplementedException();
    }

    public void UnarchiveVisits(Guid[] visitUids, out Guid[] unarchivedVisitUids) {
      throw new NotImplementedException();
    }



  }

}
