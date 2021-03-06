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
    [Migration("20201015004721_Add-Attributes-To-Loan-Data-Seed")]
    partial class AddAttributesToLoanDataSeed
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
                        });
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

                    b.ToTable("Loans");

                    b.HasData(
                        new
                        {
                            ID = new Guid("c0141d0d-1413-4633-9256-98a56e33c0e9"),
                            CreatedOn = new DateTime(2020, 10, 14, 17, 47, 20, 429, DateTimeKind.Local).AddTicks(9747),
                            IntRate = 9f,
                            IntRateLender = 8.5f,
                            IntRateLockDate = new DateTime(2020, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            LastChangedOn = new DateTime(2020, 10, 14, 17, 47, 20, 432, DateTimeKind.Local).AddTicks(4778),
                            LoanNumber = "N1234MW",
                            LoanPoints = 4f,
                            MaturityDate = new DateTime(2021, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
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
                        });
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
