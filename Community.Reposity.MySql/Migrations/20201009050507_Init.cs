using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Community.Reposity.MySql.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Community_Users",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    UserName = table.Column<string>(maxLength: 32, nullable: false),
                    Email = table.Column<string>(maxLength: 32, nullable: false),
                    Password = table.Column<string>(maxLength: 64, nullable: false),
                    NickName = table.Column<string>(maxLength: 64, nullable: true),
                    Tel = table.Column<string>(maxLength: 11, nullable: false),
                    AddTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Community_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Community_Users");
        }
    }
}
