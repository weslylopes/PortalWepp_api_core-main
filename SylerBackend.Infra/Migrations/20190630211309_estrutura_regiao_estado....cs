using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SylerBackend.Infra.Migrations
{
    public partial class estrutura_regiao_estado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "REGIAO",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NOME = table.Column<string>(type: "NVARCHAR(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REGIAO", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ESTADO",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NOME = table.Column<string>(type: "NVARCHAR(30)", maxLength: 30, nullable: false),
                    UF = table.Column<string>(type: "NVARCHAR(2)", maxLength: 2, nullable: false),
                    REGIAO_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESTADO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ESTADO_ID_X_REGIAO_ID",
                        column: x => x.REGIAO_ID,
                        principalTable: "REGIAO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MUNICIPIO",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NOME = table.Column<string>(type: "NVARCHAR(30)", maxLength: 30, nullable: false),
                    ESTADO_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MUNICIPIO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MUNICIPIO_ID_X_ESTADO_ID",
                        column: x => x.ESTADO_ID,
                        principalTable: "ESTADO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BAIRRO",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NOME = table.Column<string>(type: "NVARCHAR(70)", maxLength: 70, nullable: false),
                    MUNICIPIO_ID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BAIRRO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BAIRRO_ID_X_MUNICIPIO_ID",
                        column: x => x.MUNICIPIO_ID,
                        principalTable: "MUNICIPIO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BAIRRO_MUNICIPIO_ID",
                table: "BAIRRO",
                column: "MUNICIPIO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ESTADO_REGIAO_ID",
                table: "ESTADO",
                column: "REGIAO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MUNICIPIO_ESTADO_ID",
                table: "MUNICIPIO",
                column: "ESTADO_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BAIRRO");

            migrationBuilder.DropTable(
                name: "MUNICIPIO");

            migrationBuilder.DropTable(
                name: "ESTADO");

            migrationBuilder.DropTable(
                name: "REGIAO");
        }
    }
}
