using Microsoft.EntityFrameworkCore.Migrations;

namespace mcp.Server.Data.Migrations
{
    public partial class seed_20210407 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "TagID",
                keyValue: 8,
                column: "Description",
                value: "A vehicle built for drift events");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tag",
                keyColumn: "TagID",
                keyValue: 8,
                column: "Description",
                value: "A vehicle built for road race events");
        }
    }
}
