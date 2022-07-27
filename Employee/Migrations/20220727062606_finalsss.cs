using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employee.Migrations
{
    public partial class finalsss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_GenderId",
                table: "Employees",
                column: "GenderId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Gender_GenderId",
                table: "Employees",
                column: "GenderId",
                principalTable: "Gender",
                principalColumn: "GenderId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Gender_GenderId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_GenderId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "Employees");
        }
    }
}
