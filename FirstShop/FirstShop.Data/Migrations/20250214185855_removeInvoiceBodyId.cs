using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstShop.Data.Migrations
{
    public partial class removeInvoiceBodyId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvoiceBodyId",
                table: "InvoiceHead");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "InvoiceBodyId",
                table: "InvoiceHead",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
