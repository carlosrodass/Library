using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Library.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddingEnumData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ResumeTypeId",
                table: "Resumes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Libraries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ResumeTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumeTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ResumeTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Chapter" },
                    { 2, "Full" }
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Private" },
                    { 2, "Public" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Resumes_ResumeTypeId",
                table: "Resumes",
                column: "ResumeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Libraries_StatusId",
                table: "Libraries",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_StatusId",
                table: "Books",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Status_StatusId",
                table: "Books",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Libraries_Status_StatusId",
                table: "Libraries",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Resumes_ResumeTypes_ResumeTypeId",
                table: "Resumes",
                column: "ResumeTypeId",
                principalTable: "ResumeTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Status_StatusId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "FK_Libraries_Status_StatusId",
                table: "Libraries");

            migrationBuilder.DropForeignKey(
                name: "FK_Resumes_ResumeTypes_ResumeTypeId",
                table: "Resumes");

            migrationBuilder.DropTable(
                name: "ResumeTypes");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropIndex(
                name: "IX_Resumes_ResumeTypeId",
                table: "Resumes");

            migrationBuilder.DropIndex(
                name: "IX_Libraries_StatusId",
                table: "Libraries");

            migrationBuilder.DropIndex(
                name: "IX_Books_StatusId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "ResumeTypeId",
                table: "Resumes");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Libraries");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Books");
        }
    }
}
