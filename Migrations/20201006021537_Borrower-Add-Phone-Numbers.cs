using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class BorrowerAddPhoneNumbers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PhoneModel",
                columns: table => new
                {
                    PhoneID = table.Column<Guid>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    BorrowerModelID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneModel", x => x.PhoneID);
                    table.ForeignKey(
                        name: "FK_PhoneModel_Borrowers_BorrowerModelID",
                        column: x => x.BorrowerModelID,
                        principalTable: "Borrowers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhoneModel_BorrowerModelID",
                table: "PhoneModel",
                column: "BorrowerModelID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhoneModel");
        }
    }
}
