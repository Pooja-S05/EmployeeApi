using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employee.Migrations
{
    public partial class finals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_State_StateId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_StateId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "Employees");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_State",
                table: "Employees",
                column: "State");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_State_State",
                table: "Employees",
                column: "State",
                principalTable: "State",
                principalColumn: "StateId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_State_State",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_State",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_StateId",
                table: "Employees",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_State_StateId",
                table: "Employees",
                column: "StateId",
                principalTable: "State",
                principalColumn: "StateId");
        }
    }
}
