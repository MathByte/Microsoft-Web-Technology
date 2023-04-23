using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuarterlySales.Models;



namespace QuarterlySales.Components
{
    public class TopQuartersByEmployeeModel
    {
        public int NumberOfQuartersToDisplay { get; set; }
        public List<Sales> NumberOfQuartersIntermsOfSale { get; set; }
    }
}
