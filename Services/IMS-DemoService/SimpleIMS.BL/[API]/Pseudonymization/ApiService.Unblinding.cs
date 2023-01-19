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

  partial class ApiService : IUnblindingService {
    public int RequestUnblindingToken(string[] pseudonymsToUnblind, string requestReason, string requestBy, out string unblindingToken) {
      throw new NotImplementedException();
    }

    public int TryUnblind(string unblindingToken, string[] pseudonymsToUnblind, IdentityDetails[] unblindedIdentities) {
      throw new NotImplementedException();
    }
  }

}
