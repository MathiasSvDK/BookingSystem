using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Datalayer.Migrations
{
    public partial class PatientId_String : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PatientId",
                table: "Bookings",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "hospitalization",
                columns: table => new
                {
                    HospitalizationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Reason = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TimeOfHospitalized = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TimeOfDischarged = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsDischarged = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    HospitalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hospitalization", x => x.HospitalizationID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Availables",
                keyColumn: "AvailableId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 8, 22, 9, 58, 15, 81, DateTimeKind.Local).AddTicks(7775));

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: 1,
                column: "PatientId",
                value: "1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "hospitalization");

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                table: "Bookings",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Availables",
                keyColumn: "AvailableId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 8, 19, 17, 35, 24, 688, DateTimeKind.Local).AddTicks(6247));

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: 1,
                column: "PatientId",
                value: 1);
        }
    }
}
