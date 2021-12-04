using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicalResearch.StudyManagement.Migrations
{
    public partial class V001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SmsInvolvedPersons",
                columns: table => new
                {
                    InvolvedPersonUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DisplayLabel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailAddress = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmsInvolvedPersons", x => x.InvolvedPersonUid);
                });

            migrationBuilder.CreateTable(
                name: "SmsInstituteRelatedSystemAssignments",
                columns: table => new
                {
                    InstituteRelatedSystemAssignemntUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SystemEndpointUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InstituteUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UseAsOwnPatientSdr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UseAsCandidateSdr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UseAsOwnWdr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UseAsConsumingExternalWdr = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmsInstituteRelatedSystemAssignments", x => x.InstituteRelatedSystemAssignemntUid);
                });

            migrationBuilder.CreateTable(
                name: "SmsResearchStudies",
                columns: table => new
                {
                    ResearchStudyUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DisplayLabel = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    InitiatorInstituteUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StudyWorkflowName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudyWorkflowVersion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TerminationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SubjectIdentifierTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TerminatedReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    InitiatorRelatedProjectNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginWdrEndpointUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrimaryImsEndpointUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmsResearchStudies", x => x.ResearchStudyUid);
                });

            migrationBuilder.CreateTable(
                name: "SmsSites",
                columns: table => new
                {
                    SiteUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RepresentingInstituteUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResearchStudyUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EnrollmentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TerminationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TerminatedReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudyRelatedSiteIdentifer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayLabel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SiteRelatedProjectNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmsSites", x => x.SiteUid);
                    table.ForeignKey(
                        name: "FK_SmsSites_SmsResearchStudies_ResearchStudyUid",
                        column: x => x.ResearchStudyUid,
                        principalTable: "SmsResearchStudies",
                        principalColumn: "ResearchStudyUid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SmsInvolvementRoles",
                columns: table => new
                {
                    InvolvedPersonRoleUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResearchStudyUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InvolvedFrom = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InvolvedUntil = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DedicatedToSiteUid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    InvolvedPersonUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmsInvolvementRoles", x => x.InvolvedPersonRoleUid);
                    table.ForeignKey(
                        name: "FK_SmsInvolvementRoles_SmsInvolvedPersons_InvolvedPersonUid",
                        column: x => x.InvolvedPersonUid,
                        principalTable: "SmsInvolvedPersons",
                        principalColumn: "InvolvedPersonUid",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SmsInvolvementRoles_SmsResearchStudies_ResearchStudyUid",
                        column: x => x.ResearchStudyUid,
                        principalTable: "SmsResearchStudies",
                        principalColumn: "ResearchStudyUid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SmsInvolvementRoles_SmsSites_DedicatedToSiteUid",
                        column: x => x.DedicatedToSiteUid,
                        principalTable: "SmsSites",
                        principalColumn: "SiteUid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SmsSystemConnections",
                columns: table => new
                {
                    SystemConnectionUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OwnerInstituteUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HierSpäterJWTSEttings = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TargetSystemEndpointUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DedicatedSiteRelatedSystemAssignmentUid = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmsSystemConnections", x => x.SystemConnectionUid);
                });

            migrationBuilder.CreateTable(
                name: "SmsSystemEndpoints",
                columns: table => new
                {
                    SystemEndpointUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProviderInstituteUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AvailableRoles = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApprovedCert = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPublic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Label = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmsSystemEndpoints", x => x.SystemEndpointUid);
                });

            migrationBuilder.CreateTable(
                name: "SmsInstitutes",
                columns: table => new
                {
                    InstituteUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DisplayLabel = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    OwnPatientSdrEndpointUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmsInstitutes", x => x.InstituteUid);
                    table.ForeignKey(
                        name: "FK_SmsInstitutes_SmsSystemEndpoints_OwnPatientSdrEndpointUid",
                        column: x => x.OwnPatientSdrEndpointUid,
                        principalTable: "SmsSystemEndpoints",
                        principalColumn: "SystemEndpointUid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SmsSiteRelatedSystemAssignments",
                columns: table => new
                {
                    SiteRelatedSystemAssignmentUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SystemEndpointUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SiteUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmsSiteRelatedSystemAssignments", x => x.SiteRelatedSystemAssignmentUid);
                    table.ForeignKey(
                        name: "FK_SmsSiteRelatedSystemAssignments_SmsSites_SiteUid",
                        column: x => x.SiteUid,
                        principalTable: "SmsSites",
                        principalColumn: "SiteUid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SmsSiteRelatedSystemAssignments_SmsSystemEndpoints_SystemEndpointUid",
                        column: x => x.SystemEndpointUid,
                        principalTable: "SmsSystemEndpoints",
                        principalColumn: "SystemEndpointUid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SmsStudyRelatedSystemAssignments",
                columns: table => new
                {
                    StudyRelatedSystemAssignmentUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResearchStudyUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SystemEndpointUid = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmsStudyRelatedSystemAssignments", x => x.StudyRelatedSystemAssignmentUid);
                    table.ForeignKey(
                        name: "FK_SmsStudyRelatedSystemAssignments_SmsResearchStudies_ResearchStudyUid",
                        column: x => x.ResearchStudyUid,
                        principalTable: "SmsResearchStudies",
                        principalColumn: "ResearchStudyUid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SmsStudyRelatedSystemAssignments_SmsSystemEndpoints_SystemEndpointUid",
                        column: x => x.SystemEndpointUid,
                        principalTable: "SmsSystemEndpoints",
                        principalColumn: "SystemEndpointUid",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SmsInstituteRelatedSystemAssignments_InstituteUid",
                table: "SmsInstituteRelatedSystemAssignments",
                column: "InstituteUid");

            migrationBuilder.CreateIndex(
                name: "IX_SmsInstituteRelatedSystemAssignments_SystemEndpointUid",
                table: "SmsInstituteRelatedSystemAssignments",
                column: "SystemEndpointUid");

            migrationBuilder.CreateIndex(
                name: "IX_SmsInstitutes_OwnPatientSdrEndpointUid",
                table: "SmsInstitutes",
                column: "OwnPatientSdrEndpointUid");

            migrationBuilder.CreateIndex(
                name: "IX_SmsInvolvementRoles_DedicatedToSiteUid",
                table: "SmsInvolvementRoles",
                column: "DedicatedToSiteUid");

            migrationBuilder.CreateIndex(
                name: "IX_SmsInvolvementRoles_InvolvedPersonUid",
                table: "SmsInvolvementRoles",
                column: "InvolvedPersonUid");

            migrationBuilder.CreateIndex(
                name: "IX_SmsInvolvementRoles_ResearchStudyUid",
                table: "SmsInvolvementRoles",
                column: "ResearchStudyUid");

            migrationBuilder.CreateIndex(
                name: "IX_SmsResearchStudies_InitiatorInstituteUid",
                table: "SmsResearchStudies",
                column: "InitiatorInstituteUid");

            migrationBuilder.CreateIndex(
                name: "IX_SmsResearchStudies_OriginWdrEndpointUid",
                table: "SmsResearchStudies",
                column: "OriginWdrEndpointUid");

            migrationBuilder.CreateIndex(
                name: "IX_SmsResearchStudies_PrimaryImsEndpointUid",
                table: "SmsResearchStudies",
                column: "PrimaryImsEndpointUid");

            migrationBuilder.CreateIndex(
                name: "IX_SmsSiteRelatedSystemAssignments_SiteUid",
                table: "SmsSiteRelatedSystemAssignments",
                column: "SiteUid");

            migrationBuilder.CreateIndex(
                name: "IX_SmsSiteRelatedSystemAssignments_SystemEndpointUid",
                table: "SmsSiteRelatedSystemAssignments",
                column: "SystemEndpointUid");

            migrationBuilder.CreateIndex(
                name: "IX_SmsSites_RepresentingInstituteUid",
                table: "SmsSites",
                column: "RepresentingInstituteUid");

            migrationBuilder.CreateIndex(
                name: "IX_SmsSites_ResearchStudyUid",
                table: "SmsSites",
                column: "ResearchStudyUid");

            migrationBuilder.CreateIndex(
                name: "IX_SmsStudyRelatedSystemAssignments_ResearchStudyUid",
                table: "SmsStudyRelatedSystemAssignments",
                column: "ResearchStudyUid");

            migrationBuilder.CreateIndex(
                name: "IX_SmsStudyRelatedSystemAssignments_SystemEndpointUid",
                table: "SmsStudyRelatedSystemAssignments",
                column: "SystemEndpointUid");

            migrationBuilder.CreateIndex(
                name: "IX_SmsSystemConnections_DedicatedSiteRelatedSystemAssignmentUid",
                table: "SmsSystemConnections",
                column: "DedicatedSiteRelatedSystemAssignmentUid");

            migrationBuilder.CreateIndex(
                name: "IX_SmsSystemConnections_OwnerInstituteUid",
                table: "SmsSystemConnections",
                column: "OwnerInstituteUid");

            migrationBuilder.CreateIndex(
                name: "IX_SmsSystemConnections_TargetSystemEndpointUid",
                table: "SmsSystemConnections",
                column: "TargetSystemEndpointUid");

            migrationBuilder.CreateIndex(
                name: "IX_SmsSystemEndpoints_ProviderInstituteUid",
                table: "SmsSystemEndpoints",
                column: "ProviderInstituteUid");

            migrationBuilder.AddForeignKey(
                name: "FK_SmsInstituteRelatedSystemAssignments_SmsInstitutes_InstituteUid",
                table: "SmsInstituteRelatedSystemAssignments",
                column: "InstituteUid",
                principalTable: "SmsInstitutes",
                principalColumn: "InstituteUid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SmsInstituteRelatedSystemAssignments_SmsSystemEndpoints_SystemEndpointUid",
                table: "SmsInstituteRelatedSystemAssignments",
                column: "SystemEndpointUid",
                principalTable: "SmsSystemEndpoints",
                principalColumn: "SystemEndpointUid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SmsResearchStudies_SmsInstitutes_InitiatorInstituteUid",
                table: "SmsResearchStudies",
                column: "InitiatorInstituteUid",
                principalTable: "SmsInstitutes",
                principalColumn: "InstituteUid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SmsResearchStudies_SmsSystemEndpoints_OriginWdrEndpointUid",
                table: "SmsResearchStudies",
                column: "OriginWdrEndpointUid",
                principalTable: "SmsSystemEndpoints",
                principalColumn: "SystemEndpointUid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SmsResearchStudies_SmsSystemEndpoints_PrimaryImsEndpointUid",
                table: "SmsResearchStudies",
                column: "PrimaryImsEndpointUid",
                principalTable: "SmsSystemEndpoints",
                principalColumn: "SystemEndpointUid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SmsSites_SmsInstitutes_RepresentingInstituteUid",
                table: "SmsSites",
                column: "RepresentingInstituteUid",
                principalTable: "SmsInstitutes",
                principalColumn: "InstituteUid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SmsSystemConnections_SmsInstitutes_OwnerInstituteUid",
                table: "SmsSystemConnections",
                column: "OwnerInstituteUid",
                principalTable: "SmsInstitutes",
                principalColumn: "InstituteUid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SmsSystemConnections_SmsSiteRelatedSystemAssignments_DedicatedSiteRelatedSystemAssignmentUid",
                table: "SmsSystemConnections",
                column: "DedicatedSiteRelatedSystemAssignmentUid",
                principalTable: "SmsSiteRelatedSystemAssignments",
                principalColumn: "SiteRelatedSystemAssignmentUid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SmsSystemConnections_SmsSystemEndpoints_TargetSystemEndpointUid",
                table: "SmsSystemConnections",
                column: "TargetSystemEndpointUid",
                principalTable: "SmsSystemEndpoints",
                principalColumn: "SystemEndpointUid",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SmsSystemEndpoints_SmsInstitutes_ProviderInstituteUid",
                table: "SmsSystemEndpoints",
                column: "ProviderInstituteUid",
                principalTable: "SmsInstitutes",
                principalColumn: "InstituteUid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SmsSystemEndpoints_SmsInstitutes_ProviderInstituteUid",
                table: "SmsSystemEndpoints");

            migrationBuilder.DropTable(
                name: "SmsInstituteRelatedSystemAssignments");

            migrationBuilder.DropTable(
                name: "SmsInvolvementRoles");

            migrationBuilder.DropTable(
                name: "SmsStudyRelatedSystemAssignments");

            migrationBuilder.DropTable(
                name: "SmsSystemConnections");

            migrationBuilder.DropTable(
                name: "SmsInvolvedPersons");

            migrationBuilder.DropTable(
                name: "SmsSiteRelatedSystemAssignments");

            migrationBuilder.DropTable(
                name: "SmsSites");

            migrationBuilder.DropTable(
                name: "SmsResearchStudies");

            migrationBuilder.DropTable(
                name: "SmsInstitutes");

            migrationBuilder.DropTable(
                name: "SmsSystemEndpoints");
        }
    }
}
