using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Datalayer.Migrations
{
    public partial class dataseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Availables",
                columns: new[] { "AvailableId", "Date", "IsTaken" },
                values: new object[] { 1, new DateTime(2022, 8, 15, 14, 11, 32, 699, DateTimeKind.Local).AddTicks(4846), true });

            migrationBuilder.InsertData(
                table: "Treatments",
                columns: new[] { "TreatmentId", "TreatmentName" },
                values: new object[] { 1, "Test" });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "BookingId", "AvailableId", "HospitalId", "PatientId", "Reason", "TreatmentId" },
                values: new object[] { 1, 1, 1, 1, "Check up", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Availables",
                keyColumn: "AvailableId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Treatments",
                keyColumn: "TreatmentId",
                keyValue: 1);
        }
    }
}
