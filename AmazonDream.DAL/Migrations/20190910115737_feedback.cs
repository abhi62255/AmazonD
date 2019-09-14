using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AmazonDream.DAL.Migrations
{
    public partial class feedback : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FEEDBACK",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Rating = table.Column<int>(nullable: false),
                    Review = table.Column<string>(maxLength: 5000, nullable: false),
                    Product_ID = table.Column<long>(nullable: false),
                    Customer_ID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FEEDBACK", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FEEDBACK_CUSTOMER_Customer_ID",
                        column: x => x.Customer_ID,
                        principalTable: "CUSTOMER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FEEDBACK_PRODUCT_Product_ID",
                        column: x => x.Product_ID,
                        principalTable: "PRODUCT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FEEDBACK_Customer_ID",
                table: "FEEDBACK",
                column: "Customer_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FEEDBACK_Product_ID",
                table: "FEEDBACK",
                column: "Product_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FEEDBACK");
        }
    }
}
