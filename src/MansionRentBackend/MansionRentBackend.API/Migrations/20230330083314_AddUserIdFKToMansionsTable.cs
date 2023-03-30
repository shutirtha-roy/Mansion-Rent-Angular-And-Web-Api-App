using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MansionRentBackend.API.Migrations
{
    public partial class AddUserIdFKToMansionsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Mansions",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Mansions_UserId",
                table: "Mansions",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mansions_AspNetUsers_UserId",
                table: "Mansions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mansions_AspNetUsers_UserId",
                table: "Mansions");

            migrationBuilder.DropIndex(
                name: "IX_Mansions_UserId",
                table: "Mansions");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Mansions");
        }
    }
}
