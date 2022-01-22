using MedicalResearch.VisitData.Model;
using System;
using System.Data.AccessControl;
using System.Linq;

namespace MedicalResearch.VisitData {

  public partial class ApiService : IVisitHL7ExportService {
    public bool ExportVisitFhirRessources(Guid visitUid, out VisitFhirRessourceContainer[] visitFhirRessources) {
      throw new NotImplementedException();
    }
  }

}
