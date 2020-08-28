using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.DAL.Migrations
{
    public partial class parentcategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ParentCategoryID",
                table: "Categories",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentCategoryID",
                table: "Categories",
                column: "ParentCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_ParentCategoryID",
                table: "Categories",
                column: "ParentCategoryID",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_ParentCategoryID",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_ParentCategoryID",
                table: "Categories");

            migrationBuilder.AlterColumn<int>(
                name: "ParentCategoryID",
                table: "Categories",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
