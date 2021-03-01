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
    [Migration("20201005164224_Add-Loan-Model")]
    partial class AddLoanModel
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
                });

            modelBuilder.Entity("App.Models.LoanModel", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("BorrowerID")
                        .HasColumnType("int");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("IntRate")
                        .HasColumnType("real");

                    b.Property<float>("IntRateLender")
                        .HasColumnType("real");

                    b.Property<DateTime>("IntRateLockDate")
                        .HasColumnType("datetime2");

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

                    b.Property<int>("TrusteeID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Loans");
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
                });
#pragma warning restore 612, 618
        }
    }
}