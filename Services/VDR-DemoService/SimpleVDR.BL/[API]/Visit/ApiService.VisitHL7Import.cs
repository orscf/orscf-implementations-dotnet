using MedicalResearch.VisitData.Model;
using System;
using System.Data.AccessControl;
using System.Linq;

namespace MedicalResearch.VisitData {

  public partial class ApiService : IVisitHL7ImportService {
    public void ImportVisitFhirRessources(VisitFhirRessourceContainer[] visitFhirRessources, out Guid[] importedVisitUids, out Guid[] updatedVisitUids) {
      throw new NotImplementedException();
    }
  }

}
