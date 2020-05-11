using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthSQLDB.Migrations
{
    public partial class AddedCursAndSickness : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Ailments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 3, "Broken bone" },
                    { 4, "tyfus" },
                    { 5, "Stubed Tow" },
                    { 6, "Depression" }
                });

            migrationBuilder.InsertData(
                table: "Medications",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 3, "Ibux" },
                    { 4, "Sunshine" },
                    { 5, "Kondoms" },
                    { 6, "Scream" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ailments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ailments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Ailments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Ailments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Medications",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
