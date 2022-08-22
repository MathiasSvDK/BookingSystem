using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Datalayer.Migrations
{
    public partial class removeSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_hospitalization",
                table: "hospitalization");

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Availables",
                keyColumn: "AvailableId",
                keyValue: 1);

            migrationBuilder.RenameTable(
                name: "hospitalization",
                newName: "Hospitalization");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hospitalization",
                table: "Hospitalization",
                column: "HospitalizationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Hospitalization",
                table: "Hospitalization");

            migrationBuilder.RenameTable(
                name: "Hospitalization",
                newName: "hospitalization");

            migrationBuilder.AddPrimaryKey(
                name: "PK_hospitalization",
                table: "hospitalization",
                column: "HospitalizationID");

            migrationBuilder.InsertData(
                table: "Availables",
                columns: new[] { "AvailableId", "Date", "EmployeeId", "IsTaken" },
                values: new object[] { 1, new DateTime(2022, 8, 22, 9, 58, 15, 81, DateTimeKind.Local).AddTicks(7775), 2, true });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "BookingId", "AvailableId", "HospitalId", "IsApproved", "PatientId", "Reason", "TreatmentId" },
                values: new object[] { 1, 1, 1, false, "1", "Check up", 1 });
        }
    }
}
