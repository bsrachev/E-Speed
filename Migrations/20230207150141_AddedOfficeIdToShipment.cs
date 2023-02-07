using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Speed.Migrations
{
    public partial class AddedOfficeIdToShipment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OfficeId",
                table: "Shipments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OfficeId",
                table: "ShipmentRequests",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OfficeId",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "OfficeId",
                table: "ShipmentRequests");
        }
    }
}
