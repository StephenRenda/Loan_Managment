using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class LoanModelForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoanBorrowerModel",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    LoanID = table.Column<Guid>(nullable: true),
                    BorrowerID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanBorrowerModel", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LoanBorrowerModel_Borrowers_BorrowerID",
                        column: x => x.BorrowerID,
                        principalTable: "Borrowers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LoanBorrowerModel_Loans_LoanID",
                        column: x => x.LoanID,
                        principalTable: "Loans",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LoanTrusteeModel",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    LoanID = table.Column<Guid>(nullable: true),
                    TrusteeID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanTrusteeModel", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LoanTrusteeModel_Loans_LoanID",
                        column: x => x.LoanID,
                        principalTable: "Loans",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LoanTrusteeModel_Trustees_TrusteeID",
                        column: x => x.TrusteeID,
                        principalTable: "Trustees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoanBorrowerModel_BorrowerID",
                table: "LoanBorrowerModel",
                column: "BorrowerID");

            migrationBuilder.CreateIndex(
                name: "IX_LoanBorrowerModel_LoanID",
                table: "LoanBorrowerModel",
                column: "LoanID");

            migrationBuilder.CreateIndex(
                name: "IX_LoanTrusteeModel_LoanID",
                table: "LoanTrusteeModel",
                column: "LoanID");

            migrationBuilder.CreateIndex(
                name: "IX_LoanTrusteeModel_TrusteeID",
                table: "LoanTrusteeModel",
                column: "TrusteeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoanBorrowerModel");

            migrationBuilder.DropTable(
                name: "LoanTrusteeModel");
        }
    }
}
