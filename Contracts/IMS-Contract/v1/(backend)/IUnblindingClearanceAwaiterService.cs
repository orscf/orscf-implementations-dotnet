using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using H7 = Hl7.Fhir.Model;
using MedicalResearch.IdentityManagement.Model;

namespace MedicalResearch.IdentityManagement {

  /// <summary>
  /// Following the "PASSIVE-APPROVAL" Workflow, this endpoint is directly implemented on the IMS!
  /// "PASSIVE-APPROVAL" is based on the idea, that clearances have to be (pre-)delivered by a foreign master system ('push' principle) 
  /// </summary>
  public partial interface IUnblindingClearanceAwaiterService {
      void GrantClearanceForUnblinding(
        string unblindingToken,
        string[] pseudonymsToUnblind,
        DateTime grantedUnitl
      );
    }

}
