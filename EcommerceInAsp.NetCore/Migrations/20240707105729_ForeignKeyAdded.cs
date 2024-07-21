using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceInAsp.NetCore.Migrations
{
    public partial class ForeignKeyAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_tbl_order_customer_id",
                table: "tbl_order",
                column: "customer_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_order_tbl_Customer_customer_id",
                table: "tbl_order",
                column: "customer_id",
                principalTable: "tbl_Customer",
                principalColumn: "customer_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_order_tbl_Customer_customer_id",
                table: "tbl_order");

            migrationBuilder.DropIndex(
                name: "IX_tbl_order_customer_id",
                table: "tbl_order");
        }
    }
}
