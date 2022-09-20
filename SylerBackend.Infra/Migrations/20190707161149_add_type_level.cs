using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SylerBackend.Infra.Migrations
{
    public partial class add_type_level : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TYPE_LEVEL",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    TITULO = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TYPE_LEVEL", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TYPE_LEVEL");
        }
    }
}
