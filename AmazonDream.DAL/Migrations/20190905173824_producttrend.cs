using Microsoft.EntityFrameworkCore.Migrations;

namespace AmazonDream.DAL.Migrations
{
    public partial class producttrend : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductTrend",
                table: "PRODUCT",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductTrend",
                table: "PRODUCT");
        }
    }
}
