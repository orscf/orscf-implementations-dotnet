using System;
using Microsoft.EntityFrameworkCore;
using MedicalResearch.Workflow.Persistence;

namespace MedicalResearch.Workflow.Persistence.EF {

  /// <summary> EntityFramework DbContext (based on schema version '1.3.0') </summary>
  public partial class WorkflowDefinitionDbContext : DbContext{

    public const String SchemaVersion = "1.3.0";

    public DbSet<ArmEntity> Arms { get; set; }

    public DbSet<ResearchStudyEntity> ResearchStudies { get; set; }

    public DbSet<ProcedureScheduleEntity> ProcedureSchedules { get; set; }

    public DbSet<DataRecordingTaskEntity> DataRecordingTasks { get; set; }

    public DbSet<InducedDataRecordingTaskEntity> InducedDataRecordingTasks { get; set; }

    public DbSet<DrugApplymentTaskEntity> DrugAppliymentTasks { get; set; }

    public DbSet<InducedDrugApplymentTaskEntity> InducedDrugApplymentTasks { get; set; }

    public DbSet<TaskScheduleEntity> TaskSchedules { get; set; }

    public DbSet<InducedSubProcedureScheduleEntity> InducedSubProcedureSchedules { get; set; }

    public DbSet<InducedSubTaskScheduleEntity> InducedSubTaskSchedules { get; set; }

    public DbSet<InducedTreatmentTaskEntity> InducedTreatmentTasks { get; set; }

    public DbSet<TreatmentTaskEntity> TreatmentTasks { get; set; }

    public DbSet<InducedVisitProcedureEntity> InducedVisitProcedures { get; set; }

    public DbSet<VisitProdecureDefinitionEntity> VisitProdecureDefinitions { get; set; }

    public DbSet<ProcedureCycleDefinitionEntity> ProcedureCycleDefinitions { get; set; }

    public DbSet<StudyEventEntity> StudyEvents { get; set; }

    public DbSet<TaskCycleDefinitionEntity> TaskCycleDefinitions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      base.OnModelCreating(modelBuilder);

#region Mapping

      //////////////////////////////////////////////////////////////////////////////////////
      // Arm
      //////////////////////////////////////////////////////////////////////////////////////

      var cfgArm = modelBuilder.Entity<ArmEntity>();
      cfgArm.ToTable("WdrArms");
      cfgArm.HasKey((e) => new {e.StudyArmName, e.StudyWorkflowName, e.StudyWorkflowVersion});

      // PRINCIPAL: >>> ResearchStudy
      cfgArm
        .HasOne((lcl) => lcl.ResearchStudy )
        .WithMany((rem) => rem.Arms )
        .HasForeignKey(nameof(ArmEntity.StudyWorkflowName), nameof(ArmEntity.StudyWorkflowVersion))
        .OnDelete(DeleteBehavior.Cascade);

      // LOOKUP: >>> ProcedureSchedule
      cfgArm
        .HasOne((lcl) => lcl.RootProcedureSchedule )
        .WithMany((rem) => rem.EntryArms )
        .HasForeignKey(nameof(ArmEntity.RootProcedureScheduleId))
        .OnDelete(DeleteBehavior.Restrict);

      //////////////////////////////////////////////////////////////////////////////////////
      // ResearchStudy
      //////////////////////////////////////////////////////////////////////////////////////

      var cfgResearchStudy = modelBuilder.Entity<ResearchStudyEntity>();
      cfgResearchStudy.ToTable("WdrResearchStudies");
      cfgResearchStudy.HasKey((e) => new {e.StudyWorkflowName, e.StudyWorkflowVersion});

      //////////////////////////////////////////////////////////////////////////////////////
      // ProcedureSchedule
      //////////////////////////////////////////////////////////////////////////////////////

      var cfgProcedureSchedule = modelBuilder.Entity<ProcedureScheduleEntity>();
      cfgProcedureSchedule.ToTable("WdrProcedureSchedules");
      cfgProcedureSchedule.HasKey((e) => e.ProcedureScheduleId);

      // PRINCIPAL: >>> ResearchStudy
      cfgProcedureSchedule
        .HasOne((lcl) => lcl.ResearchStudy )
        .WithMany((rem) => rem.ProcedureSchedules )
        .HasForeignKey(nameof(ProcedureScheduleEntity.StudyWorkflowName), nameof(ProcedureScheduleEntity.StudyWorkflowVersion))
        .OnDelete(DeleteBehavior.Cascade);

      //////////////////////////////////////////////////////////////////////////////////////
      // DataRecordingTask
      //////////////////////////////////////////////////////////////////////////////////////

      var cfgDataRecordingTask = modelBuilder.Entity<DataRecordingTaskEntity>();
      cfgDataRecordingTask.ToTable("WdrDataRecordingTasks");
      cfgDataRecordingTask.HasKey((e) => e.DataRecordingName);

      // PRINCIPAL: >>> ResearchStudy
      cfgDataRecordingTask
        .HasOne((lcl) => lcl.ResearchStudy )
        .WithMany((rem) => rem.DataRecordingTasks )
        .HasForeignKey(nameof(DataRecordingTaskEntity.StudyWorkflowName), nameof(DataRecordingTaskEntity.StudyWorkflowVersion))
        .OnDelete(DeleteBehavior.Cascade);

      //////////////////////////////////////////////////////////////////////////////////////
      // InducedDataRecordingTask
      //////////////////////////////////////////////////////////////////////////////////////

      var cfgInducedDataRecordingTask = modelBuilder.Entity<InducedDataRecordingTaskEntity>();
      cfgInducedDataRecordingTask.ToTable("WdrInducedDataRecordingTasks");
      cfgInducedDataRecordingTask.HasKey((e) => e.Id);

      // LOOKUP: >>> DataRecordingTask
      cfgInducedDataRecordingTask
        .HasOne((lcl) => lcl.InducedTask )
        .WithMany((rem) => rem.Inducements )
        .HasForeignKey(nameof(InducedDataRecordingTaskEntity.InducedDataRecordingName))
        .OnDelete(DeleteBehavior.Restrict);

      // PRINCIPAL: >>> TaskSchedule
      cfgInducedDataRecordingTask
        .HasOne((lcl) => lcl.TaskSchedule )
        .WithMany((rem) => rem.InducedDataRecordingTasks )
        .HasForeignKey(nameof(InducedDataRecordingTaskEntity.TaskScheduleId))
        .OnDelete(DeleteBehavior.Cascade);

      //////////////////////////////////////////////////////////////////////////////////////
      // DrugApplymentTask
      //////////////////////////////////////////////////////////////////////////////////////

      var cfgDrugApplymentTask = modelBuilder.Entity<DrugApplymentTaskEntity>();
      cfgDrugApplymentTask.ToTable("WdrDrugAppliymentTasks");
      cfgDrugApplymentTask.HasKey((e) => e.DrugApplymentName);

      // PRINCIPAL: >>> ResearchStudy
      cfgDrugApplymentTask
        .HasOne((lcl) => lcl.ResearchStudy )
        .WithMany((rem) => rem.DrugApplymentTasks )
        .HasForeignKey(nameof(DrugApplymentTaskEntity.StudyWorkflowName), nameof(DrugApplymentTaskEntity.StudyWorkflowVersion))
        .OnDelete(DeleteBehavior.Cascade);

      //////////////////////////////////////////////////////////////////////////////////////
      // InducedDrugApplymentTask
      //////////////////////////////////////////////////////////////////////////////////////

      var cfgInducedDrugApplymentTask = modelBuilder.Entity<InducedDrugApplymentTaskEntity>();
      cfgInducedDrugApplymentTask.ToTable("WdrInducedDrugApplymentTasks");
      cfgInducedDrugApplymentTask.HasKey((e) => e.Id);

      // LOOKUP: >>> DrugApplymentTask
      cfgInducedDrugApplymentTask
        .HasOne((lcl) => lcl.InducedTask )
        .WithMany((rem) => rem.Inducements )
        .HasForeignKey(nameof(InducedDrugApplymentTaskEntity.InducedDrugApplymentName))
        .OnDelete(DeleteBehavior.Restrict);

      // PRINCIPAL: >>> TaskSchedule
      cfgInducedDrugApplymentTask
        .HasOne((lcl) => lcl.TaskSchedule )
        .WithMany((rem) => rem.InducedDrugApplymentTasks )
        .HasForeignKey(nameof(InducedDrugApplymentTaskEntity.TaskScheduleId))
        .OnDelete(DeleteBehavior.Cascade);

      //////////////////////////////////////////////////////////////////////////////////////
      // TaskSchedule
      //////////////////////////////////////////////////////////////////////////////////////

      var cfgTaskSchedule = modelBuilder.Entity<TaskScheduleEntity>();
      cfgTaskSchedule.ToTable("WdrTaskSchedules");
      cfgTaskSchedule.HasKey((e) => e.TaskScheduleId);

      // PRINCIPAL: >>> ResearchStudy
      cfgTaskSchedule
        .HasOne((lcl) => lcl.ResearchStudy )
        .WithMany((rem) => rem.TaskSchedules )
        .HasForeignKey(nameof(TaskScheduleEntity.StudyWorkflowName), nameof(TaskScheduleEntity.StudyWorkflowVersion))
        .OnDelete(DeleteBehavior.Cascade);

      //////////////////////////////////////////////////////////////////////////////////////
      // InducedSubProcedureSchedule
      //////////////////////////////////////////////////////////////////////////////////////

      var cfgInducedSubProcedureSchedule = modelBuilder.Entity<InducedSubProcedureScheduleEntity>();
      cfgInducedSubProcedureSchedule.ToTable("WdrInducedSubProcedureSchedules");
      cfgInducedSubProcedureSchedule.HasKey((e) => e.Id);

      // PRINCIPAL: >>> ProcedureSchedule
      cfgInducedSubProcedureSchedule
        .HasOne((lcl) => lcl.ParentProcedureSchedule )
        .WithMany((rem) => rem.InducedSubProcedureSchedules )
        .HasForeignKey(nameof(InducedSubProcedureScheduleEntity.ParentProcedureScheduleId))
        .OnDelete(DeleteBehavior.Cascade);

      // LOOKUP: >>> ProcedureSchedule
      cfgInducedSubProcedureSchedule
        .HasOne((lcl) => lcl.InducedProcedureSchedule )
        .WithMany((rem) => rem.InducingSubProcedureSchedules )
        .HasForeignKey(nameof(InducedSubProcedureScheduleEntity.InducedProcedureScheduleId))
        .OnDelete(DeleteBehavior.Restrict);

      //////////////////////////////////////////////////////////////////////////////////////
      // InducedSubTaskSchedule
      //////////////////////////////////////////////////////////////////////////////////////

      var cfgInducedSubTaskSchedule = modelBuilder.Entity<InducedSubTaskScheduleEntity>();
      cfgInducedSubTaskSchedule.ToTable("WdrInducedSubTaskSchedules");
      cfgInducedSubTaskSchedule.HasKey((e) => e.Id);

      // PRINCIPAL: >>> TaskSchedule
      cfgInducedSubTaskSchedule
        .HasOne((lcl) => lcl.ParentTaskSchedule )
        .WithMany((rem) => rem.InducedSubTaskSchedules )
        .HasForeignKey(nameof(InducedSubTaskScheduleEntity.ParentTaskScheduleId))
        .OnDelete(DeleteBehavior.Cascade);

      // LOOKUP: >>> TaskSchedule
      cfgInducedSubTaskSchedule
        .HasOne((lcl) => lcl.InducedTaskSchedule )
        .WithMany((rem) => rem.InducingTaskSchedules )
        .HasForeignKey(nameof(InducedSubTaskScheduleEntity.InducedTaskScheduleId))
        .OnDelete(DeleteBehavior.Restrict);

      //////////////////////////////////////////////////////////////////////////////////////
      // InducedTreatmentTask
      //////////////////////////////////////////////////////////////////////////////////////

      var cfgInducedTreatmentTask = modelBuilder.Entity<InducedTreatmentTaskEntity>();
      cfgInducedTreatmentTask.ToTable("WdrInducedTreatmentTasks");
      cfgInducedTreatmentTask.HasKey((e) => e.Id);

      // PRINCIPAL: >>> TaskSchedule
      cfgInducedTreatmentTask
        .HasOne((lcl) => lcl.TaskSchedule )
        .WithMany((rem) => rem.InducedTreatmentTasks )
        .HasForeignKey(nameof(InducedTreatmentTaskEntity.TaskScheduleId))
        .OnDelete(DeleteBehavior.Cascade);

      // LOOKUP: >>> TreatmentTask
      cfgInducedTreatmentTask
        .HasOne((lcl) => lcl.InducedTask )
        .WithMany((rem) => rem.Inducements )
        .HasForeignKey(nameof(InducedTreatmentTaskEntity.InducedTreatmentName))
        .OnDelete(DeleteBehavior.Restrict);

      //////////////////////////////////////////////////////////////////////////////////////
      // TreatmentTask
      //////////////////////////////////////////////////////////////////////////////////////

      var cfgTreatmentTask = modelBuilder.Entity<TreatmentTaskEntity>();
      cfgTreatmentTask.ToTable("WdrTreatmentTasks");
      cfgTreatmentTask.HasKey((e) => e.TreatmentName);

      // PRINCIPAL: >>> ResearchStudy
      cfgTreatmentTask
        .HasOne((lcl) => lcl.ResearchStudy )
        .WithMany((rem) => rem.TreatmentTasks )
        .HasForeignKey(nameof(TreatmentTaskEntity.StudyWorkflowName), nameof(TreatmentTaskEntity.StudyWorkflowVersion))
        .OnDelete(DeleteBehavior.Cascade);

      //////////////////////////////////////////////////////////////////////////////////////
      // InducedVisitProcedure
      //////////////////////////////////////////////////////////////////////////////////////

      var cfgInducedVisitProcedure = modelBuilder.Entity<InducedVisitProcedureEntity>();
      cfgInducedVisitProcedure.ToTable("WdrInducedVisitProcedures");
      cfgInducedVisitProcedure.HasKey((e) => e.Id);

      // PRINCIPAL: >>> ProcedureSchedule
      cfgInducedVisitProcedure
        .HasOne((lcl) => lcl.ProcedureSchedule )
        .WithMany((rem) => rem.InducedProcedures )
        .HasForeignKey(nameof(InducedVisitProcedureEntity.ProcedureScheduleId))
        .OnDelete(DeleteBehavior.Cascade);

      // LOOKUP: >>> VisitProdecureDefinition
      cfgInducedVisitProcedure
        .HasOne((lcl) => lcl.InducedVisitProdecure )
        .WithMany((rem) => rem.Inducements )
        .HasForeignKey(nameof(InducedVisitProcedureEntity.InducedVisitProdecureName))
        .OnDelete(DeleteBehavior.Restrict);

      //////////////////////////////////////////////////////////////////////////////////////
      // VisitProdecureDefinition
      //////////////////////////////////////////////////////////////////////////////////////

      var cfgVisitProdecureDefinition = modelBuilder.Entity<VisitProdecureDefinitionEntity>();
      cfgVisitProdecureDefinition.ToTable("WdrVisitProdecureDefinitions");
      cfgVisitProdecureDefinition.HasKey((e) => e.VisitProdecureName);

      // PRINCIPAL: >>> ResearchStudy
      cfgVisitProdecureDefinition
        .HasOne((lcl) => lcl.ResearchStudy )
        .WithMany((rem) => rem.VisitProdecureDefinitions )
        .HasForeignKey(nameof(VisitProdecureDefinitionEntity.StudyWorkflowName), nameof(VisitProdecureDefinitionEntity.StudyWorkflowVersion))
        .OnDelete(DeleteBehavior.Cascade);

      // LOOKUP: >>> TaskSchedule
      cfgVisitProdecureDefinition
        .HasOne((lcl) => lcl.RootTaskSchedule )
        .WithMany((rem) => rem.EntryVisitProdecureDefinitions )
        .HasForeignKey(nameof(VisitProdecureDefinitionEntity.RootTaskScheduleId))
        .OnDelete(DeleteBehavior.Restrict);

      //////////////////////////////////////////////////////////////////////////////////////
      // ProcedureCycleDefinition
      //////////////////////////////////////////////////////////////////////////////////////

      var cfgProcedureCycleDefinition = modelBuilder.Entity<ProcedureCycleDefinitionEntity>();
      cfgProcedureCycleDefinition.ToTable("WdrProcedureCycleDefinitions");
      cfgProcedureCycleDefinition.HasKey((e) => e.ProcedureScheduleId);

      // PRINCIPAL: >>> ProcedureSchedule
      cfgProcedureCycleDefinition
        .HasOne((lcl) => lcl.ProcedureSchedule )
        .WithOne((rem) => rem.CycleDefinition )
        .HasForeignKey(typeof(ProcedureCycleDefinitionEntity), nameof(ProcedureCycleDefinitionEntity.ProcedureScheduleId))
        .OnDelete(DeleteBehavior.Cascade);

      //////////////////////////////////////////////////////////////////////////////////////
      // StudyEvent
      //////////////////////////////////////////////////////////////////////////////////////

      var cfgStudyEvent = modelBuilder.Entity<StudyEventEntity>();
      cfgStudyEvent.ToTable("WdrStudyEvents");
      cfgStudyEvent.HasKey((e) => e.StudyEventName);

      // PRINCIPAL: >>> ResearchStudy
      cfgStudyEvent
        .HasOne((lcl) => lcl.ResearchStudy )
        .WithMany((rem) => rem.Events )
        .HasForeignKey(nameof(StudyEventEntity.StudyWorkflowName), nameof(StudyEventEntity.StudyWorkflowVersion))
        .OnDelete(DeleteBehavior.Cascade);

      //////////////////////////////////////////////////////////////////////////////////////
      // TaskCycleDefinition
      //////////////////////////////////////////////////////////////////////////////////////

      var cfgTaskCycleDefinition = modelBuilder.Entity<TaskCycleDefinitionEntity>();
      cfgTaskCycleDefinition.ToTable("WdrTaskCycleDefinitions");
      cfgTaskCycleDefinition.HasKey((e) => e.TaskScheduleId);

      // PRINCIPAL: >>> TaskSchedule
      cfgTaskCycleDefinition
        .HasOne((lcl) => lcl.TaskSchedule )
        .WithOne((rem) => rem.CycleDefinition )
        .HasForeignKey(typeof(TaskCycleDefinitionEntity), nameof(TaskCycleDefinitionEntity.TaskScheduleId))
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
        WorkflowDefinitionDbContext c = new WorkflowDefinitionDbContext();
        c.Database.Migrate();
        _Migrated = true;
        c.Dispose();
      }
    }

   private static bool _Migrated = false;

    private static String _ConnectionString = "Server=(localdb)\\MsSqlLocalDb;Database=WorkflowDefinitionDbContext;Integrated Security=True;Persist Security Info=True;MultipleActiveResultSets=True;";
    public static String ConnectionString {
      set{ _ConnectionString = value;  }
    }

  }

}
