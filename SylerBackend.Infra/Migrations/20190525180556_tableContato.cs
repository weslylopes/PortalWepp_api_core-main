using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SylerBackend.Infra.Migrations
{
    public partial class tableContato : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FORMULARIO_ID",
                table: "STATUS_GRUPO",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "CONTATO",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    COD_CLIENTE = table.Column<Guid>(nullable: false),
                    PERSON_ID = table.Column<Guid>(nullable: false),
                    NOME = table.Column<string>(type: "NVARCHAR(70)", maxLength: 70, nullable: true),
                    DATA_NASCIMENTO = table.Column<DateTime>(nullable: false),
                    TELEFONE = table.Column<string>(type: "NVARCHAR(20)", maxLength: 20, nullable: true),
                    EMAIL = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: true),
                    TITULO = table.Column<string>(type: "NVARCHAR(500)", maxLength: 500, nullable: true),
                    ATIVO = table.Column<bool>(nullable: false),
                    DATA_CADASTRO = table.Column<DateTime>(nullable: false),
                    DATA_ULTIMO_CONTATO = table.Column<DateTime>(nullable: false),
                    STATUS_ID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONTATO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CONTATO_ID_X_STATUS_ID",
                        column: x => x.STATUS_ID,
                        principalTable: "STATUS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_STATUS_GRUPO_FORMULARIO_ID",
                table: "STATUS_GRUPO",
                column: "FORMULARIO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CONTATO_COD_CLIENTE",
                table: "CONTATO",
                column: "COD_CLIENTE");

            migrationBuilder.CreateIndex(
                name: "IX_CONTATO_PERSON_ID",
                table: "CONTATO",
                column: "PERSON_ID");

            migrationBuilder.CreateIndex(
                name: "IX_CONTATO_STATUS_ID",
                table: "CONTATO",
                column: "STATUS_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CONTATO");

            migrationBuilder.DropIndex(
                name: "IX_STATUS_GRUPO_FORMULARIO_ID",
                table: "STATUS_GRUPO");

            migrationBuilder.DropColumn(
                name: "FORMULARIO_ID",
                table: "STATUS_GRUPO");
        }
    }
}
