using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SylerBackend.Infra.Migrations
{
    public partial class add_multi_level : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MULTI_LEVEL",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false),
                    COD_CLIENTE = table.Column<Guid>(nullable: false),
                    FK_ID = table.Column<string>(nullable: true),
                    USER_ID = table.Column<Guid>(nullable: false),
                    ID_PAI = table.Column<int>(nullable: true),
                    NIVEL = table.Column<int>(nullable: true),
                    TYPE_LEVEL_ID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MULTI_LEVEL", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MULTI_LEVEL_COD_CLIENTE",
                table: "MULTI_LEVEL",
                column: "COD_CLIENTE");

            migrationBuilder.CreateIndex(
                name: "IX_MULTI_LEVEL_TYPE_LEVEL_ID",
                table: "MULTI_LEVEL",
                column: "TYPE_LEVEL_ID");

            migrationBuilder.CreateIndex(
                name: "IX_MULTI_LEVEL_USER_ID",
                table: "MULTI_LEVEL",
                column: "USER_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MULTI_LEVEL");
        }
    }
}
