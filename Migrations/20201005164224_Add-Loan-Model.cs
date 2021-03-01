using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class AddLoanModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    BorrowerID = table.Column<int>(nullable: false),
                    TrusteeID = table.Column<int>(nullable: false),
                    CompanyName = table.Column<string>(nullable: true),
                    Stage = table.Column<int>(nullable: false),
                    PrincipalAmt = table.Column<float>(nullable: false),
                    IntRate = table.Column<float>(nullable: false),
                    IntRateLender = table.Column<float>(nullable: false),
                    PaymentsPerPeriod = table.Column<int>(nullable: false),
                    TotalPaymentsInPeriods = table.Column<int>(nullable: false),
                    PaymentsCollectedInAdvance = table.Column<int>(nullable: false),
                    PaymentAmortizationPeriod = table.Column<int>(nullable: false),
                    IntRateLockDate = table.Column<DateTime>(nullable: false),
                    RegPaymentAmt = table.Column<float>(nullable: false),
                    MaturityDate = table.Column<DateTime>(nullable: false),
                    LoanPoints = table.Column<float>(nullable: false),
                    TotalLoanFee = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Loans");
        }
    }
}
