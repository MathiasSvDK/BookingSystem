using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Datalayer.Migrations
{
    public partial class Added_Hospitalization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Availables",
                keyColumn: "AvailableId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 8, 19, 17, 35, 24, 688, DateTimeKind.Local).AddTicks(6247));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Availables",
                keyColumn: "AvailableId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 8, 19, 10, 50, 20, 852, DateTimeKind.Local).AddTicks(6429));
        }
    }
}
