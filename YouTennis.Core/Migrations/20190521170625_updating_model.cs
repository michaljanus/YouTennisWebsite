using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YouTennis.Core.Migrations
{
    public partial class updating_model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "OpeningTime",
                table: "OpeningHours",
                nullable: false,
                oldClrType: typeof(TimeSpan));

            migrationBuilder.AlterColumn<int>(
                name: "ClosingTime",
                table: "OpeningHours",
                nullable: false,
                oldClrType: typeof(TimeSpan));

            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CourtId = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true),
                    BookingDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Booking_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Booking_Court_CourtId",
                        column: x => x.CourtId,
                        principalTable: "Court",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Court_ClubId",
                table: "Court",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_ApplicationUserId",
                table: "Booking",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_CourtId",
                table: "Booking",
                column: "CourtId");

            migrationBuilder.AddForeignKey(
                name: "FK_Court_Club_ClubId",
                table: "Court",
                column: "ClubId",
                principalTable: "Club",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Court_Club_ClubId",
                table: "Court");

            migrationBuilder.DropTable(
                name: "Booking");

            migrationBuilder.DropIndex(
                name: "IX_Court_ClubId",
                table: "Court");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "OpeningTime",
                table: "OpeningHours",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "ClosingTime",
                table: "OpeningHours",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
