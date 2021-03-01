using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class FixNoteRenaming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Notes_NoteID",
                table: "Loans");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Users_LastEditedBy_id",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Notes_LastEditedBy_id",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Loans_NoteID",
                table: "Loans");

            migrationBuilder.DeleteData(
                table: "Notes",
                keyColumn: "ID",
                keyValue: new Guid("36ae8212-14f7-4f8a-9314-71a5202e43e6"));

            migrationBuilder.DeleteData(
                table: "Notes",
                keyColumn: "ID",
                keyValue: new Guid("a18ccee1-05cd-4537-af28-fc79eb7984e4"));

            migrationBuilder.DropColumn(
                name: "LastEditedBy_id",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "LastEditedOn",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "NoteText",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "NoteID",
                table: "Loans");

            migrationBuilder.AddColumn<bool>(
                name: "Assumable",
                table: "Notes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<float>(
                name: "BankruptcyAdminFee",
                table: "Notes",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "LateChargeDays",
                table: "Notes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "LateChargeMinimum",
                table: "Notes",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "LateChargePercentage",
                table: "Notes",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<bool>(
                name: "LateFee",
                table: "Notes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<float>(
                name: "MinCharge",
                table: "Notes",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<bool>(
                name: "NoIncomeDocumentation",
                table: "Notes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PrepaymentPenalty",
                table: "Notes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RefundIfPaidOff",
                table: "Notes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<float>(
                name: "ReturnCheckMaxFee",
                table: "Notes",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "ReturnCheckMinFee",
                table: "Notes",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "ReturnCheckPercentage",
                table: "Notes",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<bool>(
                name: "SubjectToMinCharge",
                table: "Notes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "TextNotesID",
                table: "Loans",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Street = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    County = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(nullable: true),
                    Subject = table.Column<bool>(nullable: false),
                    UnincorporatedArea = table.Column<bool>(nullable: false),
                    ConstructionType = table.Column<string>(nullable: true),
                    ConstructionDescription = table.Column<string>(nullable: true),
                    LegalDescription = table.Column<string>(nullable: true),
                    FireInsurancePolicyAmt = table.Column<float>(nullable: true),
                    AnnualInsurancePremiumAmt = table.Column<float>(nullable: true),
                    LossPayableClause = table.Column<string>(nullable: true),
                    FireInsuranceMailingStreet = table.Column<string>(nullable: true),
                    FireInsuranceMailingCity = table.Column<string>(nullable: true),
                    FireInsuranceMailingState = table.Column<string>(nullable: true),
                    FireInsuranceMailingZip = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TextNotes",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    NoteText = table.Column<string>(nullable: true),
                    LastEditedOn = table.Column<DateTime>(nullable: false),
                    LastEditedBy_id = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextNotes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TextNotes_Users_LastEditedBy_id",
                        column: x => x.LastEditedBy_id,
                        principalTable: "Users",
                        principalColumn: "_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "TextNotes",
                columns: new[] { "ID", "LastEditedBy_id", "LastEditedOn", "NoteText" },
                values: new object[] { new Guid("36ae8212-14f7-4f8a-9314-71a5202e43e6"), new Guid("2f4cc25d-c51b-4297-85d7-2b540afdde50"), new DateTime(2020, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), @"This is some test note text.Lorem ipsum dolor sit amet, consectetur adipiscing elit, 
                            sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim vniam, 
                            quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. 
                            Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. 
                            Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum." });

            migrationBuilder.InsertData(
                table: "TextNotes",
                columns: new[] { "ID", "LastEditedBy_id", "LastEditedOn", "NoteText" },
                values: new object[] { new Guid("a18ccee1-05cd-4537-af28-fc79eb7984e4"), new Guid("b282699b-5f9e-475d-85f4-5ef375e6b596"), new DateTime(2020, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), @"This is some test note text.Lorem ipsum dolor sit amet, consectetur adipiscing elit, 
                            sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim vniam, 
                            quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. 
                            Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. 
                            Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum." });

            migrationBuilder.UpdateData(
                table: "Loans",
                keyColumn: "ID",
                keyValue: new Guid("2e029a23-520e-4555-a3c6-77360bfdd2f9"),
                columns: new[] { "CreatedOn", "LastChangedOn", "TextNotesID" },
                values: new object[] { new DateTime(2020, 10, 23, 17, 35, 6, 666, DateTimeKind.Local).AddTicks(4377), new DateTime(2020, 10, 23, 17, 35, 6, 666, DateTimeKind.Local).AddTicks(4396), new Guid("a18ccee1-05cd-4537-af28-fc79eb7984e4") });

            migrationBuilder.UpdateData(
                table: "Loans",
                keyColumn: "ID",
                keyValue: new Guid("c0141d0d-1413-4633-9256-98a56e33c0e9"),
                columns: new[] { "CreatedOn", "LastChangedOn", "TextNotesID" },
                values: new object[] { new DateTime(2020, 10, 23, 17, 35, 6, 663, DateTimeKind.Local).AddTicks(5275), new DateTime(2020, 10, 23, 17, 35, 6, 666, DateTimeKind.Local).AddTicks(1945), new Guid("36ae8212-14f7-4f8a-9314-71a5202e43e6") });

            migrationBuilder.CreateIndex(
                name: "IX_Loans_TextNotesID",
                table: "Loans",
                column: "TextNotesID");

            migrationBuilder.CreateIndex(
                name: "IX_TextNotes_LastEditedBy_id",
                table: "TextNotes",
                column: "LastEditedBy_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_TextNotes_TextNotesID",
                table: "Loans",
                column: "TextNotesID",
                principalTable: "TextNotes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loans_TextNotes_TextNotesID",
                table: "Loans");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "TextNotes");

            migrationBuilder.DropIndex(
                name: "IX_Loans_TextNotesID",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "Assumable",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "BankruptcyAdminFee",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "LateChargeDays",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "LateChargeMinimum",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "LateChargePercentage",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "LateFee",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "MinCharge",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "NoIncomeDocumentation",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "PrepaymentPenalty",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "RefundIfPaidOff",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "ReturnCheckMaxFee",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "ReturnCheckMinFee",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "ReturnCheckPercentage",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "SubjectToMinCharge",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "TextNotesID",
                table: "Loans");

            migrationBuilder.AddColumn<Guid>(
                name: "LastEditedBy_id",
                table: "Notes",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastEditedOn",
                table: "Notes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "NoteText",
                table: "Notes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NoteID",
                table: "Loans",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "ID", "LastEditedBy_id", "LastEditedOn", "NoteText" },
                values: new object[] { new Guid("36ae8212-14f7-4f8a-9314-71a5202e43e6"), new Guid("2f4cc25d-c51b-4297-85d7-2b540afdde50"), new DateTime(2020, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), @"This is some test note text.Lorem ipsum dolor sit amet, consectetur adipiscing elit, 
                            sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim vniam, 
                            quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. 
                            Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. 
                            Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum." });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "ID", "LastEditedBy_id", "LastEditedOn", "NoteText" },
                values: new object[] { new Guid("a18ccee1-05cd-4537-af28-fc79eb7984e4"), new Guid("b282699b-5f9e-475d-85f4-5ef375e6b596"), new DateTime(2020, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), @"This is some test note text.Lorem ipsum dolor sit amet, consectetur adipiscing elit, 
                            sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim vniam, 
                            quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. 
                            Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. 
                            Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum." });

            migrationBuilder.UpdateData(
                table: "Loans",
                keyColumn: "ID",
                keyValue: new Guid("2e029a23-520e-4555-a3c6-77360bfdd2f9"),
                columns: new[] { "CreatedOn", "LastChangedOn", "NoteID" },
                values: new object[] { new DateTime(2020, 10, 22, 23, 14, 6, 84, DateTimeKind.Local).AddTicks(1468), new DateTime(2020, 10, 22, 23, 14, 6, 84, DateTimeKind.Local).AddTicks(1480), new Guid("a18ccee1-05cd-4537-af28-fc79eb7984e4") });

            migrationBuilder.UpdateData(
                table: "Loans",
                keyColumn: "ID",
                keyValue: new Guid("c0141d0d-1413-4633-9256-98a56e33c0e9"),
                columns: new[] { "CreatedOn", "LastChangedOn", "NoteID" },
                values: new object[] { new DateTime(2020, 10, 22, 23, 14, 6, 80, DateTimeKind.Local).AddTicks(5322), new DateTime(2020, 10, 22, 23, 14, 6, 83, DateTimeKind.Local).AddTicks(8528), new Guid("36ae8212-14f7-4f8a-9314-71a5202e43e6") });

            migrationBuilder.CreateIndex(
                name: "IX_Notes_LastEditedBy_id",
                table: "Notes",
                column: "LastEditedBy_id");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_NoteID",
                table: "Loans",
                column: "NoteID");

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_Notes_NoteID",
                table: "Loans",
                column: "NoteID",
                principalTable: "Notes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Users_LastEditedBy_id",
                table: "Notes",
                column: "LastEditedBy_id",
                principalTable: "Users",
                principalColumn: "_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
