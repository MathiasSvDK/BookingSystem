using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Datalayer.Migrations
{
    public partial class Added_Employee_To_Available : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Availables",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Availables",
                keyColumn: "AvailableId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 8, 18, 10, 51, 2, 880, DateTimeKind.Local).AddTicks(8493));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Availables");

            migrationBuilder.UpdateData(
                table: "Availables",
                keyColumn: "AvailableId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 8, 17, 12, 14, 31, 75, DateTimeKind.Local).AddTicks(6575));
        }
    }
}
