using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class BorrowerNameSplit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Borrowers");

            migrationBuilder.AddColumn<string>(
                name: "Fname",
                table: "Borrowers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lname",
                table: "Borrowers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fname",
                table: "Borrowers");

            migrationBuilder.DropColumn(
                name: "Lname",
                table: "Borrowers");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Borrowers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
