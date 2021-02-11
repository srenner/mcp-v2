using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace mcp.Server.Data.Migrations
{
    public partial class Net50Upgrade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UniqueName",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    TagID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.TagID);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    VehicleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PurchaseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PurchasePrice = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    TotalInvested = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    EstimatedValue = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    IsForSale = table.Column<bool>(type: "bit", nullable: false),
                    ForSaleLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ForSaleAskingPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    ForSaleTransactionPrice = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    IsSold = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.VehicleID);
                    table.ForeignKey(
                        name: "FK_Vehicle_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserCategory",
                columns: table => new
                {
                    UserCategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryID = table.Column<int>(type: "int", nullable: true),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCategory", x => x.UserCategoryID);
                    table.ForeignKey(
                        name: "FK_UserCategory_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserCategory_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    ProjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleID = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserCategoryID = table.Column<int>(type: "int", nullable: true),
                    TargetCost = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    ActualCost = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TargetEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActualEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsComplete = table.Column<bool>(type: "bit", nullable: false),
                    IsPublic = table.Column<bool>(type: "bit", nullable: false),
                    IsCostPublic = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "VehicleModification",
                columns: table => new
                {
                    VehicleModificationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleID = table.Column<int>(type: "int", nullable: false),
                    UserCategoryID = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    IsHighlighted = table.Column<bool>(type: "bit", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "ProjectDependency",
                columns: table => new
                {
                    ProjectDependencyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectID = table.Column<int>(type: "int", nullable: false),
                    DependsOnProjectID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectDependency", x => x.ProjectDependencyID);
                    table.ForeignKey(
                        name: "FK_ProjectDependency_Project_DependsOnProjectID",
                        column: x => x.DependsOnProjectID,
                        principalTable: "Project",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectDependency_Project_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Project",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "CategoryID", "Name", "SortOrder" },
                values: new object[,]
                {
                    { 1, "Engine", 1 },
                    { 2, "Suspension/Chassis", 2 },
                    { 3, "Brakes", 3 },
                    { 4, "Interior", 4 },
                    { 5, "Body", 5 },
                    { 6, "Electrical", 6 },
                    { 7, "Audio/Video", 7 }
                });

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "TagID", "Description", "IsDeleted", "Name", "SortOrder" },
                values: new object[,]
                {
                    { 18, "A vehicle with collector value", false, "Collector", 0 },
                    { 17, "A vehicle from the 1930s and 1940s modified in the hot rod style", false, "Hot Rod", 0 },
                    { 16, "A vehicle modified to have an impressive stereo, often used in competition", false, "Stereo", 0 },
                    { 15, "A vehicle that has been lightly modified with upgraded parts from the manufacturer", false, "OEM+", 0 },
                    { 14, "A vehicle from Japan often modified in a Japanese style", false, "JDM", 0 },
                    { 13, "A vehicle from Europe, typically modified by removing seams, badges, or trim", false, "Euro", 0 },
                    { 12, "A vehicle modified to be lower, often with stretched tires and lots of negative camber", false, "Stanced", 0 },
                    { 11, "A vehicle with airbags or hydraulics modified in the lowrider style", false, "Lowrider", 0 },
                    { 10, "A vehicle that is entered into car shows", false, "Show", 0 },
                    { 7, "A vehicle that competes in road race competitions", false, "Road Race", 0 },
                    { 8, "A vehicle built for road race events", false, "Drift", 0 },
                    { 19, "A vehicle driven on a road course for fun instead of competition", false, "Open Track", 0 },
                    { 6, "A vehicle that competes in autocross competitions", false, "Autocross", 0 },
                    { 5, "A vehicle used on the drag strip that is rarely, if ever, street driven", false, "Drag", 0 },
                    { 4, "A vehicle that is street driven and also goes to the drag strip", false, "Street/Strip", 0 },
                    { 3, "A vehicle that is built for performance but driven on public streets", false, "Performance Street", 0 },
                    { 2, "A vehicle being restored while making modifications along the way", false, "Restomod", 0 },
                    { 1, "A vehicle being restored to a like-new state", false, "Restoration", 0 },
                    { 9, "A vehicle modified to deliberately look worn or unfinished", false, "Rat Rod", 0 },
                    { 20, "A vehicle that is much faster than it looks", false, "Sleeper", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UniqueName",
                table: "AspNetUsers",
                column: "UniqueName",
                unique: true,
                filter: "[UniqueName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Project_UserCategoryID",
                table: "Project",
                column: "UserCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Project_VehicleID",
                table: "Project",
                column: "VehicleID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectDependency_DependsOnProjectID",
                table: "ProjectDependency",
                column: "DependsOnProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectDependency_ProjectID",
                table: "ProjectDependency",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_UserCategory_CategoryID",
                table: "UserCategory",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_UserCategory_UserID",
                table: "UserCategory",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_UserID",
                table: "Vehicle",
                column: "UserID");

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
                name: "ProjectDependency");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "VehicleModification");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "UserCategory");

            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UniqueName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DisplayName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UniqueName",
                table: "AspNetUsers");
        }
    }
}
