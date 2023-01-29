using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Speed.Migrations
{
    public partial class ShipmentChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shipments_AspNetUsers_UserId",
                table: "Shipments");

            migrationBuilder.DropIndex(
                name: "IX_Shipments_UserId",
                table: "Shipments");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Shipments",
                newName: "ReceiverId");

            migrationBuilder.RenameColumn(
                name: "Sender",
                table: "Shipments",
                newName: "ReceiverPhone");

            migrationBuilder.RenameColumn(
                name: "Receiver",
                table: "Shipments",
                newName: "ReceiverName");

            migrationBuilder.AddColumn<int>(
                name: "SenderId",
                table: "Shipments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "UserServiceModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsEmployee = table.Column<bool>(type: "bit", nullable: false),
                    IsOfficeEmployee = table.Column<bool>(type: "bit", nullable: false),
                    IsDeliveryEmployee = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserServiceModel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_SenderId",
                table: "Shipments",
                column: "SenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shipments_AspNetUsers_SenderId",
                table: "Shipments",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shipments_AspNetUsers_SenderId",
                table: "Shipments");

            migrationBuilder.DropTable(
                name: "UserServiceModel");

            migrationBuilder.DropIndex(
                name: "IX_Shipments_SenderId",
                table: "Shipments");

            migrationBuilder.DropColumn(
                name: "SenderId",
                table: "Shipments");

            migrationBuilder.RenameColumn(
                name: "ReceiverPhone",
                table: "Shipments",
                newName: "Sender");

            migrationBuilder.RenameColumn(
                name: "ReceiverName",
                table: "Shipments",
                newName: "Receiver");

            migrationBuilder.RenameColumn(
                name: "ReceiverId",
                table: "Shipments",
                newName: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Shipments_UserId",
                table: "Shipments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shipments_AspNetUsers_UserId",
                table: "Shipments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
