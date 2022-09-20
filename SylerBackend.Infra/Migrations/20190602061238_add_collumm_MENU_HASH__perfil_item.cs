using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SylerBackend.Infra.Migrations
{
    public partial class add_collumm_MENU_HASH__perfil_item : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MENU_HASH",
                table: "PERFIL_ITEM",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_PERFIL_ITEM_MENU_HASH",
                table: "PERFIL_ITEM",
                column: "MENU_HASH");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PERFIL_ITEM_MENU_HASH",
                table: "PERFIL_ITEM");

            migrationBuilder.DropColumn(
                name: "MENU_HASH",
                table: "PERFIL_ITEM");
        }
    }
}
