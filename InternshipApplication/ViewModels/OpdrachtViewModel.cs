using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InternshipApplication.ViewModels
{
    public class OpdrachtViewModel
    {
        [Display(Name = "Titel : ")]
        [Required(ErrorMessage = "{0} is verplicht.")]
        [StringLength(50, ErrorMessage = "{0} is te lang.")]
        public String Title { get; set; }
        [Display(Name = "Opdracht omschrijving : ")]
        [Required(ErrorMessage = "{0} is verplicht.")]
        [StringLength(500, ErrorMessage = "{0} is te lang.")]
        public String Omschrijving { get; set; }
        [Display(Name="1ste Semester : ")]
        public Boolean isSemester1 { get; set; }
        [Display(Name="2de Semester : ")]
        public Boolean isSemester2 { get; set; }

    }
}