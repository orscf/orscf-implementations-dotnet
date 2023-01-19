using System;
using System.Collections.Generic;
using System.Data.AccessControl;
using System.Linq;
using Hl7.Fhir.Model;
using MedicalResearch.IdentityManagement;
using MedicalResearch.IdentityManagement.Model;
using MedicalResearch.IdentityManagement.Persistence;
using MedicalResearch.IdentityManagement.Persistence.EF;
using Microsoft.EntityFrameworkCore;

namespace MedicalResearch.IdentityManagement {

  partial class ApiService : IUnblindingClearanceGrantingService {
    public int HasClearanceForUnblinding(string unblindingToken, string[] pseudonymsToUnblind, Dictionary<string, string> accessRelatedDetails) {
      throw new NotImplementedException();
    }
  }

}
