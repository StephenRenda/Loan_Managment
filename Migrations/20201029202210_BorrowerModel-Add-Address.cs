using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class BorrowerModelAddAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AddressID",
                table: "Borrowers",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Loans",
                keyColumn: "ID",
                keyValue: new Guid("2e029a23-520e-4555-a3c6-77360bfdd2f9"),
                columns: new[] { "CreatedOn", "LastChangedOn" },
                values: new object[] { new DateTime(2020, 10, 29, 13, 22, 9, 918, DateTimeKind.Local).AddTicks(9195), new DateTime(2020, 10, 29, 13, 22, 9, 918, DateTimeKind.Local).AddTicks(9211) });

            migrationBuilder.UpdateData(
                table: "Loans",
                keyColumn: "ID",
                keyValue: new Guid("c0141d0d-1413-4633-9256-98a56e33c0e9"),
                columns: new[] { "CreatedOn", "LastChangedOn" },
                values: new object[] { new DateTime(2020, 10, 29, 13, 22, 9, 916, DateTimeKind.Local).AddTicks(217), new DateTime(2020, 10, 29, 13, 22, 9, 918, DateTimeKind.Local).AddTicks(6678) });

            migrationBuilder.CreateIndex(
                name: "IX_Borrowers_AddressID",
                table: "Borrowers",
                column: "AddressID");

            migrationBuilder.AddForeignKey(
                name: "FK_Borrowers_Addresses_AddressID",
                table: "Borrowers",
                column: "AddressID",
                principalTable: "Addresses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Borrowers_Addresses_AddressID",
                table: "Borrowers");

            migrationBuilder.DropIndex(
                name: "IX_Borrowers_AddressID",
                table: "Borrowers");

            migrationBuilder.DropColumn(
                name: "AddressID",
                table: "Borrowers");

            migrationBuilder.UpdateData(
                table: "Loans",
                keyColumn: "ID",
                keyValue: new Guid("2e029a23-520e-4555-a3c6-77360bfdd2f9"),
                columns: new[] { "CreatedOn", "LastChangedOn" },
                values: new object[] { new DateTime(2020, 10, 29, 13, 21, 29, 40, DateTimeKind.Local).AddTicks(8717), new DateTime(2020, 10, 29, 13, 21, 29, 40, DateTimeKind.Local).AddTicks(8735) });

            migrationBuilder.UpdateData(
                table: "Loans",
                keyColumn: "ID",
                keyValue: new Guid("c0141d0d-1413-4633-9256-98a56e33c0e9"),
                columns: new[] { "CreatedOn", "LastChangedOn" },
                values: new object[] { new DateTime(2020, 10, 29, 13, 21, 29, 37, DateTimeKind.Local).AddTicks(8614), new DateTime(2020, 10, 29, 13, 21, 29, 40, DateTimeKind.Local).AddTicks(6195) });
        }
    }
}
