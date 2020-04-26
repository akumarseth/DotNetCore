using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class AddedForeighKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Departments_EmployeeID",
                table: "Departments",
                column: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Employees_EmployeeID",
                table: "Departments",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Employees_EmployeeID",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_EmployeeID",
                table: "Departments");
        }
    }
}
