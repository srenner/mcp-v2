using Microsoft.EntityFrameworkCore.Migrations;

namespace mcp.Server.Data.Migrations
{
    public partial class ProjectPartModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectPart",
                columns: table => new
                {
                    ProjectPartID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectPart", x => x.ProjectPartID);
                    table.ForeignKey(
                        name: "FK_ProjectPart_Project_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Project",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            //migrationBuilder.InsertData(
            //    table: "Category",
            //    columns: new[] { "CategoryID", "Name", "SortOrder" },
            //    values: new object[] { 8, "Drivetrain", 8 });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectPart_ProjectID",
                table: "ProjectPart",
                column: "ProjectID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectPart");

            //migrationBuilder.DeleteData(
            //    table: "Category",
            //    keyColumn: "CategoryID",
            //    keyValue: 8);
        }
    }
}
