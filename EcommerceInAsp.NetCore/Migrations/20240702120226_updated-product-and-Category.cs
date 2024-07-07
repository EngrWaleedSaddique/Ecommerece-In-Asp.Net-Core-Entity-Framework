using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceInAsp.NetCore.Migrations
{
    public partial class updatedproductandCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Product_cat_id",
                table: "Product",
                column: "cat_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_tbl_Category_cat_id",
                table: "Product",
                column: "cat_id",
                principalTable: "tbl_Category",
                principalColumn: "category_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_tbl_Category_cat_id",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_cat_id",
                table: "Product");
        }
    }
}
