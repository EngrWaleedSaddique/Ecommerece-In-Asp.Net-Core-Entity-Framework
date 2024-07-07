using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceInAsp.NetCore.Migrations
{
    public partial class OrdersTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_order",
                columns: table => new
                {
                    order_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    customer_id = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_order", x => x.order_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_order");
        }
    }
}
