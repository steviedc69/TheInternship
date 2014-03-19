using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
       
        //public UserController(){}

        public UserController(IBedrijfRepository bedrijfR, IStudentRepository studentR , IStagebegeleiderRepository stagebegeleiderR,IUserRepository usersRepository)
        {
            this.bedrijfRepository = bedrijfR;
            this.stagebegeleiderRepository = stagebegeleiderR;
            this.studentRepository = studentR;
            this.userRepository = usersRepository;
        }
        //
        // GET: /User/
        [AllowAnonymous]
        public ActionResult Login()
        {
            //login pagina moet nog worden aangemaakt
            return View();
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegistratieModel model)
        {
            if (ModelState.IsValid)
            {
                Bedrijf b = new Bedrijf();
                b.Activiteit = model.Activiteit;
                b.Bedrijfsnaam = model.Bedrijfsnaam;
                b.Bereikbaarheid = model.Bereikbaarheid;
                b.Straat = model.Straat;
                b.Straatnummer = model.Straatnummer;
                b.Telefoon = model.Telefoon;
                b.Url = model.Url;
                b.Woonplaats = model.Woonplaats;
                b.Emailadres = model.Email;
                bedrijfRepository.Add(b);
                bedrijfRepository.SaveChanges();
                WebSecurity.CreateAccount(b.Emailadres, model.Password);

                return RedirectToAction("Index", "Home",b);
            }
            return View();
        }


        [HttpPost]
        //[AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
         
           
                User user = userRepository.FindUser(model.Email);
                if (ModelState.IsValid && WebSecurity.Login(model.Email, model.Passwd, persistCookie: model.RememberMe))
                {
                
                }

            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View(model);


            }

   
        }

    }

