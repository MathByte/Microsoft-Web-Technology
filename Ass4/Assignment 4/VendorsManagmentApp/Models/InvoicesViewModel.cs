using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendorsManagmentApp.Models;
using VendorsManagmentApp.Models.DbGenerated;






namespace VendorsManagmentApp.Models
{
    public class InvoicesViewModel
    {
        public string sortOrder { get; set; }
        public string sortOrderIndex { get; set; }
        public int invoiceId { get; set; }
        public int vendorId { get; set; }
        public string amount { get; set; }
        public string description { get; set; }
        public string ReturnString { get; set; }
        public int venderInvoiceselectedItemID { get; set; }
        public List<Term> VendorInvoiceTerm { get; set; }
        public string Vendor_name { get; set; }
        public string Vendor_address { get; set; }
        public List<InvoiceLineItem> VendorInvoiceLineItems { get; set; }
        public List<Invoice> VendorInvoiceItems { get; set; }
    }
}
