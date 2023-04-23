using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace StockTransactionApp.Models
{
    public class TransactionContext : DbContext
    {
        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<TransactionType> TransactionTypes { get; set; }


        public TransactionContext(DbContextOptions options)
                : base(options)
        {

        }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<TransactionType>().HasData(
                new TransactionType()
                {
                    TransactionTypeId = "1",
                    Name = "Sell",
                    CommissionFee = 5.99
                    
                },
                new TransactionType()
                {
                    TransactionTypeId = "2",
                    Name = "Buy",
                    CommissionFee = 5.4
                  
                }
                );
            

            modelBuilder.Entity<Transaction>().HasData(
                new Transaction()
                {
                    TransactionId = 1,
                    CompanyName = "Google",
                    TickerSymbol = "GOOG",
                    SharePrice = 2701.76,
                    Quantity = 100,
                    TransactionTypeId = "1"

                },
                new Transaction()
                {
                    TransactionId = 2,
                    CompanyName = "Microsoft",
                    TickerSymbol = "MSFT",
                    SharePrice = 123.45,
                    Quantity = 100,
                    TransactionTypeId = "2"

                }


                );

        }
    }
}
