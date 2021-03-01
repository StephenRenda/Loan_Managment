using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class AddMoreSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Borrowers",
                columns: new[] { "ID", "CompanyIsBorrower", "CompanyName", "DOB", "Fname", "Lname", "SSN", "Title" },
                values: new object[] { new Guid("f0860cdf-bed2-47c8-bfee-9f2b92ed81d0"), false, "Really Cool Business Ltd.", new DateTime(1990, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mallory", "Johnson", "098-765-4321", "Miss" });

            migrationBuilder.UpdateData(
                table: "Loans",
                keyColumn: "ID",
                keyValue: new Guid("c0141d0d-1413-4633-9256-98a56e33c0e9"),
                columns: new[] { "CreatedOn", "LastChangedOn" },
                values: new object[] { new DateTime(2020, 10, 20, 15, 18, 57, 392, DateTimeKind.Local).AddTicks(316), new DateTime(2020, 10, 20, 15, 18, 57, 395, DateTimeKind.Local).AddTicks(1177) });

            migrationBuilder.InsertData(
                table: "PhoneNumbers",
                columns: new[] { "PhoneID", "BorrowerModelID", "Phone" },
                values: new object[] { new Guid("1258259e-958a-40c0-ae7f-dc3a0485457d"), null, "916-555-6789" });

            migrationBuilder.InsertData(
                table: "Trustees",
                columns: new[] { "ID", "Fname", "Lname", "Mailto" },
                values: new object[] { new Guid("c928dfd5-328d-4463-bdc9-0b386523a499"), "Miguel", "Sanchez", "999 Main Lane, Sacramento CA, 95819" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "_id", "Email", "HashedPassword", "Name", "Salt", "Username" },
                values: new object[] { new Guid("b282699b-5f9e-475d-85f4-5ef375e6b596"), "bob@test.com", "454E9893822A68491B3B9A77FFD8B52959E45A00", "Bob", "1PMnOU", "bob" });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "ID", "LastEditedBy_id", "LastEditedOn", "NoteText" },
                values: new object[] { new Guid("a18ccee1-05cd-4537-af28-fc79eb7984e4"), new Guid("b282699b-5f9e-475d-85f4-5ef375e6b596"), new DateTime(2020, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), @"This is some test note text.Lorem ipsum dolor sit amet, consectetur adipiscing elit, 
                            sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim vniam, 
                            quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. 
                            Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. 
                            Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum." });

            migrationBuilder.InsertData(
                table: "Loans",
                columns: new[] { "ID", "CompanyName", "CreatedBy_id", "CreatedOn", "IntRate", "IntRateLender", "IntRateLockDate", "LastChangedBy_id", "LastChangedOn", "LoanNumber", "LoanPoints", "MaturityDate", "Name", "NoteID", "PaymentAmortizationPeriod", "PaymentsCollectedInAdvance", "PaymentsPerPeriod", "PrincipalAmt", "RegPaymentAmt", "Stage", "TotalLoanFee", "TotalPaymentsInPeriods" },
                values: new object[] { new Guid("2e029a23-520e-4555-a3c6-77360bfdd2f9"), null, new Guid("b282699b-5f9e-475d-85f4-5ef375e6b596"), new DateTime(2020, 10, 20, 15, 18, 57, 395, DateTimeKind.Local).AddTicks(4455), 9f, 8.5f, new DateTime(2020, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("b282699b-5f9e-475d-85f4-5ef375e6b596"), new DateTime(2020, 10, 20, 15, 18, 57, 395, DateTimeKind.Local).AddTicks(4471), "N5678TB", 4f, new DateTime(2021, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new Guid("a18ccee1-05cd-4537-af28-fc79eb7984e4"), 999, 0, 12, 100000f, 750f, 1, 4000f, 12 });

            migrationBuilder.InsertData(
                table: "LoanBorrowerModel",
                columns: new[] { "ID", "BorrowerID", "LoanID" },
                values: new object[] { new Guid("7c690a00-cd6d-4d4f-b717-65ebf533ad0c"), new Guid("f0860cdf-bed2-47c8-bfee-9f2b92ed81d0"), new Guid("2e029a23-520e-4555-a3c6-77360bfdd2f9") });

            migrationBuilder.InsertData(
                table: "LoanTrusteeModel",
                columns: new[] { "ID", "LoanID", "TrusteeID" },
                values: new object[] { new Guid("6680e123-12dc-4815-b19f-c6f77afcc715"), new Guid("2e029a23-520e-4555-a3c6-77360bfdd2f9"), new Guid("c928dfd5-328d-4463-bdc9-0b386523a499") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LoanBorrowerModel",
                keyColumn: "ID",
                keyValue: new Guid("7c690a00-cd6d-4d4f-b717-65ebf533ad0c"));

            migrationBuilder.DeleteData(
                table: "LoanTrusteeModel",
                keyColumn: "ID",
                keyValue: new Guid("6680e123-12dc-4815-b19f-c6f77afcc715"));

            migrationBuilder.DeleteData(
                table: "PhoneNumbers",
                keyColumn: "PhoneID",
                keyValue: new Guid("1258259e-958a-40c0-ae7f-dc3a0485457d"));

            migrationBuilder.DeleteData(
                table: "Borrowers",
                keyColumn: "ID",
                keyValue: new Guid("f0860cdf-bed2-47c8-bfee-9f2b92ed81d0"));

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "ID",
                keyValue: new Guid("2e029a23-520e-4555-a3c6-77360bfdd2f9"));

            migrationBuilder.DeleteData(
                table: "Trustees",
                keyColumn: "ID",
                keyValue: new Guid("c928dfd5-328d-4463-bdc9-0b386523a499"));

            migrationBuilder.DeleteData(
                table: "Notes",
                keyColumn: "ID",
                keyValue: new Guid("a18ccee1-05cd-4537-af28-fc79eb7984e4"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "_id",
                keyValue: new Guid("b282699b-5f9e-475d-85f4-5ef375e6b596"));

            migrationBuilder.UpdateData(
                table: "Loans",
                keyColumn: "ID",
                keyValue: new Guid("c0141d0d-1413-4633-9256-98a56e33c0e9"),
                columns: new[] { "CreatedOn", "LastChangedOn" },
                values: new object[] { new DateTime(2020, 10, 14, 19, 54, 55, 34, DateTimeKind.Local).AddTicks(377), new DateTime(2020, 10, 14, 19, 54, 55, 36, DateTimeKind.Local).AddTicks(6409) });
        }
    }
}
