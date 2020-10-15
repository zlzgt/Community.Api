using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Community.Reposity.MySql.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Community_Article",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    NickName = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: false),
                    IsDraft = table.Column<int>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    Summary = table.Column<string>(nullable: true),
                    Img = table.Column<string>(nullable: true),
                    Config = table.Column<string>(nullable: true),
                    EntryName = table.Column<string>(nullable: true),
                    ArticleCategoryJson = table.Column<string>(nullable: true),
                    ReadCount = table.Column<int>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    PubTime = table.Column<DateTime>(nullable: false),
                    AddTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Community_Article", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Community_Category",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Title = table.Column<string>(maxLength: 32, nullable: false),
                    Description = table.Column<string>(nullable: true),
                    AddTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Community_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Community_Comment",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    ArticleId = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: false),
                    ParentId = table.Column<int>(nullable: false),
                    CommentDate = table.Column<DateTime>(nullable: false),
                    AddTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Community_Comment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Community_Users",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    UserName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: false),
                    NickName = table.Column<string>(nullable: true),
                    Tel = table.Column<string>(nullable: true),
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
                name: "Community_Article");

            migrationBuilder.DropTable(
                name: "Community_Category");

            migrationBuilder.DropTable(
                name: "Community_Comment");

            migrationBuilder.DropTable(
                name: "Community_Users");
        }
    }
}
