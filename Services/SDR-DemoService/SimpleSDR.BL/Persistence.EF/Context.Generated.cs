using System;
using Microsoft.EntityFrameworkCore;
using MedicalResearch.SubjectData.Persistence;

namespace MedicalResearch.SubjectData.Persistence.EF {

  /// <summary> EntityFramework DbContext (based on schema version '0.1.0') </summary>
  public partial class SubjectDataDbContext : DbContext{

    public const String SchemaVersion = "0.1.0";

    /// <summary> Subject: entity, which relates to <see href="https://www.hl7.org/fhir/researchsubject.html">HL7.ResearchSubject</see> </summary>
    public DbSet<SubjectEntity> Subjects { get; set; }

    public DbSet<SubjectSiteAssignmentEntity> SubjectSiteAssignments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      base.OnModelCreating(modelBuilder);

#region Mapping

      //////////////////////////////////////////////////////////////////////////////////////
      // Subject
      //////////////////////////////////////////////////////////////////////////////////////

      var cfgSubject = modelBuilder.Entity<SubjectEntity>();
      cfgSubject.ToTable("SmsSubjects");
      cfgSubject.HasKey((e) => e.SubjectUid);

      //////////////////////////////////////////////////////////////////////////////////////
      // SubjectSiteAssignment
      //////////////////////////////////////////////////////////////////////////////////////

      var cfgSubjectSiteAssignment = modelBuilder.Entity<SubjectSiteAssignmentEntity>();
      cfgSubjectSiteAssignment.ToTable("SmsSubjectSiteAssignments");
      cfgSubjectSiteAssignment.HasKey((e) => e.SubjectSiteAssignmentUid);

      // LOOKUP: >>> Subject
      cfgSubjectSiteAssignment
        .HasOne((lcl) => lcl.Subject )
        .WithMany((rem) => rem.SiteAssignments )
        .HasForeignKey(nameof(SubjectSiteAssignmentEntity.SubjectUid))
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
        SubjectDataDbContext c = new SubjectDataDbContext();
        c.Database.Migrate();
        _Migrated = true;
        c.Dispose();
      }
    }

   private static bool _Migrated = false;

    private static String _ConnectionString = "Server=(localdb)\\MsSqlLocalDb;Database=SubjectDataDbContext;Integrated Security=True;Persist Security Info=True;MultipleActiveResultSets=True;";
    public static String ConnectionString {
      set{ _ConnectionString = value;  }
    }

  }

}
