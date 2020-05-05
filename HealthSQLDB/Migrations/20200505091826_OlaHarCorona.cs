using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthSQLDB.Migrations
{
    public partial class OlaHarCorona : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Patients",
                columns: new[] { "PatientId", "Name" },
                values: new object[] { 1, "Ola Nordmann" });

            migrationBuilder.InsertData(
                table: "PatientAilments",
                columns: new[] { "AilmentId", "PatientId" },
                values: new object[] { 1, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PatientAilments",
                keyColumns: new[] { "AilmentId", "PatientId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Patients",
                keyColumn: "PatientId",
                keyValue: 1);
        }
    }
}
