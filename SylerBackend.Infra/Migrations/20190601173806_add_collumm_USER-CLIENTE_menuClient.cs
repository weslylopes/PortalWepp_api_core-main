using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SylerBackend.Infra.Migrations
{
    public partial class add_collumm_USERCLIENTE_menuClient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "USER_CLIENTE",
                table: "MENU_CLIENTE",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_MENU_CLIENTE_USER_CLIENTE",
                table: "MENU_CLIENTE",
                column: "USER_CLIENTE");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MENU_CLIENTE_USER_CLIENTE",
                table: "MENU_CLIENTE");

            migrationBuilder.DropColumn(
                name: "USER_CLIENTE",
                table: "MENU_CLIENTE");
        }
    }
}
