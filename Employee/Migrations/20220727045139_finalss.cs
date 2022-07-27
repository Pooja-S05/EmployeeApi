using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employee.Migrations
{
    public partial class finalss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Gender_GenderId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_State_State",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_GenderId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_State",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Employees");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_GenderId",
                table: "Employees",
                column: "GenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_State",
                table: "Employees",
                column: "State");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Gender_GenderId",
                table: "Employees",
                column: "GenderId",
                principalTable: "Gender",
                principalColumn: "GenderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_State_State",
                table: "Employees",
                column: "State",
                principalTable: "State",
                principalColumn: "StateId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
