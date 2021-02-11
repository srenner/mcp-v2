using Microsoft.EntityFrameworkCore.Migrations;

namespace mcp.Server.Data.Migrations
{
    public partial class TagModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    TagID = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    SortOrder = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.TagID);
                });

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "TagID", "Description", "Name", "SortOrder" },
                values: new object[,]
                {
                    { 1, "A vehicle being restored to a like-new state", "Restoration", 0 },
                    { 18, "A vehicle with collector value", "Collector", 0 },
                    { 17, "A vehicle from the 1930s and 1940s modified in the hot rod style", "Hot Rod", 0 },
                    { 16, "A vehicle modified to have an impressive stereo, often used in competition", "Stereo", 0 },
                    { 15, "A vehicle that has been lightly modified with upgraded parts from the manufacturer", "OEM+", 0 },
                    { 14, "A vehicle from Japan often modified in a Japanese style", "JDM", 0 },
                    { 13, "A vehicle from Europe, typically modified by removing seams, badges, or trim", "Euro", 0 },
                    { 12, "A vehicle modified to be lower, often with stretched tires and lots of negative camber", "Stanced", 0 },
                    { 11, "A vehicle with airbags or hydraulics modified in the lowrider style", "Lowrider", 0 },
                    { 10, "A vehicle that is entered into car shows", "Show", 0 },
                    { 9, "A vehicle modified to deliberately look worn or unfinished", "Rat Rod", 0 },
                    { 8, "A vehicle built for road race events", "Drift", 0 },
                    { 7, "A vehicle that competes in road race competitions", "Road Race", 0 },
                    { 6, "A vehicle that competes in autocross competitions", "Autocross", 0 },
                    { 5, "A vehicle used on the drag strip that is rarely, if ever, street driven", "Drag", 0 },
                    { 4, "A vehicle that is street driven and also goes to the drag strip", "Street/Strip", 0 },
                    { 3, "A vehicle that is built for performance but driven on public streets", "Performance Street", 0 },
                    { 2, "A vehicle being restored while making modifications along the way", "Restomod", 0 },
                    { 19, "A vehicle driven on a road course for fun instead of competition", "Open Track", 0 },
                    { 20, "A vehicle that is much faster than it looks", "Sleeper", 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tag");
        }
    }
}
