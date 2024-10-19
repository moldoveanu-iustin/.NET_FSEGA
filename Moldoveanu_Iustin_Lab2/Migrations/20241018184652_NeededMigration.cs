using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Moldoveanu_Iustin_Lab2.Migrations
{
    /// <inheritdoc />
    public partial class NeededMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Authors_AuthorsId",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_AuthorsId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "AuthorsId",
                table: "Book");

            migrationBuilder.CreateIndex(
                name: "IX_Book_AuthorID",
                table: "Book",
                column: "AuthorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Authors_AuthorID",
                table: "Book",
                column: "AuthorID",
                principalTable: "Authors",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Authors_AuthorID",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_AuthorID",
                table: "Book");

            migrationBuilder.AddColumn<int>(
                name: "AuthorsId",
                table: "Book",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Book_AuthorsId",
                table: "Book",
                column: "AuthorsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Authors_AuthorsId",
                table: "Book",
                column: "AuthorsId",
                principalTable: "Authors",
                principalColumn: "Id");
        }
    }
}
