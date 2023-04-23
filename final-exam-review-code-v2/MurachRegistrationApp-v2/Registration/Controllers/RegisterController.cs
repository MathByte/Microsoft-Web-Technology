using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Registration.Models;

namespace Registration.Controllers
{
    public class RegisterController : Controller
    {
        public RegisterController(RegistrationContext ctx) => _context = ctx;

        [HttpGet()]
        public IActionResult Index() => View();

        [HttpPost()]
        public IActionResult Index(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
                return RedirectToAction("Welcome", "Register");
            }
            else
            {
                // Here we'll add general note indicating the presence of valid errs:
                ModelState.AddModelError("", "There were errors in the form - please fix them and try again.");
                return View(customer);
            }
        }

        [HttpGet()]
        public IActionResult Welcome(Customer customer)
        {
            return View();
        }

        private RegistrationContext _context;
    }
}