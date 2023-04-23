﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StockTransactionApp.Models;

namespace StockTransactionApp.Migrations
{
    [DbContext(typeof(TransactionContext))]
    partial class TransactionContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StockTransactionApp.Models.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<double>("SharePrice")
                        .HasColumnType("float");

                    b.Property<string>("TickerSymbol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TransactionTypeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("TransactionId");

                    b.HasIndex("TransactionTypeId");

                    b.ToTable("Transactions");

                    b.HasData(
                        new
                        {
                            TransactionId = 1,
                            CompanyName = "Google",
                            Quantity = 100,
                            SharePrice = 2701.7600000000002,
                            TickerSymbol = "GOOG",
                            TransactionTypeId = "1"
                        },
                        new
                        {
                            TransactionId = 2,
                            CompanyName = "Microsoft",
                            Quantity = 100,
                            SharePrice = 123.45,
                            TickerSymbol = "MSFT",
                            TransactionTypeId = "2"
                        });
                });

            modelBuilder.Entity("StockTransactionApp.Models.TransactionType", b =>
                {
                    b.Property<string>("TransactionTypeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("CommissionFee")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TransactionTypeId");

                    b.ToTable("TransactionTypes");

                    b.HasData(
                        new
                        {
                            TransactionTypeId = "1",
                            CommissionFee = 5.9900000000000002,
                            Name = "Sell"
                        },
                        new
                        {
                            TransactionTypeId = "2",
                            CommissionFee = 5.4000000000000004,
                            Name = "Buy"
                        });
                });

            modelBuilder.Entity("StockTransactionApp.Models.Transaction", b =>
                {
                    b.HasOne("StockTransactionApp.Models.TransactionType", "TransactionType")
                        .WithMany()
                        .HasForeignKey("TransactionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TransactionType");
                });
#pragma warning restore 612, 618
        }
    }
}
