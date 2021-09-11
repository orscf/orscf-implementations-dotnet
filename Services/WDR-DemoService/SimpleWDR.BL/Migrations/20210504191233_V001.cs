using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicalResearch.Workflow.Migrations
{
    public partial class V001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WdrResearchStudies",
                columns: table => new
                {
                    StudyWorkflowName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StudyWorkflowVersion = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    OfficialLabel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DefinitionOwner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentationUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogoImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VersionIdentity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastChangeUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DraftState = table.Column<int>(type: "int", nullable: false),
                    BillingCurrency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BillablePriceForGeneralPreparation = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    StudyDocumentationUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaseReportFormUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WdrResearchStudies", x => new { x.StudyWorkflowName, x.StudyWorkflowVersion });
                });

            migrationBuilder.CreateTable(
                name: "WdrDataRecordingTasks",
                columns: table => new
                {
                    DataRecordingName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StudyWorkflowName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StudyWorkflowVersion = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    BillablePriceOnCompletedExecution = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaskSpecificDocumentationUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImportantNotices = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataSchemaUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DefaultData = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WdrDataRecordingTasks", x => x.DataRecordingName);
                    table.ForeignKey(
                        name: "FK_WdrDataRecordingTasks_WdrResearchStudies_StudyWorkflowName_StudyWorkflowVersion",
                        columns: x => new { x.StudyWorkflowName, x.StudyWorkflowVersion },
                        principalTable: "WdrResearchStudies",
                        principalColumns: new[] { "StudyWorkflowName", "StudyWorkflowVersion" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WdrDrugAppliymentTasks",
                columns: table => new
                {
                    DrugApplymentName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StudyWorkflowName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StudyWorkflowVersion = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    BillablePriceOnCompletedExecution = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaskSpecificDocumentationUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DrugName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DrugDoseMgPerUnitMg = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitsToApply = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ApplymentRoute = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImportantNotices = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WdrDrugAppliymentTasks", x => x.DrugApplymentName);
                    table.ForeignKey(
                        name: "FK_WdrDrugAppliymentTasks_WdrResearchStudies_StudyWorkflowName_StudyWorkflowVersion",
                        columns: x => new { x.StudyWorkflowName, x.StudyWorkflowVersion },
                        principalTable: "WdrResearchStudies",
                        principalColumns: new[] { "StudyWorkflowName", "StudyWorkflowVersion" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WdrProcedureSchedules",
                columns: table => new
                {
                    ProcedureScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudyWorkflowName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StudyWorkflowVersion = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxSkipsBeforeLost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxSubsequentSkipsBeforeLost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxLostsBeforeLtfuAbort = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxSubsequentLostsBeforeLtfuAbort = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventOnLtfuAbort = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventOnCycleEnded = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventOnAllCyclesEnded = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InducingEvents = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AbortCausingEvents = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WdrProcedureSchedules", x => x.ProcedureScheduleId);
                    table.ForeignKey(
                        name: "FK_WdrProcedureSchedules_WdrResearchStudies_StudyWorkflowName_StudyWorkflowVersion",
                        columns: x => new { x.StudyWorkflowName, x.StudyWorkflowVersion },
                        principalTable: "WdrResearchStudies",
                        principalColumns: new[] { "StudyWorkflowName", "StudyWorkflowVersion" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WdrStudyEvents",
                columns: table => new
                {
                    StudyEventName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StudyWorkflowName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StudyWorkflowVersion = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MaxOccourrencesBeforeExclusion = table.Column<int>(type: "int", nullable: true),
                    AllowManualTrigger = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EvenSpecificDocumentationUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WdrStudyEvents", x => x.StudyEventName);
                    table.ForeignKey(
                        name: "FK_WdrStudyEvents_WdrResearchStudies_StudyWorkflowName_StudyWorkflowVersion",
                        columns: x => new { x.StudyWorkflowName, x.StudyWorkflowVersion },
                        principalTable: "WdrResearchStudies",
                        principalColumns: new[] { "StudyWorkflowName", "StudyWorkflowVersion" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WdrTaskSchedules",
                columns: table => new
                {
                    TaskScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudyWorkflowName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StudyWorkflowVersion = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxSkipsBeforeLost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxSubsequentSkipsBeforeLost = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxLostsBeforeLtfuAbort = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxSubsequentLostsBeforeLtfuAbort = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventOnLtfuAbort = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventOnCycleEnded = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventOnAllCyclesEnded = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InducingEvents = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AbortCausingEvents = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WdrTaskSchedules", x => x.TaskScheduleId);
                    table.ForeignKey(
                        name: "FK_WdrTaskSchedules_WdrResearchStudies_StudyWorkflowName_StudyWorkflowVersion",
                        columns: x => new { x.StudyWorkflowName, x.StudyWorkflowVersion },
                        principalTable: "WdrResearchStudies",
                        principalColumns: new[] { "StudyWorkflowName", "StudyWorkflowVersion" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WdrTreatmentTasks",
                columns: table => new
                {
                    TreatmentName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StudyWorkflowName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StudyWorkflowVersion = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    BillablePriceOnCompletedExecution = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaskSpecificDocumentationUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TreatmentDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImportantNotices = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WdrTreatmentTasks", x => x.TreatmentName);
                    table.ForeignKey(
                        name: "FK_WdrTreatmentTasks_WdrResearchStudies_StudyWorkflowName_StudyWorkflowVersion",
                        columns: x => new { x.StudyWorkflowName, x.StudyWorkflowVersion },
                        principalTable: "WdrResearchStudies",
                        principalColumns: new[] { "StudyWorkflowName", "StudyWorkflowVersion" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WdrArms",
                columns: table => new
                {
                    StudyArmName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StudyWorkflowName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StudyWorkflowVersion = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    RootProcedureScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BillablePriceOnFailedInclusion = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BillablePriceOnSuccessfullInclusion = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BillablePriceOnAbortedParticipation = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BillablePriceOnCompletedParticipation = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ArmSpecificDocumentationUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InclusionCriteria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Substudy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WdrArms", x => new { x.StudyArmName, x.StudyWorkflowName, x.StudyWorkflowVersion });
                    table.ForeignKey(
                        name: "FK_WdrArms_WdrProcedureSchedules_RootProcedureScheduleId",
                        column: x => x.RootProcedureScheduleId,
                        principalTable: "WdrProcedureSchedules",
                        principalColumn: "ProcedureScheduleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WdrArms_WdrResearchStudies_StudyWorkflowName_StudyWorkflowVersion",
                        columns: x => new { x.StudyWorkflowName, x.StudyWorkflowVersion },
                        principalTable: "WdrResearchStudies",
                        principalColumns: new[] { "StudyWorkflowName", "StudyWorkflowVersion" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WdrInducedSubProcedureSchedules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParentProcedureScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InducedProcedureScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Offset = table.Column<int>(type: "int", nullable: false),
                    OffsetUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SchedulingVariabilityBefore = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SchedulingVariabilityAfter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SchedulingVariabilityUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SharedSkipCounters = table.Column<bool>(type: "bit", nullable: false),
                    SharedLostCounters = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WdrInducedSubProcedureSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WdrInducedSubProcedureSchedules_WdrProcedureSchedules_InducedProcedureScheduleId",
                        column: x => x.InducedProcedureScheduleId,
                        principalTable: "WdrProcedureSchedules",
                        principalColumn: "ProcedureScheduleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WdrInducedSubProcedureSchedules_WdrProcedureSchedules_ParentProcedureScheduleId",
                        column: x => x.ParentProcedureScheduleId,
                        principalTable: "WdrProcedureSchedules",
                        principalColumn: "ProcedureScheduleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WdrProcedureCycleDefinitions",
                columns: table => new
                {
                    ProcedureScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReschedulingBase = table.Column<int>(type: "int", nullable: false),
                    ReschedulingOffset = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReschedulingOffsetUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CycleLimit = table.Column<int>(type: "int", nullable: true),
                    SharedSkipCounters = table.Column<bool>(type: "bit", nullable: false),
                    SharedLostCounters = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WdrProcedureCycleDefinitions", x => x.ProcedureScheduleId);
                    table.ForeignKey(
                        name: "FK_WdrProcedureCycleDefinitions_WdrProcedureSchedules_ProcedureScheduleId",
                        column: x => x.ProcedureScheduleId,
                        principalTable: "WdrProcedureSchedules",
                        principalColumn: "ProcedureScheduleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WdrInducedDataRecordingTasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaskScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InducedDataRecordingName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Offset = table.Column<int>(type: "int", nullable: false),
                    OffsetUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SchedulingVariabilityBefore = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SchedulingVariabilityAfter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SchedulingVariabilityUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InducedTaskExecutionTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Skipable = table.Column<bool>(type: "bit", nullable: false),
                    EventOnSkip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventOnLost = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WdrInducedDataRecordingTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WdrInducedDataRecordingTasks_WdrDataRecordingTasks_InducedDataRecordingName",
                        column: x => x.InducedDataRecordingName,
                        principalTable: "WdrDataRecordingTasks",
                        principalColumn: "DataRecordingName",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WdrInducedDataRecordingTasks_WdrTaskSchedules_TaskScheduleId",
                        column: x => x.TaskScheduleId,
                        principalTable: "WdrTaskSchedules",
                        principalColumn: "TaskScheduleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WdrInducedDrugApplymentTasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaskScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InducedDrugApplymentName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Offset = table.Column<int>(type: "int", nullable: false),
                    OffsetUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SchedulingVariabilityBefore = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SchedulingVariabilityAfter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SchedulingVariabilityUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InducedTaskExecutionTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Skipable = table.Column<bool>(type: "bit", nullable: false),
                    EventOnSkip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventOnLost = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WdrInducedDrugApplymentTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WdrInducedDrugApplymentTasks_WdrDrugAppliymentTasks_InducedDrugApplymentName",
                        column: x => x.InducedDrugApplymentName,
                        principalTable: "WdrDrugAppliymentTasks",
                        principalColumn: "DrugApplymentName",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WdrInducedDrugApplymentTasks_WdrTaskSchedules_TaskScheduleId",
                        column: x => x.TaskScheduleId,
                        principalTable: "WdrTaskSchedules",
                        principalColumn: "TaskScheduleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WdrInducedSubTaskSchedules",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParentTaskScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InducedTaskScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Offset = table.Column<int>(type: "int", nullable: false),
                    OffsetUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SchedulingVariabilityBefore = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SchedulingVariabilityAfter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SchedulingVariabilityUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SharedSkipCounters = table.Column<bool>(type: "bit", nullable: false),
                    SharedLostCounters = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WdrInducedSubTaskSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WdrInducedSubTaskSchedules_WdrTaskSchedules_InducedTaskScheduleId",
                        column: x => x.InducedTaskScheduleId,
                        principalTable: "WdrTaskSchedules",
                        principalColumn: "TaskScheduleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WdrInducedSubTaskSchedules_WdrTaskSchedules_ParentTaskScheduleId",
                        column: x => x.ParentTaskScheduleId,
                        principalTable: "WdrTaskSchedules",
                        principalColumn: "TaskScheduleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WdrTaskCycleDefinitions",
                columns: table => new
                {
                    TaskScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReschedulingBase = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReschedulingOffset = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReschedulingOffsetUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CycleLimit = table.Column<int>(type: "int", nullable: true),
                    SharedSkipCounters = table.Column<bool>(type: "bit", nullable: false),
                    SharedLostCounters = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WdrTaskCycleDefinitions", x => x.TaskScheduleId);
                    table.ForeignKey(
                        name: "FK_WdrTaskCycleDefinitions_WdrTaskSchedules_TaskScheduleId",
                        column: x => x.TaskScheduleId,
                        principalTable: "WdrTaskSchedules",
                        principalColumn: "TaskScheduleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WdrVisitProdecureDefinitions",
                columns: table => new
                {
                    VisitProdecureName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StudyWorkflowName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StudyWorkflowVersion = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    RootTaskScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    BillablePriceOnAbortedExecution = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BillablePriceOnCompletedExecution = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    VisitSpecificDocumentationUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WdrVisitProdecureDefinitions", x => x.VisitProdecureName);
                    table.ForeignKey(
                        name: "FK_WdrVisitProdecureDefinitions_WdrResearchStudies_StudyWorkflowName_StudyWorkflowVersion",
                        columns: x => new { x.StudyWorkflowName, x.StudyWorkflowVersion },
                        principalTable: "WdrResearchStudies",
                        principalColumns: new[] { "StudyWorkflowName", "StudyWorkflowVersion" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WdrVisitProdecureDefinitions_WdrTaskSchedules_RootTaskScheduleId",
                        column: x => x.RootTaskScheduleId,
                        principalTable: "WdrTaskSchedules",
                        principalColumn: "TaskScheduleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WdrInducedTreatmentTasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TaskScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InducedTreatmentName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Offset = table.Column<int>(type: "int", nullable: false),
                    OffsetUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SchedulingVariabilityBefore = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SchedulingVariabilityAfter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SchedulingVariabilityUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InducedTaskExecutionTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Skipable = table.Column<bool>(type: "bit", nullable: false),
                    EventOnSkip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventOnLost = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WdrInducedTreatmentTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WdrInducedTreatmentTasks_WdrTaskSchedules_TaskScheduleId",
                        column: x => x.TaskScheduleId,
                        principalTable: "WdrTaskSchedules",
                        principalColumn: "TaskScheduleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WdrInducedTreatmentTasks_WdrTreatmentTasks_InducedTreatmentName",
                        column: x => x.InducedTreatmentName,
                        principalTable: "WdrTreatmentTasks",
                        principalColumn: "TreatmentName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WdrInducedVisitProcedures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProcedureScheduleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Offset = table.Column<int>(type: "int", nullable: false),
                    OffsetUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SchedulingVariabilityBefore = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SchedulingVariabilityAfter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SchedulingVariabilityUnit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InducedVisitProdecureName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    InducedVisitExecutionTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Skipable = table.Column<bool>(type: "bit", nullable: false),
                    EventOnSkip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventOnLost = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WdrInducedVisitProcedures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WdrInducedVisitProcedures_WdrProcedureSchedules_ProcedureScheduleId",
                        column: x => x.ProcedureScheduleId,
                        principalTable: "WdrProcedureSchedules",
                        principalColumn: "ProcedureScheduleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WdrInducedVisitProcedures_WdrVisitProdecureDefinitions_InducedVisitProdecureName",
                        column: x => x.InducedVisitProdecureName,
                        principalTable: "WdrVisitProdecureDefinitions",
                        principalColumn: "VisitProdecureName",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WdrArms_RootProcedureScheduleId",
                table: "WdrArms",
                column: "RootProcedureScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_WdrArms_StudyWorkflowName_StudyWorkflowVersion",
                table: "WdrArms",
                columns: new[] { "StudyWorkflowName", "StudyWorkflowVersion" });

            migrationBuilder.CreateIndex(
                name: "IX_WdrDataRecordingTasks_StudyWorkflowName_StudyWorkflowVersion",
                table: "WdrDataRecordingTasks",
                columns: new[] { "StudyWorkflowName", "StudyWorkflowVersion" });

            migrationBuilder.CreateIndex(
                name: "IX_WdrDrugAppliymentTasks_StudyWorkflowName_StudyWorkflowVersion",
                table: "WdrDrugAppliymentTasks",
                columns: new[] { "StudyWorkflowName", "StudyWorkflowVersion" });

            migrationBuilder.CreateIndex(
                name: "IX_WdrInducedDataRecordingTasks_InducedDataRecordingName",
                table: "WdrInducedDataRecordingTasks",
                column: "InducedDataRecordingName");

            migrationBuilder.CreateIndex(
                name: "IX_WdrInducedDataRecordingTasks_TaskScheduleId",
                table: "WdrInducedDataRecordingTasks",
                column: "TaskScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_WdrInducedDrugApplymentTasks_InducedDrugApplymentName",
                table: "WdrInducedDrugApplymentTasks",
                column: "InducedDrugApplymentName");

            migrationBuilder.CreateIndex(
                name: "IX_WdrInducedDrugApplymentTasks_TaskScheduleId",
                table: "WdrInducedDrugApplymentTasks",
                column: "TaskScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_WdrInducedSubProcedureSchedules_InducedProcedureScheduleId",
                table: "WdrInducedSubProcedureSchedules",
                column: "InducedProcedureScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_WdrInducedSubProcedureSchedules_ParentProcedureScheduleId",
                table: "WdrInducedSubProcedureSchedules",
                column: "ParentProcedureScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_WdrInducedSubTaskSchedules_InducedTaskScheduleId",
                table: "WdrInducedSubTaskSchedules",
                column: "InducedTaskScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_WdrInducedSubTaskSchedules_ParentTaskScheduleId",
                table: "WdrInducedSubTaskSchedules",
                column: "ParentTaskScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_WdrInducedTreatmentTasks_InducedTreatmentName",
                table: "WdrInducedTreatmentTasks",
                column: "InducedTreatmentName");

            migrationBuilder.CreateIndex(
                name: "IX_WdrInducedTreatmentTasks_TaskScheduleId",
                table: "WdrInducedTreatmentTasks",
                column: "TaskScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_WdrInducedVisitProcedures_InducedVisitProdecureName",
                table: "WdrInducedVisitProcedures",
                column: "InducedVisitProdecureName");

            migrationBuilder.CreateIndex(
                name: "IX_WdrInducedVisitProcedures_ProcedureScheduleId",
                table: "WdrInducedVisitProcedures",
                column: "ProcedureScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_WdrProcedureSchedules_StudyWorkflowName_StudyWorkflowVersion",
                table: "WdrProcedureSchedules",
                columns: new[] { "StudyWorkflowName", "StudyWorkflowVersion" });

            migrationBuilder.CreateIndex(
                name: "IX_WdrStudyEvents_StudyWorkflowName_StudyWorkflowVersion",
                table: "WdrStudyEvents",
                columns: new[] { "StudyWorkflowName", "StudyWorkflowVersion" });

            migrationBuilder.CreateIndex(
                name: "IX_WdrTaskSchedules_StudyWorkflowName_StudyWorkflowVersion",
                table: "WdrTaskSchedules",
                columns: new[] { "StudyWorkflowName", "StudyWorkflowVersion" });

            migrationBuilder.CreateIndex(
                name: "IX_WdrTreatmentTasks_StudyWorkflowName_StudyWorkflowVersion",
                table: "WdrTreatmentTasks",
                columns: new[] { "StudyWorkflowName", "StudyWorkflowVersion" });

            migrationBuilder.CreateIndex(
                name: "IX_WdrVisitProdecureDefinitions_RootTaskScheduleId",
                table: "WdrVisitProdecureDefinitions",
                column: "RootTaskScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_WdrVisitProdecureDefinitions_StudyWorkflowName_StudyWorkflowVersion",
                table: "WdrVisitProdecureDefinitions",
                columns: new[] { "StudyWorkflowName", "StudyWorkflowVersion" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WdrArms");

            migrationBuilder.DropTable(
                name: "WdrInducedDataRecordingTasks");

            migrationBuilder.DropTable(
                name: "WdrInducedDrugApplymentTasks");

            migrationBuilder.DropTable(
                name: "WdrInducedSubProcedureSchedules");

            migrationBuilder.DropTable(
                name: "WdrInducedSubTaskSchedules");

            migrationBuilder.DropTable(
                name: "WdrInducedTreatmentTasks");

            migrationBuilder.DropTable(
                name: "WdrInducedVisitProcedures");

            migrationBuilder.DropTable(
                name: "WdrProcedureCycleDefinitions");

            migrationBuilder.DropTable(
                name: "WdrStudyEvents");

            migrationBuilder.DropTable(
                name: "WdrTaskCycleDefinitions");

            migrationBuilder.DropTable(
                name: "WdrDataRecordingTasks");

            migrationBuilder.DropTable(
                name: "WdrDrugAppliymentTasks");

            migrationBuilder.DropTable(
                name: "WdrTreatmentTasks");

            migrationBuilder.DropTable(
                name: "WdrVisitProdecureDefinitions");

            migrationBuilder.DropTable(
                name: "WdrProcedureSchedules");

            migrationBuilder.DropTable(
                name: "WdrTaskSchedules");

            migrationBuilder.DropTable(
                name: "WdrResearchStudies");
        }
    }
}
