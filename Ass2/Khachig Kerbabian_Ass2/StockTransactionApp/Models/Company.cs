using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace StockTransactionApp.Models
{
    public class Company
    {
        //using [key] dataannotation is used to specify the TransactionTypeId is prmarry key
        [Key]
        public int CompanyId { get; set; }

        [Required(ErrorMessage = "Please Enter Conpany Name!")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Please Enter Conpany Address!")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Please Enter TickerSymbol!")]
        public string? TickerSymbol { get; set; }
    }
}
