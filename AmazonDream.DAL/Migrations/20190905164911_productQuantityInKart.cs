using Microsoft.EntityFrameworkCore.Migrations;

namespace AmazonDream.DAL.Migrations
{
    public partial class productQuantityInKart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductQuantityInKart",
                table: "PRODUCT",
                nullable: true,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductQuantityInKart",
                table: "PRODUCT");
        }
    }
}
