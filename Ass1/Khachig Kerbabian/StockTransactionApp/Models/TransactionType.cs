using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace StockTransactionApp.Models
{
    public class TransactionType
    {
        /// Part two
       
        // we used string for ID to make it FK in database
        public string TransactionTypeId { get; set; }

        public string Name { get; set; }

        public double CommissionFee { get; set; }

     
    }
}
