using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StockTransactionApp.Models
{
    public class TransactionContext : DbContext
    {

        //private data to store all the information from database
        public DbSet<TransactionRecord> TransactionRecords { get; set; }

        public DbSet<TransactionType> TransactionTypes { get; set; }

        public DbSet<Company> Companys { get; set; }

        public TransactionContext(DbContextOptions options)
                : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TransactionRecord>().HasData(
               new TransactionRecord()
               {
                   TransactionId = 1,
                   Quantity = 100,
                   SharePrice = 2701.76,
                   CompanyId = 1,
                   TransactionTypeId = 1
               },

               new TransactionRecord()
               {
                   TransactionId = 2,
                   Quantity = 100,
                   SharePrice = 123.45,
                   CompanyId = 2,
                   TransactionTypeId = 2
               }
               ); 

            modelBuilder.Entity<TransactionType>().HasData(
                new TransactionType()
                {
                    TransactionTypeId = 1,
                    Name = "Sell",
                    CommissionFee = 5.99
                },

                new TransactionType()
                {
                    TransactionTypeId = 2,
                    Name = "Buy",
                    CommissionFee = 5.4
                }
                );


            

            modelBuilder.Entity<Company>().HasData(
               new Company()
               {
                   CompanyId = 1,
                   Name = "Google",
                   Address = "Waterloo",
                   TickerSymbol = "GOOG"

               },

               new Company()
               {
                   CompanyId = 2,
                   Name = "Microsoft",
                   Address = "Kitchener",
                   TickerSymbol = "MSFT"
               }
               );
            
        }
    }
}
