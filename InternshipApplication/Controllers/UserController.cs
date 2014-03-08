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
                b.Password = model.Password;
                bedrijfRepository.Add(b);
                bedrijfRepository.SaveChanges();
                return RedirectToAction("Index", "Home",b);
            }
            return View();
        }


        [HttpPost]
        //[AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            
            if (ModelState.IsValid)
            {
                //is misschien wat ingewikkeld, ma zal voorlopig werken
                User user = userRepository.FindUser(model.Email);
                if (user != null)
                {
                    //hier geraakt hij niet door
                    if (user.Password.Equals(user.sha256_hash(model.Passwd)))
                    {
                        if (user.GetType() == typeof (Bedrijf))
                        {
                            Bedrijf b = bedrijfRepository.FindById(user.Id);
                            return RedirectToAction("Index", "Home", b);
                        }
                        if (user.GetType() == typeof (Stagebegeleider))
                        {
                            Stagebegeleider s = stagebegeleiderRepository.FindById(user.Id);
                            return RedirectToAction("Index", "Home", s);
                        }
                        if (user.GetType() == typeof (Student))
                        {
                            Student s = studentRepository.FindById(user.Id);
                            return RedirectToAction("Index", "Home", s);
                        }

                    }
                }
                else
                {
                    ModelState.AddModelError("", "E-mail en gebruikersnaam komen niet overeen, of registreer u gratis");
                    return View(model);
                }

            }
                
            ModelState.AddModelError("","Velden zijn niet correct");
            return View(model);
   
        }

    }
}
