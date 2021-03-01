using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class RemoveTrusteeIDBorrowerIDFromLoanModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BorrowerID",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "TrusteeID",
                table: "Loans");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BorrowerID",
                table: "Loans",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TrusteeID",
                table: "Loans",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
