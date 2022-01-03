using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebNetCoreProjectApp.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WebSitePasswords",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    WebSite = table.Column<string>(nullable: true),
                    WebSiteUrl = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    CopyCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebSitePasswords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WebSitePasswordHistories",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ExpiredDate = table.Column<DateTime>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    WebSitePasswordId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebSitePasswordHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WebSitePasswordHistories_WebSitePasswords_WebSitePasswordId",
                        column: x => x.WebSitePasswordId,
                        principalTable: "WebSitePasswords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WebSitePasswordHistories_WebSitePasswordId",
                table: "WebSitePasswordHistories",
                column: "WebSitePasswordId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WebSitePasswordHistories");

            migrationBuilder.DropTable(
                name: "WebSitePasswords");
        }
    }
}
