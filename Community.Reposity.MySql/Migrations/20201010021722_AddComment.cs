using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Community.Reposity.MySql.Migrations
{
    public partial class AddComment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Community_Comment",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 36, nullable: false),
                    ArticleId = table.Column<int>(nullable: false),
                    Content = table.Column<string>(maxLength: 512, nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    ParentId = table.Column<int>(nullable: false),
                    CommentDate = table.Column<DateTime>(nullable: false),
                    AddTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Community_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Community_Comment_Community_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Community_Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Community_Comment_UserId",
                table: "Community_Comment",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Community_Comment");
        }
    }
}
