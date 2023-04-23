using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendorsManagmentApp.Models.DbGenerated;
using VendorsManagmentApp.Services;

using VendorsManagmentApp.Models;



namespace VendorsManagmentApp.Controllers
{
    public class InvoicesController : Controller
    {


        private apContext _apContext;




        public InvoicesController(apContext apContext)
        {
            _apContext = apContext;
        }




        [HttpGet("/invoices/{vendorID?}")]
        public IActionResult Index(int vendorID)
        {

            TempData["VendorId"] = vendorID;
            TempData["InvoiceId"] = VendorsServices.getFirstInvoiceId(_apContext, vendorID);

            if(Int32.Parse(TempData["InvoiceId"].ToString()) == -1)
            {
                TempData["prevent"] = true;
            }
            else
            {
                TempData["prevent"] = false;
            }
            InvoicesViewModel invm = new InvoicesViewModel();
            invm.vendorId = vendorID;
            invm.invoiceId = Int32.Parse(TempData["InvoiceId"].ToString());
            invm.venderInvoiceselectedItemID = invm.invoiceId;
            invm.VendorInvoiceTerm = VendorsServices.getterms(_apContext, vendorID);
            invm.Vendor_name = VendorsServices.getVendorName(_apContext, vendorID);
            invm.Vendor_address = VendorsServices.getVendoraddress(_apContext, vendorID);

            InvoicesServices.vendorId = vendorID;
            InvoicesServices.invoiceId = Int32.Parse(TempData["InvoiceId"].ToString());
            InvoicesServices.sortOrder = TempData["activeCathegory"].ToString();
            InvoicesServices.sortOrderIndex = TempData["activeCathegoryIndex"].ToString();

            invm.sortOrder = InvoicesServices.sortOrder;
            invm.sortOrderIndex = InvoicesServices.sortOrderIndex;
            invm.VendorInvoiceItems = VendorsServices.getInvoiceItems(_apContext, vendorID);
            invm.VendorInvoiceLineItems = VendorsServices.getLineItemsWithInvoiceId(_apContext, vendorID, Int32.Parse(TempData["InvoiceId"].ToString()));
            invm.ReturnString = "Return to " + TempData["activeCathegory"] + " Vendors";
            InvoicesServices.retuendLink = "Return to " + TempData["activeCathegory"] + " Vendors"; ;
            return View(invm);

        }



        [HttpGet("/invoices/{VendorId?}/{InvoiceId?}")]
        public IActionResult GetLineItems(InvoicesViewModel vv, int VendorId, int InvoiceId)
        {
            TempData["VendorId"] = VendorId;
            TempData["InvoiceId"] = InvoiceId;
            if (Int32.Parse(TempData["InvoiceId"].ToString()) == -1)
            {
                TempData["prevent"] = true;
            }
            else
            {
                TempData["prevent"] = false;
            }
            InvoicesServices.vendorId = VendorId;
            InvoicesServices.invoiceId = InvoiceId;

            InvoicesViewModel invm = new InvoicesViewModel();
            invm.vendorId = VendorId;
            invm.invoiceId = Int32.Parse(TempData["InvoiceId"].ToString());

            invm.VendorInvoiceTerm = VendorsServices.getterms(_apContext, VendorId);
            invm.Vendor_name = "Invoice for " + VendorsServices.getVendorName(_apContext, VendorId) + " Company";
            invm.Vendor_address = VendorsServices.getVendoraddress(_apContext, VendorId);
            invm.sortOrder = InvoicesServices.sortOrder;
            invm.sortOrderIndex = InvoicesServices.sortOrderIndex;
            invm.ReturnString = InvoicesServices.retuendLink;

            invm.venderInvoiceselectedItemID = invm.invoiceId;
            invm.VendorInvoiceItems = VendorsServices.getInvoiceItems(_apContext, VendorId);
            invm.VendorInvoiceLineItems = VendorsServices.getLineItemsWithInvoiceId(_apContext, VendorId, InvoiceId);




            return View("Index", invm);
        }

        [HttpPost()]
        public IActionResult AddLineDes(InvoicesViewModel vv)
        {
            if (vv.description == null)
                vv.description = "0";
            if (vv.amount == null)
                vv.amount = "0";




            TempData["VendorId"] = InvoicesServices.vendorId;
            TempData["InvoiceId"] = InvoicesServices.invoiceId;

            InvoiceLineItem lineItem = new InvoiceLineItem();
            lineItem.Invoice = _apContext.Invoices.Find(InvoicesServices.invoiceId);
            lineItem.InvoiceId = InvoicesServices.invoiceId;
            lineItem.LineItemDescription = vv.description;
            lineItem.LineItemAmount = decimal.Parse(vv.amount);


            _apContext.InvoiceLineItems.Add(lineItem);

            _apContext.SaveChanges();




            InvoicesViewModel invm = new InvoicesViewModel();

            invm.vendorId = InvoicesServices.vendorId;
            invm.invoiceId = Int32.Parse(TempData["InvoiceId"].ToString());

            invm.VendorInvoiceTerm = VendorsServices.getterms(_apContext, InvoicesServices.vendorId);
            invm.Vendor_name = "Invoice for " + VendorsServices.getVendorName(_apContext, InvoicesServices.vendorId) + " Company";
            invm.Vendor_address = VendorsServices.getVendoraddress(_apContext, InvoicesServices.vendorId);
            invm.sortOrder = InvoicesServices.sortOrder;
            invm.sortOrderIndex = InvoicesServices.sortOrderIndex;
            invm.ReturnString = InvoicesServices.retuendLink;

            invm.venderInvoiceselectedItemID = invm.invoiceId;
            invm.VendorInvoiceItems = VendorsServices.getInvoiceItems(_apContext, InvoicesServices.vendorId);
            invm.VendorInvoiceLineItems = VendorsServices.getLineItemsWithInvoiceId(_apContext, InvoicesServices.vendorId, InvoicesServices.invoiceId);
            return View("Index", invm);



        }


    }
}
