using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_Development_Assignment_3.Migrations
{
    public partial class Added_Even_More_Seed_Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Franchises",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 4, "You are a wizard harry", "Harry Potter" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Franchises",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
