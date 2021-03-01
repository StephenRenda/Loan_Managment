using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class ChangePhoneModeltabletoPhoneNumbers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhoneModel_Borrowers_BorrowerModelID",
                table: "PhoneModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhoneModel",
                table: "PhoneModel");

            migrationBuilder.RenameTable(
                name: "PhoneModel",
                newName: "PhoneNumbers");

            migrationBuilder.RenameIndex(
                name: "IX_PhoneModel_BorrowerModelID",
                table: "PhoneNumbers",
                newName: "IX_PhoneNumbers_BorrowerModelID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhoneNumbers",
                table: "PhoneNumbers",
                column: "PhoneID");

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneNumbers_Borrowers_BorrowerModelID",
                table: "PhoneNumbers",
                column: "BorrowerModelID",
                principalTable: "Borrowers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhoneNumbers_Borrowers_BorrowerModelID",
                table: "PhoneNumbers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PhoneNumbers",
                table: "PhoneNumbers");

            migrationBuilder.RenameTable(
                name: "PhoneNumbers",
                newName: "PhoneModel");

            migrationBuilder.RenameIndex(
                name: "IX_PhoneNumbers_BorrowerModelID",
                table: "PhoneModel",
                newName: "IX_PhoneModel_BorrowerModelID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PhoneModel",
                table: "PhoneModel",
                column: "PhoneID");

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneModel_Borrowers_BorrowerModelID",
                table: "PhoneModel",
                column: "BorrowerModelID",
                principalTable: "Borrowers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
