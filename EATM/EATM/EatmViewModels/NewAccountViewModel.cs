using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EATM.EatmViewModels
{
    public class NewAccountViewModel
    {
        [Required(ErrorMessage = "Please enter a card number")]
        [Remote("IsAlreadySigned", "Eatm")]
        public int CardNumber { get; set; }

        [Required(ErrorMessage = "Please enter a pin number")]
        [DataType(DataType.Password)]
        public int PinNumber { get; set; }

        [Required(ErrorMessage = "Please confirm your pin number")]
        [DataType(DataType.Password)]
        [System.Web.Mvc.Compare("PinNumber", ErrorMessage = "The pin number and confirmation pin number do not match.")]
        public int ConfirmPinNumber { get; set; }

        [Required(ErrorMessage = "Please enter a balance")]      
        public int Balance { get; set; }         
    }
}