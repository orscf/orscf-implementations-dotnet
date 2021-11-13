using System;
using Microsoft.EntityFrameworkCore;
using MedicalResearch.BillingData.Persistence;

namespace MedicalResearch.BillingData.Persistence.EF {

  /// <summary> EntityFramework DbContext (based on schema version '1.5.0') </summary>
  public partial class BillingDataDbContext : DbContext{

    public const String SchemaVersion = "1.5.0";

    public DbSet<BillableTaskEntity> BillableTasks { get; set; }

    public DbSet<BillableVisitEntity> BillableVisits { get; set; }

    public DbSet<StudyExecutionScopeEntity> StudyExecutionScopes { get; set; }

    /// <summary> BillingDemand: created by the sponsor </summary>
    public DbSet<BillingDemandEntity> BillingDemands { get; set; }

    /// <summary> Invoice: created by the executor-company </summary>
    public DbSet<InvoiceEntity> Invoices { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      base.OnModelCreating(modelBuilder);

#region Mapping

      //////////////////////////////////////////////////////////////////////////////////////
      // BillableTask
      //////////////////////////////////////////////////////////////////////////////////////

      var cfgBillableTask = modelBuilder.Entity<BillableTaskEntity>();
      cfgBillableTask.ToTable("BdrBillableTasks");
      cfgBillableTask.HasKey((e) => e.TaskGuid);

      // PRINCIPAL: >>> BillableVisit
      cfgBillableTask
        .HasOne((lcl) => lcl.BillableVisit )
        .WithMany((rem) => rem.BillableTasks )
        .HasForeignKey(nameof(BillableTaskEntity.VisitGuid))
        .OnDelete(DeleteBehavior.Cascade);

      //////////////////////////////////////////////////////////////////////////////////////
      // BillableVisit
      //////////////////////////////////////////////////////////////////////////////////////

      var cfgBillableVisit = modelBuilder.Entity<BillableVisitEntity>();
      cfgBillableVisit.ToTable("BdrBillableVisits");
      cfgBillableVisit.HasKey((e) => e.VisitGuid);

      // PRINCIPAL: >>> StudyExecutionScope
      cfgBillableVisit
        .HasOne((lcl) => lcl.StudyExecution )
        .WithMany((rem) => rem.BillableVisits )
        .HasForeignKey(nameof(BillableVisitEntity.StudyExecutionIdentifier))
        .OnDelete(DeleteBehavior.Cascade);

      // LOOKUP: >>> BillingDemand
      cfgBillableVisit
        .HasOne((lcl) => lcl.AssignedBillingDemand )
        .WithMany((rem) => rem.AssignedVisits )
        .HasForeignKey(nameof(BillableVisitEntity.BillingDemandId))
        .OnDelete(DeleteBehavior.Restrict);

      // LOOKUP: >>> Invoice
      cfgBillableVisit
        .HasOne((lcl) => lcl.AssignedInvoice )
        .WithMany((rem) => rem.AssignedVisits )
        .HasForeignKey(nameof(BillableVisitEntity.InvoiceId))
        .OnDelete(DeleteBehavior.Restrict);

      //////////////////////////////////////////////////////////////////////////////////////
      // StudyExecutionScope
      //////////////////////////////////////////////////////////////////////////////////////

      var cfgStudyExecutionScope = modelBuilder.Entity<StudyExecutionScopeEntity>();
      cfgStudyExecutionScope.ToTable("BdrStudyExecutionScopes");
      cfgStudyExecutionScope.HasKey((e) => e.StudyExecutionIdentifier);

      //////////////////////////////////////////////////////////////////////////////////////
      // BillingDemand
      //////////////////////////////////////////////////////////////////////////////////////

      var cfgBillingDemand = modelBuilder.Entity<BillingDemandEntity>();
      cfgBillingDemand.ToTable("BdrBillingDemands");
      cfgBillingDemand.HasKey((e) => e.Id);

      // PRINCIPAL: >>> StudyExecutionScope
      cfgBillingDemand
        .HasOne((lcl) => lcl.StudyExecution )
        .WithMany((rem) => rem.BillingDemands )
        .HasForeignKey(nameof(BillingDemandEntity.StudyExecutionIdentifier))
        .OnDelete(DeleteBehavior.Cascade);

      //////////////////////////////////////////////////////////////////////////////////////
      // Invoice
      //////////////////////////////////////////////////////////////////////////////////////

      var cfgInvoice = modelBuilder.Entity<InvoiceEntity>();
      cfgInvoice.ToTable("BdrInvoices");
      cfgInvoice.HasKey((e) => e.Id);

      // PRINCIPAL: >>> StudyExecutionScope
      cfgInvoice
        .HasOne((lcl) => lcl.StudyExecution )
        .WithMany((rem) => rem.Invoices )
        .HasForeignKey(nameof(InvoiceEntity.StudyExecutionIdentifier))
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
        BillingDataDbContext c = new BillingDataDbContext();
        c.Database.Migrate();
        _Migrated = true;
        c.Dispose();
      }
    }

   private static bool _Migrated = false;

    private static String _ConnectionString = "Server=(localdb)\\MsSqlLocalDb;Database=BillingDataDbContext;Integrated Security=True;Persist Security Info=True;MultipleActiveResultSets=True;";
    public static String ConnectionString {
      set{ _ConnectionString = value;  }
    }

  }

}
