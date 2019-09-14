using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AmazonDream.DAL.Migrations
{
    public partial class placedorder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PLACEDORDER",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderNumber = table.Column<long>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Amount = table.Column<long>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false),
                    PaymentType = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Product_ID = table.Column<long>(nullable: false),
                    Customer_ID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PLACEDORDER", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PLACEDORDER_CUSTOMER_Customer_ID",
                        column: x => x.Customer_ID,
                        principalTable: "CUSTOMER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PLACEDORDER_PRODUCT_Product_ID",
                        column: x => x.Product_ID,
                        principalTable: "PRODUCT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PLACEDORDER_Customer_ID",
                table: "PLACEDORDER",
                column: "Customer_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PLACEDORDER_Product_ID",
                table: "PLACEDORDER",
                column: "Product_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PLACEDORDER");
        }
    }
}
