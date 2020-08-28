using Microsoft.EntityFrameworkCore.Migrations;

namespace Store.DAL.Migrations
{
    public partial class ContractAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContractId",
                table: "Suppliers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Contract",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    SupplierID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contract", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_ContractId",
                table: "Suppliers",
                column: "ContractId");

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_Contract_ContractId",
                table: "Suppliers",
                column: "ContractId",
                principalTable: "Contract",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_Contract_ContractId",
                table: "Suppliers");

            migrationBuilder.DropTable(
                name: "Contract");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_ContractId",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "ContractId",
                table: "Suppliers");
        }
    }
}
