using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddTimingAndPatientReport : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientReport_AspNetUsers_DoctorId",
                table: "PatientReport");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientReport_AspNetUsers_PatientId",
                table: "PatientReport");

            migrationBuilder.DropForeignKey(
                name: "FK_PrescribedMedicines_PatientReport_PatientReportId",
                table: "PrescribedMedicines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PatientReport",
                table: "PatientReport");

            migrationBuilder.RenameTable(
                name: "PatientReport",
                newName: "PatientReports");

            migrationBuilder.RenameIndex(
                name: "IX_PatientReport_PatientId",
                table: "PatientReports",
                newName: "IX_PatientReports_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_PatientReport_DoctorId",
                table: "PatientReports",
                newName: "IX_PatientReports_DoctorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PatientReports",
                table: "PatientReports",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Timings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MorningShiftStartTime = table.Column<int>(type: "int", nullable: false),
                    MorningShiftEndTime = table.Column<int>(type: "int", nullable: false),
                    AfternoonShiftStartTime = table.Column<int>(type: "int", nullable: false),
                    AfternoonShiftEndTime = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Timings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Timings_AspNetUsers_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Timings_DoctorId",
                table: "Timings",
                column: "DoctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientReports_AspNetUsers_DoctorId",
                table: "PatientReports",
                column: "DoctorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientReports_AspNetUsers_PatientId",
                table: "PatientReports",
                column: "PatientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PrescribedMedicines_PatientReports_PatientReportId",
                table: "PrescribedMedicines",
                column: "PatientReportId",
                principalTable: "PatientReports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientReports_AspNetUsers_DoctorId",
                table: "PatientReports");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientReports_AspNetUsers_PatientId",
                table: "PatientReports");

            migrationBuilder.DropForeignKey(
                name: "FK_PrescribedMedicines_PatientReports_PatientReportId",
                table: "PrescribedMedicines");

            migrationBuilder.DropTable(
                name: "Timings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PatientReports",
                table: "PatientReports");

            migrationBuilder.RenameTable(
                name: "PatientReports",
                newName: "PatientReport");

            migrationBuilder.RenameIndex(
                name: "IX_PatientReports_PatientId",
                table: "PatientReport",
                newName: "IX_PatientReport_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_PatientReports_DoctorId",
                table: "PatientReport",
                newName: "IX_PatientReport_DoctorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PatientReport",
                table: "PatientReport",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientReport_AspNetUsers_DoctorId",
                table: "PatientReport",
                column: "DoctorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientReport_AspNetUsers_PatientId",
                table: "PatientReport",
                column: "PatientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PrescribedMedicines_PatientReport_PatientReportId",
                table: "PrescribedMedicines",
                column: "PatientReportId",
                principalTable: "PatientReport",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
