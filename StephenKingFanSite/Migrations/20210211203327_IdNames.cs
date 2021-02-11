using Microsoft.EntityFrameworkCore.Migrations;

namespace StephenKingFanSite.Migrations
{
    public partial class IdNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Replies_ForumPosts_ForumPostID",
                table: "Replies");

            migrationBuilder.RenameColumn(
                name: "ForumPostID",
                table: "Replies",
                newName: "ForumPostPostID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Replies",
                newName: "ReplyID");

            migrationBuilder.RenameIndex(
                name: "IX_Replies_ForumPostID",
                table: "Replies",
                newName: "IX_Replies_ForumPostPostID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "ForumPosts",
                newName: "PostID");

            migrationBuilder.AddForeignKey(
                name: "FK_Replies_ForumPosts_ForumPostPostID",
                table: "Replies",
                column: "ForumPostPostID",
                principalTable: "ForumPosts",
                principalColumn: "PostID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Replies_ForumPosts_ForumPostPostID",
                table: "Replies");

            migrationBuilder.RenameColumn(
                name: "ForumPostPostID",
                table: "Replies",
                newName: "ForumPostID");

            migrationBuilder.RenameColumn(
                name: "ReplyID",
                table: "Replies",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Replies_ForumPostPostID",
                table: "Replies",
                newName: "IX_Replies_ForumPostID");

            migrationBuilder.RenameColumn(
                name: "PostID",
                table: "ForumPosts",
                newName: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Replies_ForumPosts_ForumPostID",
                table: "Replies",
                column: "ForumPostID",
                principalTable: "ForumPosts",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
