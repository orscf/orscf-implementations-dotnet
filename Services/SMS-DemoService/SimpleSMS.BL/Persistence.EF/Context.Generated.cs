using System;
using Microsoft.EntityFrameworkCore;
using MedicalResearch.StudyManagement.Persistence;

namespace MedicalResearch.StudyManagement.Persistence.EF {

  /// <summary> EntityFramework DbContext (based on schema version '1.6.0') </summary>
  public partial class StudyManagementDbContext : DbContext{

    public const String SchemaVersion = "1.6.0";

    public DbSet<InstituteEntity> Institutes { get; set; }

    /// <summary> ResearchStudy: entity, which relates to <see href="https://www.hl7.org/fhir/researchstudy.html">HL7.ResearchStudy</see> </summary>
    public DbSet<ResearchStudyEntity> ResearchStudies { get; set; }

    public DbSet<SiteEntity> Sites { get; set; }

    public DbSet<SystemEndpointEntity> SystemEndpoints { get; set; }

    public DbSet<InstituteRelatedSystemAssignmentEntity> InstituteRelatedSystemAssignments { get; set; }

    public DbSet<SystemConnectionEntity> SystemConnections { get; set; }

    public DbSet<InvolvedPersonEntity> InvolvedPersons { get; set; }

    public DbSet<InvolvementRoleEntity> InvolvementRoles { get; set; }

    public DbSet<StudyRelatedSystemAssignmentEntity> StudyRelatedSystemAssignments { get; set; }

    public DbSet<SiteRelatedSystemAssignmentEntity> SiteRelatedSystemAssignments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      base.OnModelCreating(modelBuilder);

#region Mapping

      //////////////////////////////////////////////////////////////////////////////////////
      // Institute
      //////////////////////////////////////////////////////////////////////////////////////

      var cfgInstitute = modelBuilder.Entity<InstituteEntity>();
      cfgInstitute.ToTable("SmsInstitutes");
      cfgInstitute.HasKey((e) => e.InstituteUid);

      //////////////////////////////////////////////////////////////////////////////////////
      // ResearchStudy
      //////////////////////////////////////////////////////////////////////////////////////

      var cfgResearchStudy = modelBuilder.Entity<ResearchStudyEntity>();
      cfgResearchStudy.ToTable("SmsResearchStudies");
      cfgResearchStudy.HasKey((e) => e.ResearchStudyUid);

      // LOOKUP: >>> Institute
      cfgResearchStudy
        .HasOne((lcl) => lcl.InitiatorInstitute )
        .WithMany((rem) => rem.InitiatedStudies )
        .HasForeignKey(nameof(ResearchStudyEntity.InitiatorInstituteUid))
        .OnDelete(DeleteBehavior.Restrict);

      // LOOKUP: >>> SystemEndpoint
      cfgResearchStudy
        .HasOne((lcl) => lcl.OriginWdr )
        .WithMany()
        .HasForeignKey(nameof(ResearchStudyEntity.OriginWdrEndpointUid))
        .OnDelete(DeleteBehavior.Restrict);

      //////////////////////////////////////////////////////////////////////////////////////
      // Site
      //////////////////////////////////////////////////////////////////////////////////////

      var cfgSite = modelBuilder.Entity<SiteEntity>();
      cfgSite.ToTable("SmsSites");
      cfgSite.HasKey((e) => e.SiteUid);

      // LOOKUP: >>> Institute
      cfgSite
        .HasOne((lcl) => lcl.RepresentingInstitute )
        .WithMany((rem) => rem.RepresentedSites )
        .HasForeignKey(nameof(SiteEntity.RepresentingInstituteUid))
        .OnDelete(DeleteBehavior.Restrict);

      // PRINCIPAL: >>> ResearchStudy
      cfgSite
        .HasOne((lcl) => lcl.Study )
        .WithMany((rem) => rem.Sites )
        .HasForeignKey(nameof(SiteEntity.ResearchStudyUid))
        .OnDelete(DeleteBehavior.Cascade);

      //////////////////////////////////////////////////////////////////////////////////////
      // SystemEndpoint
      //////////////////////////////////////////////////////////////////////////////////////

      var cfgSystemEndpoint = modelBuilder.Entity<SystemEndpointEntity>();
      cfgSystemEndpoint.ToTable("SmsSystemEndpoints");
      cfgSystemEndpoint.HasKey((e) => e.SystemEndpointUid);

      // PRINCIPAL: >>> Institute
      cfgSystemEndpoint
        .HasOne((lcl) => lcl.ProviderInstitute )
        .WithMany((rem) => rem.ProvidedSystemEndpoints )
        .HasForeignKey(nameof(SystemEndpointEntity.ProviderInstituteUid))
        .OnDelete(DeleteBehavior.Cascade);

      //////////////////////////////////////////////////////////////////////////////////////
      // InstituteRelatedSystemAssignment
      //////////////////////////////////////////////////////////////////////////////////////

      var cfgInstituteRelatedSystemAssignment = modelBuilder.Entity<InstituteRelatedSystemAssignmentEntity>();
      cfgInstituteRelatedSystemAssignment.ToTable("SmsInstituteRelatedSystemAssignments");
      cfgInstituteRelatedSystemAssignment.HasKey((e) => e.InstituteRelatedSystemAssignemntUid);

      // PRINCIPAL: >>> Institute
      cfgInstituteRelatedSystemAssignment
        .HasOne((lcl) => lcl.Institute )
        .WithMany((rem) => rem.SystemAssignment )
        .HasForeignKey(nameof(InstituteRelatedSystemAssignmentEntity.InstituteUid))
        .OnDelete(DeleteBehavior.Cascade);

      // LOOKUP: >>> SystemEndpoint
      cfgInstituteRelatedSystemAssignment
        .HasOne((lcl) => lcl.SystemEndpoint )
        .WithMany((rem) => rem.InstituteAssignments )
        .HasForeignKey(nameof(InstituteRelatedSystemAssignmentEntity.SystemEndpointUid))
        .OnDelete(DeleteBehavior.Restrict);

      //////////////////////////////////////////////////////////////////////////////////////
      // SystemConnection
      //////////////////////////////////////////////////////////////////////////////////////

      var cfgSystemConnection = modelBuilder.Entity<SystemConnectionEntity>();
      cfgSystemConnection.ToTable("SmsSystemConnections");
      cfgSystemConnection.HasKey((e) => e.SystemConnectionUid);

      // PRINCIPAL: >>> Institute
      cfgSystemConnection
        .HasOne((lcl) => lcl.OwnerInstitute )
        .WithMany((rem) => rem.SystemConnections )
        .HasForeignKey(nameof(SystemConnectionEntity.OwnerInstituteUid))
        .OnDelete(DeleteBehavior.Cascade);

      // LOOKUP: >>> SiteRelatedSystemAssignment
      cfgSystemConnection
        .HasOne((lcl) => lcl.DedicatedSiteRelatedSystemAssignment )
        .WithMany((rem) => rem.DedicatedSystemConnection )
        .HasForeignKey(nameof(SystemConnectionEntity.DedicatedSiteRelatedSystemAssignmentUid))
        .OnDelete(DeleteBehavior.Restrict);

      // LOOKUP: >>> SystemEndpoint
      cfgSystemConnection
        .HasOne((lcl) => lcl.TargetEndpoint )
        .WithMany()
        .HasForeignKey(nameof(SystemConnectionEntity.TargetSystemEndpointUid))
        .OnDelete(DeleteBehavior.Restrict);

      //////////////////////////////////////////////////////////////////////////////////////
      // InvolvedPerson
      //////////////////////////////////////////////////////////////////////////////////////

      var cfgInvolvedPerson = modelBuilder.Entity<InvolvedPersonEntity>();
      cfgInvolvedPerson.ToTable("SmsInvolvedPersons");
      cfgInvolvedPerson.HasKey((e) => e.InvolvedPersonUid);

      //////////////////////////////////////////////////////////////////////////////////////
      // InvolvementRole
      //////////////////////////////////////////////////////////////////////////////////////

      var cfgInvolvementRole = modelBuilder.Entity<InvolvementRoleEntity>();
      cfgInvolvementRole.ToTable("SmsInvolvementRoles");
      cfgInvolvementRole.HasKey((e) => e.InvolvedPersonRoleUid);

      // LOOKUP: >>> InvolvedPerson
      cfgInvolvementRole
        .HasOne((lcl) => lcl.InvolvedPerson )
        .WithMany((rem) => rem.InvolvementRoles )
        .HasForeignKey(nameof(InvolvementRoleEntity.InvolvedPersonUid))
        .OnDelete(DeleteBehavior.Restrict);

      // PRINCIPAL: >>> ResearchStudy
      cfgInvolvementRole
        .HasOne((lcl) => lcl.ResearchStudy )
        .WithMany((rem) => rem.InvolvementRoles )
        .HasForeignKey(nameof(InvolvementRoleEntity.ResearchStudyUid))
        .OnDelete(DeleteBehavior.Cascade);

      // LOOKUP: >>> Site
      cfgInvolvementRole
        .HasOne((lcl) => lcl.DedicatedToSite )
        .WithMany((rem) => rem.SiteDedicatedInvolvementRoles )
        .HasForeignKey(nameof(InvolvementRoleEntity.DedicatedToSiteUid))
        .OnDelete(DeleteBehavior.Restrict);

      //////////////////////////////////////////////////////////////////////////////////////
      // StudyRelatedSystemAssignment
      //////////////////////////////////////////////////////////////////////////////////////

      var cfgStudyRelatedSystemAssignment = modelBuilder.Entity<StudyRelatedSystemAssignmentEntity>();
      cfgStudyRelatedSystemAssignment.ToTable("SmsStudyRelatedSystemAssignments");
      cfgStudyRelatedSystemAssignment.HasKey((e) => e.StudyRelatedSystemAssignmentUid);

      // PRINCIPAL: >>> ResearchStudy
      cfgStudyRelatedSystemAssignment
        .HasOne((lcl) => lcl.ResearchStudy )
        .WithMany((rem) => rem.SystemAssignments )
        .HasForeignKey(nameof(StudyRelatedSystemAssignmentEntity.ResearchStudyUid))
        .OnDelete(DeleteBehavior.Cascade);

      // LOOKUP: >>> SystemEndpoint
      cfgStudyRelatedSystemAssignment
        .HasOne((lcl) => lcl.SystemEndpoint )
        .WithMany((rem) => rem.StudyAssignments )
        .HasForeignKey(nameof(StudyRelatedSystemAssignmentEntity.SystemEndpointUid))
        .OnDelete(DeleteBehavior.Restrict);

      //////////////////////////////////////////////////////////////////////////////////////
      // SiteRelatedSystemAssignment
      //////////////////////////////////////////////////////////////////////////////////////

      var cfgSiteRelatedSystemAssignment = modelBuilder.Entity<SiteRelatedSystemAssignmentEntity>();
      cfgSiteRelatedSystemAssignment.ToTable("SmsSiteRelatedSystemAssignments");
      cfgSiteRelatedSystemAssignment.HasKey((e) => e.SiteRelatedSystemAssignmentUid);

      // PRINCIPAL: >>> Site
      cfgSiteRelatedSystemAssignment
        .HasOne((lcl) => lcl.Site )
        .WithMany((rem) => rem.SystemAssignments )
        .HasForeignKey(nameof(SiteRelatedSystemAssignmentEntity.SiteUid))
        .OnDelete(DeleteBehavior.Cascade);

      // LOOKUP: >>> SystemEndpoint
      cfgSiteRelatedSystemAssignment
        .HasOne((lcl) => lcl.SystemEndpoint )
        .WithMany((rem) => rem.SiteAssignments )
        .HasForeignKey(nameof(SiteRelatedSystemAssignmentEntity.SystemEndpointUid))
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
        StudyManagementDbContext c = new StudyManagementDbContext();
        c.Database.Migrate();
        _Migrated = true;
        c.Dispose();
      }
    }

   private static bool _Migrated = false;

    private static String _ConnectionString = "Server=(localdb)\\MsSqlLocalDb;Database=StudyManagementDbContext;Integrated Security=True;Persist Security Info=True;MultipleActiveResultSets=True;";
    public static String ConnectionString {
      set{ _ConnectionString = value;  }
    }

  }

}
