using System;
using System.Security.Policy;

namespace InternshipApplication.Models.Domain
{
    public class Student : User
    {
        private String naam;
        private String voornaam;
        private String straat;
        private int straatnummer;
        private String woonplaats;
        private String gmsnummer;
        private String gebdatum;

        public String Naam { get; set; }
        public String Voornaam { get; set; }
        public String Straat { get; set; }
        public int Straatnummer { get; set; }
        public String Woonplaats { get; set; }
        public String Gsmnummer { get; set; }
        public String Gebdatum { get; set; }
       
        public Student()
        {
            
        }

        public Student(String emailadres, String password, String naam, String voornaam, String straat, int straatnummer,
            String woonplaats, String gsmnummer, String gebdatum)
        {
            this.Emailadres = emailadres;
            this.Password = password;
            this.Naam = naam;
            this.Voornaam = voornaam;
            this.Straat = straat;
            this.Woonplaats = woonplaats;
            this.Gsmnummer = gsmnummer;
            this.Gebdatum = gebdatum;
        }
    }
}
