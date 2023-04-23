using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace PressYourLuck.Models
{
    public class Player
    {
        [Required(ErrorMessage = "Please Enter your Name!")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Please Enter Total Coins!")]
        [Range(1, 10000, ErrorMessage = "Coins must in between 1.00 to 10000.00!")]
        public string? TotalCoins { get; set; }

     
    }
}
