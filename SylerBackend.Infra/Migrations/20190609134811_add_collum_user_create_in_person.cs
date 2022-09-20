using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SylerBackend.Infra.Migrations
{
    public partial class add_collum_user_create_in_person : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "USER_CREATE",
                table: "PERSON",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_PERSON_USER_CREATE",
                table: "PERSON",
                column: "USER_CREATE");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PERSON_USER_CREATE",
                table: "PERSON");

            migrationBuilder.DropColumn(
                name: "USER_CREATE",
                table: "PERSON");
        }
    }
}
