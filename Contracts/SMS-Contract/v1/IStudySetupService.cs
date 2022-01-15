using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using H7 = Hl7.Fhir.Model;

namespace MedicalResearch.StudyManagement {

  /// <summary> Provides an workflow-level API for interating with a 'StudyManagementSystem' (SMS) </summary>
  public partial interface IStudySetupService {

    /// <summary>
    /// returns null, if there is no matching record
    /// </summary>
    /// <param name="studyIdentifier"></param>
    /// <returns></returns>
    string GetStudyTitleByIdentifier(string studyIdentifier);








  }

}
