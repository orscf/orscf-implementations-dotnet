using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using H7 = Hl7.Fhir.Model;
using MedicalResearch.IdentityManagement.Model;

namespace MedicalResearch.IdentityManagement {

    /// <summary> Provides an workflow-level API for interating with a 'IdentityManagementSystem' (IMS) </summary>
    public partial interface IPseudonymizationService {

    /// <summary>
    /// 
    /// </summary>
    /// <param name="givenName">the Firstname a person (named as in the HL7 standard)</param>
    /// <param name="familyName"></param>
    /// <param name="birthDate">date in format 'yyyy-MM-dd' (must NOT be a partial date for this usecase!)</param>
    /// <param name="extendedFields"> additional values for each 'extendedField' that is mandatory within (and specific to) the current IMS-System. To retrieve the declarations for such fields call 'GetExtendedFieldDescriptors'</param>
    /// <param name="pseudonym"></param>
    /// <param name="wasCreatedNewly"></param>
    /// <returns></returns>
    bool GetOrCreatePseudonym(
      string givenName,
      string familyName,
      string birthDate,
      Dictionary<String,String> extendedFields,
      out string pseudonym,
      out bool wasCreatedNewly
    );

    /// <summary>
    /// 
    /// </summary>
    /// <param name="givenName"></param>
    /// <param name="familyName"></param>
    /// <param name="birthDate">date in format 'yyyy-MM-dd' (must NOT be a partial date for this usecase!)</param>
    /// <param name="extendedFields"> additional values for each 'extendedField' that is mandatory within (and specific to) the current IMS-System. To retrieve the declarations for such fields call 'GetExtendedFieldDescriptors' </param>
    /// <param name="pseudonym"></param>
    /// <returns></returns>
    bool GetExisitingPseudonym(
      string givenName,
      string familyName,
      string birthDate,
      Dictionary<String, String> extendedFields,
      out string pseudonym
    );

    ///// <summary>
    ///// Required
    ///// </summary>
    ///// <param name="researchStudyUid"></param>
    ///// <param name="siteNameUid"></param>
    ///// <param name="hl7Patient">
    ///// when using a <see href="https://hl7.org/fhir/2021may/patient.html">HL7-Patient</see> the following fields are required:  
    ///// <see href="https://hl7.org/fhir/2021may/datatypes-definitions.html#HumanName.given">name.given</see>, 
    ///// <see href="https://hl7.org/fhir/2021may/datatypes-definitions.html#HumanName.family">name.family</see>, 
    ///// <see href="https://hl7.org/fhir/2021may/patient-definitions.html#Patient.birthDate">.birthDate</see> 
    ///// </param>
    ///// <param name="extendedFields"></param>
    ///// <param name="pseudonym"></param>
    ///// <param name="wasCreatedNewly"></param>
    ///// <returns></returns>
    //bool GetOrCreatePseudonymHL7(
    //  Guid researchStudyUid,
    //  Guid siteNameUid,
    //  Model.HL7Compatibility.Patient hl7Patient,
    //  Dictionary<String, String> extendedFields,
    //  out string pseudonym,
    //  out bool wasCreatedNewly
    //);

    //bool GetExisitingPseudonymHL7(
    //  Guid researchStudyUid,
    //  Guid siteNameUid,
    //  Model.HL7Compatibility.Patient hl7Patient,
    //  Dictionary<String, String> extendedFields,
    //  out string pseudonym
    //);

  }

}
