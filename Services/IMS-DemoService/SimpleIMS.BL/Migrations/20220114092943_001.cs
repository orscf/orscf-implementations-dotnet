using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicalResearch.IdentityManagement.Migrations
{
    public partial class _001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ImsStudyScopes",
                columns: table => new
                {
                    ResearchStudyUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ParticipantIdentifierSemantic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudyWorkflowName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StudyWorkflowVersion = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImsStudyScopes", x => x.ResearchStudyUid);
                });

            migrationBuilder.CreateTable(
                name: "ImsSubjectAddresses",
                columns: table => new
                {
                    InternalRecordId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HouseNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImsSubjectAddresses", x => x.InternalRecordId);
                });

            migrationBuilder.CreateTable(
                name: "ImsStudyExecutionScopes",
                columns: table => new
                {
                    StudyExecutionIdentifier = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SiteUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResearchStudyUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImsStudyExecutionScopes", x => x.StudyExecutionIdentifier);
                    table.ForeignKey(
                        name: "FK_ImsStudyExecutionScopes_ImsStudyScopes_ResearchStudyUid",
                        column: x => x.ResearchStudyUid,
                        principalTable: "ImsStudyScopes",
                        principalColumn: "ResearchStudyUid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImsSubjectIdentities",
                columns: table => new
                {
                    RecordId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateOfDeath = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FullNamePattern = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResidentAddressId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImsSubjectIdentities", x => x.RecordId);
                    table.ForeignKey(
                        name: "FK_ImsSubjectIdentities_ImsSubjectAddresses_ResidentAddressId",
                        column: x => x.ResidentAddressId,
                        principalTable: "ImsSubjectAddresses",
                        principalColumn: "InternalRecordId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImsSubjectParticipations",
                columns: table => new
                {
                    ParticipantIdentifier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ResearchStudyUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDateUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedForStudyExecutionIdentifier = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubjectIdentityRecordId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImsSubjectParticipations", x => new { x.ParticipantIdentifier, x.ResearchStudyUid });
                    table.ForeignKey(
                        name: "FK_ImsSubjectParticipations_ImsStudyExecutionScopes_CreatedForStudyExecutionIdentifier",
                        column: x => x.CreatedForStudyExecutionIdentifier,
                        principalTable: "ImsStudyExecutionScopes",
                        principalColumn: "StudyExecutionIdentifier",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ImsSubjectParticipations_ImsStudyScopes_ResearchStudyUid",
                        column: x => x.ResearchStudyUid,
                        principalTable: "ImsStudyScopes",
                        principalColumn: "ResearchStudyUid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImsSubjectParticipations_ImsSubjectIdentities_SubjectIdentityRecordId",
                        column: x => x.SubjectIdentityRecordId,
                        principalTable: "ImsSubjectIdentities",
                        principalColumn: "RecordId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImsAdditionalSubjectParticipationIdentifiers",
                columns: table => new
                {
                    ParticipantIdentifier = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdentifierName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ResearchStudyUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdentifierValue = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImsAdditionalSubjectParticipationIdentifiers", x => new { x.ParticipantIdentifier, x.IdentifierName, x.ResearchStudyUid });
                    table.ForeignKey(
                        name: "FK_ImsAdditionalSubjectParticipationIdentifiers_ImsSubjectParticipations_ParticipantIdentifier_ResearchStudyUid",
                        columns: x => new { x.ParticipantIdentifier, x.ResearchStudyUid },
                        principalTable: "ImsSubjectParticipations",
                        principalColumns: new[] { "ParticipantIdentifier", "ResearchStudyUid" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ImsAdditionalSubjectParticipationIdentifiers_ParticipantIdentifier_ResearchStudyUid",
                table: "ImsAdditionalSubjectParticipationIdentifiers",
                columns: new[] { "ParticipantIdentifier", "ResearchStudyUid" });

            migrationBuilder.CreateIndex(
                name: "IX_ImsStudyExecutionScopes_ResearchStudyUid",
                table: "ImsStudyExecutionScopes",
                column: "ResearchStudyUid");

            migrationBuilder.CreateIndex(
                name: "IX_ImsSubjectIdentities_ResidentAddressId",
                table: "ImsSubjectIdentities",
                column: "ResidentAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_ImsSubjectParticipations_CreatedForStudyExecutionIdentifier",
                table: "ImsSubjectParticipations",
                column: "CreatedForStudyExecutionIdentifier");

            migrationBuilder.CreateIndex(
                name: "IX_ImsSubjectParticipations_ResearchStudyUid",
                table: "ImsSubjectParticipations",
                column: "ResearchStudyUid");

            migrationBuilder.CreateIndex(
                name: "IX_ImsSubjectParticipations_SubjectIdentityRecordId",
                table: "ImsSubjectParticipations",
                column: "SubjectIdentityRecordId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImsAdditionalSubjectParticipationIdentifiers");

            migrationBuilder.DropTable(
                name: "ImsSubjectParticipations");

            migrationBuilder.DropTable(
                name: "ImsStudyExecutionScopes");

            migrationBuilder.DropTable(
                name: "ImsSubjectIdentities");

            migrationBuilder.DropTable(
                name: "ImsStudyScopes");

            migrationBuilder.DropTable(
                name: "ImsSubjectAddresses");
        }
    }
}
