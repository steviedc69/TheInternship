using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InternshipApplication.ViewModels
{
    public class LoginModel
    {
   
        [Required(ErrorMessage = "{0} is verplicht")]
        [Display(Name = "Gebruikersnaam (E-mailadres) : ")]
        public String Email { get; set; }
        [Required(ErrorMessage = "{0} is verplicht")]
        [Display(Name = "Paswoord : ")]
        public String Passwd { get; set; }
    }
}