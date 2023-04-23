using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendorsManagmentApp.Models;
using VendorsManagmentApp.Models.DbGenerated;
using Microsoft.EntityFrameworkCore;


namespace VendorsManagmentApp.Services
{
    public static class VendorsServices
    {
        private static List<Vendor> _vendorItems = new List<Vendor>();
        public static string[] VendorsDisplayCategories = new string[] { "A - E", "F - K", "L - R", "S - Z" };
        public static int deletedID { get; set; }


        //public VendorsServices()
        //{

        //}


        public static List<Vendor> GetVendorsByCategory(apContext ap, string category)
        {

            List<Vendor> temp = ap.Vendors.OrderBy(n => n.VendorName).ToList();
            List<Vendor> retuened = new List<Vendor>();
            switch (category)
            {
                case "A - E":
                    {
                        for (int i = 0; i < temp.Count; i++)
                            for (char c = 'A'; c <= 'E'; c++)
                            {
                          

                                if (temp[i].VendorName[0] == c || temp[i].VendorName[0] == c + 32)
                                {
                                    retuened.Add(temp[i]);
                                    break;
                                }
                            }



                        break;
                    }
                case "F - K":
                    {
                        for (int i = 0; i < temp.Count; i++)
                            for (char c = 'F'; c <= 'K'; c++)
                                if (temp[i].VendorName[0] == c || temp[i].VendorName[0] == c + 32)
                                {
                                    retuened.Add(temp[i]);
                                    break;
                                }
                        break;
                    }
                case "L - R":
                    {
                        for (int i = 0; i < temp.Count; i++)
                            for (char c = 'L'; c <= 'R'; c++)
                                if (temp[i].VendorName[0] == c || temp[i].VendorName[0] == c + 32)
                                {
                                    retuened.Add(temp[i]);
                                    break;
                                }
                        break;
                    }
                case "S - Z":
                    {
                        for (int i = 0; i < temp.Count; i++)
                            for (char c = 'S'; c <= 'Z'; c++)
                                if (temp[i].VendorName[0] == c || temp[i].VendorName[0] == c + 32)
                                {
                                    retuened.Add(temp[i]);
                                    break;
                                }
                        break;
                    }
                default:
                    break;
            }
            // Filter Vendor items by category, using LINQ (method syntax):
            return retuened;

        }

        public static string getVendoraddress(apContext ap, int id)
        {


            List<Vendor> v = ap.Vendors.Where(n => n.VendorId == id).ToList();


            return v[0].VendorAddress1;
        }



        public static List<InvoiceLineItem> getLineItemsWithInvoiceId(apContext ap, int vendorid, int invoiceId)
        {

            List<Vendor> ventorsList = ap.Vendors.ToList();
            List<InvoiceLineItem> LineItemsList = ap.InvoiceLineItems.ToList();
            List<Invoice> InvoivesList = ap.Invoices.ToList();

            var multiple = from l in LineItemsList
                           join i in InvoivesList on l.InvoiceId equals i.InvoiceId into table1
                           from t1 in table1.DefaultIfEmpty()
                           where t1.VendorId == vendorid
                           where t1.InvoiceId == invoiceId
                           select new InvoiceLineItem() { LineItemDescription = l.LineItemDescription, LineItemAmount = l.LineItemAmount };

            // join vv in ventorsList on t1.VendorId equals vv.VendorId into table2
            //                from cc in table2.DefaultIfEmpty()


            List<InvoiceLineItem> query = multiple.Cast<InvoiceLineItem>().Select(vv => vv).ToList();

            //  List<InvoiceLineItem> v = ap.InvoiceLineItems.Include(m => m.Invoice).Where(w => w.InvoiceId).ThenInclude(q => q.Vendor).Where(s => s.InvoiceId == id).ToList();
            //  List<InvoiceLineItem> rrr = (List<InvoiceLineItem>)multiple;
            //  List<InvoiceLineItem> re = new List<InvoiceLineItem>();
            // re.Add((List<InvoiceLineItem>)multiple);
            return query;
        }

        public static int getFirstInvoiceId(apContext ap, int vendorid)
        {

            List<Vendor> ventorsList = ap.Vendors.ToList();
            List<InvoiceLineItem> LineItemsList = ap.InvoiceLineItems.ToList();
            List<Invoice> InvoivesList = ap.Invoices.ToList();

            var multiple = from l in LineItemsList
                           join i in InvoivesList on l.InvoiceId equals i.InvoiceId into table1
                           from t1 in table1.DefaultIfEmpty()
                           where t1.VendorId == vendorid
                           select new InvoiceLineItem() { LineItemDescription = l.LineItemDescription, LineItemAmount = l.LineItemAmount, InvoiceId = l.InvoiceId };

            List<InvoiceLineItem> query = multiple.Cast<InvoiceLineItem>().Select(vv => vv).ToList();
            if (query.Count() != 0)
                return query[0].InvoiceId;
            else
                return -1;
        }

        public static List<Invoice> getInvoiceItems(apContext ap, int id)
        {


            List<Invoice> InvoivesList = ap.Invoices.ToList();

            var multiple = from i in InvoivesList
                           where i.VendorId == id
                           select new Invoice() { InvoiceId = i.InvoiceId, InvoiceNumber = i.InvoiceNumber };
            /*
                        var multiple = from li in LineItemsList
                                       join i in InvoivesList on li.InvoiceId equals i.InvoiceId into table1
                                       from t1 in table1.DefaultIfEmpty()
                                       select new InvoiceLineItem();
                        List<InvoiceLineItem> query = multiple.Cast<InvoiceLineItem>().Select(vv => vv).ToList();

                        var multiple2 = from m in query
                                        where m.ve == id
                                       select new Invoice() { InvoiceId =  i.InvoiceId, InvoiceLineItems = i };
            */


            // join vv in ventorsList on t1.VendorId equals vv.VendorId into table2
            //                from cc in table2.DefaultIfEmpty()


            List<Invoice> query = multiple.Cast<Invoice>().ToList();

            //  List<InvoiceLineItem> v = ap.InvoiceLineItems.Include(m => m.Invoice).Where(w => w.InvoiceId).ThenInclude(q => q.Vendor).Where(s => s.InvoiceId == id).ToList();
            //  List<InvoiceLineItem> rrr = (List<InvoiceLineItem>)multiple;
            //  List<InvoiceLineItem> re = new List<InvoiceLineItem>();
            // re.Add((List<InvoiceLineItem>)multiple);
            return query;
        }

        public static string getVendorName(apContext ap, int id)
        {


            List<Vendor> v = ap.Vendors.Where(n => n.VendorId == id).ToList();

            return v[0].VendorName;
        }

        public static List<Term> getterms(apContext ap, int id)
        {
            Vendor VendorsList = ap.Vendors.Find(id);
            List<Term> temp = ap.Terms.Where(n => n.TermsId == VendorsList.DefaultTermsId).ToList();


            return temp;
        }


    }
}
