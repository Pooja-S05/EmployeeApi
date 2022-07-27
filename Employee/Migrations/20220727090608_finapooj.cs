using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employee.Migrations
{
    public partial class finapooj : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_State_StateId",
                table: "Employees");

            migrationBuilder.AlterColumn<int>(
                name: "StateId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_State_StateId",
                table: "Employees",
                column: "StateId",
                principalTable: "State",
                principalColumn: "StateId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_State_StateId",
                table: "Employees");

            migrationBuilder.AlterColumn<int>(
                name: "StateId",
                table: "Employees",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_State_StateId",
                table: "Employees",
                column: "StateId",
                principalTable: "State",
                principalColumn: "StateId");
        }
    }
}
