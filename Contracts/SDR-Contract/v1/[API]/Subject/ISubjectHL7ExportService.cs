using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using H7 = Hl7.Fhir.Model;
using MedicalResearch.SubjectData.Model;

namespace MedicalResearch.SubjectData {

  /// <summary> Provides an workflow-level API for interating with a 'SubjectDataRepository' (VDR) </summary>
  public partial interface ISubjectHL7ExportService {

    /// <summary>
    /// Exports a structure containing HL7/FHIR-Ressources (JSON only) and
    /// the essential fields which are required to qualify a ORSCF record.
    /// </summary>
    /// <param name="subjectUid"></param>
    /// <param name="subjectFhirRessources"></param>
    /// <returns></returns>
    bool ExportSubjectFhirRessources(
      Guid subjectUid,
      out SubjectFhirRessourceContainer[] subjectFhirRessources
    );

  }

}
