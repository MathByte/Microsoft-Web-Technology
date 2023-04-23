using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Registration.Models;

namespace Registration.Controllers
{
    public class ValidationController : Controller
    {
        public ValidationController(RegistrationContext registrationContext)
        {
            _registrationContext = registrationContext;
        }

        /// <summary>
        /// This Action, which will be called by the jquery validation code,
        /// will pass the current value of the EmailAddress field and
        /// the action will return a JSON response indicating "true" if the email 
        /// address is not in use (i.e. is available to use) and a message indicating
        /// it's in use if it's already foudn in the DB for a customer.
        /// </summary>
        public IActionResult CheckEmail(string emailAddress)
        {
            string msg = CheckIfEmailExistsInDb(emailAddress);
            if (string.IsNullOrEmpty(msg))
            {
                TempData["okEmail"] = true;
                return Json(true);
            }
            else
            {
                return Json(msg);
            }
        }

        private string CheckIfEmailExistsInDb(string email)
        {
            string msg = "";
            if (!string.IsNullOrEmpty(email))
            {
                var customer = _registrationContext.Customers.Where(c => c.EmailAddress.ToLower() == email.ToLower()).FirstOrDefault();
                if (customer != null)
                    msg = $"The email address \"{email}\" is already in use.";
            }

            return msg;
        }

        private RegistrationContext _registrationContext;
    }
}
