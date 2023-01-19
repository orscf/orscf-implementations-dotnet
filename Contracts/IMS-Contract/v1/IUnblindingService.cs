using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using H7 = Hl7.Fhir.Model;
using MedicalResearch.IdentityManagement.Model;

namespace MedicalResearch.IdentityManagement {

  /// <summary> Provides an workflow-level API for interating with a 'IdentityManagementSystem' (IMS) </summary>
  public partial interface IUnblindingService {

    /// <summary>
    /// Returns:
    ///  1: if clearance granted (token can be DIRECTLY used to call 'TryUnblind') /
    ///  0: if no realtime response is possible (delayed approval is outstanding)
    /// -1: if a new unblindingToken is required (because the current has expired or has been repressed) /
    /// -2: if the access is denied for addressed scope of data
    /// </summary>
    /// <param name="pseudonymsToUnblind"></param>
    /// <param name="requestReason"></param>
    /// <param name="requestBy"></param>
    /// <param name="unblindingToken"></param>
    /// <returns></returns>
    int RequestUnblindingToken(
      string[] pseudonymsToUnblind,
      string requestReason,
      string requestBy,
      out string unblindingToken
    );

    /// <summary>
    /// Returns:
    ///  1: on SUCCESS (unblindedIdentities should contain data) /
    ///  0: if no realtime response is possible (delayed approval is outstanding)
    /// -1: if a new unblindingToken is required (because the current has expired or has been repressed) /
    /// -2: if the access is denied for addressed scope of data
    /// </summary>
    /// <param name="unblindingToken"></param>
    /// <param name="pseudonymsToUnblind"></param>
    /// <param name="unblindedIdentities"></param>
    /// <returns></returns>
    int TryUnblind(
       string unblindingToken,
       string[] pseudonymsToUnblind,
       IdentityDetails[] unblindedIdentities
    );

  }

}
