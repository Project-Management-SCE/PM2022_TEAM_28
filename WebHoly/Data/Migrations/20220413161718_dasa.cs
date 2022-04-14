using Microsoft.EntityFrameworkCore.Migrations;

namespace WebHoly.Data.Migrations
{
    public partial class dasa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Community",
                table: "RegularSubscription",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "RegularSubscription",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Community",
                table: "HolySubscription",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "HolySubscription",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Community",
                table: "RegularSubscription");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "RegularSubscription");

            migrationBuilder.DropColumn(
                name: "Community",
                table: "HolySubscription");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "HolySubscription");
        }
    }
}
