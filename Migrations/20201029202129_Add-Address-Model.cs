using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class AddAddressModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Address1 = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.ID);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.UpdateData(
                table: "Loans",
                keyColumn: "ID",
                keyValue: new Guid("2e029a23-520e-4555-a3c6-77360bfdd2f9"),
                columns: new[] { "CreatedOn", "LastChangedOn" },
                values: new object[] { new DateTime(2020, 10, 23, 17, 35, 6, 666, DateTimeKind.Local).AddTicks(4377), new DateTime(2020, 10, 23, 17, 35, 6, 666, DateTimeKind.Local).AddTicks(4396) });

            migrationBuilder.UpdateData(
                table: "Loans",
                keyColumn: "ID",
                keyValue: new Guid("c0141d0d-1413-4633-9256-98a56e33c0e9"),
                columns: new[] { "CreatedOn", "LastChangedOn" },
                values: new object[] { new DateTime(2020, 10, 23, 17, 35, 6, 663, DateTimeKind.Local).AddTicks(5275), new DateTime(2020, 10, 23, 17, 35, 6, 666, DateTimeKind.Local).AddTicks(1945) });
        }
    }
}
