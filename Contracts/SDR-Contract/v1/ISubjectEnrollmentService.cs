using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using H7 = Hl7.Fhir.Model;
using MedicalResearch.SubjectData.Model;

namespace MedicalResearch.SubjectData {

  /// <summary> Provides an workflow-level API for interating with a 'SubjectDataRepository' (SDR) </summary>
  public partial interface ISubjectEnrollmentService {

    /// <summary>
    /// returns the null on failure or the assigned SubjectIdentifier on success
    /// </summary>
    /// <param name="researchStudyName"></param>
    /// <param name="siteName"></param>
    /// <param name="dateOfEnrollment"></param>
    /// <param name="details"></param>
    /// <param name="preDefinedSubjectId"></param>
    /// <returns></returns>
    string EnrollIdentityAsSubject(
      string researchStudyName,
      string siteName,
      DateTime dateOfEnrollment,
      IdentityDetails details,
      string preDefinedSubjectId = null
    );

    bool UpdateIdentityInformationBySubjectId(
      string researchStudyName,
      string subjectId,
      IdentityDetails newDetails,
      bool clearUnsuppliedValues = false,
      string newSiteName = null
    );

    string GetSiteNameBySubjectId(
      string researchStudyName,
      string subjectId
    );

  }

}
