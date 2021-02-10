using Microsoft.EntityFrameworkCore.Migrations;

namespace mcp.Server.Data.Migrations
{
    public partial class VehicleModificationModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VehicleModification",
                columns: table => new
                {
                    VehicleModificationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleID = table.Column<int>(nullable: false),
                    UserCategoryID = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    SortOrder = table.Column<int>(nullable: false),
                    IsHighlighted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleModification", x => x.VehicleModificationID);
                    table.ForeignKey(
                        name: "FK_VehicleModification_UserCategory_UserCategoryID",
                        column: x => x.UserCategoryID,
                        principalTable: "UserCategory",
                        principalColumn: "UserCategoryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VehicleModification_Vehicle_VehicleID",
                        column: x => x.VehicleID,
                        principalTable: "Vehicle",
                        principalColumn: "VehicleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModification_UserCategoryID",
                table: "VehicleModification",
                column: "UserCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModification_VehicleID",
                table: "VehicleModification",
                column: "VehicleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleModification");
        }
    }
}
