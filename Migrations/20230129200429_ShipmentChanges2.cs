using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Speed.Migrations
{
    public partial class ShipmentChanges2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "ShipmentTrackingNumber",
                startValue: 10000001L);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDelivered",
                table: "Shipments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Method",
                table: "Shipments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TrackingNumber",
                table: "Shipments",
                type: "int",
                nullable: false,
                defaultValueSql: "NEXT VALUE FOR ShipmentTrackingNumber");

            migrationBuilder.CreateTable(
                name: "ShipmentRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderId = table.Column<int>(type: "int", nullable: false),
                    ReceiverName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiverPhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryToOffice = table.Column<bool>(type: "bit", nullable: false),
                    DeliveryAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Method = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShipmentRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShipmentRequests_AspNetUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShipmentRequests_SenderId",
                table: "ShipmentRequests",
                column: "SenderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShipmentRequests");

            migrationBuilder.DropSequence(
                name: "ShipmentTrackingNumber");

            migrationBuilder.DropColumn(
                name: "DateDelivered",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "Method",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "TrackingNumber",
                table: "Shipments");
        }
    }
}
