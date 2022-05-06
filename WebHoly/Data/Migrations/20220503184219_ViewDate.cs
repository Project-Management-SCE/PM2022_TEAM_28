using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebHoly.Data.Migrations
{
    public partial class ViewDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ViewDate",
                table: "Halachot",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ViewDate",
                table: "Halachot");
        }
    }
}
