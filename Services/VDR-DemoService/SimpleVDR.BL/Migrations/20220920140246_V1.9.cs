using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicalResearch.VisitData.Migrations
{
    public partial class V19 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VdrVisits_VdrStudyExecutionScopes_StudyExecutionIdentifier",
                table: "VdrVisits");

            migrationBuilder.RenameColumn(
                name: "VisitProdecureName",
                table: "VdrVisits",
                newName: "VisitProcedureName");

            migrationBuilder.RenameColumn(
                name: "StudyExecutionIdentifier",
                table: "VdrVisits",
                newName: "StudyUid");

            migrationBuilder.RenameIndex(
                name: "IX_VdrVisits_StudyExecutionIdentifier",
                table: "VdrVisits",
                newName: "IX_VdrVisits_StudyUid");

            migrationBuilder.RenameColumn(
                name: "StudyExecutionIdentifier",
                table: "VdrStudyExecutionScopes",
                newName: "StudyUid");

            migrationBuilder.AddForeignKey(
                name: "FK_VdrVisits_VdrStudyExecutionScopes_StudyUid",
                table: "VdrVisits",
                column: "StudyUid",
                principalTable: "VdrStudyExecutionScopes",
                principalColumn: "StudyUid",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VdrVisits_VdrStudyExecutionScopes_StudyUid",
                table: "VdrVisits");

            migrationBuilder.RenameColumn(
                name: "VisitProcedureName",
                table: "VdrVisits",
                newName: "VisitProdecureName");

            migrationBuilder.RenameColumn(
                name: "StudyUid",
                table: "VdrVisits",
                newName: "StudyExecutionIdentifier");

            migrationBuilder.RenameIndex(
                name: "IX_VdrVisits_StudyUid",
                table: "VdrVisits",
                newName: "IX_VdrVisits_StudyExecutionIdentifier");

            migrationBuilder.RenameColumn(
                name: "StudyUid",
                table: "VdrStudyExecutionScopes",
                newName: "StudyExecutionIdentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_VdrVisits_VdrStudyExecutionScopes_StudyExecutionIdentifier",
                table: "VdrVisits",
                column: "StudyExecutionIdentifier",
                principalTable: "VdrStudyExecutionScopes",
                principalColumn: "StudyExecutionIdentifier",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
