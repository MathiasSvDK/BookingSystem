using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Datalayer.Migrations
{
    public partial class nullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Availables",
                keyColumn: "AvailableId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 8, 16, 8, 20, 42, 569, DateTimeKind.Local).AddTicks(370));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Availables",
                keyColumn: "AvailableId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 8, 15, 14, 11, 32, 699, DateTimeKind.Local).AddTicks(4846));
        }
    }
}
