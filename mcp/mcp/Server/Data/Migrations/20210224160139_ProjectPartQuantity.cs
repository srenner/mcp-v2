using Microsoft.EntityFrameworkCore.Migrations;

namespace mcp.Server.Data.Migrations
{
    public partial class ProjectPartQuantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "ProjectPart",
                type: "int",
                nullable: false,
                defaultValue: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "ProjectPart");
        }
    }
}
