using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using H7 = Hl7.Fhir.Model;
using MedicalResearch.IdentityManagement.Model;

namespace MedicalResearch.IdentityManagement {

  /// <summary> Provides an workflow-level API for interating with a 'IdentityManagementSystem' (IMS) </summary>
  public partial interface IIdentityUnblindingService {

    /// <summary>
    /// returns an unblindingToken which is not activated
    /// </summary>
    /// <param name="researchStudyName"></param>
    /// <param name="subjectId"></param>
    /// <param name="reason"></param>
    /// <param name="requestingPerson"></param>
    /// <returns></returns>
    string RequestUnblindingToken(
      string researchStudyName,
      string subjectId,
      string reason,
      string requestingPerson
    );

    /// <summary>
    /// 0: not activated yet, 1=activated (can be used for 'UnblindSubject'), 2=expired/already used
    /// </summary>
    /// <param name="unblindingToken"></param>
    /// <returns></returns>
    int GetUnblindingTokenState(
      string unblindingToken
    );

    /// <summary>
    /// (only works with an activated unblindingOtp )
    /// </summary>
    /// <param name="researchStudyName"></param>
    /// <param name="subjectId"></param>
    /// <param name="unblindingToken"></param>
    /// <returns></returns>
    IdentityDetails UnblindSubject(
      string researchStudyName,
      string subjectId,
      string unblindingToken
    );

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
