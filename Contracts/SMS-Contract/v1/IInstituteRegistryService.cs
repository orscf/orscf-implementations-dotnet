using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using H7 = Hl7.Fhir.Model;

namespace MedicalResearch.StudyManagement {

  /// <summary> Provides an workflow-level API for interating with a 'StudyManagementSystem' (SMS) </summary>
  public partial interface IInstituteRegistryService {

    Guid GetInstituteUidByTitle(string instituteTitle);

    string GetInstituteTitleByUid(Guid instituteUid);

    string ArchiveInstitute(Guid instituteUid);

    string GetInstituteInfos(Guid instituteUid);

    /// <summary>
    /// ensures, that an institute with the given Uid exists
    /// and returns true, if it has been newly created
    /// </summary>
    /// <param name="instituteUid"></param>
    /// <returns></returns>
    bool CreateInstituteIfMissing(Guid instituteUid);

    /// <summary>
    /// updated the title of the the institute or returns false, 
    /// if there is no record for the given instituteUid
    /// </summary>
    /// <param name="instituteUid"></param>
    /// <param name="newTitle"></param>
    /// <returns></returns>
    bool UpdateInstitueTitle(Guid instituteUid, string newTitle);

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
