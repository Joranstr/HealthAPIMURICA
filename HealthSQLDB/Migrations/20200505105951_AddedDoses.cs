using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthSQLDB.Migrations
{
    public partial class AddedDoses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Doses",
                table: "Medications");

            migrationBuilder.AddColumn<int>(
                name: "Doses",
                table: "PatientMedications",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Doses",
                table: "PatientMedications");

            migrationBuilder.AddColumn<string>(
                name: "Doses",
                table: "Medications",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
