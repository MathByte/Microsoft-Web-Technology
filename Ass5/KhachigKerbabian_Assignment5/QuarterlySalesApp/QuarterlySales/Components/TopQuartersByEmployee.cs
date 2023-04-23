using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuarterlySales.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;



namespace QuarterlySales.Components
{
    public class TopQuartersByEmployee : ViewComponent
    {
        public TopQuartersByEmployee(SalesContext salesContext)
        {
            _salesContext = salesContext;
        }

        /// <summary>
        /// Our invoke method uses the 2 params to show at most numberOfMoviesToDisplay movies
        /// in a list of movies whose rating is at least as high as lowestRating
        /// </summary>
        public IViewComponentResult Invoke(int NumberOfQuartersToDisplay)
        {

            var Sales = _salesContext.Sales.Include(m => m.Employee).OrderByDescending(m => m.Amount)
                .ToList().GetRange(0, NumberOfQuartersToDisplay);
 



            var viewModel = new TopQuartersByEmployeeModel()
            {
                NumberOfQuartersToDisplay = NumberOfQuartersToDisplay,
                NumberOfQuartersIntermsOfSale = Sales
            };
            return View(viewModel);

        }

        private SalesContext _salesContext;
    }
}
