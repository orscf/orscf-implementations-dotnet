﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using H7 = Hl7.Fhir.Model;
using MedicalResearch.VisitData.Model;

namespace MedicalResearch.VisitData {

  /// <summary> Provides an workflow-level API for interating with a 'VisitDataRepository' (VDR) </summary>
  public partial interface IVisitHL7ImportService {

    /// <summary>
    /// Exports a structure containing HL7/FHIR-Ressources (JSON only) and
    /// the essential fields which are required to qualify a ORSCF record.
    /// </summary>
    /// <param name="visitFhirRessources"></param>
    /// <param name="createdVisitUids"></param>
    /// <param name="updatedVisitUids"></param>
    /// <returns></returns>
    void ImportVisitFhirRessources(
       VisitFhirRessourceContainer[] visitFhirRessources,
       out Guid[] createdVisitUids,
       out Guid[] updatedVisitUids
     );

  }

}
