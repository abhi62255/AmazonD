using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AmazonDream.DAL.Migrations
{
    public partial class Intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ADMIN",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    Password = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADMIN", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CUSTOMER",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 70, nullable: false),
                    Email = table.Column<string>(maxLength: 70, nullable: false),
                    Password = table.Column<string>(maxLength: 50, nullable: false),
                    Gender = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMER", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SELLER",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Password = table.Column<string>(maxLength: 50, nullable: false),
                    Status = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SELLER", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCT",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductName = table.Column<string>(maxLength: 200, nullable: false),
                    ProductPrice = table.Column<long>(nullable: false),
                    ProductQuantity = table.Column<int>(nullable: false),
                    ProductDiscount = table.Column<int>(nullable: false),
                    ProductCategory = table.Column<string>(maxLength: 100, nullable: false),
                    ProductSubCategory = table.Column<string>(maxLength: 100, nullable: false),
                    ProductBrand = table.Column<string>(maxLength: 100, nullable: false),
                    ProductGenderType = table.Column<string>(nullable: false),
                    ProductDescription = table.Column<string>(maxLength: 100, nullable: false),
                    Seller_ID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCT", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PRODUCT_SELLER_Seller_ID",
                        column: x => x.Seller_ID,
                        principalTable: "SELLER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PRODUCT_Seller_ID",
                table: "PRODUCT",
                column: "Seller_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ADMIN");

            migrationBuilder.DropTable(
                name: "CUSTOMER");

            migrationBuilder.DropTable(
                name: "PRODUCT");

            migrationBuilder.DropTable(
                name: "SELLER");
        }
    }
}
