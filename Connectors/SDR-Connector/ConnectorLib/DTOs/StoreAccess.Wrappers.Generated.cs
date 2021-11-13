﻿using MedicalResearch.SubjectData.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MedicalResearch.SubjectData.StoreAccess {
  
  /// <summary>
  /// Contains arguments for calling 'GetSubjectBySubjectUid'.
  /// Method: Loads a specific Subject addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.
  /// </summary>
  public class GetSubjectBySubjectUidRequest {
  
    /// <summary> Required Argument for 'GetSubjectBySubjectUid' (Guid): An <see href="https://de.wikipedia.org/wiki/Universally_Unique_Identifier">Universally Unique Identifier</see> which can be generated by any origin system and is used to address this ORSCF conform data record in decentralized environments. Note that this Identity must not be changed any more! </summary>
    [Required]
    public Guid subjectUid { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'GetSubjectBySubjectUid'.
  /// Method: Loads a specific Subject addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.
  /// </summary>
  public class GetSubjectBySubjectUidResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'GetSubjectBySubjectUid' (Subject): entity, which relates to <see href="https://www.hl7.org/fhir/researchsubject.html">HL7.ResearchSubject</see> </summary>
    public Subject @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetSubjects'.
  /// Method: Loads Subjects.
  /// </summary>
  public class GetSubjectsRequest {
  
    /// <summary> Optional Argument for 'GetSubjects' (Int32?): Number of the page, which should be returned </summary>
    public Int32? page { get; set; } = null;
  
    /// <summary> Optional Argument for 'GetSubjects' (Int32?): Max count of Subjects which should be returned </summary>
    public Int32? pageSize { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains results from calling 'GetSubjects'.
  /// Method: Loads Subjects.
  /// </summary>
  public class GetSubjectsResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'GetSubjects' (Subject[]): entity, which relates to <see href="https://www.hl7.org/fhir/researchsubject.html">HL7.ResearchSubject</see> </summary>
    public Subject[] @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'SearchSubjects'.
  /// Method: Loads Subjects where values matching to the given filterExpression
  /// </summary>
  public class SearchSubjectsRequest {
  
    /// <summary> Required Argument for 'SearchSubjects' (String): a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </summary>
    [Required]
    public String filterExpression { get; set; }
  
    /// <summary> Optional Argument for 'SearchSubjects' (String): one or more property names which are used as sort order (before pagination) </summary>
    public String sortingExpression { get; set; }
  
    /// <summary> Optional Argument for 'SearchSubjects' (Int32?): Number of the page, which should be returned </summary>
    public Int32? page { get; set; } = null;
  
    /// <summary> Optional Argument for 'SearchSubjects' (Int32?): Max count of Subjects which should be returned </summary>
    public Int32? pageSize { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains results from calling 'SearchSubjects'.
  /// Method: Loads Subjects where values matching to the given filterExpression
  /// </summary>
  public class SearchSubjectsResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'SearchSubjects' (Subject[]): entity, which relates to <see href="https://www.hl7.org/fhir/researchsubject.html">HL7.ResearchSubject</see> </summary>
    public Subject[] @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'AddNewSubject'.
  /// Method: Adds a new Subject and returns its primary identifier (or null on failure).
  /// </summary>
  public class AddNewSubjectRequest {
  
    /// <summary> Required Argument for 'AddNewSubject' (Subject): Subject containing the new values </summary>
    [Required]
    public Subject subject { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'AddNewSubject'.
  /// Method: Adds a new Subject and returns its primary identifier (or null on failure).
  /// </summary>
  public class AddNewSubjectResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'AddNewSubject' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'UpdateSubject'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given Subject addressed by the primary identifier fields within the given Subject. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateSubjectRequest {
  
    /// <summary> Required Argument for 'UpdateSubject' (Subject): Subject containing the new values (the primary identifier fields within the given Subject will be used to address the target record) </summary>
    [Required]
    public Subject subject { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'UpdateSubject'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given Subject addressed by the primary identifier fields within the given Subject. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateSubjectResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'UpdateSubject' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'UpdateSubjectBySubjectUid'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given Subject addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateSubjectBySubjectUidRequest {
  
    /// <summary> Required Argument for 'UpdateSubjectBySubjectUid' (Guid): An <see href="https://de.wikipedia.org/wiki/Universally_Unique_Identifier">Universally Unique Identifier</see> which can be generated by any origin system and is used to address this ORSCF conform data record in decentralized environments. Note that this Identity must not be changed any more! </summary>
    [Required]
    public Guid subjectUid { get; set; }
  
    /// <summary> Required Argument for 'UpdateSubjectBySubjectUid' (Subject): Subject containing the new values (the primary identifier fields within the given Subject will be ignored) </summary>
    [Required]
    public Subject subject { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'UpdateSubjectBySubjectUid'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given Subject addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateSubjectBySubjectUidResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'UpdateSubjectBySubjectUid' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'DeleteSubjectBySubjectUid'.
  /// Method: Deletes a specific Subject addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class DeleteSubjectBySubjectUidRequest {
  
    /// <summary> Required Argument for 'DeleteSubjectBySubjectUid' (Guid): An <see href="https://de.wikipedia.org/wiki/Universally_Unique_Identifier">Universally Unique Identifier</see> which can be generated by any origin system and is used to address this ORSCF conform data record in decentralized environments. Note that this Identity must not be changed any more! </summary>
    [Required]
    public Guid subjectUid { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'DeleteSubjectBySubjectUid'.
  /// Method: Deletes a specific Subject addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class DeleteSubjectBySubjectUidResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'DeleteSubjectBySubjectUid' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetSubjectSiteAssignmentBySubjectSiteAssignmentUid'.
  /// Method: Loads a specific SubjectSiteAssignment addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.
  /// </summary>
  public class GetSubjectSiteAssignmentBySubjectSiteAssignmentUidRequest {
  
    /// <summary> Required Argument for 'GetSubjectSiteAssignmentBySubjectSiteAssignmentUid' (Guid): An <see href="https://de.wikipedia.org/wiki/Universally_Unique_Identifier">Universally Unique Identifier</see> which can be generated by any origin system and is used to address this ORSCF conform data record in decentralized environments. Note that this Identity must not be changed any more! </summary>
    [Required]
    public Guid subjectSiteAssignmentUid { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'GetSubjectSiteAssignmentBySubjectSiteAssignmentUid'.
  /// Method: Loads a specific SubjectSiteAssignment addressed by the given primary identifier. Returns null on failure, or if no record exists with the given identity.
  /// </summary>
  public class GetSubjectSiteAssignmentBySubjectSiteAssignmentUidResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'GetSubjectSiteAssignmentBySubjectSiteAssignmentUid' (SubjectSiteAssignment) </summary>
    public SubjectSiteAssignment @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'GetSubjectSiteAssignments'.
  /// Method: Loads SubjectSiteAssignments.
  /// </summary>
  public class GetSubjectSiteAssignmentsRequest {
  
    /// <summary> Optional Argument for 'GetSubjectSiteAssignments' (Int32?): Number of the page, which should be returned </summary>
    public Int32? page { get; set; } = null;
  
    /// <summary> Optional Argument for 'GetSubjectSiteAssignments' (Int32?): Max count of SubjectSiteAssignments which should be returned </summary>
    public Int32? pageSize { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains results from calling 'GetSubjectSiteAssignments'.
  /// Method: Loads SubjectSiteAssignments.
  /// </summary>
  public class GetSubjectSiteAssignmentsResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'GetSubjectSiteAssignments' (SubjectSiteAssignment[]) </summary>
    public SubjectSiteAssignment[] @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'SearchSubjectSiteAssignments'.
  /// Method: Loads SubjectSiteAssignments where values matching to the given filterExpression
  /// </summary>
  public class SearchSubjectSiteAssignmentsRequest {
  
    /// <summary> Required Argument for 'SearchSubjectSiteAssignments' (String): a filter expression like '((FieldName1 == "ABC" &amp;&amp; FieldName2 &gt; 12) || FieldName2 != "")' </summary>
    [Required]
    public String filterExpression { get; set; }
  
    /// <summary> Optional Argument for 'SearchSubjectSiteAssignments' (String): one or more property names which are used as sort order (before pagination) </summary>
    public String sortingExpression { get; set; }
  
    /// <summary> Optional Argument for 'SearchSubjectSiteAssignments' (Int32?): Number of the page, which should be returned </summary>
    public Int32? page { get; set; } = null;
  
    /// <summary> Optional Argument for 'SearchSubjectSiteAssignments' (Int32?): Max count of SubjectSiteAssignments which should be returned </summary>
    public Int32? pageSize { get; set; } = null;
  
  }
  
  /// <summary>
  /// Contains results from calling 'SearchSubjectSiteAssignments'.
  /// Method: Loads SubjectSiteAssignments where values matching to the given filterExpression
  /// </summary>
  public class SearchSubjectSiteAssignmentsResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'SearchSubjectSiteAssignments' (SubjectSiteAssignment[]) </summary>
    public SubjectSiteAssignment[] @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'AddNewSubjectSiteAssignment'.
  /// Method: Adds a new SubjectSiteAssignment and returns its primary identifier (or null on failure).
  /// </summary>
  public class AddNewSubjectSiteAssignmentRequest {
  
    /// <summary> Required Argument for 'AddNewSubjectSiteAssignment' (SubjectSiteAssignment): SubjectSiteAssignment containing the new values </summary>
    [Required]
    public SubjectSiteAssignment subjectSiteAssignment { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'AddNewSubjectSiteAssignment'.
  /// Method: Adds a new SubjectSiteAssignment and returns its primary identifier (or null on failure).
  /// </summary>
  public class AddNewSubjectSiteAssignmentResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'AddNewSubjectSiteAssignment' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'UpdateSubjectSiteAssignment'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given SubjectSiteAssignment addressed by the primary identifier fields within the given SubjectSiteAssignment. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateSubjectSiteAssignmentRequest {
  
    /// <summary> Required Argument for 'UpdateSubjectSiteAssignment' (SubjectSiteAssignment): SubjectSiteAssignment containing the new values (the primary identifier fields within the given SubjectSiteAssignment will be used to address the target record) </summary>
    [Required]
    public SubjectSiteAssignment subjectSiteAssignment { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'UpdateSubjectSiteAssignment'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given SubjectSiteAssignment addressed by the primary identifier fields within the given SubjectSiteAssignment. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateSubjectSiteAssignmentResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'UpdateSubjectSiteAssignment' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'UpdateSubjectSiteAssignmentBySubjectSiteAssignmentUid'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given SubjectSiteAssignment addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateSubjectSiteAssignmentBySubjectSiteAssignmentUidRequest {
  
    /// <summary> Required Argument for 'UpdateSubjectSiteAssignmentBySubjectSiteAssignmentUid' (Guid): An <see href="https://de.wikipedia.org/wiki/Universally_Unique_Identifier">Universally Unique Identifier</see> which can be generated by any origin system and is used to address this ORSCF conform data record in decentralized environments. Note that this Identity must not be changed any more! </summary>
    [Required]
    public Guid subjectSiteAssignmentUid { get; set; }
  
    /// <summary> Required Argument for 'UpdateSubjectSiteAssignmentBySubjectSiteAssignmentUid' (SubjectSiteAssignment): SubjectSiteAssignment containing the new values (the primary identifier fields within the given SubjectSiteAssignment will be ignored) </summary>
    [Required]
    public SubjectSiteAssignment subjectSiteAssignment { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'UpdateSubjectSiteAssignmentBySubjectSiteAssignmentUid'.
  /// Method: Updates all values (which are not "FixedAfterCreation") of the given SubjectSiteAssignment addressed by the supplementary given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class UpdateSubjectSiteAssignmentBySubjectSiteAssignmentUidResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'UpdateSubjectSiteAssignmentBySubjectSiteAssignmentUid' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
  /// <summary>
  /// Contains arguments for calling 'DeleteSubjectSiteAssignmentBySubjectSiteAssignmentUid'.
  /// Method: Deletes a specific SubjectSiteAssignment addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class DeleteSubjectSiteAssignmentBySubjectSiteAssignmentUidRequest {
  
    /// <summary> Required Argument for 'DeleteSubjectSiteAssignmentBySubjectSiteAssignmentUid' (Guid): An <see href="https://de.wikipedia.org/wiki/Universally_Unique_Identifier">Universally Unique Identifier</see> which can be generated by any origin system and is used to address this ORSCF conform data record in decentralized environments. Note that this Identity must not be changed any more! </summary>
    [Required]
    public Guid subjectSiteAssignmentUid { get; set; }
  
  }
  
  /// <summary>
  /// Contains results from calling 'DeleteSubjectSiteAssignmentBySubjectSiteAssignmentUid'.
  /// Method: Deletes a specific SubjectSiteAssignment addressed by the given primary identifier. Returns false on failure or if no target record was found, otherwise true.
  /// </summary>
  public class DeleteSubjectSiteAssignmentBySubjectSiteAssignmentUidResponse {
  
    /// <summary> This field contains error text equivalent to an Exception message! (note that only 'fault' XOR 'return' can have a value != null)  </summary>
    public string fault { get; set; } = null;
  
    /// <summary> Return-Value of 'DeleteSubjectSiteAssignmentBySubjectSiteAssignmentUid' (Boolean) </summary>
    public Boolean @return { get; set; }
  
  }
  
}
