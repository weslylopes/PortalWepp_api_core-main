using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SylerBackend.Infra.Migrations
{
    public partial class new_estructure_perfil_menuCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PERFIL_ITEM_FORM_HASH",
                table: "PERFIL_ITEM");

            migrationBuilder.DropIndex(
                name: "IX_MENU_CLIENTE_USER_CLIENTE",
                table: "MENU_CLIENTE");

            migrationBuilder.DropColumn(
                name: "FORM_HASH",
                table: "PERFIL_ITEM");

            migrationBuilder.DropColumn(
                name: "_titulo_menu",
                table: "PERFIL_ITEM");

            migrationBuilder.DropColumn(
                name: "USER_CLIENTE",
                table: "MENU_CLIENTE");

            migrationBuilder.RenameColumn(
                name: "MENU_HASH",
                table: "PERFIL_ITEM",
                newName: "MENU_CLIENTE_ID");

            migrationBuilder.RenameIndex(
                name: "IX_PERFIL_ITEM_MENU_HASH",
                table: "PERFIL_ITEM",
                newName: "IX_PERFIL_ITEM_MENU_CLIENTE_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_MENU_CLIENTE_ID_X_MENU_CLIENTE_ID",
                table: "PERFIL_ITEM",
                column: "MENU_CLIENTE_ID",
                principalTable: "MENU_CLIENTE",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MENU_CLIENTE_ID_X_MENU_CLIENTE_ID",
                table: "PERFIL_ITEM");

            migrationBuilder.RenameColumn(
                name: "MENU_CLIENTE_ID",
                table: "PERFIL_ITEM",
                newName: "MENU_HASH");

            migrationBuilder.RenameIndex(
                name: "IX_PERFIL_ITEM_MENU_CLIENTE_ID",
                table: "PERFIL_ITEM",
                newName: "IX_PERFIL_ITEM_MENU_HASH");

            migrationBuilder.AddColumn<Guid>(
                name: "FORM_HASH",
                table: "PERFIL_ITEM",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "_titulo_menu",
                table: "PERFIL_ITEM",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "USER_CLIENTE",
                table: "MENU_CLIENTE",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_PERFIL_ITEM_FORM_HASH",
                table: "PERFIL_ITEM",
                column: "FORM_HASH");

            migrationBuilder.CreateIndex(
                name: "IX_MENU_CLIENTE_USER_CLIENTE",
                table: "MENU_CLIENTE",
                column: "USER_CLIENTE");
        }
    }
}
