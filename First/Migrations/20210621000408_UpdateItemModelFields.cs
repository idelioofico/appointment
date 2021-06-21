using Microsoft.EntityFrameworkCore.Migrations;

namespace First.Migrations
{
    public partial class UpdateItemModelFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Items",
                newName: "Lender");

            migrationBuilder.AddColumn<string>(
                name: "Borrower",
                table: "Items",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItemName",
                table: "Items",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Borrower",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ItemName",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "Lender",
                table: "Items",
                newName: "Name");
        }
    }
}
