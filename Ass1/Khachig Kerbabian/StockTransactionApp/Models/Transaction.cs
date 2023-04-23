using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace StockTransactionApp.Models
{
    public class Transaction
    {



        /// Part one
  
        public int TransactionId { get; set; }

        [Required(ErrorMessage = "Please Enter TickerSymbol!")]
        public string TickerSymbol { get; set; }

        [Required(ErrorMessage = "Please Enter ConpanyName!")]
        public string CompanyName { get; set; }

        //[Required(ErrorMessage = "Please Enter TransactionType!")]
        //public bool TransactionType { get; set; }

        [Required(ErrorMessage = "Please Enter Quantity!")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0!")]
        public int? Quantity { get; set; }

        [Required(ErrorMessage = "Please Enter SharePrice!")]
        [Range(1, int.MaxValue, ErrorMessage = "SharePrice must be greater than 0!")]
        public double? SharePrice { get; set; }



        //Part two

        [Required(ErrorMessage = "Please Enter TransactionType!")]
        public string TransactionTypeId { get; set; }


        public TransactionType TransactionType { get; set; }




        public double? GrossValue
        {

            get
            {
                if (TransactionType == null)
                    return null;

                if (TransactionType.Name == "Sell")
                    return Quantity * SharePrice;
                else
                    return -1 * Quantity * SharePrice;
            }
        }

        public double? NetValue {
            get
            {
                if (TransactionType == null)
                    return null;
                if (TransactionType.Name == "Sell")
                    return GrossValue  - TransactionType.CommissionFee;
                else
                    return GrossValue  + TransactionType.CommissionFee;


            }
        }


        



    }
}
