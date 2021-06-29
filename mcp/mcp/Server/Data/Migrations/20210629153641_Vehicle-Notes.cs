using Microsoft.EntityFrameworkCore.Migrations;

namespace mcp.Server.Data.Migrations
{
    public partial class VehicleNotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Vehicle",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Vehicle");
        }
    }
}
