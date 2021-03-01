using App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;

namespace App
{
    public class LoanAppDbContext : DbContext
    {
        #region Members
        public DbSet<UserModel> Users { get; set; }
        public DbSet<BorrowerModel> Borrowers { get; set; }
        public DbSet<PhoneModel> PhoneNumbers { get; set; }
        public DbSet<TrusteeModel> Trustees { get; set; }
        public DbSet<LoanModel> Loans { get; set; }
        public DbSet<NotesModel> TextNotes { get; set; }
        public DbSet<NoteModel> Notes { get; set; }
        public DbSet<PropertyModel> Properties { get; set; }
        public DbSet<DeductionModel> Deductions { get; set; }
        public DbSet<CostExpenseModel> CostExpenses { get; set; }
        public DbSet<AddressModel> Addresses { get; set; }
        public DbSet<EscrowModel> Escrows { get; set; }
        public DbSet<BrokerServicingModel> BrokerServicing { get; set; }
        public DbSet<AddtlServicingModel> AddtlServicing { get; set; }  
        public DbSet<FinanceChargeModel> FinanceCharges { get; set; }
        public DbSet<AssignmentModel> Assignments { get; set; }
        #endregion

        #region Constructor
        public LoanAppDbContext(DbContextOptions<LoanAppDbContext> options)
            : base(options)
        {
        }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            UserModel user = new UserModel
            {
                _id = Guid.Parse("2F4CC25D-C51B-4297-85D7-2B540AFDDE50"),
                FName = "Alice",
                LName = "Wong",
                Username = "alice",
                Email = "alice@test.com",
                HashedPassword = "454E9893822A68491B3B9A77FFD8B52959E45A00",
                Salt = "1PMnOU",
                IsAdmin = true
            };

            UserModel user2 = new UserModel
            {
                _id = Guid.Parse("b282699b-5f9e-475d-85f4-5ef375e6b596"),
                FName = "Bob",
                LName = "Robertson",
                Username = "bob",
                Email = "bob@test.com",
                HashedPassword = "454E9893822A68491B3B9A77FFD8B52959E45A00",
                Salt = "1PMnOU",
                IsAdmin = false  
            };

            var textNote = new
            {
                ID = Guid.Parse("36ae8212-14f7-4f8a-9314-71a5202e43e6"),
                NoteText = @"This is some test note text.Lorem ipsum dolor sit amet, consectetur adipiscing elit, 
                            sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim vniam, 
                            quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. 
                            Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. 
                            Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                LastEditedBy_id = user._id,
                LastEditedOn = DateTime.Parse("2020-10-13")
            };

            var textNote2 = new
            {
                ID = Guid.Parse("a18ccee1-05cd-4537-af28-fc79eb7984e4"),
                NoteText = @"This is some test note text.Lorem ipsum dolor sit amet, consectetur adipiscing elit, 
                            sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim vniam, 
                            quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. 
                            Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. 
                            Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                LastEditedBy_id = user2._id,
                LastEditedOn = DateTime.Parse("2020-10-13")
            };

            AddressModel address = new AddressModel
            {
                ID = Guid.Parse("4f375627-00fc-4d3c-8175-fc57c2b14e16"),
                Address1 = "123 Easy Street",
                Address2 = "",
                City = "Sacramento",
                State = "CA",
                Zip = "95819"
            };

            AddressModel address2 = new AddressModel
            {
                ID = Guid.Parse("fcc822ac-55aa-4e12-9dfd-25616caae425"),
                Address1 = "456 North-South-West Street",
                Address2 = "Apt. 57",
                City = "Sacramento",
                State = "CA",
                Zip = "95825"
            };

            AddressModel propertyAddr1 = new AddressModel
            {
                ID = Guid.Parse("8f6c9cf9-7af6-4ebb-a052-f4f97a1957df"),
                Address1 = "1234 Street Lane",
                Address2 = "",
                City = "Sacramento",
                State = "CA",
                Zip = "95817"
            };

            AddressModel propertyAddr2 = new AddressModel
            {
                ID = Guid.Parse("3e32a6a4-7c5d-42b6-afd3-ac482d7352d2"),
                Address1 = "8762 Willow Road",
                Address2 = "",
                City = "Sacramento",
                State = "CA",
                Zip = "95818"
            };

            AddressModel moneyBrokersPO = new AddressModel
            {
                ID = Guid.Parse("4bd597e4-aee4-4130-a4c3-4b312ed48775"),
                Address1 = "P.O. Box 214507",
                Address2 = "",
                City = "Sacramento",
                State = "CA",
                Zip = "95821-0507"
            };

            var borrower = new
            {
                ID = Guid.Parse("608513C1-C9BC-458C-9ED8-641C442D2925"),
                CompanyName = "Testing Corp",
                DOB = DateTime.Parse("1990-10-10"),
                Fname = "John",
                Lname = "Smith",
                SSN = "123-456-7890",
                Title = "Sir",
                CompanyIsBorrower = false,
                AddressID = address.ID
            };

            var borrower2 = new
            {
                ID = Guid.Parse("f0860cdf-bed2-47c8-bfee-9f2b92ed81d0"),
                CompanyName = "Really Cool Business Ltd.",
                DOB = DateTime.Parse("1990-10-10"),
                Fname = "Mallory",
                Lname = "Johnson",
                SSN = "098-765-4321",
                Title = "Miss",
                CompanyIsBorrower = false,
                AddressID = address2.ID
            };

            var phone = new
            {
                PhoneID = Guid.Parse("D3D78C50-824C-400C-8FFF-26A002209C01"),
                Phone = "916-555-5555",
                BorrowerID = borrower.ID
            };

            var phone2 = new
            {
                PhoneID = Guid.Parse("1258259e-958a-40c0-ae7f-dc3a0485457d"),
                Phone = "916-555-6789",
                BorrowerID = borrower2.ID
            };

            PhoneModel moneyBrokersPhone = new PhoneModel
            {
                PhoneID = Guid.Parse("3cfb74a5-6894-4e0f-8819-270576c9750f"),
                Phone = "916-481-9999"
            };

            TrusteeModel trustee = new TrusteeModel
            {
                ID = Guid.Parse("501BC54C-783D-40EF-8D1F-F93CC2C83D05"),
                Fname = "Bob",
                Lname = "Jones",
                Mailto = "123 Easy Street, Sacramento CA, 95825",
            };

            TrusteeModel trustee2 = new TrusteeModel
            {
                ID = Guid.Parse("c928dfd5-328d-4463-bdc9-0b386523a499"),
                Fname = "Miguel",
                Lname = "Sanchez",
                Mailto = "999 Main Lane, Sacramento CA, 95819",
            };

            NoteModel note1 = new NoteModel
            {
                ID = Guid.Parse("db7b4f4e-0949-463e-8032-fc8ab19e8e54"),
                LateFee = true,
                LateChargeDays = 10,
                LateChargeMinimum = 5.00f,
                LateChargePercentage = 10.000f,
                ReturnCheckPercentage = 0.000f,
                ReturnCheckMinFee = 25.00f,
                ReturnCheckMaxFee = 25.00f,
                PrepaymentPenalty = true,
                SubjectToMinCharge = false,
                MinCharge = 0.00f,
                BankruptcyAdminFee = 0.00f,
                RefundIfPaidOff = false,
                Assumable = false,
                NoIncomeDocumentation = true
            };

            NoteModel note2 = new NoteModel
            {
                ID = Guid.Parse("29b6eed3-a0d5-4968-af2d-42f7b5fdcefa"),
                LateFee = true,
                LateChargeDays = 20,
                LateChargeMinimum = 10.00f,
                LateChargePercentage = 20.000f,
                ReturnCheckPercentage = 1.000f,
                ReturnCheckMinFee = 25.00f,
                ReturnCheckMaxFee = 25.00f,
                PrepaymentPenalty = true,
                SubjectToMinCharge = false,
                MinCharge = 0.00f,
                BankruptcyAdminFee = 0.00f,
                RefundIfPaidOff = false,
                Assumable = false,
                NoIncomeDocumentation = true
            };

            AddtlServicingModel addtl1 = new AddtlServicingModel
            {
                ID = Guid.Parse("c4781f88-4562-4503-9916-b8bef6dac97d"),
                ServicingAmount = 10.00f,
                ServicingPercent = 0.000f,
                ServicingPer = "Month",
                ServicingPayable = "Month",
                Assume100Investment = false,
                LateChargeSplit = 0.000f,
                PrepaySplit = 0.000f,
                DifferentialOnly = false,
                LPDInterestRate = 8.500f,
                AdditionalProvisions = "",
                BehalfOfAnother = true,
                PrincipalAsBorrower = false,
                FundingAPortion = false,
                MoreThanOneExpl = "",
                BExplanation = "",
                BrokerNotAgentRelation = ""
            };

            AddtlServicingModel addtl2 = new AddtlServicingModel
            {
                ID = Guid.Parse("c1e3c0b2-3f16-46c9-a871-3df59e016ad8"),
                ServicingAmount = 10.00f,
                ServicingPercent = 0.000f,
                ServicingPer = "Month",
                ServicingPayable = "Month",
                Assume100Investment = false,
                LateChargeSplit = 0.000f,
                PrepaySplit = 0.000f,
                DifferentialOnly = false,
                LPDInterestRate = 8.500f,
                AdditionalProvisions = "",
                BehalfOfAnother = true,
                PrincipalAsBorrower = false,
                FundingAPortion = false,
                MoreThanOneExpl = "",
                BExplanation = "",
                BrokerNotAgentRelation = ""
            };

            var broker1 = new
            {
                ID = Guid.Parse("b5d245b6-3c1e-43fb-8c85-a2ee6fa4edf7"),
                BrokerCompany = "The Money Brokers, Inc.",
                BrokerAddressID = moneyBrokersPO.ID,
                BrokerEmail = "wearebrokers@brokerbroker.com",
                BrokerPhoneID = moneyBrokersPhone.PhoneID,
                DRELicense = "00798745",
                CFLLicense = "",
                NMLSID = "307433",
                BrokerFee = 0.00f,
                AdditionalComp = false,
                CompensationAmt = 0.00f,
                BorrowerRepName = "",
                BorrowerRepDRE = "",
                BorrowerRepNMLS = "",
                LenderRepName = "Melinda D. Wood",
                LenderRepDRE = "01479727",
                LenderRepNMLS = "",
                ServicingAddressID = moneyBrokersPO.ID,
                ServicingPhoneID = moneyBrokersPhone.PhoneID
            };

            var broker2 = new
            {
                ID = Guid.Parse("5a59bc28-69a3-442e-9793-162e67684db8"),
                BrokerCompany = "The Money Brokers, Inc.",
                BrokerAddressID = moneyBrokersPO.ID,
                BrokerEmail = "wearebrokers@brokerbroker.com",
                BrokerPhoneID = moneyBrokersPhone.PhoneID,
                DRELicense = "00798745",
                CFLLicense = "",
                NMLSID = "307433",
                BrokerFee = 0.00f,
                AdditionalComp = false,
                CompensationAmt = 0.00f,
                BorrowerRepName = "",
                BorrowerRepDRE = "",
                BorrowerRepNMLS = "",
                LenderRepName = "Melinda D. Wood",
                LenderRepDRE = "01479727",
                LenderRepNMLS = "",
                ServicingAddressID = moneyBrokersPO.ID,
                ServicingPhoneID = moneyBrokersPhone.PhoneID
            };

            DeductionModel brokerDeduction1 = new DeductionModel
            {
                ID = Guid.Parse("2404938d-f2fa-42fe-bdb1-00d5ed8557ab"),
                Desc = "Notary Fee",
                RESPA = 0,
                Amount = 0.00f,
                PPF = true,
                EST = false,
                POE = false,
                NET = false,
                SEC32 = true,
                RE882M = "Notary Fee"
            };

            DeductionModel brokerDeduction2 = new DeductionModel
            {
                ID = Guid.Parse("287c3762-87a1-468a-9bf8-c833b1464a22"),
                Desc = "Processing Fee",
                RESPA = 810,
                Amount = 500.00f,
                PPF = true,
                EST = false,
                POE = false,
                NET = false,
                SEC32 = true,
                RE882M = "Processing Fee"
            };

            DeductionModel otherDeduction1 = new DeductionModel
            {
                ID = Guid.Parse("ccb11145-5699-4f25-af55-04394e3b741b"),
                Desc = "Appraisal Fee",
                RESPA = 804,
                Amount = 0.00f,
                PPF = false,
                EST = false,
                POE = false,
                NET = true,
                SEC32 = false,
                RE882M = "Appraisal Fee"
            };

            DeductionModel otherDeduction2 = new DeductionModel
            {
                ID = Guid.Parse("52637c14-6aed-4238-8769-cef7f70593c0"),
                Desc = "Recording Fees",
                RESPA = 1201,
                Amount = 0.00f,
                PPF = false,
                EST = false,
                POE = false,
                NET = false,
                SEC32 = false,
                RE882M = "Recording Fees"
            };

            DeductionModel brokerPayment1 = new DeductionModel
            {
                ID = Guid.Parse("0a263bd6-568a-46ae-b9d5-d001b1fa4fd5"),
                Desc = "Home Owner's Insurance Premiums",
                RESPA = 903,
                Amount = 0.00f,
                PPF = false,
                EST = false,
                POE = false,
                NET = false,
                SEC32 = true,
                RE882M = "Hazard"
            };

            DeductionModel brokerPayment2 = new DeductionModel
            {
                ID = Guid.Parse("e4a79270-a964-4b8c-aaca-9624ab7ef479"),
                Desc = "Credit Life or Disability Premiums",
                RESPA = 0,
                Amount = 0.00f,
                PPF = false,
                EST = false,
                POE = false,
                NET = false,
                SEC32 = true,
                RE882M = "Credit Life or Disability Premiums"
            };

            DeductionModel otherPayment1 = new DeductionModel
            {
                ID = Guid.Parse("baa28c91-ff8f-4afe-b229-a88eae5188d8"),
                Desc = "Tax Service Fee",
                RESPA = 809,
                Amount = 67.00f,
                PPF = true,
                EST = false,
                POE = false,
                NET = false,
                SEC32 = true,
                RE882M = "Tax Service Fee"
            };

            DeductionModel otherPayment2 = new DeductionModel
            {
                ID = Guid.Parse("3f90740c-0af0-4c54-9d77-f7c003685f8e"),
                Desc = "Broker Opinion of Value",
                RESPA = 1306,
                Amount = 500.00f,
                PPF = true,
                EST = false,
                POE = false,
                NET = false,
                SEC32 = true,
                RE882M = "Broker Opinion of Value"
            };

            var costExpense1 = new
            {
                ID = Guid.Parse("1a131472-6c0c-43c7-a5ca-73b4f35d16c8"),
                BrokerDeductions1ID = brokerDeduction1.ID,
                BrokerDeductions2ID = brokerDeduction2.ID,
                OtherDeductions1ID = otherDeduction1.ID,
                OtherDeductions2ID = otherDeduction2.ID,
                BrokerPayments1ID = brokerPayment1.ID,
                BrokerPayments2ID = brokerPayment2.ID,
                OtherPayments1ID = otherPayment1.ID,
                OtherPayments2ID = otherPayment2.ID
            };

            var costExpense2 = new
            {
                ID = Guid.Parse("b6582c6a-b9c9-4051-a4db-4d5e9878166d"),
                BrokerDeductions1ID = brokerDeduction1.ID,
                BrokerDeductions2ID = brokerDeduction2.ID,
                OtherDeductions1ID = otherDeduction1.ID,
                OtherDeductions2ID = otherDeduction2.ID,
                BrokerPayments1ID = brokerPayment1.ID,
                BrokerPayments2ID = brokerPayment2.ID,
                OtherPayments1ID = otherPayment1.ID,
                OtherPayments2ID = otherPayment2.ID
            };

            var property1 = new
            {
                ID = Guid.Parse("62c0b988-caa2-4920-a4a8-2e03017486be"),
                Subject = false,
                UnincorporatedArea = false,
                APN = "000-1233-012-0000",
                ConstructionType = "Wood Framed",
                ConstructionDescription = "SFR 2/2/1",
                LegalDescription = "Lot 129, as shown on the \"Plat of Vienna Woods\", recorded in the office of the County Recorder of Sacramento County of July 19, 1946, in Book 23 of Maps, Map No. 47",
                FireInsurancePolicyAmt = 100000.00f,
                AnnualInsurancePremiumAmt = 0.00f,
                LossPayableClause = "The Money Brokers, Inc., a California corporation",
                AddressID = propertyAddr1.ID,
                FireInsuranceAddressID = moneyBrokersPO.ID,
            };

            var property2 = new
            {
                ID = Guid.Parse("1e948fd2-336e-4c5f-8b46-bdaf796828dc"),
                Subject = false,
                UnincorporatedArea = false,
                APN = "000-1233-012-0000",
                ConstructionType = "Wood Framed",
                ConstructionDescription = "SFR 6/4/1",
                LegalDescription = "Lot 49, as shown on the \"Plat of Vienna Woods\", recorded in the office of the County Recorder of Sacramento County of August 29, 1968, in Book 29 of Maps, Map No. 84",
                FireInsurancePolicyAmt = 100000.00f,
                AnnualInsurancePremiumAmt = 0.00f,
                LossPayableClause = "The Money Brokers, Inc., a California corporation",
                AddressID = propertyAddr2.ID,
                FireInsuranceAddressID = moneyBrokersPO.ID,
            };

            EscrowModel escrow = new EscrowModel
            {
                ID = Guid.Parse("5d65e683-d292-4817-901f-837d7226cd3b"),
                CompanyCode = "",
                EscrowCompany = "Stewart Title of Sacramento",
                Address = "3461 Fair Oaks Blvd., Ste 150",
                City = "Sacramento",
                State = "CA",
                ZipCode = "95864",
                Phone = "916-484-6500",
                Fax = "946-482-9391",
                EscrowNumber = "",
                EscrowOfficer = "Kristene Morse",
                PolicyType = "ALTA/CLTA",
                PolicyAmount = 100000.00f,
                PercentLoan = 100.00f,
                SpecialEndorsements = "100 AND 116",
                Exceptions = "",
                ItemElimination = "",
            };

            var loan = new
            {
                ID = Guid.Parse("C0141D0D-1413-4633-9256-98A56E33C0E9"),
                LoanNumber = "N1234MW",
                IntRateLockDate = DateTime.Parse("2020-12-25"),
                PrincipalAmt = 100000.00f,
                IntRate = 9.000f,
                IntRateLender = 8.5000f,
                PaymentsPerPeriod = 12,
                TotalPaymentsInPeriods = 12,
                PaymentsCollectedInAdvance = 0,
                PaymentAmortizationPeriod = 999,
                RegPaymentAmt = 750.00f,
                LoanPoints = 4.00f,
                MaturityDate = DateTime.Parse("2021-12-25"),
                TotalLoanFee = 4000.00f,
                Stage = 1,
                TextNotesID = textNote.ID,
                CreatedBy_id = user._id,
                CreatedOn = DateTime.Parse("2020-10-13"),
                LastChangedOn = DateTime.Parse("2020-10-13"),
                LastChangedBy_id = user._id,
                BorrowerID = borrower.ID,
                BrokerRefID = broker1.ID,
                NoteRefID = note1.ID,
                AddtlRefID = addtl1.ID,
                CostRefID = costExpense1.ID,
                EscrowID = escrow.ID,
                PropertyID = property1.ID,
            };

            var loan2 = new
            {
                ID = Guid.Parse("2e029a23-520e-4555-a3c6-77360bfdd2f9"),
                LoanNumber = "N5678TB",
                IntRateLockDate = DateTime.Parse("2020-12-25"),
                PrincipalAmt = 100000.00f,
                IntRate = 9.000f,
                IntRateLender = 8.5000f,
                PaymentsPerPeriod = 12,
                TotalPaymentsInPeriods = 12,
                PaymentsCollectedInAdvance = 0,
                PaymentAmortizationPeriod = 999,
                RegPaymentAmt = 750.00f,
                LoanPoints = 4.00f,
                MaturityDate = DateTime.Parse("2021-12-25"),
                TotalLoanFee = 4000.00f,
                Stage = 1,
                TextNotesID = textNote2.ID,
                CreatedBy_id = user2._id,
                CreatedOn = DateTime.Parse("2020-10-13"),
                LastChangedOn = DateTime.Parse("2020-10-13"),
                LastChangedBy_id = user2._id,
                BorrowerID = borrower2.ID,
                BrokerRefID = broker2.ID,
                NoteRefID = note2.ID,
                AddtlRefID = addtl2.ID,
                CostRefID = costExpense2.ID,
                EscrowID = escrow.ID,
                PropertyID = property2.ID,
            };

            var loanTrustee = new
            {
                ID = Guid.Parse("D876AFCA-27D8-4BC6-9B48-5C46A2AE30FA"),
                LoanID = loan.ID,
                TrusteeID = trustee.ID
            };

            var loanTrustee2 = new
            {
                ID = Guid.Parse("6680e123-12dc-4815-b19f-c6f77afcc715"),
                LoanID = loan2.ID,
                TrusteeID = trustee2.ID
            };

            modelBuilder.Entity<UserModel>().HasData(new [] { user, user2 });
            modelBuilder.Entity<LoanModel>().HasData(new [] { loan, loan2 });
            modelBuilder.Entity<NotesModel>().HasData(new[] { textNote, textNote2 });
            modelBuilder.Entity<PhoneModel>().HasData(new[] { phone, phone2 });
            modelBuilder.Entity<AddressModel>().HasData(new[] { address, address2, moneyBrokersPO, propertyAddr1, propertyAddr2 });
            modelBuilder.Entity<BorrowerModel>().HasData(new[] { borrower, borrower2 });
            modelBuilder.Entity<TrusteeModel>().HasData(new[] { trustee, trustee2 });
            modelBuilder.Entity<LoanTrusteeModel>().HasData(new[] { loanTrustee, loanTrustee2 });
            modelBuilder.Entity<NoteModel>().HasData(new[] { note1, note2 });
            modelBuilder.Entity<AddtlServicingModel>().HasData(new[] { addtl1, addtl2 });
            modelBuilder.Entity<DeductionModel>().HasData(new[] { brokerDeduction1, brokerDeduction2, otherDeduction1, otherDeduction2, brokerPayment1, brokerPayment2, otherPayment1, otherPayment2 });
            modelBuilder.Entity<CostExpenseModel>().HasData(new[] { costExpense1, costExpense2 });
            modelBuilder.Entity<BrokerServicingModel>().HasData(new[] { broker1, broker2 });
            modelBuilder.Entity<EscrowModel>().HasData(new[] { escrow });
            modelBuilder.Entity<PropertyModel>().HasData(new[] { property1, property2 });
        }
    }
}
