using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MedicalResearch.VisitData.Model {

  public class CustomFieldDescriptor {

    [Required]
    public string TechnicalName { get; set; }

    [Required]
    public bool IsRequired { get; set; }

    [Required]
    public string DisplayLabel { get; set; }

    public string InputDescription { get; set; }

    public string DefaultValue { get; set; }

    public string[] Presets { get; set; } = null;

    public bool PresetsOnly { get; set; } = false;

    public string RegularExpression { get; set; } = null;

  }

}
