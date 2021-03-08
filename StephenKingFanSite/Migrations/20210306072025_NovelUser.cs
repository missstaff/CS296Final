using Microsoft.EntityFrameworkCore.Migrations;

namespace StephenKingFanSite.Migrations
{
    public partial class NovelUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Novels",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Novels_UserId",
                table: "Novels",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Novels_AspNetUsers_UserId",
                table: "Novels",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Novels_AspNetUsers_UserId",
                table: "Novels");

            migrationBuilder.DropIndex(
                name: "IX_Novels_UserId",
                table: "Novels");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Novels");
        }
    }
}
