using Microsoft.EntityFrameworkCore.Migrations;

namespace mcp.Server.Data.Migrations
{
    public partial class ProjectParentChildren : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentProjectID",
                table: "Project",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Project_ParentProjectID",
                table: "Project",
                column: "ParentProjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Project_ParentProjectID",
                table: "Project",
                column: "ParentProjectID",
                principalTable: "Project",
                principalColumn: "ProjectID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Project_ParentProjectID",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_ParentProjectID",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "ParentProjectID",
                table: "Project");
        }
    }
}
