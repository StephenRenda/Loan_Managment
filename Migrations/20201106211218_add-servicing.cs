using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace App.Migrations
{
    public partial class addservicing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BrokerServicingModelID",
                table: "PhoneNumbers",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BrokerServicingModelID1",
                table: "PhoneNumbers",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CostExpenseModelID1",
                table: "Deductions",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CostExpenseModelID2",
                table: "Deductions",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CostExpenseModelID3",
                table: "Deductions",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AddtlServicing",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ServicingAmount = table.Column<float>(nullable: false),
                    ServicingPercent = table.Column<float>(nullable: false),
                    ServicingPer = table.Column<string>(nullable: true),
                    ServicingPayable = table.Column<string>(nullable: true),
                    Assume100Investment = table.Column<bool>(nullable: false),
                    LateChargeSplit = table.Column<float>(nullable: false),
                    PrepaySplit = table.Column<float>(nullable: false),
                    DifferentialOnly = table.Column<bool>(nullable: false),
                    LPDInterestRate = table.Column<float>(nullable: false),
                    AdditionalProvisions = table.Column<string>(nullable: true),
                    BehalfOfAnother = table.Column<bool>(nullable: false),
                    PrincipalAsBorrower = table.Column<bool>(nullable: false),
                    FundingAPortion = table.Column<bool>(nullable: false),
                    MoreThanOneExpl = table.Column<string>(nullable: true),
                    BExplanation = table.Column<string>(nullable: true),
                    BrokerNotAgentRelation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddtlServicing", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "BrokerServicing",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    BrokerCompany = table.Column<string>(nullable: true),
                    BrokerAddressID = table.Column<Guid>(nullable: true),
                    BrokerEmail = table.Column<string>(nullable: true),
                    DRELicense = table.Column<string>(nullable: true),
                    CFLLicense = table.Column<string>(nullable: true),
                    NMLSID = table.Column<string>(nullable: true),
                    BrokerFee = table.Column<float>(nullable: false),
                    AdditionalComp = table.Column<bool>(nullable: false),
                    CompensationAmt = table.Column<float>(nullable: false),
                    BorrowerRepName = table.Column<string>(nullable: true),
                    BorrowerRepDRE = table.Column<string>(nullable: true),
                    BorrowerRepNMLS = table.Column<string>(nullable: true),
                    LenderRepName = table.Column<string>(nullable: true),
                    LenderRepDRE = table.Column<string>(nullable: true),
                    LenderRepNMLS = table.Column<string>(nullable: true),
                    ServicingCompany = table.Column<string>(nullable: true),
                    ServicingAddressID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrokerServicing", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BrokerServicing_Addresses_BrokerAddressID",
                        column: x => x.BrokerAddressID,
                        principalTable: "Addresses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BrokerServicing_Addresses_ServicingAddressID",
                        column: x => x.ServicingAddressID,
                        principalTable: "Addresses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Escrows",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    CompanyCode = table.Column<string>(nullable: true),
                    EscrowCompany = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    EscrowNumber = table.Column<string>(nullable: true),
                    EscrowOfficer = table.Column<string>(nullable: true),
                    PolicyType = table.Column<string>(nullable: true),
                    PolicyAmount = table.Column<float>(nullable: false),
                    PercentLoan = table.Column<float>(nullable: false),
                    SpecialEndorsements = table.Column<string>(nullable: true),
                    ReportDate = table.Column<DateTime>(nullable: false),
                    Exceptions = table.Column<string>(nullable: true),
                    ItemElimination = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Escrows", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FinanceCharges",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    LenderAllocation = table.Column<string>(nullable: true),
                    LenderDesc = table.Column<string>(nullable: true),
                    LenderAllocationAmt = table.Column<float>(nullable: false),
                    LenderLoanDiscFee = table.Column<float>(nullable: false),
                    BrokerAllocation = table.Column<string>(nullable: true),
                    BrokerDesc = table.Column<string>(nullable: true),
                    BrokerAllocationAmt = table.Column<float>(nullable: false),
                    OrigBrokerFee = table.Column<string>(nullable: true),
                    OrigBrokerDesc = table.Column<string>(nullable: true),
                    OrigBrokerFeeAmt = table.Column<float>(nullable: false),
                    GrossPoints = table.Column<string>(nullable: true),
                    GrossPointsDesc = table.Column<string>(nullable: true),
                    GrossPointsAmt = table.Column<float>(nullable: false),
                    AnyAmtPaidNotDeducted = table.Column<bool>(nullable: false),
                    AmtNotDeducted = table.Column<float>(nullable: false),
                    LenderYieldSpread = table.Column<float>(nullable: false),
                    BorrowerYieldSpread = table.Column<float>(nullable: false),
                    TotalCompRetained = table.Column<float>(nullable: false),
                    CreditorForTruth = table.Column<string>(nullable: true),
                    FundedByControlledFunds = table.Column<string>(nullable: false),
                    LifeDisabilityInsIncl = table.Column<bool>(nullable: false),
                    BalloonAmt = table.Column<float>(nullable: false),
                    AmtFinanced = table.Column<float>(nullable: false),
                    AmtFinancedEst = table.Column<bool>(nullable: false),
                    TotalPayments = table.Column<float>(nullable: false),
                    TotalPaymentsEst = table.Column<bool>(nullable: false),
                    AdjustmentsPaidBroker = table.Column<float>(nullable: false),
                    FinanceCharge = table.Column<float>(nullable: false),
                    FinanceChargeEst = table.Column<bool>(nullable: false),
                    AnnPercentRate = table.Column<float>(nullable: false),
                    AnnPercentRateEst = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinanceCharges", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumbers_BrokerServicingModelID",
                table: "PhoneNumbers",
                column: "BrokerServicingModelID");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumbers_BrokerServicingModelID1",
                table: "PhoneNumbers",
                column: "BrokerServicingModelID1");

            migrationBuilder.CreateIndex(
                name: "IX_Deductions_CostExpenseModelID1",
                table: "Deductions",
                column: "CostExpenseModelID1");

            migrationBuilder.CreateIndex(
                name: "IX_Deductions_CostExpenseModelID2",
                table: "Deductions",
                column: "CostExpenseModelID2");

            migrationBuilder.CreateIndex(
                name: "IX_Deductions_CostExpenseModelID3",
                table: "Deductions",
                column: "CostExpenseModelID3");

            migrationBuilder.CreateIndex(
                name: "IX_BrokerServicing_BrokerAddressID",
                table: "BrokerServicing",
                column: "BrokerAddressID");

            migrationBuilder.CreateIndex(
                name: "IX_BrokerServicing_ServicingAddressID",
                table: "BrokerServicing",
                column: "ServicingAddressID");

            migrationBuilder.AddForeignKey(
                name: "FK_Deductions_CostExpenses_CostExpenseModelID1",
                table: "Deductions",
                column: "CostExpenseModelID1",
                principalTable: "CostExpenses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Deductions_CostExpenses_CostExpenseModelID2",
                table: "Deductions",
                column: "CostExpenseModelID2",
                principalTable: "CostExpenses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Deductions_CostExpenses_CostExpenseModelID3",
                table: "Deductions",
                column: "CostExpenseModelID3",
                principalTable: "CostExpenses",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneNumbers_BrokerServicing_BrokerServicingModelID",
                table: "PhoneNumbers",
                column: "BrokerServicingModelID",
                principalTable: "BrokerServicing",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneNumbers_BrokerServicing_BrokerServicingModelID1",
                table: "PhoneNumbers",
                column: "BrokerServicingModelID1",
                principalTable: "BrokerServicing",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deductions_CostExpenses_CostExpenseModelID1",
                table: "Deductions");

            migrationBuilder.DropForeignKey(
                name: "FK_Deductions_CostExpenses_CostExpenseModelID2",
                table: "Deductions");

            migrationBuilder.DropForeignKey(
                name: "FK_Deductions_CostExpenses_CostExpenseModelID3",
                table: "Deductions");

            migrationBuilder.DropForeignKey(
                name: "FK_PhoneNumbers_BrokerServicing_BrokerServicingModelID",
                table: "PhoneNumbers");

            migrationBuilder.DropForeignKey(
                name: "FK_PhoneNumbers_BrokerServicing_BrokerServicingModelID1",
                table: "PhoneNumbers");

            migrationBuilder.DropTable(
                name: "AddtlServicing");

            migrationBuilder.DropTable(
                name: "BrokerServicing");

            migrationBuilder.DropTable(
                name: "Escrows");

            migrationBuilder.DropTable(
                name: "FinanceCharges");

            migrationBuilder.DropIndex(
                name: "IX_PhoneNumbers_BrokerServicingModelID",
                table: "PhoneNumbers");

            migrationBuilder.DropIndex(
                name: "IX_PhoneNumbers_BrokerServicingModelID1",
                table: "PhoneNumbers");

            migrationBuilder.DropIndex(
                name: "IX_Deductions_CostExpenseModelID1",
                table: "Deductions");

            migrationBuilder.DropIndex(
                name: "IX_Deductions_CostExpenseModelID2",
                table: "Deductions");

            migrationBuilder.DropIndex(
                name: "IX_Deductions_CostExpenseModelID3",
                table: "Deductions");

            migrationBuilder.DropColumn(
                name: "BrokerServicingModelID",
                table: "PhoneNumbers");

            migrationBuilder.DropColumn(
                name: "BrokerServicingModelID1",
                table: "PhoneNumbers");

            migrationBuilder.DropColumn(
                name: "CostExpenseModelID1",
                table: "Deductions");

            migrationBuilder.DropColumn(
                name: "CostExpenseModelID2",
                table: "Deductions");

            migrationBuilder.DropColumn(
                name: "CostExpenseModelID3",
                table: "Deductions");
        }
    }
}
