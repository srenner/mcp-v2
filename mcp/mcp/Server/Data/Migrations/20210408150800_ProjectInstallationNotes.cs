using Microsoft.EntityFrameworkCore.Migrations;

namespace mcp.Server.Data.Migrations
{
    public partial class ProjectInstallationNotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InstallationNotes",
                table: "Project",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InstallationNotes",
                table: "Project");
        }
    }
}
