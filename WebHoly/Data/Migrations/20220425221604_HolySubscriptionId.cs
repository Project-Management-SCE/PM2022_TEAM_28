using Microsoft.EntityFrameworkCore.Migrations;

namespace WebHoly.Data.Migrations
{
    public partial class HolySubscriptionId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SoulBoardId",
                table: "SoulBoardCssTypes",
                newName: "HolySubscriptionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HolySubscriptionId",
                table: "SoulBoardCssTypes",
                newName: "SoulBoardId");
        }
    }
}
