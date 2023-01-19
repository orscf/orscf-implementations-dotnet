using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using H7 = Hl7.Fhir.Model;
using MedicalResearch.IdentityManagement.Model;

namespace MedicalResearch.IdentityManagement.Model {

  public class IdentityDetails {

    /// <summary> 
    /// the firstname a person (named as in the HL7 standard) 
    /// </summary>
    [Required]
    public string GivenName { get; set; } = null;

    /// <summary>
    /// the lastname a person (named as in the HL7 standard)
    /// </summary>
    [Required]
    public string FamilyName { get; set; } = null;

    /// <summary>
    /// date in format 'yyyy-MM-dd' (must NOT be a partial date for this usecase!)
    /// </summary>
    [Required]
    public string BirthDate { get; set; } = null;

    /// <summary>
    /// additional values for each 'extendedField' that is mandatory within (and specific to) the current IMS-System.
    /// To retrieve the declarations for such fields call 'GetExtendedFieldDescriptors'
    /// </summary>
    public Dictionary<String, String> ExtendedFields { get; set; } = null;

  }

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
