using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Datalayer.Migrations
{
    public partial class BookingIsApproved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "Bookings",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Availables",
                keyColumn: "AvailableId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 8, 19, 10, 50, 20, 852, DateTimeKind.Local).AddTicks(6429));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "Bookings");

            migrationBuilder.UpdateData(
                table: "Availables",
                keyColumn: "AvailableId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 8, 18, 10, 58, 57, 938, DateTimeKind.Local).AddTicks(829));
        }
    }
}
