using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddAppointmentIdInBill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppoinmentId",
                table: "Bills",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bills_AppoinmentId",
                table: "Bills",
                column: "AppoinmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bills_Appoinments_AppoinmentId",
                table: "Bills",
                column: "AppoinmentId",
                principalTable: "Appoinments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bills_Appoinments_AppoinmentId",
                table: "Bills");

            migrationBuilder.DropIndex(
                name: "IX_Bills_AppoinmentId",
                table: "Bills");

            migrationBuilder.DropColumn(
                name: "AppoinmentId",
                table: "Bills");
        }
    }
}
