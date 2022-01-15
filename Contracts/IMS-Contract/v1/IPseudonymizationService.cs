using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using H7 = Hl7.Fhir.Model;
using MedicalResearch.IdentityManagement.Model;

namespace MedicalResearch.IdentityManagement {

  namespace Model {

    public class ExtendedFieldDescriptor {

      [Required]
      public string TechnicalName { get; set; }

      [Required]
      public bool IsRequired { get; set; }

      [Required]
      public string DisplayLabel { get; set; }

      public string InputDescription { get; set; }

      public string RegularExpression { get; set; }

    }

  }

    /// <summary> Provides an workflow-level API for interating with a 'IdentityManagementSystem' (IMS) </summary>
    public partial interface IPseudonymizationService {

    /// <summary>
    /// 
    /// </summary>
    /// <param name="languagePref">Preferred language for the 'DisplayLabel' and 'InputDescription' fields of the returned descriptors.</param>
    /// <returns></returns>
    ExtendedFieldDescriptor[] GetExtendedFieldDescriptors(
      string languagePref = "EN"
    );

    /// <summary>
    /// 
    /// </summary>
    /// <param name="researchStudyUid">A UUID</param>
    /// <param name="givenName">the Firstname a the paticipant (named as in the HL7 standard)</param>
    /// <param name="familyName"></param>
    /// <param name="birthDate">date in format 'yyyy-MM-dd' (must NOT be a partial date for this usecase!)</param>
    /// <param name="extendedFields"></param>
    /// <param name="siteUid">A UUID</param>
    /// <param name="pseudonym"></param>
    /// <param name="wasCreatedNewly"></param>
    /// <returns></returns>
    bool GetOrCreatePseudonym(
      Guid researchStudyUid,
      string givenName,
      string familyName,
      string birthDate,
      Dictionary<String,String> extendedFields,
      Guid siteUid,
      out string pseudonym,
      out bool wasCreatedNewly
    );


    /// <summary>
    /// 
    /// </summary>
    /// <param name="researchStudyUid">A UUID</param>
    /// <param name="givenName"></param>
    /// <param name="familyName"></param>
    /// <param name="birthDate">date in format 'yyyy-MM-dd' (must NOT be a partial date for this usecase!)</param>
    /// <param name="extendedFields"></param>
    /// <param name="pseudonym"></param>
    /// <returns></returns>
    bool GetExisitingPseudonym(
      Guid researchStudyUid,
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
