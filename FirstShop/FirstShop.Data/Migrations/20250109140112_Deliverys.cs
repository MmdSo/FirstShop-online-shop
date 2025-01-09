using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstShop.Data.Migrations
{
    public partial class Deliverys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryMethod",
                table: "shoppingBasket");

            migrationBuilder.DropColumn(
                name: "DeliveryPrice",
                table: "shoppingBasket");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeliveryMethod",
                table: "shoppingBasket",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "DeliveryPrice",
                table: "shoppingBasket",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
