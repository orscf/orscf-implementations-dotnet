using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using MedicalResearch.IdentityManagement.Model;

namespace MedicalResearch.IdentityManagement.Persistence {

public class AdditionalSubjectParticipationIdentifierEntity {

  /// <summary> *this field has a max length of 50 </summary>
  [FixedAfterCreation, MaxLength(50), Required]
  public String ParticipantIdentifier { get; set; }

  /// <summary> *this field has a max length of 30 </summary>
  [FixedAfterCreation, MaxLength(30), Required]
  public String IdentifierName { get; set; }

  [Required]
  public String IdentifierValue { get; set; }

  [Required]
  public Guid ResearchStudyUid { get; set; } = Guid.NewGuid();

  [Principal]
  public virtual SubjectParticipationEntity Participation { get; set; }

#region Mapping

  internal static Expression<Func<AdditionalSubjectParticipationIdentifier, AdditionalSubjectParticipationIdentifierEntity>> AdditionalSubjectParticipationIdentifierEntitySelector = ((AdditionalSubjectParticipationIdentifier src) => new AdditionalSubjectParticipationIdentifierEntity {
    ParticipantIdentifier = src.ParticipantIdentifier,
    IdentifierName = src.IdentifierName,
    IdentifierValue = src.IdentifierValue,
    ResearchStudyUid = src.ResearchStudyUid,
  });

  internal static Expression<Func<AdditionalSubjectParticipationIdentifierEntity, AdditionalSubjectParticipationIdentifier>> AdditionalSubjectParticipationIdentifierSelector = ((AdditionalSubjectParticipationIdentifierEntity src) => new AdditionalSubjectParticipationIdentifier {
    ParticipantIdentifier = src.ParticipantIdentifier,
    IdentifierName = src.IdentifierName,
    IdentifierValue = src.IdentifierValue,
    ResearchStudyUid = src.ResearchStudyUid,
  });

  internal void CopyContentFrom(AdditionalSubjectParticipationIdentifier source, Func<String,bool> onFixedValueChangingCallback = null){
    if(!Equals(source.ParticipantIdentifier, this.ParticipantIdentifier)){
      if(onFixedValueChangingCallback == null || onFixedValueChangingCallback.Invoke(nameof(ParticipantIdentifier))){
        this.ParticipantIdentifier = source.ParticipantIdentifier;
      }
    }
    if(!Equals(source.IdentifierName, this.IdentifierName)){
      if(onFixedValueChangingCallback == null || onFixedValueChangingCallback.Invoke(nameof(IdentifierName))){
        this.IdentifierName = source.IdentifierName;
      }
    }
    this.IdentifierValue = source.IdentifierValue;
    this.ResearchStudyUid = source.ResearchStudyUid;
  }

  internal void CopyContentTo(AdditionalSubjectParticipationIdentifier target, Func<String,bool> onFixedValueChangingCallback = null){
    if(!Equals(target.ParticipantIdentifier, this.ParticipantIdentifier)){
      if(onFixedValueChangingCallback == null || onFixedValueChangingCallback.Invoke(nameof(ParticipantIdentifier))){
        target.ParticipantIdentifier = this.ParticipantIdentifier;
      }
    }
    if(!Equals(target.IdentifierName, this.IdentifierName)){
      if(onFixedValueChangingCallback == null || onFixedValueChangingCallback.Invoke(nameof(IdentifierName))){
        target.IdentifierName = this.IdentifierName;
      }
    }
    target.IdentifierValue = this.IdentifierValue;
    target.ResearchStudyUid = this.ResearchStudyUid;
  }

#endregion

}

public class SubjectParticipationEntity {

  /// <summary> pseudonym of the patient which can be a randomization or screening number (the exact semantic is defined per study) *this field has a max length of 50 </summary>
  [MaxLength(50), Required]
  public String ParticipantIdentifier { get; set; }

  [Required]
  public Guid ResearchStudyUid { get; set; } = Guid.NewGuid();

  [Required]
  public DateTime CreationDateUtc { get; set; }

  [Required]
  public Guid CreatedForStudyExecutionIdentifier { get; set; }

  /// <summary> *this field is optional </summary>
  public Nullable<Guid> SubjectIdentityRecordId { get; set; }

  [Dependent]
  public virtual ObservableCollection<AdditionalSubjectParticipationIdentifierEntity> AdditionalIdentifiers { get; set; } = new ObservableCollection<AdditionalSubjectParticipationIdentifierEntity>();

  [Lookup]
  public virtual StudyExecutionScopeEntity StudyExecutionScope { get; set; }

  [Principal]
  public virtual StudyScopeEntity StudyScope { get; set; }

  [Lookup]
  public virtual SubjectIdentityEntity Identity { get; set; }

#region Mapping

  internal static Expression<Func<SubjectParticipation, SubjectParticipationEntity>> SubjectParticipationEntitySelector = ((SubjectParticipation src) => new SubjectParticipationEntity {
    ParticipantIdentifier = src.ParticipantIdentifier,
    ResearchStudyUid = src.ResearchStudyUid,
    CreationDateUtc = src.CreationDateUtc,
    CreatedForStudyExecutionIdentifier = src.CreatedForStudyExecutionIdentifier,
    SubjectIdentityRecordId = src.SubjectIdentityRecordId,
  });

  internal static Expression<Func<SubjectParticipationEntity, SubjectParticipation>> SubjectParticipationSelector = ((SubjectParticipationEntity src) => new SubjectParticipation {
    ParticipantIdentifier = src.ParticipantIdentifier,
    ResearchStudyUid = src.ResearchStudyUid,
    CreationDateUtc = src.CreationDateUtc,
    CreatedForStudyExecutionIdentifier = src.CreatedForStudyExecutionIdentifier,
    SubjectIdentityRecordId = src.SubjectIdentityRecordId,
  });

  internal void CopyContentFrom(SubjectParticipation source, Func<String,bool> onFixedValueChangingCallback = null){
    this.ParticipantIdentifier = source.ParticipantIdentifier;
    this.ResearchStudyUid = source.ResearchStudyUid;
    this.CreationDateUtc = source.CreationDateUtc;
    this.CreatedForStudyExecutionIdentifier = source.CreatedForStudyExecutionIdentifier;
    this.SubjectIdentityRecordId = source.SubjectIdentityRecordId;
  }

  internal void CopyContentTo(SubjectParticipation target, Func<String,bool> onFixedValueChangingCallback = null){
    target.ParticipantIdentifier = this.ParticipantIdentifier;
    target.ResearchStudyUid = this.ResearchStudyUid;
    target.CreationDateUtc = this.CreationDateUtc;
    target.CreatedForStudyExecutionIdentifier = this.CreatedForStudyExecutionIdentifier;
    target.SubjectIdentityRecordId = this.SubjectIdentityRecordId;
  }

#endregion

}

public class StudyExecutionScopeEntity {

  /// <summary> a global unique id of a concrete study execution (dedicated to a concrete institute) which is usually originated at the primary CRF or study management system ('SMS') </summary>
  [Required]
  public Guid StudyExecutionIdentifier { get; set; } = Guid.NewGuid();

  /// <summary> the institute which is executing the study (this should be an invariant technical representation of the company name or a guid) </summary>
  [Required]
  public Guid SiteUid { get; set; }

  [Required]
  public Guid ResearchStudyUid { get; set; }

  [Principal]
  public virtual StudyScopeEntity StudyScope { get; set; }

  [Referer]
  public virtual ObservableCollection<SubjectParticipationEntity> CreatedParticipations { get; set; } = new ObservableCollection<SubjectParticipationEntity>();

#region Mapping

  internal static Expression<Func<StudyExecutionScope, StudyExecutionScopeEntity>> StudyExecutionScopeEntitySelector = ((StudyExecutionScope src) => new StudyExecutionScopeEntity {
    StudyExecutionIdentifier = src.StudyExecutionIdentifier,
    SiteUid = src.SiteUid,
    ResearchStudyUid = src.ResearchStudyUid,
  });

  internal static Expression<Func<StudyExecutionScopeEntity, StudyExecutionScope>> StudyExecutionScopeSelector = ((StudyExecutionScopeEntity src) => new StudyExecutionScope {
    StudyExecutionIdentifier = src.StudyExecutionIdentifier,
    SiteUid = src.SiteUid,
    ResearchStudyUid = src.ResearchStudyUid,
  });

  internal void CopyContentFrom(StudyExecutionScope source, Func<String,bool> onFixedValueChangingCallback = null){
    this.StudyExecutionIdentifier = source.StudyExecutionIdentifier;
    this.SiteUid = source.SiteUid;
    this.ResearchStudyUid = source.ResearchStudyUid;
  }

  internal void CopyContentTo(StudyExecutionScope target, Func<String,bool> onFixedValueChangingCallback = null){
    target.StudyExecutionIdentifier = this.StudyExecutionIdentifier;
    target.SiteUid = this.SiteUid;
    target.ResearchStudyUid = this.ResearchStudyUid;
  }

#endregion

}

public class StudyScopeEntity {

  /// <summary> the official invariant name of the study as given by the sponsor </summary>
  [FixedAfterCreation, Required]
  public Guid ResearchStudyUid { get; set; } = Guid.NewGuid();

  /// <summary> for example "Screening-Number" or "Randomization-Number" </summary>
  [Required]
  public String ParticipantIdentifierSemantic { get; set; }

  /// <summary> *this field has a max length of 100 </summary>
  [MaxLength(100), Required]
  public String StudyWorkflowName { get; set; }

  /// <summary> *this field has a max length of 20 </summary>
  [MaxLength(20), Required]
  public String StudyWorkflowVersion { get; set; }

  [Dependent]
  public virtual ObservableCollection<StudyExecutionScopeEntity> ExecutionScopes { get; set; } = new ObservableCollection<StudyExecutionScopeEntity>();

  [Dependent]
  public virtual ObservableCollection<SubjectParticipationEntity> Participations { get; set; } = new ObservableCollection<SubjectParticipationEntity>();

#region Mapping

  internal static Expression<Func<StudyScope, StudyScopeEntity>> StudyScopeEntitySelector = ((StudyScope src) => new StudyScopeEntity {
    ResearchStudyUid = src.ResearchStudyUid,
    ParticipantIdentifierSemantic = src.ParticipantIdentifierSemantic,
    StudyWorkflowName = src.StudyWorkflowName,
    StudyWorkflowVersion = src.StudyWorkflowVersion,
  });

  internal static Expression<Func<StudyScopeEntity, StudyScope>> StudyScopeSelector = ((StudyScopeEntity src) => new StudyScope {
    ResearchStudyUid = src.ResearchStudyUid,
    ParticipantIdentifierSemantic = src.ParticipantIdentifierSemantic,
    StudyWorkflowName = src.StudyWorkflowName,
    StudyWorkflowVersion = src.StudyWorkflowVersion,
  });

  internal void CopyContentFrom(StudyScope source, Func<String,bool> onFixedValueChangingCallback = null){
    if(!Equals(source.ResearchStudyUid, this.ResearchStudyUid)){
      if(onFixedValueChangingCallback == null || onFixedValueChangingCallback.Invoke(nameof(ResearchStudyUid))){
        this.ResearchStudyUid = source.ResearchStudyUid;
      }
    }
    this.ParticipantIdentifierSemantic = source.ParticipantIdentifierSemantic;
    this.StudyWorkflowName = source.StudyWorkflowName;
    this.StudyWorkflowVersion = source.StudyWorkflowVersion;
  }

  internal void CopyContentTo(StudyScope target, Func<String,bool> onFixedValueChangingCallback = null){
    if(!Equals(target.ResearchStudyUid, this.ResearchStudyUid)){
      if(onFixedValueChangingCallback == null || onFixedValueChangingCallback.Invoke(nameof(ResearchStudyUid))){
        target.ResearchStudyUid = this.ResearchStudyUid;
      }
    }
    target.ParticipantIdentifierSemantic = this.ParticipantIdentifierSemantic;
    target.StudyWorkflowName = this.StudyWorkflowName;
    target.StudyWorkflowVersion = this.StudyWorkflowVersion;
  }

#endregion

}

public class SubjectAddressEntity {

  [Required]
  public Guid InternalRecordId { get; set; } = Guid.NewGuid();

  [Required]
  public String Street { get; set; }

  [Required]
  public String HouseNumber { get; set; }

  [Required]
  public String PostCode { get; set; }

  [Required]
  public String City { get; set; }

  [Required]
  public String State { get; set; }

  [Required]
  public String Country { get; set; }

  /// <summary> *this field is optional (use null as value) </summary>
  public String PhoneNumber { get; set; }

  [Referer]
  public virtual ObservableCollection<SubjectIdentityEntity> SubjectIdentities { get; set; } = new ObservableCollection<SubjectIdentityEntity>();

#region Mapping

  internal static Expression<Func<SubjectAddress, SubjectAddressEntity>> SubjectAddressEntitySelector = ((SubjectAddress src) => new SubjectAddressEntity {
    InternalRecordId = src.InternalRecordId,
    Street = src.Street,
    HouseNumber = src.HouseNumber,
    PostCode = src.PostCode,
    City = src.City,
    State = src.State,
    Country = src.Country,
    PhoneNumber = src.PhoneNumber,
  });

  internal static Expression<Func<SubjectAddressEntity, SubjectAddress>> SubjectAddressSelector = ((SubjectAddressEntity src) => new SubjectAddress {
    InternalRecordId = src.InternalRecordId,
    Street = src.Street,
    HouseNumber = src.HouseNumber,
    PostCode = src.PostCode,
    City = src.City,
    State = src.State,
    Country = src.Country,
    PhoneNumber = src.PhoneNumber,
  });

  internal void CopyContentFrom(SubjectAddress source, Func<String,bool> onFixedValueChangingCallback = null){
    this.InternalRecordId = source.InternalRecordId;
    this.Street = source.Street;
    this.HouseNumber = source.HouseNumber;
    this.PostCode = source.PostCode;
    this.City = source.City;
    this.State = source.State;
    this.Country = source.Country;
    this.PhoneNumber = source.PhoneNumber;
  }

  internal void CopyContentTo(SubjectAddress target, Func<String,bool> onFixedValueChangingCallback = null){
    target.InternalRecordId = this.InternalRecordId;
    target.Street = this.Street;
    target.HouseNumber = this.HouseNumber;
    target.PostCode = this.PostCode;
    target.City = this.City;
    target.State = this.State;
    target.Country = this.Country;
    target.PhoneNumber = this.PhoneNumber;
  }

#endregion

}

public class SubjectIdentityEntity {

  [Required]
  public Guid RecordId { get; set; } = Guid.NewGuid();

  /// <summary> *this field is optional (use null as value) </summary>
  public String FirstName { get; set; }

  /// <summary> *this field is optional (use null as value) </summary>
  public String LastName { get; set; }

  /// <summary> 0=Male / 1=Female / 2=Other *this field is optional </summary>
  public Nullable<Int32> Gender { get; set; }

  /// <summary> *this field is optional </summary>
  public Nullable<DateTime> DateOfBirth { get; set; }

  /// <summary> *this field is optional </summary>
  public Nullable<DateTime> DateOfDeath { get; set; }

  /// <summary> can be used to specify the full salutation including all academic grades by a string containing the placeholders: "{G}"=Gender {F}="FirstName" {L}="LastName". If not specified, a generic fallback can be used *this field is optional (use null as value) </summary>
  public String FullNamePattern { get; set; }

  /// <summary> *this field is optional (use null as value) </summary>
  public String Language { get; set; }

  /// <summary> *this field is optional (use null as value) </summary>
  public String Notes { get; set; }

  /// <summary> *this field is optional (use null as value) </summary>
  public String Email { get; set; }

  /// <summary> *this field is optional (use null as value) </summary>
  public String MobileNumber { get; set; }

  /// <summary> *this field is optional </summary>
  public Nullable<Guid> ResidentAddressId { get; set; }

  [Lookup]
  public virtual SubjectAddressEntity ResidentAddress { get; set; }

  [Referer]
  public virtual ObservableCollection<SubjectParticipationEntity> Participations { get; set; } = new ObservableCollection<SubjectParticipationEntity>();

#region Mapping

  internal static Expression<Func<SubjectIdentity, SubjectIdentityEntity>> SubjectIdentityEntitySelector = ((SubjectIdentity src) => new SubjectIdentityEntity {
    RecordId = src.RecordId,
    FirstName = src.FirstName,
    LastName = src.LastName,
    Gender = src.Gender,
    DateOfBirth = src.DateOfBirth,
    DateOfDeath = src.DateOfDeath,
    FullNamePattern = src.FullNamePattern,
    Language = src.Language,
    Notes = src.Notes,
    Email = src.Email,
    MobileNumber = src.MobileNumber,
    ResidentAddressId = src.ResidentAddressId,
  });

  internal static Expression<Func<SubjectIdentityEntity, SubjectIdentity>> SubjectIdentitySelector = ((SubjectIdentityEntity src) => new SubjectIdentity {
    RecordId = src.RecordId,
    FirstName = src.FirstName,
    LastName = src.LastName,
    Gender = src.Gender,
    DateOfBirth = src.DateOfBirth,
    DateOfDeath = src.DateOfDeath,
    FullNamePattern = src.FullNamePattern,
    Language = src.Language,
    Notes = src.Notes,
    Email = src.Email,
    MobileNumber = src.MobileNumber,
    ResidentAddressId = src.ResidentAddressId,
  });

  internal void CopyContentFrom(SubjectIdentity source, Func<String,bool> onFixedValueChangingCallback = null){
    this.RecordId = source.RecordId;
    this.FirstName = source.FirstName;
    this.LastName = source.LastName;
    this.Gender = source.Gender;
    this.DateOfBirth = source.DateOfBirth;
    this.DateOfDeath = source.DateOfDeath;
    this.FullNamePattern = source.FullNamePattern;
    this.Language = source.Language;
    this.Notes = source.Notes;
    this.Email = source.Email;
    this.MobileNumber = source.MobileNumber;
    this.ResidentAddressId = source.ResidentAddressId;
  }

  internal void CopyContentTo(SubjectIdentity target, Func<String,bool> onFixedValueChangingCallback = null){
    target.RecordId = this.RecordId;
    target.FirstName = this.FirstName;
    target.LastName = this.LastName;
    target.Gender = this.Gender;
    target.DateOfBirth = this.DateOfBirth;
    target.DateOfDeath = this.DateOfDeath;
    target.FullNamePattern = this.FullNamePattern;
    target.Language = this.Language;
    target.Notes = this.Notes;
    target.Email = this.Email;
    target.MobileNumber = this.MobileNumber;
    target.ResidentAddressId = this.ResidentAddressId;
  }

#endregion

}

}
