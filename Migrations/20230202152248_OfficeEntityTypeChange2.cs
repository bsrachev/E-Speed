using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Speed.Migrations
{
    public partial class OfficeEntityTypeChange2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeOffices_Offices_OfficeId1",
                table: "EmployeeOffices");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeOffices_OfficeId1",
                table: "EmployeeOffices");

            migrationBuilder.DropColumn(
                name: "OfficeId1",
                table: "EmployeeOffices");

            migrationBuilder.AlterColumn<int>(
                name: "OfficeId",
                table: "EmployeeOffices",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeOffices_OfficeId",
                table: "EmployeeOffices",
                column: "OfficeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeOffices_Offices_OfficeId",
                table: "EmployeeOffices",
                column: "OfficeId",
                principalTable: "Offices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeOffices_Offices_OfficeId",
                table: "EmployeeOffices");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeOffices_OfficeId",
                table: "EmployeeOffices");

            migrationBuilder.AlterColumn<string>(
                name: "OfficeId",
                table: "EmployeeOffices",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "OfficeId1",
                table: "EmployeeOffices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeOffices_OfficeId1",
                table: "EmployeeOffices",
                column: "OfficeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeOffices_Offices_OfficeId1",
                table: "EmployeeOffices",
                column: "OfficeId1",
                principalTable: "Offices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
