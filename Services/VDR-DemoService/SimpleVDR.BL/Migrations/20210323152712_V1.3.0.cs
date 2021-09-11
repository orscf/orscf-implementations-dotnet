using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicalResearch.VisitData.Migrations
{
    public partial class V130 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VdrStudyExecutionScopes",
                columns: table => new
                {
                    StudyExecutionIdentifier = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExecutingInstituteIdentifier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudyWorkflowName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StudyWorkflowVersion = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    ExtendedMetaData = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VdrStudyExecutionScopes", x => x.StudyExecutionIdentifier);
                });

            migrationBuilder.CreateTable(
                name: "VdrStudyEvents",
                columns: table => new
                {
                    EventGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParticipantIdentifier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudyExecutionIdentifier = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudyEventName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExtendedMetaData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OccourrenceDateTimeUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CauseInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdditionalNotes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VdrStudyEvents", x => x.EventGuid);
                    table.ForeignKey(
                        name: "FK_VdrStudyEvents_VdrStudyExecutionScopes_StudyExecutionIdentifier",
                        column: x => x.StudyExecutionIdentifier,
                        principalTable: "VdrStudyExecutionScopes",
                        principalColumn: "StudyExecutionIdentifier",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VdrVisits",
                columns: table => new
                {
                    VisitGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParticipantIdentifier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StudyExecutionIdentifier = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VisitProdecureName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VisitExecutionTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScheduledDateUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExecutionDateUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExecutionState = table.Column<int>(type: "int", nullable: false),
                    ExtendedMetaData = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExecutingPerson = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VdrVisits", x => x.VisitGuid);
                    table.ForeignKey(
                        name: "FK_VdrVisits_VdrStudyExecutionScopes_StudyExecutionIdentifier",
                        column: x => x.StudyExecutionIdentifier,
                        principalTable: "VdrStudyExecutionScopes",
                        principalColumn: "StudyExecutionIdentifier",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VdrDataRecordings",
                columns: table => new
                {
                    TaskGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VisitGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataRecordingName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaskExecutionTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScheduledDateTimeUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExecutionDateTimeUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExecutionState = table.Column<int>(type: "int", nullable: false),
                    DataSchemaUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecordedData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NotesRegardingOutcome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtendedMetaData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExecutingPerson = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VdrDataRecordings", x => x.TaskGuid);
                    table.ForeignKey(
                        name: "FK_VdrDataRecordings_VdrVisits_VisitGuid",
                        column: x => x.VisitGuid,
                        principalTable: "VdrVisits",
                        principalColumn: "VisitGuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VdrDrugApplyments",
                columns: table => new
                {
                    TaskGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VisitGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DrugApplymentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaskExecutionTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScheduledDateTimeUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExecutionDateTimeUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExecutionState = table.Column<int>(type: "int", nullable: false),
                    DrugName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DrugDoseMgPerUnitMg = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AppliedUnits = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NotesRegardingOutcome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtendedMetaData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExecutingPerson = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VdrDrugApplyments", x => x.TaskGuid);
                    table.ForeignKey(
                        name: "FK_VdrDrugApplyments_VdrVisits_VisitGuid",
                        column: x => x.VisitGuid,
                        principalTable: "VdrVisits",
                        principalColumn: "VisitGuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VdrTreatments",
                columns: table => new
                {
                    TaskGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VisitGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TreatmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaskExecutionTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScheduledDateTimeUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExecutionDateTimeUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExecutionState = table.Column<int>(type: "int", nullable: false),
                    NotesRegardingOutcome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExtendedMetaData = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExecutingPerson = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VdrTreatments", x => x.TaskGuid);
                    table.ForeignKey(
                        name: "FK_VdrTreatments_VdrVisits_VisitGuid",
                        column: x => x.VisitGuid,
                        principalTable: "VdrVisits",
                        principalColumn: "VisitGuid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VdrDataRecordings_VisitGuid",
                table: "VdrDataRecordings",
                column: "VisitGuid");

            migrationBuilder.CreateIndex(
                name: "IX_VdrDrugApplyments_VisitGuid",
                table: "VdrDrugApplyments",
                column: "VisitGuid");

            migrationBuilder.CreateIndex(
                name: "IX_VdrStudyEvents_StudyExecutionIdentifier",
                table: "VdrStudyEvents",
                column: "StudyExecutionIdentifier");

            migrationBuilder.CreateIndex(
                name: "IX_VdrTreatments_VisitGuid",
                table: "VdrTreatments",
                column: "VisitGuid");

            migrationBuilder.CreateIndex(
                name: "IX_VdrVisits_StudyExecutionIdentifier",
                table: "VdrVisits",
                column: "StudyExecutionIdentifier");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VdrDataRecordings");

            migrationBuilder.DropTable(
                name: "VdrDrugApplyments");

            migrationBuilder.DropTable(
                name: "VdrStudyEvents");

            migrationBuilder.DropTable(
                name: "VdrTreatments");

            migrationBuilder.DropTable(
                name: "VdrVisits");

            migrationBuilder.DropTable(
                name: "VdrStudyExecutionScopes");
        }
    }
}
