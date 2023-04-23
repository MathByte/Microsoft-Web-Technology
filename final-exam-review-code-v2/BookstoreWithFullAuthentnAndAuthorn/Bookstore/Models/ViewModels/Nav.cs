using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookstore.Models
{
    public static class Nav
    {
        /// <summary>
        /// A static help method (in a static class) that returns the string "active",
        /// for Bootstarp CSS styling, if the params match, otherwise ""
        /// </summary>
        public static string Active(string value, string current)
        {
            return (value == current) ? "active" : "";
        }
    }
}
