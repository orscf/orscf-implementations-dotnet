using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using H7 = Hl7.Fhir.Model;
using MedicalResearch.IdentityManagement.Model;

namespace MedicalResearch.IdentityManagement {

  /// <summary> Provides an workflow-level API for interating with a 'IdentityManagementSystem' (IMS) </summary>
  public partial interface IIdentityManagementService {

    /// <summary>
    /// returns the list of currently exposed unblinding-tokens
    /// </summary>
    /// <returns></returns>
    UnblindingTokenInfo[] GetUnblindingTokenInfos();

    /// <summary>
    /// unlocks an unblinding-token to be usable for retrieval of indentity information
    /// </summary>
    /// <param name="token"></param>
    void UnlockUnblindingToken(string token);

    /// <summary>
    /// returns the Version of the API itself, which can be used for 
    /// backward compatibility within inhomogeneous infrastructures
    /// </summary>
    string GetApiVersion();

    /// <summary>
    /// returns if the authenticated accessor of the
    /// API has the permission to use this service
    /// </summary>
    /// <returns></returns>
    bool HasAccess();

  }

}
