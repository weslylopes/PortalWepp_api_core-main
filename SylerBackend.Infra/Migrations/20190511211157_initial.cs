using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SylerBackend.Infra.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CLIENTE",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CODIGO_AUX = table.Column<int>(nullable: false),
                    FANTASIA = table.Column<string>(nullable: false),
                    RAZAO_SOCIAL = table.Column<string>(nullable: true),
                    CPF_CNPJ = table.Column<string>(nullable: true),
                    ENDERECO = table.Column<string>(nullable: true),
                    BAIRRO = table.Column<string>(nullable: true),
                    CIDADE = table.Column<string>(nullable: true),
                    ESTADO = table.Column<string>(nullable: true),
                    TELEFONE = table.Column<string>(nullable: true),
                    CELULAR_1 = table.Column<string>(nullable: true),
                    CELULAR_2 = table.Column<string>(nullable: true),
                    CELULAR_3 = table.Column<string>(nullable: true),
                    ATIVO = table.Column<bool>(nullable: false),
                    DATA_CADASTRO = table.Column<DateTime>(nullable: false),
                    DIA_VENC = table.Column<string>(nullable: true),
                    NOME_RESP = table.Column<string>(nullable: true),
                    EMAIL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENTE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FORMULARIO",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    NOME = table.Column<string>(nullable: false),
                    URL = table.Column<string>(nullable: false),
                    OBJETIVO = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FORMULARIO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NOTICIA_GRUPO",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    COD_CLIENTE = table.Column<Guid>(nullable: false),
                    TITULO = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    LARGURA_G = table.Column<int>(nullable: false),
                    ALTURA_G = table.Column<int>(nullable: false),
                    LARGURA_P = table.Column<int>(nullable: false),
                    ALTURA_P = table.Column<int>(nullable: false),
                    THUMBNAIL = table.Column<bool>(nullable: false),
                    VIDEO = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    ATIVO = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NOTICIA_GRUPO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OS",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    COD_CLIENTE = table.Column<Guid>(nullable: false),
                    CODIGO_OS = table.Column<int>(nullable: false),
                    PLACA = table.Column<string>(type: "NVARCHAR(8)", maxLength: 8, nullable: true),
                    PD = table.Column<string>(nullable: true),
                    VT = table.Column<string>(nullable: true),
                    PT = table.Column<string>(nullable: true),
                    PB = table.Column<string>(nullable: true),
                    FX = table.Column<string>(nullable: true),
                    TOTAL = table.Column<double>(nullable: false),
                    TOTAL_PAGAR = table.Column<double>(nullable: false),
                    DESC_PERCENT = table.Column<double>(nullable: false),
                    DESC_MOEDA = table.Column<double>(nullable: false),
                    DATA_CRIADO = table.Column<DateTime>(nullable: false),
                    DATA_FINALIZADO = table.Column<DateTime>(nullable: false),
                    OBSERVACAO = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PERFIL",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    COD_CLIENTE = table.Column<Guid>(nullable: false),
                    TITULO = table.Column<string>(type: "NVARCHAR(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERFIL", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PERSON",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    COD_CLIENTE = table.Column<Guid>(nullable: false),
                    NOME = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    CPF_CNPJ = table.Column<string>(type: "NVARCHAR(20)", maxLength: 20, nullable: true),
                    DATA_NASCIMENTO = table.Column<DateTime>(nullable: false),
                    SEXO = table.Column<string>(type: "NVARCHAR(1)", maxLength: 1, nullable: true),
                    EMAIL = table.Column<string>(type: "NVARCHAR(70)", maxLength: 70, nullable: true),
                    TELEFONE = table.Column<string>(type: "NVARCHAR(20)", maxLength: 20, nullable: true),
                    CELULAR = table.Column<string>(type: "NVARCHAR(20)", maxLength: 20, nullable: true),
                    CEP = table.Column<string>(type: "NVARCHAR(10)", maxLength: 10, nullable: true),
                    ENDERECO = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    NUMERO = table.Column<string>(type: "NVARCHAR(6)", maxLength: 6, nullable: true),
                    BAIRRO = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: true),
                    CIDADE = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: true),
                    ESTADO = table.Column<string>(type: "NVARCHAR(2)", maxLength: 2, nullable: true),
                    COMPLEMENTO = table.Column<string>(type: "NVARCHAR(200)", maxLength: 200, nullable: true),
                    IMAGEM = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    DATA_CADASTRO = table.Column<DateTime>(nullable: false),
                    ATIVO = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERSON", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PUSH_CLIENTE",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    COD_CLIENTE = table.Column<Guid>(nullable: false),
                    IDS_PUSH = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    KEYS_PUSH = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    TITULO = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    MENSAGEM = table.Column<string>(type: "NVARCHAR(500)", maxLength: 500, nullable: true),
                    LINK_URL = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    IMG_URL = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    ATIVO = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PUSH_CLIENTE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "STATUS_GRUPO",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    COD_CLIENTE = table.Column<Guid>(nullable: false),
                    TITULO = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STATUS_GRUPO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "USER_TYPE",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    TITULO = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER_TYPE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FIELDS",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    FORMULARIO_ID = table.Column<Guid>(nullable: false),
                    NOME = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    TYPE = table.Column<string>(type: "NVARCHAR(20)", maxLength: 20, nullable: true),
                    SIZE = table.Column<string>(type: "NVARCHAR(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FIELDS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FIELDS_FORMULARIO_ID_X_FORMULARIO_ID",
                        column: x => x.FORMULARIO_ID,
                        principalTable: "FORMULARIO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MENU",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    TITULO = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    GRID_TITULO = table.Column<string>(type: "NVARCHAR(30)", maxLength: 30, nullable: false),
                    URL = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    ATIVO = table.Column<bool>(nullable: false),
                    FORMULARIO_ID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MENU", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MENU_FORMULARIO_ID_X_FORMULARIO_ID",
                        column: x => x.FORMULARIO_ID,
                        principalTable: "FORMULARIO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NOTICIA",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    COD_CLIENTE = table.Column<Guid>(nullable: false),
                    TITULO = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    DESC_CURTA = table.Column<string>(type: "NVARCHAR(200)", maxLength: 200, nullable: false),
                    DESC_LONG = table.Column<string>(type: "NVARCHAR(2000)", maxLength: 2000, nullable: false),
                    DATA_INICIAL = table.Column<DateTime>(nullable: false),
                    DATA_FINAL = table.Column<DateTime>(nullable: false),
                    IMAGEM = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    NOTICIA_GRUPO_ID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NOTICIA", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NOTICIA_GRUPO_NOTICIA_ID_X_GRUPO_NOTICIA_ID",
                        column: x => x.NOTICIA_GRUPO_ID,
                        principalTable: "NOTICIA_GRUPO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OS_ITEM",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    QUANTIDADE = table.Column<int>(nullable: false),
                    DESCRICAO = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    PRECO = table.Column<double>(nullable: false),
                    TOTAL = table.Column<double>(nullable: false),
                    OS_ID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OS_ITEM", x => x.ID);
                    table.ForeignKey(
                        name: "FK_OS_ID_X_OS_ITEM_ID",
                        column: x => x.OS_ID,
                        principalTable: "OS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PERFIL_ITEM",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    COD_CLIENTE = table.Column<Guid>(nullable: false),
                    FORM_HASH = table.Column<Guid>(nullable: false),
                    READ = table.Column<bool>(nullable: false),
                    WRITE = table.Column<bool>(nullable: false),
                    DELETE = table.Column<bool>(nullable: false),
                    PERFIL_ID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERFIL_ITEM", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PERFIL_ID_X_PERFIL_ITEM_ID",
                        column: x => x.PERFIL_ID,
                        principalTable: "PERFIL",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "STATUS",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    TITULO = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: true),
                    STATUS_GRUPO_ID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STATUS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_STATUS_STATUS_GRUPO_ID_X_STATUS_STATUS_GRUPO_ID",
                        column: x => x.STATUS_GRUPO_ID,
                        principalTable: "STATUS_GRUPO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "USER",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    COD_CLIENTE = table.Column<Guid>(nullable: false),
                    NOME = table.Column<string>(type: "NVARCHAR(70)", maxLength: 70, nullable: false),
                    EMAIL = table.Column<string>(type: "NVARCHAR(70)", maxLength: 70, nullable: false),
                    SENHA = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    ATIVO = table.Column<bool>(nullable: false),
                    USA_PERFIL = table.Column<bool>(nullable: false),
                    USER_TYPE_ID = table.Column<Guid>(nullable: false),
                    PERFIL_ID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER", x => x.ID);
                    table.ForeignKey(
                        name: "FK_USER_PERFIL_ID_X_PERFIL_ID",
                        column: x => x.PERFIL_ID,
                        principalTable: "PERFIL",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_USER_USER_TYPE_ID_X_USER_TYPE_ID",
                        column: x => x.USER_TYPE_ID,
                        principalTable: "USER_TYPE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FIELDS_CLIENTE",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    TITULO = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    IS_COLUNA_GRID = table.Column<bool>(nullable: false),
                    GRID_TITULO = table.Column<string>(type: "NVARCHAR(30)", maxLength: 30, nullable: true),
                    IS_VALIDA = table.Column<bool>(nullable: false),
                    FIELD_ID = table.Column<Guid>(nullable: false),
                    COD_CLIENTE = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FIELDS_CLIENTE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FIELDS_CLIENTE_COD_CLIENTE_X_CLIENTE_ID",
                        column: x => x.COD_CLIENTE,
                        principalTable: "CLIENTE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FIELDS_CLIENTE_ID_X_FIELDS_ID",
                        column: x => x.FIELD_ID,
                        principalTable: "FIELDS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MENU_CLIENTE",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    COD_CLIENTE = table.Column<Guid>(nullable: false),
                    TITULO = table.Column<string>(type: "NVARCHAR(30)", maxLength: 30, nullable: false),
                    URL = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    ICONE = table.Column<string>(nullable: false),
                    POSICAO = table.Column<int>(nullable: false),
                    ATIVO = table.Column<bool>(nullable: false),
                    MENU_ID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MENU_CLIENTE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MENU_CLIENTE_MENU_ID_X_MENU_ID",
                        column: x => x.MENU_ID,
                        principalTable: "MENU",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FIELDS_FORMULARIO_ID",
                table: "FIELDS",
                column: "FORMULARIO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_FIELDS_CLIENTE_COD_CLIENTE",
                table: "FIELDS_CLIENTE",
                column: "COD_CLIENTE");

            migrationBuilder.CreateIndex(
                name: "IX_FIELDS_CLIENTE_FIELD_ID",
                table: "FIELDS_CLIENTE",
                column: "FIELD_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MENU_FORMULARIO_ID",
                table: "MENU",
                column: "FORMULARIO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MENU_CLIENTE_COD_CLIENTE",
                table: "MENU_CLIENTE",
                column: "COD_CLIENTE");

            migrationBuilder.CreateIndex(
                name: "IX_MENU_CLIENTE_MENU_ID",
                table: "MENU_CLIENTE",
                column: "MENU_ID");

            migrationBuilder.CreateIndex(
                name: "IX_NOTICIA_COD_CLIENTE",
                table: "NOTICIA",
                column: "COD_CLIENTE");

            migrationBuilder.CreateIndex(
                name: "IX_NOTICIA_NOTICIA_GRUPO_ID",
                table: "NOTICIA",
                column: "NOTICIA_GRUPO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_NOTICIA_GRUPO_COD_CLIENTE",
                table: "NOTICIA_GRUPO",
                column: "COD_CLIENTE");

            migrationBuilder.CreateIndex(
                name: "IX_OS_COD_CLIENTE",
                table: "OS",
                column: "COD_CLIENTE");

            migrationBuilder.CreateIndex(
                name: "IX_OS_ITEM_OS_ID",
                table: "OS_ITEM",
                column: "OS_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PERFIL_COD_CLIENTE",
                table: "PERFIL",
                column: "COD_CLIENTE");

            migrationBuilder.CreateIndex(
                name: "IX_PERFIL_ITEM_COD_CLIENTE",
                table: "PERFIL_ITEM",
                column: "COD_CLIENTE");

            migrationBuilder.CreateIndex(
                name: "IX_PERFIL_ITEM_FORM_HASH",
                table: "PERFIL_ITEM",
                column: "FORM_HASH");

            migrationBuilder.CreateIndex(
                name: "IX_PERFIL_ITEM_PERFIL_ID",
                table: "PERFIL_ITEM",
                column: "PERFIL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_PERSON_COD_CLIENTE",
                table: "PERSON",
                column: "COD_CLIENTE");

            migrationBuilder.CreateIndex(
                name: "IX_PUSH_CLIENTE_COD_CLIENTE",
                table: "PUSH_CLIENTE",
                column: "COD_CLIENTE");

            migrationBuilder.CreateIndex(
                name: "IX_STATUS_STATUS_GRUPO_ID",
                table: "STATUS",
                column: "STATUS_GRUPO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_STATUS_GRUPO_COD_CLIENTE",
                table: "STATUS_GRUPO",
                column: "COD_CLIENTE");

            migrationBuilder.CreateIndex(
                name: "IX_USER_COD_CLIENTE",
                table: "USER",
                column: "COD_CLIENTE");

            migrationBuilder.CreateIndex(
                name: "IX_USER_PERFIL_ID",
                table: "USER",
                column: "PERFIL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_USER_USER_TYPE_ID",
                table: "USER",
                column: "USER_TYPE_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FIELDS_CLIENTE");

            migrationBuilder.DropTable(
                name: "MENU_CLIENTE");

            migrationBuilder.DropTable(
                name: "NOTICIA");

            migrationBuilder.DropTable(
                name: "OS_ITEM");

            migrationBuilder.DropTable(
                name: "PERFIL_ITEM");

            migrationBuilder.DropTable(
                name: "PERSON");

            migrationBuilder.DropTable(
                name: "PUSH_CLIENTE");

            migrationBuilder.DropTable(
                name: "STATUS");

            migrationBuilder.DropTable(
                name: "USER");

            migrationBuilder.DropTable(
                name: "CLIENTE");

            migrationBuilder.DropTable(
                name: "FIELDS");

            migrationBuilder.DropTable(
                name: "MENU");

            migrationBuilder.DropTable(
                name: "NOTICIA_GRUPO");

            migrationBuilder.DropTable(
                name: "OS");

            migrationBuilder.DropTable(
                name: "STATUS_GRUPO");

            migrationBuilder.DropTable(
                name: "PERFIL");

            migrationBuilder.DropTable(
                name: "USER_TYPE");

            migrationBuilder.DropTable(
                name: "FORMULARIO");
        }
    }
}
