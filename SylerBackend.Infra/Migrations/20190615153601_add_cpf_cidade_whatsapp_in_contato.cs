using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SylerBackend.Infra.Migrations
{
    public partial class add_cpf_cidade_whatsapp_in_contato : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TITULO",
                table: "CONTATO",
                newName: "COMENTARIO");

            migrationBuilder.AddColumn<string>(
                name: "CIDADE",
                table: "CONTATO",
                type: "NVARCHAR(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CPF",
                table: "CONTATO",
                type: "NVARCHAR(15)",
                maxLength: 15,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "USER_ID_CREATE",
                table: "CONTATO",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "WHATSAPP",
                table: "CONTATO",
                type: "NVARCHAR(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CONTATO_USER_ID_CREATE",
                table: "CONTATO",
                column: "USER_ID_CREATE");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CONTATO_USER_ID_CREATE",
                table: "CONTATO");

            migrationBuilder.DropColumn(
                name: "CIDADE",
                table: "CONTATO");

            migrationBuilder.DropColumn(
                name: "CPF",
                table: "CONTATO");

            migrationBuilder.DropColumn(
                name: "USER_ID_CREATE",
                table: "CONTATO");

            migrationBuilder.DropColumn(
                name: "WHATSAPP",
                table: "CONTATO");

            migrationBuilder.RenameColumn(
                name: "COMENTARIO",
                table: "CONTATO",
                newName: "TITULO");
        }
    }
}
