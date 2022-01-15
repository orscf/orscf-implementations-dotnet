using System;
using Microsoft.EntityFrameworkCore;
using MedicalResearch.IdentityManagement.Persistence;

namespace MedicalResearch.IdentityManagement.Persistence.EF {

  /// <summary> EntityFramework DbContext (based on schema version '1.5.0') </summary>
  public partial class IdentityManagementDbContext : DbContext{

    public const String SchemaVersion = "1.5.0";

    public DbSet<AdditionalSubjectParticipationIdentifierEntity> AdditionalSubjectParticipationIdentifiers { get; set; }

    public DbSet<SubjectParticipationEntity> SubjectParticipations { get; set; }

    public DbSet<StudyExecutionScopeEntity> StudyExecutionScopes { get; set; }

    public DbSet<StudyScopeEntity> StudyScopes { get; set; }

    public DbSet<SubjectAddressEntity> SubjectAddresses { get; set; }

    public DbSet<SubjectIdentityEntity> SubjectIdentities { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      base.OnModelCreating(modelBuilder);

#region Mapping

      //////////////////////////////////////////////////////////////////////////////////////
      // AdditionalSubjectParticipationIdentifier
      //////////////////////////////////////////////////////////////////////////////////////

      var cfgAdditionalSubjectParticipationIdentifier = modelBuilder.Entity<AdditionalSubjectParticipationIdentifierEntity>();
      cfgAdditionalSubjectParticipationIdentifier.ToTable("ImsAdditionalSubjectParticipationIdentifiers");
      cfgAdditionalSubjectParticipationIdentifier.HasKey((e) => new {e.ParticipantIdentifier, e.IdentifierName, e.ResearchStudyUid});

      // PRINCIPAL: >>> SubjectParticipation
      cfgAdditionalSubjectParticipationIdentifier
        .HasOne((lcl) => lcl.Participation )
        .WithMany((rem) => rem.AdditionalIdentifiers )
        .HasForeignKey(nameof(AdditionalSubjectParticipationIdentifierEntity.ParticipantIdentifier), nameof(AdditionalSubjectParticipationIdentifierEntity.ResearchStudyUid))
        .OnDelete(DeleteBehavior.Cascade);

      //////////////////////////////////////////////////////////////////////////////////////
      // SubjectParticipation
      //////////////////////////////////////////////////////////////////////////////////////

      var cfgSubjectParticipation = modelBuilder.Entity<SubjectParticipationEntity>();
      cfgSubjectParticipation.ToTable("ImsSubjectParticipations");
      cfgSubjectParticipation.HasKey((e) => new {e.ParticipantIdentifier, e.ResearchStudyUid});

      // LOOKUP: >>> StudyExecutionScope
      cfgSubjectParticipation
        .HasOne((lcl) => lcl.StudyExecutionScope )
        .WithMany((rem) => rem.CreatedParticipations )
        .HasForeignKey(nameof(SubjectParticipationEntity.CreatedForStudyExecutionIdentifier))
        .OnDelete(DeleteBehavior.Restrict);

      // PRINCIPAL: >>> StudyScope
      cfgSubjectParticipation
        .HasOne((lcl) => lcl.StudyScope )
        .WithMany((rem) => rem.Participations )
        .HasForeignKey(nameof(SubjectParticipationEntity.ResearchStudyUid))
        .OnDelete(DeleteBehavior.Cascade);

      // LOOKUP: >>> SubjectIdentity
      cfgSubjectParticipation
        .HasOne((lcl) => lcl.Identity )
        .WithMany((rem) => rem.Participations )
        .HasForeignKey(nameof(SubjectParticipationEntity.SubjectIdentityRecordId))
        .OnDelete(DeleteBehavior.Restrict);

      //////////////////////////////////////////////////////////////////////////////////////
      // StudyExecutionScope
      //////////////////////////////////////////////////////////////////////////////////////

      var cfgStudyExecutionScope = modelBuilder.Entity<StudyExecutionScopeEntity>();
      cfgStudyExecutionScope.ToTable("ImsStudyExecutionScopes");
      cfgStudyExecutionScope.HasKey((e) => e.StudyExecutionIdentifier);

      // PRINCIPAL: >>> StudyScope
      cfgStudyExecutionScope
        .HasOne((lcl) => lcl.StudyScope )
        .WithMany((rem) => rem.ExecutionScopes )
        .HasForeignKey(nameof(StudyExecutionScopeEntity.ResearchStudyUid))
        .OnDelete(DeleteBehavior.Cascade);

      //////////////////////////////////////////////////////////////////////////////////////
      // StudyScope
      //////////////////////////////////////////////////////////////////////////////////////

      var cfgStudyScope = modelBuilder.Entity<StudyScopeEntity>();
      cfgStudyScope.ToTable("ImsStudyScopes");
      cfgStudyScope.HasKey((e) => e.ResearchStudyUid);

      //////////////////////////////////////////////////////////////////////////////////////
      // SubjectAddress
      //////////////////////////////////////////////////////////////////////////////////////

      var cfgSubjectAddress = modelBuilder.Entity<SubjectAddressEntity>();
      cfgSubjectAddress.ToTable("ImsSubjectAddresses");
      cfgSubjectAddress.HasKey((e) => e.InternalRecordId);

      //////////////////////////////////////////////////////////////////////////////////////
      // SubjectIdentity
      //////////////////////////////////////////////////////////////////////////////////////

      var cfgSubjectIdentity = modelBuilder.Entity<SubjectIdentityEntity>();
      cfgSubjectIdentity.ToTable("ImsSubjectIdentities");
      cfgSubjectIdentity.HasKey((e) => e.RecordId);

      // LOOKUP: >>> SubjectAddress
      cfgSubjectIdentity
        .HasOne((lcl) => lcl.ResidentAddress )
        .WithMany((rem) => rem.SubjectIdentities )
        .HasForeignKey(nameof(SubjectIdentityEntity.ResidentAddressId))
        .OnDelete(DeleteBehavior.Restrict);

#endregion

      this.OnModelCreatingCustom(modelBuilder);
    }

    partial void OnModelCreatingCustom(ModelBuilder modelBuilder);

    protected override void OnConfiguring(DbContextOptionsBuilder options) {

      //reqires separate nuget-package Microsoft.EntityFrameworkCore.SqlServer
      options.UseSqlServer(_ConnectionString);

      //reqires separate nuget-package Microsoft.EntityFrameworkCore.Proxies
      options.UseLazyLoadingProxies();

      this.OnConfiguringCustom(options);
    }

    partial void OnConfiguringCustom(DbContextOptionsBuilder options);

    public static void Migrate() {
      if (!_Migrated) {
        IdentityManagementDbContext c = new IdentityManagementDbContext();
        c.Database.Migrate();
        _Migrated = true;
        c.Dispose();
      }
    }

   private static bool _Migrated = false;

    private static String _ConnectionString = "Server=(localdb)\\MsSqlLocalDb;Database=IdentityManagementDbContext;Integrated Security=True;Persist Security Info=True;MultipleActiveResultSets=True;";
    public static String ConnectionString {
      set{ _ConnectionString = value;  }
    }

  }

}
