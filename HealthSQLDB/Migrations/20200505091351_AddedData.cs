using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthSQLDB.Migrations
{
    public partial class AddedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Ailments",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Covid-19" });

            migrationBuilder.InsertData(
                table: "Ailments",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Manflu" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ailments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ailments",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
