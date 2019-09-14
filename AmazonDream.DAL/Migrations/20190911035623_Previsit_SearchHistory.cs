using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AmazonDream.DAL.Migrations
{
    public partial class Previsit_SearchHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PREVISIT",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Product_ID = table.Column<long>(nullable: false),
                    Customer_ID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PREVISIT", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PREVISIT_CUSTOMER_Customer_ID",
                        column: x => x.Customer_ID,
                        principalTable: "CUSTOMER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PREVISIT_PRODUCT_Product_ID",
                        column: x => x.Product_ID,
                        principalTable: "PRODUCT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SEARCHHISTORY",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SearchTag = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Customer_ID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SEARCHHISTORY", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SEARCHHISTORY_CUSTOMER_Customer_ID",
                        column: x => x.Customer_ID,
                        principalTable: "CUSTOMER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PREVISIT_Customer_ID",
                table: "PREVISIT",
                column: "Customer_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PREVISIT_Product_ID",
                table: "PREVISIT",
                column: "Product_ID");

            migrationBuilder.CreateIndex(
                name: "IX_SEARCHHISTORY_Customer_ID",
                table: "SEARCHHISTORY",
                column: "Customer_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PREVISIT");

            migrationBuilder.DropTable(
                name: "SEARCHHISTORY");
        }
    }
}
