using Microsoft.EntityFrameworkCore.Migrations;

namespace mcp.Server.Data.Migrations
{
    public partial class UserUniqueName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UniqueName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UniqueName",
                table: "AspNetUsers",
                column: "UniqueName",
                unique: true,
                filter: "[UniqueName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UniqueName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UniqueName",
                table: "AspNetUsers");
        }
    }
}
