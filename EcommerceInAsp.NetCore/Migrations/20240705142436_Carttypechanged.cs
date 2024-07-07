using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceInAsp.NetCore.Migrations
{
    public partial class Carttypechanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_tbl_Category_cat_id",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "tbl_Product");

            migrationBuilder.RenameIndex(
                name: "IX_Product_cat_id",
                table: "tbl_Product",
                newName: "IX_tbl_Product_cat_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tbl_Product",
                table: "tbl_Product",
                column: "product_id");

            migrationBuilder.CreateTable(
                name: "tbl_Cart",
                columns: table => new
                {
                    cart_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    prod_id = table.Column<int>(type: "int", nullable: false),
                    cust_id = table.Column<int>(type: "int", nullable: false),
                    product_quantity = table.Column<int>(type: "int", nullable: false),
                    cart_status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Cart", x => x.cart_id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_tbl_Product_tbl_Category_cat_id",
                table: "tbl_Product",
                column: "cat_id",
                principalTable: "tbl_Category",
                principalColumn: "category_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tbl_Product_tbl_Category_cat_id",
                table: "tbl_Product");

            migrationBuilder.DropTable(
                name: "tbl_Cart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tbl_Product",
                table: "tbl_Product");

            migrationBuilder.RenameTable(
                name: "tbl_Product",
                newName: "Product");

            migrationBuilder.RenameIndex(
                name: "IX_tbl_Product_cat_id",
                table: "Product",
                newName: "IX_Product_cat_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "product_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_tbl_Category_cat_id",
                table: "Product",
                column: "cat_id",
                principalTable: "tbl_Category",
                principalColumn: "category_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
