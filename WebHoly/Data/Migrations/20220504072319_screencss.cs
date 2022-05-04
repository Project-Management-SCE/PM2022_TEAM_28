using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebHoly.Data.Migrations
{
    public partial class screencss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ScreenCssTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HolySubscriptionId = table.Column<int>(type: "int", nullable: false),
                    FontSize = table.Column<int>(type: "int", nullable: false),
                    PictureType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FontColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FontType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScreenCssTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScreenCssTypes_HolySubscription_HolySubscriptionId",
                        column: x => x.HolySubscriptionId,
                        principalTable: "HolySubscription",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScreenCssTypes_HolySubscriptionId",
                table: "ScreenCssTypes",
                column: "HolySubscriptionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScreenCssTypes");
        }
    }
}
