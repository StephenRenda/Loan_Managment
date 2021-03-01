using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class UserSplitNameFirstLast : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "FName",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LName",
                table: "Users",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Loans",
                keyColumn: "ID",
                keyValue: new Guid("2e029a23-520e-4555-a3c6-77360bfdd2f9"),
                columns: new[] { "CreatedOn", "LastChangedOn" },
                values: new object[] { new DateTime(2020, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Loans",
                keyColumn: "ID",
                keyValue: new Guid("c0141d0d-1413-4633-9256-98a56e33c0e9"),
                columns: new[] { "CreatedOn", "LastChangedOn" },
                values: new object[] { new DateTime(2020, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "_id",
                keyValue: new Guid("2f4cc25d-c51b-4297-85d7-2b540afdde50"),
                columns: new[] { "FName", "LName" },
                values: new object[] { "Alice", "Wong" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "_id",
                keyValue: new Guid("b282699b-5f9e-475d-85f4-5ef375e6b596"),
                columns: new[] { "FName", "LName" },
                values: new object[] { "Bob", "Robertson" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "LName",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

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
                column: "Name",
                value: "Alice");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "_id",
                keyValue: new Guid("b282699b-5f9e-475d-85f4-5ef375e6b596"),
                column: "Name",
                value: "Bob");
        }
    }
}
