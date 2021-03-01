using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class AddInitialTestData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Borrowers",
                columns: new[] { "ID", "CompanyIsBorrower", "CompanyName", "DOB", "Fname", "Lname", "SSN", "Title" },
                values: new object[] { new Guid("608513c1-c9bc-458c-9ed8-641c442d2925"), false, "Testing Corp", new DateTime(1990, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "Smith", "123-456-7890", "Sir" });

            migrationBuilder.InsertData(
                table: "Loans",
                columns: new[] { "ID", "CompanyName", "CreatedBy_id", "CreatedOn", "IntRate", "IntRateLender", "IntRateLockDate", "LastChangedBy_id", "LastChangedOn", "LoanNumber", "LoanPoints", "MaturityDate", "Name", "PaymentAmortizationPeriod", "PaymentsCollectedInAdvance", "PaymentsPerPeriod", "PrincipalAmt", "RegPaymentAmt", "Stage", "TotalLoanFee", "TotalPaymentsInPeriods" },
                values: new object[] { new Guid("c0141d0d-1413-4633-9256-98a56e33c0e9"), null, null, new DateTime(2020, 10, 10, 18, 50, 16, 714, DateTimeKind.Local).AddTicks(6198), 9f, 8.5f, new DateTime(2020, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 10, 10, 18, 50, 16, 717, DateTimeKind.Local).AddTicks(7159), null, 4f, new DateTime(2021, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 999, 0, 12, 100000f, 750f, 1, 4000f, 12 });

            migrationBuilder.InsertData(
                table: "PhoneNumbers",
                columns: new[] { "PhoneID", "BorrowerModelID", "Phone" },
                values: new object[] { new Guid("d3d78c50-824c-400c-8fff-26a002209c01"), null, "916-555-5555" });

            migrationBuilder.InsertData(
                table: "Trustees",
                columns: new[] { "ID", "Fname", "Lname", "Mailto" },
                values: new object[] { new Guid("501bc54c-783d-40ef-8d1f-f93cc2c83d05"), "Bob", "Jones", "123 Easy Street, Sacramento CA, 95825" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "_id", "Email", "HashedPassword", "Name", "Salt", "Username" },
                values: new object[] { new Guid("2f4cc25d-c51b-4297-85d7-2b540afdde50"), "alice@test.com", "454E9893822A68491B3B9A77FFD8B52959E45A00", "Alice", "1PMnOU", "alice" });

            migrationBuilder.InsertData(
                table: "LoanBorrowerModel",
                columns: new[] { "ID", "BorrowerID", "LoanID" },
                values: new object[] { new Guid("763c90c9-410f-475d-bba3-f2ce2716db10"), new Guid("608513c1-c9bc-458c-9ed8-641c442d2925"), new Guid("c0141d0d-1413-4633-9256-98a56e33c0e9") });

            migrationBuilder.InsertData(
                table: "LoanTrusteeModel",
                columns: new[] { "ID", "LoanID", "TrusteeID" },
                values: new object[] { new Guid("d876afca-27d8-4bc6-9b48-5c46a2ae30fa"), new Guid("c0141d0d-1413-4633-9256-98a56e33c0e9"), new Guid("501bc54c-783d-40ef-8d1f-f93cc2c83d05") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LoanBorrowerModel",
                keyColumn: "ID",
                keyValue: new Guid("763c90c9-410f-475d-bba3-f2ce2716db10"));

            migrationBuilder.DeleteData(
                table: "LoanTrusteeModel",
                keyColumn: "ID",
                keyValue: new Guid("d876afca-27d8-4bc6-9b48-5c46a2ae30fa"));

            migrationBuilder.DeleteData(
                table: "PhoneNumbers",
                keyColumn: "PhoneID",
                keyValue: new Guid("d3d78c50-824c-400c-8fff-26a002209c01"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "_id",
                keyValue: new Guid("2f4cc25d-c51b-4297-85d7-2b540afdde50"));

            migrationBuilder.DeleteData(
                table: "Borrowers",
                keyColumn: "ID",
                keyValue: new Guid("608513c1-c9bc-458c-9ed8-641c442d2925"));

            migrationBuilder.DeleteData(
                table: "Loans",
                keyColumn: "ID",
                keyValue: new Guid("c0141d0d-1413-4633-9256-98a56e33c0e9"));

            migrationBuilder.DeleteData(
                table: "Trustees",
                keyColumn: "ID",
                keyValue: new Guid("501bc54c-783d-40ef-8d1f-f93cc2c83d05"));
        }
    }
}
