using Microsoft.EntityFrameworkCore.Migrations;

namespace SylerBackend.Infra.Migrations
{
    public partial class add_collumm_titulo_menu__perfil_item : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FROM_TITULO_MENU",
                table: "PERFIL_ITEM",
                type: "NVARCHAR(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FROM_TITULO_MENU",
                table: "PERFIL_ITEM");
        }
    }
}
