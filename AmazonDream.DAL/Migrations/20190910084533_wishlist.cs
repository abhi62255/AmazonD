using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AmazonDream.DAL.Migrations
{
    public partial class wishlist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WISHLIST",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Product_ID = table.Column<long>(nullable: false),
                    Customer_ID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WISHLIST", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WISHLIST_CUSTOMER_Customer_ID",
                        column: x => x.Customer_ID,
                        principalTable: "CUSTOMER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WISHLIST_PRODUCT_Product_ID",
                        column: x => x.Product_ID,
                        principalTable: "PRODUCT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WISHLIST_Customer_ID",
                table: "WISHLIST",
                column: "Customer_ID");

            migrationBuilder.CreateIndex(
                name: "IX_WISHLIST_Product_ID",
                table: "WISHLIST",
                column: "Product_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WISHLIST");
        }
    }
}
