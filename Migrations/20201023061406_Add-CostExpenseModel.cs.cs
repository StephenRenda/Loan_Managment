using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class AddCostExpenseModelcs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mailto",
                table: "Deductions");

            migrationBuilder.AddColumn<Guid>(
                name: "CostExpenseModelID",
                table: "Deductions",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CostExpenses",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CostExpenses", x => x.ID);
                });

            migrationBuilder.UpdateData(
                table: "Loans",
                keyColumn: "ID",
                keyValue: new Guid("2e029a23-520e-4555-a3c6-77360bfdd2f9"),
                columns: new[] { "CreatedOn", "LastChangedOn" },
                values: new object[] { new DateTime(2020, 10, 22, 23, 14, 6, 84, DateTimeKind.Local).AddTicks(1468), new DateTime(2020, 10, 22, 23, 14, 6, 84, DateTimeKind.Local).AddTicks(1480) });

            migrationBuilder.UpdateData(
                table: "Loans",
                keyColumn: "ID",
                keyValue: new Guid("c0141d0d-1413-4633-9256-98a56e33c0e9"),
                columns: new[] { "CreatedOn", "LastChangedOn" },
                values: new object[] { new DateTime(2020, 10, 22, 23, 14, 6, 80, DateTimeKind.Local).AddTicks(5322), new DateTime(2020, 10, 22, 23, 14, 6, 83, DateTimeKind.Local).AddTicks(8528) });

            migrationBuilder.CreateIndex(
                name: "IX_Deductions_CostExpenseModelID",
                table: "Deductions",
                column: "CostExpenseModelID");

            migrationBuilder.AddForeignKey(
                name: "FK_Deductions_CostExpenses_CostExpenseModelID",
                table: "Deductions",
                column: "CostExpenseModelID",
                principalTable: "CostExpenses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deductions_CostExpenses_CostExpenseModelID",
                table: "Deductions");

            migrationBuilder.DropTable(
                name: "CostExpenses");

            migrationBuilder.DropIndex(
                name: "IX_Deductions_CostExpenseModelID",
                table: "Deductions");

            migrationBuilder.DropColumn(
                name: "CostExpenseModelID",
                table: "Deductions");

            migrationBuilder.AddColumn<string>(
                name: "Mailto",
                table: "Deductions",
                type: "nvarchar(max)",
                nullable: true);

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
    }
}
