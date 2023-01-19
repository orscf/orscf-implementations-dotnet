using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using H7 = Hl7.Fhir.Model;
using MedicalResearch.IdentityManagement.Model;

namespace MedicalResearch.IdentityManagement {

  /// <summary>
  /// Following the "ACTIVE-APPROVAL" Workflow, this endpoint is usually implemented on a FOREIGN system, that should be queried by an IMS!
  /// "ACTIVE-APPROVAL" is based on the idea, that clearances have to be requested on demand from a foreign master system  ('pull' principle)
  /// </summary>
  public partial interface IUnblindingClearanceGrantingService {

    /// <summary>
    /// Returns:
    ///  1: if clearance granted /
    ///  0: if no realtime response is possible (delayed approval)
    /// -1: if a new unblindingToken is required (because the current has expired or has been repressed) /
    /// -2: if the access is denied for addressed scope of data
    /// </summary>
    /// <param name="unblindingToken"></param>
    /// <param name="pseudonymsToUnblind"></param>
    /// <param name="accessRelatedDetails"> 
    /// an optional container that can contain for example the ipadress
    /// or JWT token of the accessor or some MFA related information</param>
    /// <returns></returns>
    int HasClearanceForUnblinding(
       string unblindingToken,
       string[] pseudonymsToUnblind,
       Dictionary<string,string> accessRelatedDetails //con contain the JWT, ipadrressen, ...
    );

  }

}
