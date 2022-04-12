using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebHoly.Data.Migrations
{
    public partial class data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Halachot",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Contents = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Halachot", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HolySubscription",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Last4Digits = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TokenNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentityNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HolySubscription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HolySubscription_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Mails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SendDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegularSubscription",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    TopicsOfInterest = table.Column<int>(type: "int", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegularSubscription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegularSubscription_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReceptionNumber = table.Column<int>(type: "int", nullable: false),
                    HolySubscriptionId = table.Column<int>(type: "int", nullable: false),
                    Aproved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payment_HolySubscription_HolySubscriptionId",
                        column: x => x.HolySubscriptionId,
                        principalTable: "HolySubscription",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PrayerTimes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShacharitPrayer = table.Column<TimeSpan>(type: "time", nullable: false),
                    InauguralPrayer = table.Column<TimeSpan>(type: "time", nullable: false),
                    MaarivPrayer = table.Column<TimeSpan>(type: "time", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HolySubscriptionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrayerTimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PrayerTimes_HolySubscription_HolySubscriptionId",
                        column: x => x.HolySubscriptionId,
                        principalTable: "HolySubscription",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SoulBoard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfDeathForeign = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfDeathHebrew = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HolySubscriptionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoulBoard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SoulBoard_HolySubscription_HolySubscriptionId",
                        column: x => x.HolySubscriptionId,
                        principalTable: "HolySubscription",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HolySubscription_UserId",
                table: "HolySubscription",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_HolySubscriptionId",
                table: "Payment",
                column: "HolySubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_PrayerTimes_HolySubscriptionId",
                table: "PrayerTimes",
                column: "HolySubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_RegularSubscription_UserId",
                table: "RegularSubscription",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SoulBoard_HolySubscriptionId",
                table: "SoulBoard",
                column: "HolySubscriptionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Halachot");

            migrationBuilder.DropTable(
                name: "Mails");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "PrayerTimes");

            migrationBuilder.DropTable(
                name: "RegularSubscription");

            migrationBuilder.DropTable(
                name: "SoulBoard");

            migrationBuilder.DropTable(
                name: "HolySubscription");
        }
    }
}
