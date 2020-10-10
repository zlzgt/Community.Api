using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Community.Reposity.MySql.Migrations
{
    public partial class Article : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Community_Article",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    NickName = table.Column<string>(nullable: true),
                    Title = table.Column<string>(maxLength: 256, nullable: false),
                    IsDraft = table.Column<int>(nullable: false),
                    Content = table.Column<string>(nullable: false),
                    Summary = table.Column<string>(maxLength: 512, nullable: false),
                    Img = table.Column<string>(nullable: true),
                    Config = table.Column<string>(nullable: true),
                    EntryName = table.Column<string>(nullable: true),
                    CategoryId = table.Column<string>(nullable: false),
                    CategoryName = table.Column<string>(nullable: false),
                    ReadCount = table.Column<int>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    PubTime = table.Column<DateTime>(nullable: false),
                    AddTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Community_Article", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Community_Article_Community_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Community_Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Community_Article_Community_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Community_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Community_Article_CategoryId",
                table: "Community_Article",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Community_Article_UserId",
                table: "Community_Article",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Community_Article");

            migrationBuilder.DropTable(
                name: "Community_Category");
        }
    }
}
