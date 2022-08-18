using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Datalayer.Migrations
{
    public partial class Changed_Dataseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Availables",
                keyColumn: "AvailableId",
                keyValue: 1,
                columns: new[] { "Date", "EmployeeId" },
                values: new object[] { new DateTime(2022, 8, 18, 10, 58, 57, 938, DateTimeKind.Local).AddTicks(829), 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Availables",
                keyColumn: "AvailableId",
                keyValue: 1,
                columns: new[] { "Date", "EmployeeId" },
                values: new object[] { new DateTime(2022, 8, 18, 10, 51, 2, 880, DateTimeKind.Local).AddTicks(8493), 0 });
        }
    }
}
