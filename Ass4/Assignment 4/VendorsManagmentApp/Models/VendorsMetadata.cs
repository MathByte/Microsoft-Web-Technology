using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using VendorsManagmentApp.Models.DbGenerated;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace VendorsManagmentApp.Models
{
    public class VendorsMetadata
    {


        [Required(ErrorMessage = "Please enter a VendorName.")]
        [RegularExpression("(?i)^[a-z0-9]+$", ErrorMessage = "Name cannot contain spaces or special characters.")]
        public string VendorName { get; set; }


        [Required(ErrorMessage = "Please enter a VendorAddress1.")]
        public string VendorAddress1 { get; set; }


        public string VendorAddress2 { get; set; }

        [Required(ErrorMessage = "Please enter a VendorCity.")]
        public string VendorCity { get; set; }

        [Required(ErrorMessage = "Please enter a VendorState.")]
        [RegularExpression("^([A-Za-z]{2}|[A-Za-z]{2,})", ErrorMessage = "State either a aname or 2 leter code.")]
        public string VendorState { get; set; }

        [Required(ErrorMessage = "Please enter a VendorZipCode.")]
        [RegularExpression("^[0-9]{5}$", ErrorMessage = "zipcode number should be 5 digit.")]
        public string VendorZipCode { get; set; }

        [Required(ErrorMessage = "Please enter a VendorPhone.")]
        [RegularExpression(@"^\([0-9]{3}\) [0-9]{3}-[0-9]{4}$", ErrorMessage = "Phone number should be 10 digit (999) 999-9999.")]
        [Remote("CheckPhone", "Validation")]
        public string VendorPhone { get; set; }


        public string VendorContactLastName { get; set; }


        public string VendorContactFirstName { get; set; }


        public string VendorContactEmail { get; set; }


        [Required(ErrorMessage = "Please enter a DefaultTerms.")]
        public int DefaultTermsId { get; set; }




        [Required(ErrorMessage = "Please enter a DefaultAccountNumberNavigation.")]
        public int DefaultAccountNumber { get; set; }




        
        public virtual GeneralLedgerAccount DefaultAccountNumberNavigation { get; set; }

 
        public virtual Term DefaultTerms { get; set; }


        public virtual ICollection<Invoice> Invoices { get; set; }


    }
}
