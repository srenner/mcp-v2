using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace mcp.Server.Data.Migrations
{
    public partial class ProjectModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    ProjectID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    UserCategoryID = table.Column<int>(nullable: true),
                    TargetCost = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    ActualCost = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    StartDate = table.Column<DateTime>(nullable: true),
                    TargetEndDate = table.Column<DateTime>(nullable: true),
                    ActualEndDate = table.Column<DateTime>(nullable: true),
                    IsComplete = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ProjectID);
                    table.ForeignKey(
                        name: "FK_Project_UserCategory_UserCategoryID",
                        column: x => x.UserCategoryID,
                        principalTable: "UserCategory",
                        principalColumn: "UserCategoryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Project_Vehicle_VehicleID",
                        column: x => x.VehicleID,
                        principalTable: "Vehicle",
                        principalColumn: "VehicleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Project_UserCategoryID",
                table: "Project",
                column: "UserCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Project_VehicleID",
                table: "Project",
                column: "VehicleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Project");
        }
    }
}
