using System;
using Microsoft.EntityFrameworkCore;
using MedicalResearch.VisitData.Persistence;

namespace MedicalResearch.VisitData.Persistence.EF {

  /// <summary> EntityFramework DbContext (based on schema version '1.3.0') </summary>
  public partial class VisitDataDbContext : DbContext{

    public const String SchemaVersion = "1.3.0";

    public DbSet<DataRecordingEntity> DataRecordings { get; set; }

    public DbSet<VisitEntity> Visits { get; set; }

    public DbSet<DrugApplymentEntity> DrugApplyments { get; set; }

    public DbSet<StudyEventEntity> StudyEvents { get; set; }

    public DbSet<StudyExecutionScopeEntity> StudyExecutionScopes { get; set; }

    public DbSet<TreatmentEntity> Treatments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      base.OnModelCreating(modelBuilder);

#region Mapping

      //////////////////////////////////////////////////////////////////////////////////////
      // DataRecording
      //////////////////////////////////////////////////////////////////////////////////////

      var cfgDataRecording = modelBuilder.Entity<DataRecordingEntity>();
      cfgDataRecording.ToTable("VdrDataRecordings");
      cfgDataRecording.HasKey((e) => e.TaskGuid);

      // PRINCIPAL: >>> Visit
      cfgDataRecording
        .HasOne((lcl) => lcl.Visit )
        .WithMany((rem) => rem.DataRecordings )
        .HasForeignKey(nameof(DataRecordingEntity.VisitGuid))
        .OnDelete(DeleteBehavior.Cascade);

      //////////////////////////////////////////////////////////////////////////////////////
      // Visit
      //////////////////////////////////////////////////////////////////////////////////////

      var cfgVisit = modelBuilder.Entity<VisitEntity>();
      cfgVisit.ToTable("VdrVisits");
      cfgVisit.HasKey((e) => e.VisitGuid);

      // LOOKUP: >>> StudyExecutionScope
      cfgVisit
        .HasOne((lcl) => lcl.StudyExecution )
        .WithMany((rem) => rem.Visits )
        .HasForeignKey(nameof(VisitEntity.StudyExecutionIdentifier))
        .OnDelete(DeleteBehavior.Restrict);

      //////////////////////////////////////////////////////////////////////////////////////
      // DrugApplyment
      //////////////////////////////////////////////////////////////////////////////////////

      var cfgDrugApplyment = modelBuilder.Entity<DrugApplymentEntity>();
      cfgDrugApplyment.ToTable("VdrDrugApplyments");
      cfgDrugApplyment.HasKey((e) => e.TaskGuid);

      // PRINCIPAL: >>> Visit
      cfgDrugApplyment
        .HasOne((lcl) => lcl.Visit )
        .WithMany((rem) => rem.DrugApplyments )
        .HasForeignKey(nameof(DrugApplymentEntity.VisitGuid))
        .OnDelete(DeleteBehavior.Cascade);

      //////////////////////////////////////////////////////////////////////////////////////
      // StudyEvent
      //////////////////////////////////////////////////////////////////////////////////////

      var cfgStudyEvent = modelBuilder.Entity<StudyEventEntity>();
      cfgStudyEvent.ToTable("VdrStudyEvents");
      cfgStudyEvent.HasKey((e) => e.EventGuid);

      // LOOKUP: >>> StudyExecutionScope
      cfgStudyEvent
        .HasOne((lcl) => lcl.StudyExecution )
        .WithMany((rem) => rem.Events )
        .HasForeignKey(nameof(StudyEventEntity.StudyExecutionIdentifier))
        .OnDelete(DeleteBehavior.Restrict);

      //////////////////////////////////////////////////////////////////////////////////////
      // StudyExecutionScope
      //////////////////////////////////////////////////////////////////////////////////////

      var cfgStudyExecutionScope = modelBuilder.Entity<StudyExecutionScopeEntity>();
      cfgStudyExecutionScope.ToTable("VdrStudyExecutionScopes");
      cfgStudyExecutionScope.HasKey((e) => e.StudyExecutionIdentifier);

      //////////////////////////////////////////////////////////////////////////////////////
      // Treatment
      //////////////////////////////////////////////////////////////////////////////////////

      var cfgTreatment = modelBuilder.Entity<TreatmentEntity>();
      cfgTreatment.ToTable("VdrTreatments");
      cfgTreatment.HasKey((e) => e.TaskGuid);

      // PRINCIPAL: >>> Visit
      cfgTreatment
        .HasOne((lcl) => lcl.Visit )
        .WithMany((rem) => rem.Treatments )
        .HasForeignKey(nameof(TreatmentEntity.VisitGuid))
        .OnDelete(DeleteBehavior.Cascade);

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
        VisitDataDbContext c = new VisitDataDbContext();
        c.Database.Migrate();
        _Migrated = true;
        c.Dispose();
      }
    }

   private static bool _Migrated = false;

    private static String _ConnectionString = "Server=(localdb)\\MsSqlLocalDb;Database=VisitDataDbContext;Integrated Security=True;Persist Security Info=True;MultipleActiveResultSets=True;";
    public static String ConnectionString {
      set{ _ConnectionString = value;  }
    }

  }

}
