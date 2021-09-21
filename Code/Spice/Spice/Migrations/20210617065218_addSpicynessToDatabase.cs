using Microsoft.EntityFrameworkCore.Migrations;

namespace Spice.Migrations
{
    public partial class addSpicynessToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Spicynesses",
                columns: table => new
                {
                    SpicynessID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpicynessName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spicynesses", x => x.SpicynessID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Spicynesses");
        }
    }
}
