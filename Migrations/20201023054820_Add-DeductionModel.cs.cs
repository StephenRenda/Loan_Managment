using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class AddDeductionModelcs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Deductions",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Desc = table.Column<string>(nullable: true),
                    RESPA = table.Column<int>(nullable: false),
                    Amount = table.Column<float>(nullable: false),
                    PPF = table.Column<bool>(nullable: false),
                    EST = table.Column<bool>(nullable: false),
                    POE = table.Column<bool>(nullable: false),
                    NET = table.Column<bool>(nullable: false),
                    SEC32 = table.Column<bool>(nullable: false),
                    RE882M = table.Column<string>(nullable: true),
                    Mailto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deductions", x => x.ID);
                });

            migrationBuilder.UpdateData(
                table: "Loans",
                keyColumn: "ID",
                keyValue: new Guid("2e029a23-520e-4555-a3c6-77360bfdd2f9"),
                columns: new[] { "CreatedOn", "LastChangedOn" },
                values: new object[] { new DateTime(2020, 10, 22, 22, 48, 19, 814, DateTimeKind.Local).AddTicks(4859), new DateTime(2020, 10, 22, 22, 48, 19, 814, DateTimeKind.Local).AddTicks(4871) });

            migrationBuilder.UpdateData(
                table: "Loans",
                keyColumn: "ID",
                keyValue: new Guid("c0141d0d-1413-4633-9256-98a56e33c0e9"),
                columns: new[] { "CreatedOn", "LastChangedOn" },
                values: new object[] { new DateTime(2020, 10, 22, 22, 48, 19, 810, DateTimeKind.Local).AddTicks(7996), new DateTime(2020, 10, 22, 22, 48, 19, 814, DateTimeKind.Local).AddTicks(2078) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deductions");

            migrationBuilder.UpdateData(
                table: "Loans",
                keyColumn: "ID",
                keyValue: new Guid("2e029a23-520e-4555-a3c6-77360bfdd2f9"),
                columns: new[] { "CreatedOn", "LastChangedOn" },
                values: new object[] { new DateTime(2020, 10, 20, 15, 18, 57, 395, DateTimeKind.Local).AddTicks(4455), new DateTime(2020, 10, 20, 15, 18, 57, 395, DateTimeKind.Local).AddTicks(4471) });

            migrationBuilder.UpdateData(
                table: "Loans",
                keyColumn: "ID",
                keyValue: new Guid("c0141d0d-1413-4633-9256-98a56e33c0e9"),
                columns: new[] { "CreatedOn", "LastChangedOn" },
                values: new object[] { new DateTime(2020, 10, 20, 15, 18, 57, 392, DateTimeKind.Local).AddTicks(316), new DateTime(2020, 10, 20, 15, 18, 57, 395, DateTimeKind.Local).AddTicks(1177) });
        }
    }
}
