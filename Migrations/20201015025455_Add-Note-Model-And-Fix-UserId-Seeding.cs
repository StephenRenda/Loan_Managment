using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class AddNoteModelAndFixUserIdSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "NoteID",
                table: "Loans",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    NoteText = table.Column<string>(nullable: true),
                    LastEditedOn = table.Column<DateTime>(nullable: false),
                    LastEditedBy_id = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Notes_Users_LastEditedBy_id",
                        column: x => x.LastEditedBy_id,
                        principalTable: "Users",
                        principalColumn: "_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "ID", "LastEditedBy_id", "LastEditedOn", "NoteText" },
                values: new object[] { new Guid("36ae8212-14f7-4f8a-9314-71a5202e43e6"), new Guid("2f4cc25d-c51b-4297-85d7-2b540afdde50"), new DateTime(2020, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), @"This is some test note text.Lorem ipsum dolor sit amet, consectetur adipiscing elit, 
                            sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim vniam, 
                            quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. 
                            Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. 
                            Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum." });

            migrationBuilder.UpdateData(
                table: "Loans",
                keyColumn: "ID",
                keyValue: new Guid("c0141d0d-1413-4633-9256-98a56e33c0e9"),
                columns: new[] { "CreatedBy_id", "CreatedOn", "LastChangedBy_id", "LastChangedOn", "NoteID" },
                values: new object[] { new Guid("2f4cc25d-c51b-4297-85d7-2b540afdde50"), new DateTime(2020, 10, 14, 19, 54, 55, 34, DateTimeKind.Local).AddTicks(377), new Guid("2f4cc25d-c51b-4297-85d7-2b540afdde50"), new DateTime(2020, 10, 14, 19, 54, 55, 36, DateTimeKind.Local).AddTicks(6409), new Guid("36ae8212-14f7-4f8a-9314-71a5202e43e6") });

            migrationBuilder.CreateIndex(
                name: "IX_Loans_NoteID",
                table: "Loans",
                column: "NoteID");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_LastEditedBy_id",
                table: "Notes",
                column: "LastEditedBy_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_Notes_NoteID",
                table: "Loans",
                column: "NoteID",
                principalTable: "Notes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Notes_NoteID",
                table: "Loans");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Loans_NoteID",
                table: "Loans");

            migrationBuilder.DropColumn(
                name: "NoteID",
                table: "Loans");

            migrationBuilder.UpdateData(
                table: "Loans",
                keyColumn: "ID",
                keyValue: new Guid("c0141d0d-1413-4633-9256-98a56e33c0e9"),
                columns: new[] { "CreatedBy_id", "CreatedOn", "LastChangedBy_id", "LastChangedOn" },
                values: new object[] { null, new DateTime(2020, 10, 14, 17, 47, 20, 429, DateTimeKind.Local).AddTicks(9747), null, new DateTime(2020, 10, 14, 17, 47, 20, 432, DateTimeKind.Local).AddTicks(4778) });
        }
    }
}
