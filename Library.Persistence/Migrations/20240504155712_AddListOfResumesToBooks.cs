using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyLibrary.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddListOfResumesToBooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resumes_Books_ResumeId",
                table: "Resumes");

            migrationBuilder.AddForeignKey(
                name: "FK_Resumes_Books_ResumeId",
                table: "Resumes",
                column: "ResumeId",
                principalTable: "Books",
                principalColumn: "BookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resumes_Books_ResumeId",
                table: "Resumes");

            migrationBuilder.AddForeignKey(
                name: "FK_Resumes_Books_ResumeId",
                table: "Resumes",
                column: "ResumeId",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
