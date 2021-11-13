using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicalResearch.SubjectData.Migrations
{
    public partial class V001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SmsSubjects",
                columns: table => new
                {
                    SubjectUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ActualSiteIdentifier = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EnrollingSiteIdentifier = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EnrollmentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TerminationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TerminatedReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubjectIdentifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResearchStudyUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmsSubjects", x => x.SubjectUid);
                });

            migrationBuilder.CreateTable(
                name: "SmsSubjectSiteAssignments",
                columns: table => new
                {
                    SubjectSiteAssignmentUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ValidFrom = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SiteUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubjectUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SiteRelatedPatientIdentifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ByInvolvedPersonUid = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmsSubjectSiteAssignments", x => x.SubjectSiteAssignmentUid);
                    table.ForeignKey(
                        name: "FK_SmsSubjectSiteAssignments_SmsSubjects_SubjectUid",
                        column: x => x.SubjectUid,
                        principalTable: "SmsSubjects",
                        principalColumn: "SubjectUid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SmsSubjectSiteAssignments_SubjectUid",
                table: "SmsSubjectSiteAssignments",
                column: "SubjectUid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SmsSubjectSiteAssignments");

            migrationBuilder.DropTable(
                name: "SmsSubjects");
        }
    }
}
