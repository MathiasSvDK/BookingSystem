using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Datalayer.Migrations
{
    public partial class Added_TreatmentDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Treatments",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Availables",
                keyColumn: "AvailableId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 8, 17, 12, 14, 31, 75, DateTimeKind.Local).AddTicks(6575));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "TreatmentId",
                keyValue: 1,
                columns: new[] { "Description", "TreatmentName" },
                values: new object[] { "Blodprøver er blod udtaget fra en vene, som er de blodårer, der fører tilbage til hjertet. Blodet kan undersøges for sammensætning af salte, enzymer og proteiner, og i et vist omfang genetisk materiale. ", "Blodprøve" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Treatments");

            migrationBuilder.UpdateData(
                table: "Availables",
                keyColumn: "AvailableId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 8, 16, 8, 20, 42, 569, DateTimeKind.Local).AddTicks(370));

            migrationBuilder.UpdateData(
                table: "Treatments",
                keyColumn: "TreatmentId",
                keyValue: 1,
                column: "TreatmentName",
                value: "Test");
        }
    }
}
