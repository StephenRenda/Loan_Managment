﻿// <auto-generated />
using System;
using App;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace App.Migrations
{
    [DbContext(typeof(LoanAppDbContext))]
    [Migration("20201023061406_Add-CostExpenseModel.cs")]
    partial class AddCostExpenseModelcs
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("App.Models.BorrowerModel", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("CompanyIsBorrower")
                        .HasColumnType("bit");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Fname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SSN")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Borrowers");

                    b.HasData(
                        new
                        {
                            ID = new Guid("608513c1-c9bc-458c-9ed8-641c442d2925"),
                            CompanyIsBorrower = false,
                            CompanyName = "Testing Corp",
                            DOB = new DateTime(1990, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fname = "John",
                            Lname = "Smith",
                            SSN = "123-456-7890",
                            Title = "Sir"
                        },
                        new
                        {
                            ID = new Guid("f0860cdf-bed2-47c8-bfee-9f2b92ed81d0"),
                            CompanyIsBorrower = false,
                            CompanyName = "Really Cool Business Ltd.",
                            DOB = new DateTime(1990, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fname = "Mallory",
                            Lname = "Johnson",
                            SSN = "098-765-4321",
                            Title = "Miss"
                        });
                });

            modelBuilder.Entity("App.Models.CostExpenseModel", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.ToTable("CostExpenses");
                });

            modelBuilder.Entity("App.Models.DeductionModel", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<float>("Amount")
                        .HasColumnType("real");

                    b.Property<Guid?>("CostExpenseModelID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Desc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EST")
                        .HasColumnType("bit");

                    b.Property<bool>("NET")
                        .HasColumnType("bit");

                    b.Property<bool>("POE")
                        .HasColumnType("bit");

                    b.Property<bool>("PPF")
                        .HasColumnType("bit");

                    b.Property<string>("RE882M")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RESPA")
                        .HasColumnType("int");

                    b.Property<bool>("SEC32")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.HasIndex("CostExpenseModelID");

                    b.ToTable("Deductions");
                });

            modelBuilder.Entity("App.Models.LoanBorrowerModel", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BorrowerID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("LoanID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("BorrowerID");

                    b.HasIndex("LoanID");

                    b.ToTable("LoanBorrowerModel");

                    b.HasData(
                        new
                        {
                            ID = new Guid("763c90c9-410f-475d-bba3-f2ce2716db10"),
                            BorrowerID = new Guid("608513c1-c9bc-458c-9ed8-641c442d2925"),
                            LoanID = new Guid("c0141d0d-1413-4633-9256-98a56e33c0e9")
                        },
                        new
                        {
                            ID = new Guid("7c690a00-cd6d-4d4f-b717-65ebf533ad0c"),
                            BorrowerID = new Guid("f0860cdf-bed2-47c8-bfee-9f2b92ed81d0"),
                            LoanID = new Guid("2e029a23-520e-4555-a3c6-77360bfdd2f9")
                        });
                });

            modelBuilder.Entity("App.Models.LoanModel", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CreatedBy_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<float>("IntRate")
                        .HasColumnType("real");

                    b.Property<float>("IntRateLender")
                        .HasColumnType("real");

                    b.Property<DateTime>("IntRateLockDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LastChangedBy_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("LastChangedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("LoanNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("LoanPoints")
                        .HasColumnType("real");

                    b.Property<DateTime>("MaturityDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("NoteID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PaymentAmortizationPeriod")
                        .HasColumnType("int");

                    b.Property<int>("PaymentsCollectedInAdvance")
                        .HasColumnType("int");

                    b.Property<int>("PaymentsPerPeriod")
                        .HasColumnType("int");

                    b.Property<float>("PrincipalAmt")
                        .HasColumnType("real");

                    b.Property<float>("RegPaymentAmt")
                        .HasColumnType("real");

                    b.Property<int>("Stage")
                        .HasColumnType("int");

                    b.Property<float>("TotalLoanFee")
                        .HasColumnType("real");

                    b.Property<int>("TotalPaymentsInPeriods")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CreatedBy_id");

                    b.HasIndex("LastChangedBy_id");

                    b.HasIndex("NoteID");

                    b.ToTable("Loans");

                    b.HasData(
                        new
                        {
                            ID = new Guid("c0141d0d-1413-4633-9256-98a56e33c0e9"),
                            CreatedBy_id = new Guid("2f4cc25d-c51b-4297-85d7-2b540afdde50"),
                            CreatedOn = new DateTime(2020, 10, 22, 23, 14, 6, 80, DateTimeKind.Local).AddTicks(5322),
                            IntRate = 9f,
                            IntRateLender = 8.5f,
                            IntRateLockDate = new DateTime(2020, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastChangedBy_id = new Guid("2f4cc25d-c51b-4297-85d7-2b540afdde50"),
                            LastChangedOn = new DateTime(2020, 10, 22, 23, 14, 6, 83, DateTimeKind.Local).AddTicks(8528),
                            LoanNumber = "N1234MW",
                            LoanPoints = 4f,
                            MaturityDate = new DateTime(2021, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NoteID = new Guid("36ae8212-14f7-4f8a-9314-71a5202e43e6"),
                            PaymentAmortizationPeriod = 999,
                            PaymentsCollectedInAdvance = 0,
                            PaymentsPerPeriod = 12,
                            PrincipalAmt = 100000f,
                            RegPaymentAmt = 750f,
                            Stage = 1,
                            TotalLoanFee = 4000f,
                            TotalPaymentsInPeriods = 12
                        },
                        new
                        {
                            ID = new Guid("2e029a23-520e-4555-a3c6-77360bfdd2f9"),
                            CreatedBy_id = new Guid("b282699b-5f9e-475d-85f4-5ef375e6b596"),
                            CreatedOn = new DateTime(2020, 10, 22, 23, 14, 6, 84, DateTimeKind.Local).AddTicks(1468),
                            IntRate = 9f,
                            IntRateLender = 8.5f,
                            IntRateLockDate = new DateTime(2020, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastChangedBy_id = new Guid("b282699b-5f9e-475d-85f4-5ef375e6b596"),
                            LastChangedOn = new DateTime(2020, 10, 22, 23, 14, 6, 84, DateTimeKind.Local).AddTicks(1480),
                            LoanNumber = "N5678TB",
                            LoanPoints = 4f,
                            MaturityDate = new DateTime(2021, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NoteID = new Guid("a18ccee1-05cd-4537-af28-fc79eb7984e4"),
                            PaymentAmortizationPeriod = 999,
                            PaymentsCollectedInAdvance = 0,
                            PaymentsPerPeriod = 12,
                            PrincipalAmt = 100000f,
                            RegPaymentAmt = 750f,
                            Stage = 1,
                            TotalLoanFee = 4000f,
                            TotalPaymentsInPeriods = 12
                        });
                });

            modelBuilder.Entity("App.Models.LoanTrusteeModel", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("LoanID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("TrusteeID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("LoanID");

                    b.HasIndex("TrusteeID");

                    b.ToTable("LoanTrusteeModel");

                    b.HasData(
                        new
                        {
                            ID = new Guid("d876afca-27d8-4bc6-9b48-5c46a2ae30fa"),
                            LoanID = new Guid("c0141d0d-1413-4633-9256-98a56e33c0e9"),
                            TrusteeID = new Guid("501bc54c-783d-40ef-8d1f-f93cc2c83d05")
                        },
                        new
                        {
                            ID = new Guid("6680e123-12dc-4815-b19f-c6f77afcc715"),
                            LoanID = new Guid("2e029a23-520e-4555-a3c6-77360bfdd2f9"),
                            TrusteeID = new Guid("c928dfd5-328d-4463-bdc9-0b386523a499")
                        });
                });

            modelBuilder.Entity("App.Models.NoteModel", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("LastEditedBy_id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("LastEditedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("NoteText")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("LastEditedBy_id");

                    b.ToTable("Notes");

                    b.HasData(
                        new
                        {
                            ID = new Guid("36ae8212-14f7-4f8a-9314-71a5202e43e6"),
                            LastEditedBy_id = new Guid("2f4cc25d-c51b-4297-85d7-2b540afdde50"),
                            LastEditedOn = new DateTime(2020, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NoteText = @"This is some test note text.Lorem ipsum dolor sit amet, consectetur adipiscing elit, 
                            sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim vniam, 
                            quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. 
                            Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. 
                            Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
                        },
                        new
                        {
                            ID = new Guid("a18ccee1-05cd-4537-af28-fc79eb7984e4"),
                            LastEditedBy_id = new Guid("b282699b-5f9e-475d-85f4-5ef375e6b596"),
                            LastEditedOn = new DateTime(2020, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            NoteText = @"This is some test note text.Lorem ipsum dolor sit amet, consectetur adipiscing elit, 
                            sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim vniam, 
                            quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. 
                            Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. 
                            Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
                        });
                });

            modelBuilder.Entity("App.Models.PhoneModel", b =>
                {
                    b.Property<Guid>("PhoneID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BorrowerModelID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PhoneID");

                    b.HasIndex("BorrowerModelID");

                    b.ToTable("PhoneNumbers");

                    b.HasData(
                        new
                        {
                            PhoneID = new Guid("d3d78c50-824c-400c-8fff-26a002209c01"),
                            Phone = "916-555-5555"
                        },
                        new
                        {
                            PhoneID = new Guid("1258259e-958a-40c0-ae7f-dc3a0485457d"),
                            Phone = "916-555-6789"
                        });
                });

            modelBuilder.Entity("App.Models.TrusteeModel", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Fname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mailto")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Trustees");

                    b.HasData(
                        new
                        {
                            ID = new Guid("501bc54c-783d-40ef-8d1f-f93cc2c83d05"),
                            Fname = "Bob",
                            Lname = "Jones",
                            Mailto = "123 Easy Street, Sacramento CA, 95825"
                        },
                        new
                        {
                            ID = new Guid("c928dfd5-328d-4463-bdc9-0b386523a499"),
                            Fname = "Miguel",
                            Lname = "Sanchez",
                            Mailto = "999 Main Lane, Sacramento CA, 95819"
                        });
                });

            modelBuilder.Entity("App.Models.UserModel", b =>
                {
                    b.Property<Guid>("_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HashedPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("_id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            _id = new Guid("2f4cc25d-c51b-4297-85d7-2b540afdde50"),
                            Email = "alice@test.com",
                            HashedPassword = "454E9893822A68491B3B9A77FFD8B52959E45A00",
                            Name = "Alice",
                            Salt = "1PMnOU",
                            Username = "alice"
                        },
                        new
                        {
                            _id = new Guid("b282699b-5f9e-475d-85f4-5ef375e6b596"),
                            Email = "bob@test.com",
                            HashedPassword = "454E9893822A68491B3B9A77FFD8B52959E45A00",
                            Name = "Bob",
                            Salt = "1PMnOU",
                            Username = "bob"
                        });
                });

            modelBuilder.Entity("App.Models.DeductionModel", b =>
                {
                    b.HasOne("App.Models.CostExpenseModel", null)
                        .WithMany("Deductions")
                        .HasForeignKey("CostExpenseModelID");
                });

            modelBuilder.Entity("App.Models.LoanBorrowerModel", b =>
                {
                    b.HasOne("App.Models.BorrowerModel", "Borrower")
                        .WithMany("LoanBorrowers")
                        .HasForeignKey("BorrowerID");

                    b.HasOne("App.Models.LoanModel", "Loan")
                        .WithMany("LoanBorrowers")
                        .HasForeignKey("LoanID");
                });

            modelBuilder.Entity("App.Models.LoanModel", b =>
                {
                    b.HasOne("App.Models.UserModel", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedBy_id");

                    b.HasOne("App.Models.UserModel", "LastChangedBy")
                        .WithMany()
                        .HasForeignKey("LastChangedBy_id");

                    b.HasOne("App.Models.NoteModel", "Note")
                        .WithMany()
                        .HasForeignKey("NoteID");
                });

            modelBuilder.Entity("App.Models.LoanTrusteeModel", b =>
                {
                    b.HasOne("App.Models.LoanModel", "Loan")
                        .WithMany("LoanTrustees")
                        .HasForeignKey("LoanID");

                    b.HasOne("App.Models.TrusteeModel", "Trustee")
                        .WithMany("LoanTrustees")
                        .HasForeignKey("TrusteeID");
                });

            modelBuilder.Entity("App.Models.NoteModel", b =>
                {
                    b.HasOne("App.Models.UserModel", "LastEditedBy")
                        .WithMany()
                        .HasForeignKey("LastEditedBy_id");
                });

            modelBuilder.Entity("App.Models.PhoneModel", b =>
                {
                    b.HasOne("App.Models.BorrowerModel", null)
                        .WithMany("PhoneNumbers")
                        .HasForeignKey("BorrowerModelID");
                });
#pragma warning restore 612, 618
        }
    }
}
