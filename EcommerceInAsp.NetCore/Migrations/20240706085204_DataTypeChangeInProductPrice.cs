using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceInAsp.NetCore.Migrations
{
    public partial class DataTypeChangeInProductPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "product_price",
                table: "tbl_Product",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "product_price",
                table: "tbl_Product",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
