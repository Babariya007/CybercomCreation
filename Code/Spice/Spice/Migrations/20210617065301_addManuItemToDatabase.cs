using Microsoft.EntityFrameworkCore.Migrations;

namespace Spice.Migrations
{
    public partial class addManuItemToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ManuItems",
                columns: table => new
                {
                    ManuItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Decription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    SubCategoryID = table.Column<int>(type: "int", nullable: false),
                    SpicynessID = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManuItems", x => x.ManuItemID);
                    table.ForeignKey(
                        name: "FK_ManuItems_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManuItems_Spicynesses_SpicynessID",
                        column: x => x.SpicynessID,
                        principalTable: "Spicynesses",
                        principalColumn: "SpicynessID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManuItems_SubCategories_SubCategoryID",
                        column: x => x.SubCategoryID,
                        principalTable: "SubCategories",
                        principalColumn: "SubCategoryID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ManuItems_CategoryID",
                table: "ManuItems",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_ManuItems_SpicynessID",
                table: "ManuItems",
                column: "SpicynessID");

            migrationBuilder.CreateIndex(
                name: "IX_ManuItems_SubCategoryID",
                table: "ManuItems",
                column: "SubCategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ManuItems");
        }
    }
}
