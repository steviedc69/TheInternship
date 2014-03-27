using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNetOpenAuth.OpenId.Extensions.AttributeExchange;
using InternshipApplication.Models.Domain;

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
        //[Display(Name="1ste Semester : ")]
        //public Boolean isSemester1 { get; set; }
        //[Display(Name="2de Semester : ")]
        //public Boolean isSemester2 { get; set; }
        [Required(ErrorMessage = "Er moet een keuze gemaakt worden.")]
        [Display(Name="Semester : ")]
        public SelectList Semesters
        {
            get { return new SelectList("Semester 1", "Semester 2", "Semester 1 en 2"); }
        }
        [Display(Name= "Specialisatie : ")]
        [Required(ErrorMessage = "U moet een specialisatie kiezen.")]
        public Specialisatie Specialisatie { get; set; }
        [Display(Name = "Commentaar van de stagebeheerder : ")]
        public String AdminComment { get; set; }

    }
}