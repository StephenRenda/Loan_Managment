using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class LoansAddLoanNumberCreatedOnLastEditedOn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CreatedBy_id",
                table: "Loans",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Loans",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "LastChangedBy_id",
                table: "Loans",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastChangedOn",
                table: "Loans",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LoanNumber",
                table: "Loans",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Loans_CreatedBy_id",
                table: "Loans",
                column: "CreatedBy_id");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_LastChangedBy_id",
                table: "Loans",
                column: "LastChangedBy_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_Users_CreatedBy_id",
                table: "Loans",
                column: "CreatedBy_id",
                principalTable: "Users",
                principalColumn: "_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_Users_LastChangedBy_id",
                table: "Loans",
                column: "LastChangedBy_id",
                principalTable: "Users",
                principalColumn: "_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Users_CreatedBy_id",
                table: "Loans");

            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Users_LastChangedBy_id",
                table: "Loans");

            migrationBuilder.DropIndex(
                name: "IX_Loans_CreatedBy_id",
                table: "Loans");

            migrationBuilder.DropIndex(
                name: "IX_Loans_LastChangedBy_id",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "CreatedBy_id",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "LastChangedBy_id",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "LastChangedOn",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "LoanNumber",
                table: "Loans");
        }
    }
}
