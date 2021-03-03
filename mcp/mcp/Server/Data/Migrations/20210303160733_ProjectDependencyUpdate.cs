using Microsoft.EntityFrameworkCore.Migrations;

namespace mcp.Server.Data.Migrations
{
    public partial class ProjectDependencyUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectDependency_Project_DependsOnProjectID",
                table: "ProjectDependency");

            migrationBuilder.DropForeignKey(
                name: "FK_ProjectDependency_Project_ProjectID",
                table: "ProjectDependency");

            migrationBuilder.DropIndex(
                name: "IX_ProjectDependency_DependsOnProjectID",
                table: "ProjectDependency");

            migrationBuilder.DropIndex(
                name: "IX_ProjectDependency_ProjectID",
                table: "ProjectDependency");

            migrationBuilder.DropColumn(
                name: "DependsOnProjectID",
                table: "ProjectDependency");

            migrationBuilder.DropColumn(
                name: "ProjectID",
                table: "ProjectDependency");

            migrationBuilder.CreateTable(
                name: "ProjectProjectDependency",
                columns: table => new
                {
                    DependenciesProjectDependencyID = table.Column<int>(type: "int", nullable: false),
                    ProjectsProjectID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectProjectDependency", x => new { x.DependenciesProjectDependencyID, x.ProjectsProjectID });
                    table.ForeignKey(
                        name: "FK_ProjectProjectDependency_Project_ProjectsProjectID",
                        column: x => x.ProjectsProjectID,
                        principalTable: "Project",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectProjectDependency_ProjectDependency_DependenciesProjectDependencyID",
                        column: x => x.DependenciesProjectDependencyID,
                        principalTable: "ProjectDependency",
                        principalColumn: "ProjectDependencyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectProjectDependency_ProjectsProjectID",
                table: "ProjectProjectDependency",
                column: "ProjectsProjectID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectProjectDependency");

            migrationBuilder.AddColumn<int>(
                name: "DependsOnProjectID",
                table: "ProjectDependency",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProjectID",
                table: "ProjectDependency",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ProjectDependency_DependsOnProjectID",
                table: "ProjectDependency",
                column: "DependsOnProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectDependency_ProjectID",
                table: "ProjectDependency",
                column: "ProjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectDependency_Project_DependsOnProjectID",
                table: "ProjectDependency",
                column: "DependsOnProjectID",
                principalTable: "Project",
                principalColumn: "ProjectID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectDependency_Project_ProjectID",
                table: "ProjectDependency",
                column: "ProjectID",
                principalTable: "Project",
                principalColumn: "ProjectID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
