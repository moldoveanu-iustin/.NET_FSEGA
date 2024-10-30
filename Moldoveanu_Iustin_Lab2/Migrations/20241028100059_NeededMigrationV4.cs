using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Moldoveanu_Iustin_Lab2.Migrations
{
    public partial class NeededMigrationV4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Drop the foreign key and old primary key
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Category_CategoryID",
                table: "Book");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookCategory",
                table: "BookCategory");

            migrationBuilder.DropIndex(
                name: "IX_BookCategory_BookID",
                table: "BookCategory");

            migrationBuilder.DropIndex(
                name: "IX_Book_CategoryID",
                table: "Book");

            // Drop the ID column from BookCategory
            migrationBuilder.DropColumn(
                name: "ID",
                table: "BookCategory");

            // Drop the CategoryID column from Book table
            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Book");

            // Add the new composite primary key for BookCategory
            migrationBuilder.AddPrimaryKey(
                name: "PK_BookCategory",
                table: "BookCategory",
                columns: new[] { "BookID", "CategoryID" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Recreate the ID column with Identity
            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "BookCategory",
                type: "int",
                nullable: false)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Book",
                type: "int",
                nullable: true);

            // Recreate the original primary key
            migrationBuilder.AddPrimaryKey(
                name: "PK_BookCategory",
                table: "BookCategory",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_BookCategory_BookID",
                table: "BookCategory",
                column: "BookID");

            migrationBuilder.CreateIndex(
                name: "IX_Book_CategoryID",
                table: "Book",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Category_CategoryID",
                table: "Book",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "ID");
        }
    }
}