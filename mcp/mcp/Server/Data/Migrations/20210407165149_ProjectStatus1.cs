using Microsoft.EntityFrameworkCore.Migrations;

namespace mcp.Server.Data.Migrations
{
    public partial class ProjectStatus1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectStatusID",
                table: "Project",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateTable(
                name: "ProjectStatus",
                columns: table => new
                {
                    ProjectStatusID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectStatus", x => x.ProjectStatusID);
                });

            migrationBuilder.InsertData(
                table: "ProjectStatus",
                columns: new[] { "ProjectStatusID", "Name" },
                values: new object[,]
                {
                    { 1, "Backlog" },
                    { 2, "Active" },
                    { 3, "Complete" },
                    { 4, "Canceled" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Project_ProjectStatusID",
                table: "Project",
                column: "ProjectStatusID");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_ProjectStatus_ProjectStatusID",
                table: "Project",
                column: "ProjectStatusID",
                principalTable: "ProjectStatus",
                principalColumn: "ProjectStatusID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_ProjectStatus_ProjectStatusID",
                table: "Project");

            migrationBuilder.DropTable(
                name: "ProjectStatus");

            migrationBuilder.DropIndex(
                name: "IX_Project_ProjectStatusID",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "ProjectStatusID",
                table: "Project");
        }
    }
}
