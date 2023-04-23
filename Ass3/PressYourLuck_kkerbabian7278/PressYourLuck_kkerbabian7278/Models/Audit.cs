using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PressYourLuck.Models
{
    public class Audit
    {
        [Key]
        public int AuditID { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public int AuditTypeID { get; set; }
        public AuditType AuditType { get; set; }
        public string Ammount { get; set; }
    }
}
