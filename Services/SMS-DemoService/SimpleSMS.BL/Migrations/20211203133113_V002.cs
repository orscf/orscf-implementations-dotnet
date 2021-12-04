using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicalResearch.StudyManagement.Migrations
{
    public partial class V002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SmsInstitutes_SmsSystemEndpoints_OwnPatientSdrEndpointUid",
                table: "SmsInstitutes");

            migrationBuilder.DropForeignKey(
                name: "FK_SmsResearchStudies_SmsSystemEndpoints_PrimaryImsEndpointUid",
                table: "SmsResearchStudies");

            migrationBuilder.DropIndex(
                name: "IX_SmsResearchStudies_PrimaryImsEndpointUid",
                table: "SmsResearchStudies");

            migrationBuilder.DropIndex(
                name: "IX_SmsInstitutes_OwnPatientSdrEndpointUid",
                table: "SmsInstitutes");

            migrationBuilder.DropColumn(
                name: "PrimaryImsEndpointUid",
                table: "SmsResearchStudies");

            migrationBuilder.DropColumn(
                name: "OwnPatientSdrEndpointUid",
                table: "SmsInstitutes");

            migrationBuilder.AddColumn<string>(
                name: "CustomRoles",
                table: "SmsStudyRelatedSystemAssignments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CustomRoles",
                table: "SmsSiteRelatedSystemAssignments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<Guid>(
                name: "OriginWdrEndpointUid",
                table: "SmsResearchStudies",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "CustomRoles",
                table: "SmsInstituteRelatedSystemAssignments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomRoles",
                table: "SmsStudyRelatedSystemAssignments");

            migrationBuilder.DropColumn(
                name: "CustomRoles",
                table: "SmsSiteRelatedSystemAssignments");

            migrationBuilder.DropColumn(
                name: "CustomRoles",
                table: "SmsInstituteRelatedSystemAssignments");

            migrationBuilder.AlterColumn<Guid>(
                name: "OriginWdrEndpointUid",
                table: "SmsResearchStudies",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PrimaryImsEndpointUid",
                table: "SmsResearchStudies",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "OwnPatientSdrEndpointUid",
                table: "SmsInstitutes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_SmsResearchStudies_PrimaryImsEndpointUid",
                table: "SmsResearchStudies",
                column: "PrimaryImsEndpointUid");

            migrationBuilder.CreateIndex(
                name: "IX_SmsInstitutes_OwnPatientSdrEndpointUid",
                table: "SmsInstitutes",
                column: "OwnPatientSdrEndpointUid");

            migrationBuilder.AddForeignKey(
                name: "FK_SmsInstitutes_SmsSystemEndpoints_OwnPatientSdrEndpointUid",
                table: "SmsInstitutes",
                column: "OwnPatientSdrEndpointUid",
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
        }
    }
}
