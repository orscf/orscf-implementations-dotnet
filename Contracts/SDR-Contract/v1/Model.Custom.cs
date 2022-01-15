using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using H7 = Hl7.Fhir.Model;
using MedicalResearch.SubjectData.Model;

namespace MedicalResearch.SubjectData.Model {

  public class IdentityDetails {
    public string FirstName { get; set; } = null;
    public string LastName { get; set; } = null;
    public string Email { get; set; } = null;
    public string Phone { get; set; } = null;
    public string Street { get; set; } = null;
    public string HouseNumber { get; set; } = null;
    public string PostCode { get; set; } = null;
    public string City { get; set; } = null;
    public string State { get; set; } = null;

    /// <summary> two letter ISO code </summary>
    public string Country { get; set; } = null;
    public DateTime? DateOfBirth { get; set; } = null;
    public DateTime? DateOfDeath { get; set; } = null;
  }

  public class UnblindingTokenInfo {

    public string token { get; set; } = null;

    /// 0: not activated yet, 1=activated (can be used for 'UnblindSubject'), 2=expired/already used
    public int state { get; set; } = 0;

    public string researchStudyName { get; set; } = null;
    public string subjectId { get; set; } = null;
    public string reason { get; set; } = null;
    public string requestingPerson { get; set; } = null;
  }


}
