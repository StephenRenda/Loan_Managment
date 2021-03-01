using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class AddAttributesToLoanDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Loans",
                keyColumn: "ID",
                keyValue: new Guid("c0141d0d-1413-4633-9256-98a56e33c0e9"),
                columns: new[] { "CreatedOn", "LastChangedOn", "LoanNumber" },
                values: new object[] { new DateTime(2020, 10, 14, 17, 47, 20, 429, DateTimeKind.Local).AddTicks(9747), new DateTime(2020, 10, 14, 17, 47, 20, 432, DateTimeKind.Local).AddTicks(4778), "N1234MW" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Loans",
                keyColumn: "ID",
                keyValue: new Guid("c0141d0d-1413-4633-9256-98a56e33c0e9"),
                columns: new[] { "CreatedOn", "LastChangedOn", "LoanNumber" },
                values: new object[] { new DateTime(2020, 10, 10, 18, 50, 16, 714, DateTimeKind.Local).AddTicks(6198), new DateTime(2020, 10, 10, 18, 50, 16, 717, DateTimeKind.Local).AddTicks(7159), null });
        }
    }
}
