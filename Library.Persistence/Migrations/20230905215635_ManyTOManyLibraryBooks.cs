using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyLibrary.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ManyTOManyLibraryBooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_LibraryBooks_BookId",
                table: "LibraryBooks",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_LibraryBooks_LibraryId",
                table: "LibraryBooks",
                column: "LibraryId");

            migrationBuilder.AddForeignKey(
                name: "FK_LibraryBooks_Books_BookId",
                table: "LibraryBooks",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LibraryBooks_Libraries_LibraryId",
                table: "LibraryBooks",
                column: "LibraryId",
                principalTable: "Libraries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LibraryBooks_Books_BookId",
                table: "LibraryBooks");

            migrationBuilder.DropForeignKey(
                name: "FK_LibraryBooks_Libraries_LibraryId",
                table: "LibraryBooks");

            migrationBuilder.DropIndex(
                name: "IX_LibraryBooks_BookId",
                table: "LibraryBooks");

            migrationBuilder.DropIndex(
                name: "IX_LibraryBooks_LibraryId",
                table: "LibraryBooks");
        }
    }
}
