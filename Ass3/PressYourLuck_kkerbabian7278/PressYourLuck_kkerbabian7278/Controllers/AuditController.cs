using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PressYourLuck.Models;
using PressYourLuck.Helpers;
using Microsoft.EntityFrameworkCore;

namespace PressYourLuck.Controllers
{
    public class AuditController : Controller
    {
        private PULContext _pulContext;

        public AuditController(PULContext pulContext)
        {
            _pulContext = pulContext;
        }

        [HttpGet("/Audit/{sortOrder?}")]
        public IActionResult Index(string sortOrder)
        {
            TempData["switchtogamemode"] = false;

            //calling filter function andreturn the resault back to the view

            List<Audit> savedAudits = _pulContext.Audits.Include(m => m.AuditType).OrderByDescending(m => m.Date).ToList();


            List<Audit> records = filter(sortOrder, savedAudits);
            ViewBag.activate = sortOrder;
            return View(records);
        }


        public List<Audit> filter(string order, List<Audit> records)
        {

            // filter according to the order
            switch (order)
            {
                case "All":
                    {
                  
                        return records;

                    }
                case "Cash In":
                    {
                        List<Audit> recordsAfterSort = new List<Audit>();
                        foreach (Audit item in records)
                            if (item.AuditType.Name == "Cash In")
                                recordsAfterSort.Add(item);
                        return recordsAfterSort;
                    }
                case "Cash Out":
                    {
                        List<Audit> recordsAfterSort = new List<Audit>();
                        foreach (Audit item in records)
                            if (item.AuditType.Name == "Cash Out")
                                recordsAfterSort.Add(item);
                        return recordsAfterSort;
                    }
                case "Lose":
                    {
                        List<Audit> recordsAfterSort = new List<Audit>();
                        foreach (Audit item in records)
                            if (item.AuditType.Name == "Lose")
                                recordsAfterSort.Add(item);
                        return recordsAfterSort;
                    }
                case "Win":
                    {
                        List<Audit> recordsAfterSort = new List<Audit>();
                        foreach (Audit item in records)
                            if (item.AuditType.Name == "Win")
                                recordsAfterSort.Add(item);
                        return recordsAfterSort;
                    }
                default:
                    break;
            }


            List<Audit> temp = new List<Audit>();

            return temp;
        }

    }
}
