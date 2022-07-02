using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using H7 = Hl7.Fhir.Model;
using MedicalResearch.StudyManagement.Model;

namespace MedicalResearch.StudyManagement {

  /// <summary> Provides an workflow-level API for interating with a 'StudyManagementSystem' (SMS) </summary>
  public partial interface IInstituteMgmtService {

    Guid GetInstituteUidByTitle(string instituteTitle);

    string GetInstituteTitleByUid(Guid instituteUid);

    string ArchiveInstitute(Guid instituteUid);

    InstituteInfo[] GetInstituteInfos(Guid instituteUid);

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

  }

}
