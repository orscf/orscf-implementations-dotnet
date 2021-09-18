using MedicalResearch.IdentityManagement.Model;
using MedicalResearch.IdentityManagement.StoreAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MedicalResearch.IdentityManagement.WebAPI.DTOs {
  
  /// <summary>
  /// Contains arguments for calling 'GetAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentity'.
  /// Method: Loads a specific AdditionalSubjectParticipationIdentifier addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.
  /// </summary>
  public class GetAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentityRequest {
  
    /// <summary> Required Argument for 'GetAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentity' (AdditionalSubjectParticipationIdentifierIdentity): Composite Key, which represents the primary identity of a AdditionalSubjectParticipationIdentifier </summary>
    [Required]
    public AdditionalSubjectParticipationIdentifierIdentity additionalSubjectParticipationIdentifierIdentity { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'GetAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentity'.
  /// Method: Loads a specific AdditionalSubjectParticipationIdentifier addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.
  /// </summary>
  public class GetAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentityResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'GetAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentity' (AdditionalSubjectParticipationIdentifier) </summary>
    public AdditionalSubjectParticipationIdentifier @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetAdditionalSubjectParticipationIdentifiers'.
  /// Method: Loads AdditionalSubjectParticipationIdentifiers.
  /// </summary>
  public class GetAdditionalSubjectParticipationIdentifiersRequest {
  
    /// <summary> Optional Argument for 'GetAdditionalSubjectParticipationIdentifiers' (Int32?): Number of the page, which should be returned </summary>
    public Int32? page { get; set; } = null;
  
    /// <summary> Optional Argument for 'GetAdditionalSubjectParticipationIdentifiers' (Int32?): Max count of AdditionalSubjectParticipationIdentifiers which should be returned </summary>
    public Int32? pageSize { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains results from calling 'GetAdditionalSubjectParticipationIdentifiers'.
  /// Method: Loads AdditionalSubjectParticipationIdentifiers.
  /// </summary>
  public class GetAdditionalSubjectParticipationIdentifiersResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'GetAdditionalSubjectParticipationIdentifiers' (AdditionalSubjectParticipationIdentifier[]) </summary>
    public AdditionalSubjectParticipationIdentifier[] @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'SearchAdditionalSubjectParticipationIdentifiers'.
  /// Method: Loads AdditionalSubjectParticipationIdentifiers where values matching to the given filterExpression
  /// </summary>
  public class SearchAdditionalSubjectParticipationIdentifiersRequest {
  
    /// <summary> Required Argument for 'SearchAdditionalSubjectParticipationIdentifiers' (String): a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </summary>
    [Required]
    public String filterExpression { get; set; }
  
    /// <summary> Optional Argument for 'SearchAdditionalSubjectParticipationIdentifiers' (String): one or more property names which are used as sort order (before pagination) </summary>
    public String sortingExpression { get; set; }
  
    /// <summary> Optional Argument for 'SearchAdditionalSubjectParticipationIdentifiers' (Int32?): Number of the page, which should be returned </summary>
    public Int32? page { get; set; } = null;
  
    /// <summary> Optional Argument for 'SearchAdditionalSubjectParticipationIdentifiers' (Int32?): Max count of AdditionalSubjectParticipationIdentifiers which should be returned </summary>
    public Int32? pageSize { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains results from calling 'SearchAdditionalSubjectParticipationIdentifiers'.
  /// Method: Loads AdditionalSubjectParticipationIdentifiers where values matching to the given filterExpression
  /// </summary>
  public class SearchAdditionalSubjectParticipationIdentifiersResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'SearchAdditionalSubjectParticipationIdentifiers' (AdditionalSubjectParticipationIdentifier[]) </summary>
    public AdditionalSubjectParticipationIdentifier[] @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'AddNewAdditionalSubjectParticipationIdentifier'.
  /// Method: Adds a new AdditionalSubjectParticipationIdentifier and returns its primary identifier (or null on failure).
  /// </summary>
  public class AddNewAdditionalSubjectParticipationIdentifierRequest {
  
    /// <summary> Required Argument for 'AddNewAdditionalSubjectParticipationIdentifier' (AdditionalSubjectParticipationIdentifier): AdditionalSubjectParticipationIdentifier containing the new values </summary>
    [Required]
    public AdditionalSubjectParticipationIdentifier additionalSubjectParticipationIdentifier { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'AddNewAdditionalSubjectParticipationIdentifier'.
  /// Method: Adds a new AdditionalSubjectParticipationIdentifier and returns its primary identifier (or null on failure).
  /// </summary>
  public class AddNewAdditionalSubjectParticipationIdentifierResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'AddNewAdditionalSubjectParticipationIdentifier' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'UpdateAdditionalSubjectParticipationIdentifier'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given AdditionalSubjectParticipationIdentifier addressed by the primary identifier fields within the given AdditionalSubjectParticipationIdentifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateAdditionalSubjectParticipationIdentifierRequest {
  
    /// <summary> Required Argument for 'UpdateAdditionalSubjectParticipationIdentifier' (AdditionalSubjectParticipationIdentifier): AdditionalSubjectParticipationIdentifier containing the new values (the primary identifier fields within the given AdditionalSubjectParticipationIdentifier will be used to address the target record) </summary>
    [Required]
    public AdditionalSubjectParticipationIdentifier additionalSubjectParticipationIdentifier { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'UpdateAdditionalSubjectParticipationIdentifier'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given AdditionalSubjectParticipationIdentifier addressed by the primary identifier fields within the given AdditionalSubjectParticipationIdentifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateAdditionalSubjectParticipationIdentifierResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'UpdateAdditionalSubjectParticipationIdentifier' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'UpdateAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentity'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given AdditionalSubjectParticipationIdentifier addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentityRequest {
  
    /// <summary> Required Argument for 'UpdateAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentity' (AdditionalSubjectParticipationIdentifierIdentity): Composite Key, which represents the primary identity of a AdditionalSubjectParticipationIdentifier </summary>
    [Required]
    public AdditionalSubjectParticipationIdentifierIdentity additionalSubjectParticipationIdentifierIdentity { get; set; }
  
    /// <summary> Required Argument for 'UpdateAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentity' (AdditionalSubjectParticipationIdentifier): AdditionalSubjectParticipationIdentifier containing the new values (the primary identifier fields within the given AdditionalSubjectParticipationIdentifier will be ignored) </summary>
    [Required]
    public AdditionalSubjectParticipationIdentifier additionalSubjectParticipationIdentifier { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'UpdateAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentity'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given AdditionalSubjectParticipationIdentifier addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentityResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'UpdateAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentity' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'DeleteAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentity'.
  /// Method: Deletes a specific AdditionalSubjectParticipationIdentifier addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class DeleteAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentityRequest {
  
    /// <summary> Required Argument for 'DeleteAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentity' (AdditionalSubjectParticipationIdentifierIdentity): Composite Key, which represents the primary identity of a AdditionalSubjectParticipationIdentifier </summary>
    [Required]
    public AdditionalSubjectParticipationIdentifierIdentity additionalSubjectParticipationIdentifierIdentity { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'DeleteAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentity'.
  /// Method: Deletes a specific AdditionalSubjectParticipationIdentifier addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class DeleteAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentityResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'DeleteAdditionalSubjectParticipationIdentifierByAdditionalSubjectParticipationIdentifierIdentity' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetSubjectParticipationByParticipantIdentifier'.
  /// Method: Loads a specific SubjectParticipation addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.
  /// </summary>
  public class GetSubjectParticipationByParticipantIdentifierRequest {
  
    /// <summary> Required Argument for 'GetSubjectParticipationByParticipantIdentifier' (String): identity of the patient which can be a randomization or screening number (the exact semantic is defined per study) </summary>
    [Required]
    public String participantIdentifier { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'GetSubjectParticipationByParticipantIdentifier'.
  /// Method: Loads a specific SubjectParticipation addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.
  /// </summary>
  public class GetSubjectParticipationByParticipantIdentifierResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'GetSubjectParticipationByParticipantIdentifier' (SubjectParticipation) </summary>
    public SubjectParticipation @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetSubjectParticipations'.
  /// Method: Loads SubjectParticipations.
  /// </summary>
  public class GetSubjectParticipationsRequest {
  
    /// <summary> Optional Argument for 'GetSubjectParticipations' (Int32?): Number of the page, which should be returned </summary>
    public Int32? page { get; set; } = null;
  
    /// <summary> Optional Argument for 'GetSubjectParticipations' (Int32?): Max count of SubjectParticipations which should be returned </summary>
    public Int32? pageSize { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains results from calling 'GetSubjectParticipations'.
  /// Method: Loads SubjectParticipations.
  /// </summary>
  public class GetSubjectParticipationsResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'GetSubjectParticipations' (SubjectParticipation[]) </summary>
    public SubjectParticipation[] @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'SearchSubjectParticipations'.
  /// Method: Loads SubjectParticipations where values matching to the given filterExpression
  /// </summary>
  public class SearchSubjectParticipationsRequest {
  
    /// <summary> Required Argument for 'SearchSubjectParticipations' (String): a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </summary>
    [Required]
    public String filterExpression { get; set; }
  
    /// <summary> Optional Argument for 'SearchSubjectParticipations' (String): one or more property names which are used as sort order (before pagination) </summary>
    public String sortingExpression { get; set; }
  
    /// <summary> Optional Argument for 'SearchSubjectParticipations' (Int32?): Number of the page, which should be returned </summary>
    public Int32? page { get; set; } = null;
  
    /// <summary> Optional Argument for 'SearchSubjectParticipations' (Int32?): Max count of SubjectParticipations which should be returned </summary>
    public Int32? pageSize { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains results from calling 'SearchSubjectParticipations'.
  /// Method: Loads SubjectParticipations where values matching to the given filterExpression
  /// </summary>
  public class SearchSubjectParticipationsResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'SearchSubjectParticipations' (SubjectParticipation[]) </summary>
    public SubjectParticipation[] @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'AddNewSubjectParticipation'.
  /// Method: Adds a new SubjectParticipation and returns its primary identifier (or null on failure).
  /// </summary>
  public class AddNewSubjectParticipationRequest {
  
    /// <summary> Required Argument for 'AddNewSubjectParticipation' (SubjectParticipation): SubjectParticipation containing the new values </summary>
    [Required]
    public SubjectParticipation subjectParticipation { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'AddNewSubjectParticipation'.
  /// Method: Adds a new SubjectParticipation and returns its primary identifier (or null on failure).
  /// </summary>
  public class AddNewSubjectParticipationResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'AddNewSubjectParticipation' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'UpdateSubjectParticipation'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given SubjectParticipation addressed by the primary identifier fields within the given SubjectParticipation. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateSubjectParticipationRequest {
  
    /// <summary> Required Argument for 'UpdateSubjectParticipation' (SubjectParticipation): SubjectParticipation containing the new values (the primary identifier fields within the given SubjectParticipation will be used to address the target record) </summary>
    [Required]
    public SubjectParticipation subjectParticipation { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'UpdateSubjectParticipation'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given SubjectParticipation addressed by the primary identifier fields within the given SubjectParticipation. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateSubjectParticipationResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'UpdateSubjectParticipation' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'UpdateSubjectParticipationByParticipantIdentifier'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given SubjectParticipation addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateSubjectParticipationByParticipantIdentifierRequest {
  
    /// <summary> Required Argument for 'UpdateSubjectParticipationByParticipantIdentifier' (String): identity of the patient which can be a randomization or screening number (the exact semantic is defined per study) </summary>
    [Required]
    public String participantIdentifier { get; set; }
  
    /// <summary> Required Argument for 'UpdateSubjectParticipationByParticipantIdentifier' (SubjectParticipation): SubjectParticipation containing the new values (the primary identifier fields within the given SubjectParticipation will be ignored) </summary>
    [Required]
    public SubjectParticipation subjectParticipation { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'UpdateSubjectParticipationByParticipantIdentifier'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given SubjectParticipation addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateSubjectParticipationByParticipantIdentifierResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'UpdateSubjectParticipationByParticipantIdentifier' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'DeleteSubjectParticipationByParticipantIdentifier'.
  /// Method: Deletes a specific SubjectParticipation addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class DeleteSubjectParticipationByParticipantIdentifierRequest {
  
    /// <summary> Required Argument for 'DeleteSubjectParticipationByParticipantIdentifier' (String): identity of the patient which can be a randomization or screening number (the exact semantic is defined per study) </summary>
    [Required]
    public String participantIdentifier { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'DeleteSubjectParticipationByParticipantIdentifier'.
  /// Method: Deletes a specific SubjectParticipation addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class DeleteSubjectParticipationByParticipantIdentifierResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'DeleteSubjectParticipationByParticipantIdentifier' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetStudyExecutionScopeByStudyExecutionIdentifier'.
  /// Method: Loads a specific StudyExecutionScope addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.
  /// </summary>
  public class GetStudyExecutionScopeByStudyExecutionIdentifierRequest {
  
    /// <summary> Required Argument for 'GetStudyExecutionScopeByStudyExecutionIdentifier' (Guid): a global unique id of a concrete study execution (dedicated to a concrete institute) which is usually originated at the primary CRF or study management system ('SMS') </summary>
    [Required]
    public Guid studyExecutionIdentifier { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'GetStudyExecutionScopeByStudyExecutionIdentifier'.
  /// Method: Loads a specific StudyExecutionScope addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.
  /// </summary>
  public class GetStudyExecutionScopeByStudyExecutionIdentifierResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'GetStudyExecutionScopeByStudyExecutionIdentifier' (StudyExecutionScope) </summary>
    public StudyExecutionScope @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetStudyExecutionScopes'.
  /// Method: Loads StudyExecutionScopes.
  /// </summary>
  public class GetStudyExecutionScopesRequest {
  
    /// <summary> Optional Argument for 'GetStudyExecutionScopes' (Int32?): Number of the page, which should be returned </summary>
    public Int32? page { get; set; } = null;
  
    /// <summary> Optional Argument for 'GetStudyExecutionScopes' (Int32?): Max count of StudyExecutionScopes which should be returned </summary>
    public Int32? pageSize { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains results from calling 'GetStudyExecutionScopes'.
  /// Method: Loads StudyExecutionScopes.
  /// </summary>
  public class GetStudyExecutionScopesResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'GetStudyExecutionScopes' (StudyExecutionScope[]) </summary>
    public StudyExecutionScope[] @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'SearchStudyExecutionScopes'.
  /// Method: Loads StudyExecutionScopes where values matching to the given filterExpression
  /// </summary>
  public class SearchStudyExecutionScopesRequest {
  
    /// <summary> Required Argument for 'SearchStudyExecutionScopes' (String): a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </summary>
    [Required]
    public String filterExpression { get; set; }
  
    /// <summary> Optional Argument for 'SearchStudyExecutionScopes' (String): one or more property names which are used as sort order (before pagination) </summary>
    public String sortingExpression { get; set; }
  
    /// <summary> Optional Argument for 'SearchStudyExecutionScopes' (Int32?): Number of the page, which should be returned </summary>
    public Int32? page { get; set; } = null;
  
    /// <summary> Optional Argument for 'SearchStudyExecutionScopes' (Int32?): Max count of StudyExecutionScopes which should be returned </summary>
    public Int32? pageSize { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains results from calling 'SearchStudyExecutionScopes'.
  /// Method: Loads StudyExecutionScopes where values matching to the given filterExpression
  /// </summary>
  public class SearchStudyExecutionScopesResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'SearchStudyExecutionScopes' (StudyExecutionScope[]) </summary>
    public StudyExecutionScope[] @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'AddNewStudyExecutionScope'.
  /// Method: Adds a new StudyExecutionScope and returns its primary identifier (or null on failure).
  /// </summary>
  public class AddNewStudyExecutionScopeRequest {
  
    /// <summary> Required Argument for 'AddNewStudyExecutionScope' (StudyExecutionScope): StudyExecutionScope containing the new values </summary>
    [Required]
    public StudyExecutionScope studyExecutionScope { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'AddNewStudyExecutionScope'.
  /// Method: Adds a new StudyExecutionScope and returns its primary identifier (or null on failure).
  /// </summary>
  public class AddNewStudyExecutionScopeResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'AddNewStudyExecutionScope' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'UpdateStudyExecutionScope'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given StudyExecutionScope addressed by the primary identifier fields within the given StudyExecutionScope. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateStudyExecutionScopeRequest {
  
    /// <summary> Required Argument for 'UpdateStudyExecutionScope' (StudyExecutionScope): StudyExecutionScope containing the new values (the primary identifier fields within the given StudyExecutionScope will be used to address the target record) </summary>
    [Required]
    public StudyExecutionScope studyExecutionScope { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'UpdateStudyExecutionScope'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given StudyExecutionScope addressed by the primary identifier fields within the given StudyExecutionScope. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateStudyExecutionScopeResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'UpdateStudyExecutionScope' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'UpdateStudyExecutionScopeByStudyExecutionIdentifier'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given StudyExecutionScope addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateStudyExecutionScopeByStudyExecutionIdentifierRequest {
  
    /// <summary> Required Argument for 'UpdateStudyExecutionScopeByStudyExecutionIdentifier' (Guid): a global unique id of a concrete study execution (dedicated to a concrete institute) which is usually originated at the primary CRF or study management system ('SMS') </summary>
    [Required]
    public Guid studyExecutionIdentifier { get; set; }
  
    /// <summary> Required Argument for 'UpdateStudyExecutionScopeByStudyExecutionIdentifier' (StudyExecutionScope): StudyExecutionScope containing the new values (the primary identifier fields within the given StudyExecutionScope will be ignored) </summary>
    [Required]
    public StudyExecutionScope studyExecutionScope { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'UpdateStudyExecutionScopeByStudyExecutionIdentifier'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given StudyExecutionScope addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateStudyExecutionScopeByStudyExecutionIdentifierResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'UpdateStudyExecutionScopeByStudyExecutionIdentifier' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'DeleteStudyExecutionScopeByStudyExecutionIdentifier'.
  /// Method: Deletes a specific StudyExecutionScope addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class DeleteStudyExecutionScopeByStudyExecutionIdentifierRequest {
  
    /// <summary> Required Argument for 'DeleteStudyExecutionScopeByStudyExecutionIdentifier' (Guid): a global unique id of a concrete study execution (dedicated to a concrete institute) which is usually originated at the primary CRF or study management system ('SMS') </summary>
    [Required]
    public Guid studyExecutionIdentifier { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'DeleteStudyExecutionScopeByStudyExecutionIdentifier'.
  /// Method: Deletes a specific StudyExecutionScope addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class DeleteStudyExecutionScopeByStudyExecutionIdentifierResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'DeleteStudyExecutionScopeByStudyExecutionIdentifier' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetStudyScopeByStudyScopeIdentity'.
  /// Method: Loads a specific StudyScope addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.
  /// </summary>
  public class GetStudyScopeByStudyScopeIdentityRequest {
  
    /// <summary> Required Argument for 'GetStudyScopeByStudyScopeIdentity' (StudyScopeIdentity): Composite Key, which represents the primary identity of a StudyScope </summary>
    [Required]
    public StudyScopeIdentity studyScopeIdentity { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'GetStudyScopeByStudyScopeIdentity'.
  /// Method: Loads a specific StudyScope addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.
  /// </summary>
  public class GetStudyScopeByStudyScopeIdentityResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'GetStudyScopeByStudyScopeIdentity' (StudyScope) </summary>
    public StudyScope @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetStudyScopes'.
  /// Method: Loads StudyScopes.
  /// </summary>
  public class GetStudyScopesRequest {
  
    /// <summary> Optional Argument for 'GetStudyScopes' (Int32?): Number of the page, which should be returned </summary>
    public Int32? page { get; set; } = null;
  
    /// <summary> Optional Argument for 'GetStudyScopes' (Int32?): Max count of StudyScopes which should be returned </summary>
    public Int32? pageSize { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains results from calling 'GetStudyScopes'.
  /// Method: Loads StudyScopes.
  /// </summary>
  public class GetStudyScopesResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'GetStudyScopes' (StudyScope[]) </summary>
    public StudyScope[] @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'SearchStudyScopes'.
  /// Method: Loads StudyScopes where values matching to the given filterExpression
  /// </summary>
  public class SearchStudyScopesRequest {
  
    /// <summary> Required Argument for 'SearchStudyScopes' (String): a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </summary>
    [Required]
    public String filterExpression { get; set; }
  
    /// <summary> Optional Argument for 'SearchStudyScopes' (String): one or more property names which are used as sort order (before pagination) </summary>
    public String sortingExpression { get; set; }
  
    /// <summary> Optional Argument for 'SearchStudyScopes' (Int32?): Number of the page, which should be returned </summary>
    public Int32? page { get; set; } = null;
  
    /// <summary> Optional Argument for 'SearchStudyScopes' (Int32?): Max count of StudyScopes which should be returned </summary>
    public Int32? pageSize { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains results from calling 'SearchStudyScopes'.
  /// Method: Loads StudyScopes where values matching to the given filterExpression
  /// </summary>
  public class SearchStudyScopesResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'SearchStudyScopes' (StudyScope[]) </summary>
    public StudyScope[] @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'AddNewStudyScope'.
  /// Method: Adds a new StudyScope and returns its primary identifier (or null on failure).
  /// </summary>
  public class AddNewStudyScopeRequest {
  
    /// <summary> Required Argument for 'AddNewStudyScope' (StudyScope): StudyScope containing the new values </summary>
    [Required]
    public StudyScope studyScope { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'AddNewStudyScope'.
  /// Method: Adds a new StudyScope and returns its primary identifier (or null on failure).
  /// </summary>
  public class AddNewStudyScopeResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'AddNewStudyScope' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'UpdateStudyScope'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given StudyScope addressed by the primary identifier fields within the given StudyScope. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateStudyScopeRequest {
  
    /// <summary> Required Argument for 'UpdateStudyScope' (StudyScope): StudyScope containing the new values (the primary identifier fields within the given StudyScope will be used to address the target record) </summary>
    [Required]
    public StudyScope studyScope { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'UpdateStudyScope'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given StudyScope addressed by the primary identifier fields within the given StudyScope. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateStudyScopeResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'UpdateStudyScope' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'UpdateStudyScopeByStudyScopeIdentity'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given StudyScope addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateStudyScopeByStudyScopeIdentityRequest {
  
    /// <summary> Required Argument for 'UpdateStudyScopeByStudyScopeIdentity' (StudyScopeIdentity): Composite Key, which represents the primary identity of a StudyScope </summary>
    [Required]
    public StudyScopeIdentity studyScopeIdentity { get; set; }
  
    /// <summary> Required Argument for 'UpdateStudyScopeByStudyScopeIdentity' (StudyScope): StudyScope containing the new values (the primary identifier fields within the given StudyScope will be ignored) </summary>
    [Required]
    public StudyScope studyScope { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'UpdateStudyScopeByStudyScopeIdentity'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given StudyScope addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateStudyScopeByStudyScopeIdentityResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'UpdateStudyScopeByStudyScopeIdentity' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'DeleteStudyScopeByStudyScopeIdentity'.
  /// Method: Deletes a specific StudyScope addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class DeleteStudyScopeByStudyScopeIdentityRequest {
  
    /// <summary> Required Argument for 'DeleteStudyScopeByStudyScopeIdentity' (StudyScopeIdentity): Composite Key, which represents the primary identity of a StudyScope </summary>
    [Required]
    public StudyScopeIdentity studyScopeIdentity { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'DeleteStudyScopeByStudyScopeIdentity'.
  /// Method: Deletes a specific StudyScope addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class DeleteStudyScopeByStudyScopeIdentityResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'DeleteStudyScopeByStudyScopeIdentity' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetSubjectAddressByInternalRecordId'.
  /// Method: Loads a specific SubjectAddress addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.
  /// </summary>
  public class GetSubjectAddressByInternalRecordIdRequest {
  
    /// <summary> Required Argument for 'GetSubjectAddressByInternalRecordId' (Guid): Represents the primary identity of a SubjectAddress </summary>
    [Required]
    public Guid internalRecordId { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'GetSubjectAddressByInternalRecordId'.
  /// Method: Loads a specific SubjectAddress addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.
  /// </summary>
  public class GetSubjectAddressByInternalRecordIdResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'GetSubjectAddressByInternalRecordId' (SubjectAddress) </summary>
    public SubjectAddress @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetSubjectAddresses'.
  /// Method: Loads SubjectAddresses.
  /// </summary>
  public class GetSubjectAddressesRequest {
  
    /// <summary> Optional Argument for 'GetSubjectAddresses' (Int32?): Number of the page, which should be returned </summary>
    public Int32? page { get; set; } = null;
  
    /// <summary> Optional Argument for 'GetSubjectAddresses' (Int32?): Max count of SubjectAddresses which should be returned </summary>
    public Int32? pageSize { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains results from calling 'GetSubjectAddresses'.
  /// Method: Loads SubjectAddresses.
  /// </summary>
  public class GetSubjectAddressesResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'GetSubjectAddresses' (SubjectAddress[]) </summary>
    public SubjectAddress[] @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'SearchSubjectAddresses'.
  /// Method: Loads SubjectAddresses where values matching to the given filterExpression
  /// </summary>
  public class SearchSubjectAddressesRequest {
  
    /// <summary> Required Argument for 'SearchSubjectAddresses' (String): a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </summary>
    [Required]
    public String filterExpression { get; set; }
  
    /// <summary> Optional Argument for 'SearchSubjectAddresses' (String): one or more property names which are used as sort order (before pagination) </summary>
    public String sortingExpression { get; set; }
  
    /// <summary> Optional Argument for 'SearchSubjectAddresses' (Int32?): Number of the page, which should be returned </summary>
    public Int32? page { get; set; } = null;
  
    /// <summary> Optional Argument for 'SearchSubjectAddresses' (Int32?): Max count of SubjectAddresses which should be returned </summary>
    public Int32? pageSize { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains results from calling 'SearchSubjectAddresses'.
  /// Method: Loads SubjectAddresses where values matching to the given filterExpression
  /// </summary>
  public class SearchSubjectAddressesResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'SearchSubjectAddresses' (SubjectAddress[]) </summary>
    public SubjectAddress[] @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'AddNewSubjectAddress'.
  /// Method: Adds a new SubjectAddress and returns its primary identifier (or null on failure).
  /// </summary>
  public class AddNewSubjectAddressRequest {
  
    /// <summary> Required Argument for 'AddNewSubjectAddress' (SubjectAddress): SubjectAddress containing the new values </summary>
    [Required]
    public SubjectAddress subjectAddress { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'AddNewSubjectAddress'.
  /// Method: Adds a new SubjectAddress and returns its primary identifier (or null on failure).
  /// </summary>
  public class AddNewSubjectAddressResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'AddNewSubjectAddress' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'UpdateSubjectAddress'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given SubjectAddress addressed by the primary identifier fields within the given SubjectAddress. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateSubjectAddressRequest {
  
    /// <summary> Required Argument for 'UpdateSubjectAddress' (SubjectAddress): SubjectAddress containing the new values (the primary identifier fields within the given SubjectAddress will be used to address the target record) </summary>
    [Required]
    public SubjectAddress subjectAddress { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'UpdateSubjectAddress'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given SubjectAddress addressed by the primary identifier fields within the given SubjectAddress. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateSubjectAddressResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'UpdateSubjectAddress' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'UpdateSubjectAddressByInternalRecordId'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given SubjectAddress addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateSubjectAddressByInternalRecordIdRequest {
  
    /// <summary> Required Argument for 'UpdateSubjectAddressByInternalRecordId' (Guid): Represents the primary identity of a SubjectAddress </summary>
    [Required]
    public Guid internalRecordId { get; set; }
  
    /// <summary> Required Argument for 'UpdateSubjectAddressByInternalRecordId' (SubjectAddress): SubjectAddress containing the new values (the primary identifier fields within the given SubjectAddress will be ignored) </summary>
    [Required]
    public SubjectAddress subjectAddress { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'UpdateSubjectAddressByInternalRecordId'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given SubjectAddress addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateSubjectAddressByInternalRecordIdResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'UpdateSubjectAddressByInternalRecordId' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'DeleteSubjectAddressByInternalRecordId'.
  /// Method: Deletes a specific SubjectAddress addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class DeleteSubjectAddressByInternalRecordIdRequest {
  
    /// <summary> Required Argument for 'DeleteSubjectAddressByInternalRecordId' (Guid): Represents the primary identity of a SubjectAddress </summary>
    [Required]
    public Guid internalRecordId { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'DeleteSubjectAddressByInternalRecordId'.
  /// Method: Deletes a specific SubjectAddress addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class DeleteSubjectAddressByInternalRecordIdResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'DeleteSubjectAddressByInternalRecordId' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetSubjectIdentityByRecordId'.
  /// Method: Loads a specific SubjectIdentity addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.
  /// </summary>
  public class GetSubjectIdentityByRecordIdRequest {
  
    /// <summary> Required Argument for 'GetSubjectIdentityByRecordId' (Guid): Represents the primary identity of a SubjectIdentity </summary>
    [Required]
    public Guid recordId { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'GetSubjectIdentityByRecordId'.
  /// Method: Loads a specific SubjectIdentity addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.
  /// </summary>
  public class GetSubjectIdentityByRecordIdResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'GetSubjectIdentityByRecordId' (SubjectIdentity) </summary>
    public SubjectIdentity @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetSubjectIdentities'.
  /// Method: Loads SubjectIdentities.
  /// </summary>
  public class GetSubjectIdentitiesRequest {
  
    /// <summary> Optional Argument for 'GetSubjectIdentities' (Int32?): Number of the page, which should be returned </summary>
    public Int32? page { get; set; } = null;
  
    /// <summary> Optional Argument for 'GetSubjectIdentities' (Int32?): Max count of SubjectIdentities which should be returned </summary>
    public Int32? pageSize { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains results from calling 'GetSubjectIdentities'.
  /// Method: Loads SubjectIdentities.
  /// </summary>
  public class GetSubjectIdentitiesResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'GetSubjectIdentities' (SubjectIdentity[]) </summary>
    public SubjectIdentity[] @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'SearchSubjectIdentities'.
  /// Method: Loads SubjectIdentities where values matching to the given filterExpression
  /// </summary>
  public class SearchSubjectIdentitiesRequest {
  
    /// <summary> Required Argument for 'SearchSubjectIdentities' (String): a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </summary>
    [Required]
    public String filterExpression { get; set; }
  
    /// <summary> Optional Argument for 'SearchSubjectIdentities' (String): one or more property names which are used as sort order (before pagination) </summary>
    public String sortingExpression { get; set; }
  
    /// <summary> Optional Argument for 'SearchSubjectIdentities' (Int32?): Number of the page, which should be returned </summary>
    public Int32? page { get; set; } = null;
  
    /// <summary> Optional Argument for 'SearchSubjectIdentities' (Int32?): Max count of SubjectIdentities which should be returned </summary>
    public Int32? pageSize { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains results from calling 'SearchSubjectIdentities'.
  /// Method: Loads SubjectIdentities where values matching to the given filterExpression
  /// </summary>
  public class SearchSubjectIdentitiesResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'SearchSubjectIdentities' (SubjectIdentity[]) </summary>
    public SubjectIdentity[] @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'AddNewSubjectIdentity'.
  /// Method: Adds a new SubjectIdentity and returns its primary identifier (or null on failure).
  /// </summary>
  public class AddNewSubjectIdentityRequest {
  
    /// <summary> Required Argument for 'AddNewSubjectIdentity' (SubjectIdentity): SubjectIdentity containing the new values </summary>
    [Required]
    public SubjectIdentity subjectIdentity { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'AddNewSubjectIdentity'.
  /// Method: Adds a new SubjectIdentity and returns its primary identifier (or null on failure).
  /// </summary>
  public class AddNewSubjectIdentityResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'AddNewSubjectIdentity' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'UpdateSubjectIdentity'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given SubjectIdentity addressed by the primary identifier fields within the given SubjectIdentity. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateSubjectIdentityRequest {
  
    /// <summary> Required Argument for 'UpdateSubjectIdentity' (SubjectIdentity): SubjectIdentity containing the new values (the primary identifier fields within the given SubjectIdentity will be used to address the target record) </summary>
    [Required]
    public SubjectIdentity subjectIdentity { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'UpdateSubjectIdentity'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given SubjectIdentity addressed by the primary identifier fields within the given SubjectIdentity. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateSubjectIdentityResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'UpdateSubjectIdentity' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'UpdateSubjectIdentityByRecordId'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given SubjectIdentity addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateSubjectIdentityByRecordIdRequest {
  
    /// <summary> Required Argument for 'UpdateSubjectIdentityByRecordId' (Guid): Represents the primary identity of a SubjectIdentity </summary>
    [Required]
    public Guid recordId { get; set; }
  
    /// <summary> Required Argument for 'UpdateSubjectIdentityByRecordId' (SubjectIdentity): SubjectIdentity containing the new values (the primary identifier fields within the given SubjectIdentity will be ignored) </summary>
    [Required]
    public SubjectIdentity subjectIdentity { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'UpdateSubjectIdentityByRecordId'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given SubjectIdentity addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateSubjectIdentityByRecordIdResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'UpdateSubjectIdentityByRecordId' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'DeleteSubjectIdentityByRecordId'.
  /// Method: Deletes a specific SubjectIdentity addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class DeleteSubjectIdentityByRecordIdRequest {
  
    /// <summary> Required Argument for 'DeleteSubjectIdentityByRecordId' (Guid): Represents the primary identity of a SubjectIdentity </summary>
    [Required]
    public Guid recordId { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'DeleteSubjectIdentityByRecordId'.
  /// Method: Deletes a specific SubjectIdentity addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class DeleteSubjectIdentityByRecordIdResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'DeleteSubjectIdentityByRecordId' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
}
