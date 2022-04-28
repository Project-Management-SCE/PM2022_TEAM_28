using Microsoft.EntityFrameworkCore.Migrations;

namespace WebHoly.Data.Migrations
{
    public partial class city : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "HolySubscription",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SoulBoardCssTypes_HolySubscriptionId",
                table: "SoulBoardCssTypes",
                column: "HolySubscriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_SoulBoardCssTypes_HolySubscription_HolySubscriptionId",
                table: "SoulBoardCssTypes",
                column: "HolySubscriptionId",
                principalTable: "HolySubscription",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SoulBoardCssTypes_HolySubscription_HolySubscriptionId",
                table: "SoulBoardCssTypes");

            migrationBuilder.DropIndex(
                name: "IX_SoulBoardCssTypes_HolySubscriptionId",
                table: "SoulBoardCssTypes");

            migrationBuilder.DropColumn(
                name: "City",
                table: "HolySubscription");
        }
    }
}
