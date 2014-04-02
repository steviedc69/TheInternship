using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNetOpenAuth.OpenId.Extensions.AttributeExchange;
using InternshipApplication.Models;
using InternshipApplication.Models.Domain;
using InternshipApplication.ViewModels;
using WebMatrix.WebData;
using LoginModel = InternshipApplication.ViewModels.LoginModel;

namespace InternshipApplication.Controllers
{
    public class UserController : Controller
    {
        private IBedrijfRepository bedrijfRepository;
        private IStudentRepository studentRepository;
        private IStagebegeleiderRepository stagebegeleiderRepository;
        private IUserRepository userRepository;
        private ISpecialisatieRepository specialisatieRepository;
        private IOpdrachtRepository opdrachtRepository;

        //public UserController(){}

        public UserController(IBedrijfRepository bedrijfR, IStudentRepository studentR,
            IStagebegeleiderRepository stagebegeleiderR, IUserRepository usersRepository,
            ISpecialisatieRepository specialisatie, IOpdrachtRepository opdracht)
        {
            this.bedrijfRepository = bedrijfR;
            this.stagebegeleiderRepository = stagebegeleiderR;
            this.studentRepository = studentR;
            this.userRepository = usersRepository;
            this.specialisatieRepository = specialisatie;
            this.opdrachtRepository = opdracht;
        }

        public ActionResult UserIndex()
        {
            Bedrijf b = bedrijfRepository.FindById(1);
            return View(b);
        }

        public ActionResult ContactPersonen(int id)
        {
            Bedrijf bedrijf = bedrijfRepository.FindById(id);
            ViewBag.bedrijfsId = id;
            if (bedrijf.ContactPersonen == null)
            {
                //voorlopig
                return RedirectToAction("UserIndex");
            }
            
            return View(bedrijf.ContactPersonen);
        }

        public ActionResult UpdateContact(int id, int idC)
        {
            //opvragen van contact
            ContactPersoon contact = bedrijfRepository.FindById(id).ContactPersonen.FirstOrDefault(m => m.Id == idC);


            
            //view teruggeven met een viewmodel van contactpersonen (ContactCreateModel) dat gevuld is met het gekozen contact
            return View("UpdateContact", contact.ConvertToContactCreateModel(id));
        }

        

        [HttpPost]
        public ActionResult UpdateContact(ContactCreateModel model, int id)
        {
            if (ModelState.IsValid)
            {
                //ophalen van bedrijf
                Bedrijf b = bedrijfRepository.FindById(id);
                //ophalen van aan te passen contact in collectie Contactpersonen in bedrijf
                ContactPersoon contact = b.ContactPersonen.FirstOrDefault(m => m.Id == model.id);
                //via extension method updaten van contact
                contact.UpdateContact(model);
                bedrijfRepository.SaveChanges();
                return RedirectToAction("UserIndex");
            }
            return View("UpdateContact", model);
        }


        public ActionResult OpdrachtenView(int id)
        {
            Bedrijf bedrijf = bedrijfRepository.FindById(id);
            if (bedrijf.Opdrachten == null)
            {
                return RedirectToAction("UserIndex");
            }
            return View(bedrijf);
        }

        public ActionResult UserToolbar(int id)
        {
            Bedrijf bedrijf = bedrijfRepository.FindById(id);
            return PartialView(bedrijf);
        }

        public ActionResult OpdrachtenPartial(int bedrijfId, int opdrachtId)
        {
            Opdracht o = opdrachtRepository.FindOpdracht(opdrachtId);
            return PartialView(o);
        }


        public ActionResult AddContact()
        {
            return View(new ContactPersoon().ConvertToContactCreateModel(0));
        }
        // Contact wordt toegevoegd
        [HttpPost]
        public ActionResult AddContact(ContactCreateModel contact, int id)
        {
            if (ModelState.IsValid)
            {
                bedrijfRepository.FindById(id).AddContactPersoon(new ContactPersoon(contact.Naam, contact.Voornaam, contact.Functie, contact.ContactEmail, contact.ContactTelNr, contact.GsmNummer));
                bedrijfRepository.SaveChanges();
                return View("UserIndex", bedrijfRepository.FindById(id));

            }
            return View(contact);
        }

        public ActionResult Delete(int id,int idC)
        {
            ContactPersoon contact = bedrijfRepository.FindById(id).ContactPersonen.First(m=>m.Id == idC);
            return View(new ContactDeleteViewModel(contact.Naam, contact.Voornaam));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int idC, int id)
        {
            
            try
            {
                bedrijfRepository.FindById(id).RemoveContactPersoon(bedrijfRepository.FindById(id).ContactPersonen.FirstOrDefault(m=>m.Id == idC));
                
                bedrijfRepository.SaveChanges();
                return RedirectToAction("UserIndex", bedrijfRepository.FindById(id));
            }
            catch (Exception)
            {
                ContactPersoon contact = bedrijfRepository.FindById(id).ContactPersonen.FirstOrDefault(m => m.Id == idC);
                TempData["Message"] = "Verwijderen brouwer is mislukt";
                return View(new ContactDeleteViewModel(contact.Naam, contact.Voornaam));
            }
        }

        public ActionResult AddOpdracht()
        {
            IEnumerable<Specialisatie> specialisaties;
            specialisaties = specialisatieRepository.FindAllSpecialisaties();
            return View(new CreateOpdrachtViewModel(specialisaties, new OpdrachtViewModel()));
        }

        [HttpPost]
        public ActionResult AddOpdracht([Bind(Prefix = "OpdrachtViewModel")]OpdrachtViewModel model, int id)
        {
            if (ModelState.IsValid)
            {
                Opdracht opdracht = new Opdracht();
                opdracht.Title = model.Title;
                opdracht.Omschrijving = model.Omschrijving;
                if (model.Semesters.Equals("Semester 1"))
                {
                    opdracht.IsSemester1 = true;
                    opdracht.IsSemester2 = false;
                }
                else if (model.Semesters.Equals("Semester 2"))
                {
                    opdracht.IsSemester2 = true;
                    opdracht.IsSemester1 = false;
                }
                else
                {
                    opdracht.IsSemester1 = true;
                    opdracht.IsSemester2 = true;
                }
                opdracht.Specialisatie = specialisatieRepository.FindSpecialisatieNaam(model.Specialisatie);
                bedrijfRepository.FindById(id).AddOpdracht(opdracht);

                bedrijfRepository.SaveChanges();
                return RedirectToAction("UserIndex");
            }
            IEnumerable<Specialisatie> specialisaties;
            specialisaties = specialisatieRepository.FindAllSpecialisaties();
            return View(new CreateOpdrachtViewModel(specialisaties, model));

        }

        /*public ActionResult AddContactPersoon()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddContactPersoon(ContactCreateModel model, int id)
        {
            if (ModelState.IsValid)
            {
                ContactPersoon contact = new ContactPersoon();
                contact.Naam = model.Naam;
                contact.Voornaam = model.Voornaam;
                contact.ContactEmail = model.ContactEmail;
                contact.ContactTelNr = model.ContactTelNr;
                contact.Functie = model.Functie;
                contact.GsmNummer = model.GsmNummer;
                return RedirectToAction("UserIndex");
            }
            return View(model);
        }*/



    }

}

