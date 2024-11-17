using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GMAShop.Cargo.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CargoOperations_CargoCustomers_CargoCustomerId",
                table: "CargoOperations");

            migrationBuilder.DropIndex(
                name: "IX_CargoOperations_CargoCustomerId",
                table: "CargoOperations");

            migrationBuilder.DropColumn(
                name: "CargoCustomerId",
                table: "CargoOperations");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CargoCustomerId",
                table: "CargoOperations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CargoOperations_CargoCustomerId",
                table: "CargoOperations",
                column: "CargoCustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CargoOperations_CargoCustomers_CargoCustomerId",
                table: "CargoOperations",
                column: "CargoCustomerId",
                principalTable: "CargoCustomers",
                principalColumn: "CargoCustomerId");
        }
    }
}
