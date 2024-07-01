using Microsoft.EntityFrameworkCore.Migrations;

namespace EcommerceInAsp.NetCore.Migrations
{
    public partial class FaqsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_Faqs",
                columns: table => new
                {
                    faq_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    faq_question = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    faq_answer = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Faqs", x => x.faq_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_Faqs");
        }
    }
}
