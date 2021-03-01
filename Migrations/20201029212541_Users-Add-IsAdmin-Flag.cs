using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class UsersAddIsAdminFlag : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Loans",
                keyColumn: "ID",
                keyValue: new Guid("2e029a23-520e-4555-a3c6-77360bfdd2f9"),
                columns: new[] { "CreatedOn", "LastChangedOn" },
                values: new object[] { new DateTime(2020, 10, 29, 14, 25, 40, 286, DateTimeKind.Local).AddTicks(296), new DateTime(2020, 10, 29, 14, 25, 40, 286, DateTimeKind.Local).AddTicks(313) });

            migrationBuilder.UpdateData(
                table: "Loans",
                keyColumn: "ID",
                keyValue: new Guid("c0141d0d-1413-4633-9256-98a56e33c0e9"),
                columns: new[] { "CreatedOn", "LastChangedOn" },
                values: new object[] { new DateTime(2020, 10, 29, 14, 25, 40, 283, DateTimeKind.Local).AddTicks(1682), new DateTime(2020, 10, 29, 14, 25, 40, 285, DateTimeKind.Local).AddTicks(7856) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "_id",
                keyValue: new Guid("2f4cc25d-c51b-4297-85d7-2b540afdde50"),
                column: "IsAdmin",
                value: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "Users");

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
        }
    }
}
