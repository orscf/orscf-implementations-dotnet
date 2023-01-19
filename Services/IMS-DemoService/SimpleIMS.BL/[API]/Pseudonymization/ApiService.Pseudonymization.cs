using System;
using System.Collections.Generic;
using System.Data.AccessControl;
using System.Linq;
using Hl7.Fhir.Model;
using MedicalResearch.IdentityManagement;
using MedicalResearch.IdentityManagement.Model;
using MedicalResearch.IdentityManagement.Persistence;
using MedicalResearch.IdentityManagement.Persistence.EF;
using Microsoft.EntityFrameworkCore;

namespace MedicalResearch.IdentityManagement {

  partial class ApiService : IPseudonymizationService {

    public bool GetOrCreatePseudonym(string givenName, string familyName, string birthDate, Dictionary<string, string> extendedFields, out string pseudonym, out bool wasCreatedNewly) {

      if (this.GetExisitingPseudonym( givenName, familyName, birthDate, extendedFields, out pseudonym)) {
        wasCreatedNewly = false;
        return true;
      }

      var parsedBirthDate = DateTime.Parse(birthDate);
      string generatedPseudonym = null;
      using (var db = new IdentityManagementDbContext()) {

        StudyScopeEntity study = (
          from s in db.StudyScopes
          where s.ResearchStudyUid == Guid.Empty 
          select s
        ).SingleOrDefault();

        if (study == null) {
          study = new StudyScopeEntity {
            ResearchStudyUid = Guid.Empty,
            StudyWorkflowName = "",
            StudyWorkflowVersion = "",
            ParticipantIdentifierSemantic = "generated Pseudonym"
          };
          if (!AccessControlContext.Current.ValidateEntityScope(study)) {
            wasCreatedNewly = false;
            pseudonym = null;
            return false;
          }
          db.StudyScopes.Add(study);
        }

        StudyExecutionScopeEntity execution = (
          from s in db.StudyExecutionScopes
          where s.ResearchStudyUid == Guid.Empty && s.SiteUid == Guid.Empty
          select s
        ).SingleOrDefault();

        if (execution == null) {
          execution = new StudyExecutionScopeEntity {
            ResearchStudyUid = Guid.Empty,
            SiteUid = Guid.Empty
          };
          if (!AccessControlContext.Current.ValidateEntityScope(execution)) {
            wasCreatedNewly = false;
            pseudonym = null;
            return false;
          }
          db.StudyExecutionScopes.Add(execution);
        }

        SubjectIdentityEntity subjectIdentity = (
          from p in db.SubjectIdentities
          where
            p.FirstName.ToLower() == givenName.ToLower() &&
            p.LastName.ToLower() == familyName.ToLower() &&
            p.DateOfBirth == parsedBirthDate
          select p
        ).SingleOrDefault();

        if (subjectIdentity == null) {
          subjectIdentity = new SubjectIdentityEntity {
            FirstName = givenName,
            LastName = familyName,
            DateOfBirth = parsedBirthDate
          };
          db.SubjectIdentities.Add(subjectIdentity);
        }

        generatedPseudonym = Guid.NewGuid().ToString().ToLower().Replace("-", "");
        var subjectParticipation = new SubjectParticipationEntity {
          ParticipantIdentifier = generatedPseudonym,
          CreationDateUtc = DateTime.UtcNow,
          CreatedForStudyExecutionIdentifier = execution.StudyExecutionIdentifier,
          SubjectIdentityRecordId = subjectIdentity.RecordId
        };
        db.SubjectParticipations.Add(subjectParticipation);

        try {
          db.SaveChanges();
          wasCreatedNewly = true;
          pseudonym = generatedPseudonym;
          return true;
        }
        catch (Exception ex) {
          wasCreatedNewly = false;
          pseudonym = null;
          return false;
        }

      };
    }

    public bool GetExisitingPseudonym(string givenName, string familyName, string birthDate, Dictionary<string, string> extendedFields, out string pseudonym) {

      var parsedBirthDate = DateTime.Parse(birthDate);

      using (var db = new IdentityManagementDbContext()) {

        string participantIdentifier = (
          from
            p in db.SubjectParticipations.AsNoTracking().AccessScopeFiltered()
          where
            p.Identity.FirstName.ToLower() == givenName.ToLower() &&
            p.Identity.LastName.ToLower() == familyName.ToLower() &&
            p.Identity.DateOfBirth == parsedBirthDate
          select
            p.ParticipantIdentifier
        ).SingleOrDefault();

        if (string.IsNullOrWhiteSpace(participantIdentifier)) {
          pseudonym = null;
          return false;
        }
        else {
          pseudonym = participantIdentifier;
          return true;
        }

      };

    }
  }

}
