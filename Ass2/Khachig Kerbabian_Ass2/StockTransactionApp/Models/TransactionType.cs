using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace StockTransactionApp.Models
{
    public class TransactionType
    {
      
       
        //using [key] dataannotation is used to specify the TransactionTypeId is prmarry key
        [Key]
        public int TransactionTypeId { get; set; }

        [Required(ErrorMessage = "Please Enter Transaction Type Name!")]
        public string? Name { get; set; }


        [Required(ErrorMessage = "Please Enter Transaction Commission Fee!")]
        public double? CommissionFee { get; set; }

     
    }
}
