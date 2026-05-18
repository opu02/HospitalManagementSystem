using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class FixPayrollEmployeeFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payrolls_AspNetUsers_EmployeeIdId",
                table: "Payrolls");

            migrationBuilder.DropIndex(
                name: "IX_Payrolls_EmployeeIdId",
                table: "Payrolls");

            migrationBuilder.DropColumn(
                name: "EmployeeIdId",
                table: "Payrolls");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeId",
                table: "Payrolls",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Payrolls_EmployeeId",
                table: "Payrolls",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payrolls_AspNetUsers_EmployeeId",
                table: "Payrolls",
                column: "EmployeeId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payrolls_AspNetUsers_EmployeeId",
                table: "Payrolls");

            migrationBuilder.DropIndex(
                name: "IX_Payrolls_EmployeeId",
                table: "Payrolls");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Payrolls");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeIdId",
                table: "Payrolls",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payrolls_EmployeeIdId",
                table: "Payrolls",
                column: "EmployeeIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payrolls_AspNetUsers_EmployeeIdId",
                table: "Payrolls",
                column: "EmployeeIdId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
