using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AmazonDream.DAL.Migrations
{
    public partial class Address : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ADDRESS",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AddressLine = table.Column<string>(maxLength: 500, nullable: false),
                    City = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    PostalCode = table.Column<int>(nullable: false),
                    AddressType = table.Column<string>(nullable: true),
                    Seller_ID = table.Column<long>(nullable: true),
                    Customer_ID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADDRESS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ADDRESS_CUSTOMER_Customer_ID",
                        column: x => x.Customer_ID,
                        principalTable: "CUSTOMER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ADDRESS_SELLER_Seller_ID",
                        column: x => x.Seller_ID,
                        principalTable: "SELLER",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ADDRESS_Customer_ID",
                table: "ADDRESS",
                column: "Customer_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ADDRESS_Seller_ID",
                table: "ADDRESS",
                column: "Seller_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ADDRESS");
        }
    }
}
