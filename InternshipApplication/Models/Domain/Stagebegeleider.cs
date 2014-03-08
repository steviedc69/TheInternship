using System;
using System.Security.Policy;

namespace InternshipApplication.Models.Domain
{
    public class Stagebegeleider : User
    {
        private String naam;
        private String voornaam;
        private String gmsnummer;

        public String Naam { get; set; }
        public String Voornaam { get; set; }
        public String Gsmnummer { get; set; }
       
        public Stagebegeleider()
        {
            
        }

        public Stagebegeleider(String emailadres, String password, String naam, String voornaam, String gsmnummer,
            String gebdatum)
        {
            this.Emailadres = emailadres;
            this.Password = password;
            this.Naam = naam;
            this.Voornaam = voornaam;
            this.Gsmnummer = gsmnummer;
        }
    }
}
