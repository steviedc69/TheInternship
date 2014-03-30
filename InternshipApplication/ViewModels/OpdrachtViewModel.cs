using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNetOpenAuth.OpenId.Extensions.AttributeExchange;
using InternshipApplication.Models.Domain;

namespace InternshipApplication.ViewModels
{
    public class CreateOpdrachtViewModel
    {
        public OpdrachtViewModel OpdrachtViewModel { get; set; }
        public SelectList SpecialisatieList { get; private set; }
        public SelectList SemesterLijst { get; private set; }

        public CreateOpdrachtViewModel(IEnumerable<Specialisatie> specialisaties ,OpdrachtViewModel opdrachtViewModel)
        {
            
            SpecialisatieList = new SelectList(specialisaties);
            List<String> lijstSemester = new List<string>(new String[] {"Semester 1", "Semester 2", "Semester 1 en 2"});
            SemesterLijst = new SelectList(lijstSemester);

            OpdrachtViewModel = OpdrachtViewModel;
        }
    }
    
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
        [Required(ErrorMessage = "Er moet een keuze gemaakt worden.")]
        [Display(Name="Semester : ")]
        public String Semesters { get; set; }
        [Display(Name= "Specialisatie : ")]
        [Required(ErrorMessage = "U moet een specialisatie kiezen.")]
        public Specialisatie Specialisatie { get; set; }
        [Display(Name = "Commentaar van de stagebeheerder : ")]
        public String AdminComment { get; set; }

    }
}