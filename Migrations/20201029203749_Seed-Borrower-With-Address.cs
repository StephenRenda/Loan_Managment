using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class SeedBorrowerWithAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "ID", "Address1", "Address2", "City", "State", "Zip" },
                values: new object[,]
                {
                    { new Guid("4f375627-00fc-4d3c-8175-fc57c2b14e16"), "123 Easy Street", "", "Sacramento", "CA", "95819" },
                    { new Guid("fcc822ac-55aa-4e12-9dfd-25616caae425"), "456 North-South-West Street", "Apt. 57", "Sacramento", "CA", "95825" }
                });

            migrationBuilder.UpdateData(
                table: "Loans",
                keyColumn: "ID",
                keyValue: new Guid("2e029a23-520e-4555-a3c6-77360bfdd2f9"),
                columns: new[] { "CreatedOn", "LastChangedOn" },
                values: new object[] { new DateTime(2020, 10, 29, 13, 37, 49, 10, DateTimeKind.Local).AddTicks(3784), new DateTime(2020, 10, 29, 13, 37, 49, 10, DateTimeKind.Local).AddTicks(3800) });

            migrationBuilder.UpdateData(
                table: "Loans",
                keyColumn: "ID",
                keyValue: new Guid("c0141d0d-1413-4633-9256-98a56e33c0e9"),
                columns: new[] { "CreatedOn", "LastChangedOn" },
                values: new object[] { new DateTime(2020, 10, 29, 13, 37, 49, 7, DateTimeKind.Local).AddTicks(4938), new DateTime(2020, 10, 29, 13, 37, 49, 10, DateTimeKind.Local).AddTicks(1247) });

            migrationBuilder.UpdateData(
                table: "Borrowers",
                keyColumn: "ID",
                keyValue: new Guid("608513c1-c9bc-458c-9ed8-641c442d2925"),
                column: "AddressID",
                value: new Guid("4f375627-00fc-4d3c-8175-fc57c2b14e16"));

            migrationBuilder.UpdateData(
                table: "Borrowers",
                keyColumn: "ID",
                keyValue: new Guid("f0860cdf-bed2-47c8-bfee-9f2b92ed81d0"),
                column: "AddressID",
                value: new Guid("fcc822ac-55aa-4e12-9dfd-25616caae425"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "ID",
                keyValue: new Guid("4f375627-00fc-4d3c-8175-fc57c2b14e16"));

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "ID",
                keyValue: new Guid("fcc822ac-55aa-4e12-9dfd-25616caae425"));

            migrationBuilder.UpdateData(
                table: "Borrowers",
                keyColumn: "ID",
                keyValue: new Guid("608513c1-c9bc-458c-9ed8-641c442d2925"),
                column: "AddressID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Borrowers",
                keyColumn: "ID",
                keyValue: new Guid("f0860cdf-bed2-47c8-bfee-9f2b92ed81d0"),
                column: "AddressID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Borrowers",
                keyColumn: "ID",
                keyValue: new Guid("608513c1-c9bc-458c-9ed8-641c442d2925"),
                column: "AddressID",
                value: null);

            migrationBuilder.UpdateData(
                table: "Borrowers",
                keyColumn: "ID",
                keyValue: new Guid("f0860cdf-bed2-47c8-bfee-9f2b92ed81d0"),
                column: "AddressID",
                value: null);

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
        }
    }
}
