using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyLibrary.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangeBookResumeRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resume_Books_Id",
                table: "Resume");

            migrationBuilder.DropColumn(
                name: "LibraryId",
                table: "Books");

            migrationBuilder.AddForeignKey(
                name: "FK_Resume_Books_Id",
                table: "Resume",
                column: "Id",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resume_Books_Id",
                table: "Resume");

            migrationBuilder.AddColumn<long>(
                name: "LibraryId",
                table: "Books",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Resume_Books_Id",
                table: "Resume",
                column: "Id",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
