using Microsoft.EntityFrameworkCore.Migrations;

namespace SylerBackend.Infra.Migrations
{
    public partial class remove_collumm_titulo_menu__perfil_item : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FROM_TITULO_MENU",
                table: "PERFIL_ITEM",
                newName: "_titulo_menu");

            migrationBuilder.AlterColumn<string>(
                name: "_titulo_menu",
                table: "PERFIL_ITEM",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(30)",
                oldMaxLength: 30);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "_titulo_menu",
                table: "PERFIL_ITEM",
                newName: "FROM_TITULO_MENU");

            migrationBuilder.AlterColumn<string>(
                name: "FROM_TITULO_MENU",
                table: "PERFIL_ITEM",
                type: "NVARCHAR(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
