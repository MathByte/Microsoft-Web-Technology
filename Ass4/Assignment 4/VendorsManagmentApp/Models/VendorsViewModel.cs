using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendorsManagmentApp.Models;
using VendorsManagmentApp.Models.DbGenerated;

namespace VendorsManagmentApp.Models
{
    public class VendorsViewModel
    {
        public List<Vendor> VendorsItems { get; set; }

        public string[] VendorsCategories { get; set; }

        public int ActiveCategoryindex { get; set; }
        public string ActiveCategory { get; set; }
    }
}
