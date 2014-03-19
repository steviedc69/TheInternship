using System;
using System.Security.Policy;

namespace InternshipApplication.Models.Domain
{
    public class Student : User
    {


        public String Naam { get; set; }
        public String Voornaam { get; set; }
        public String Straat { get; set; }
        public int Straatnummer { get; set; }
        public String Woonplaats { get; set; }
        public int Postcode { get; set; }
        public String Gsmnummer { get; set; }
        public String Gebdatum { get; set; }
       
        public Student()
        {
            
        }

        public Student(String emailadres, String naam, String voornaam, String straat, int straatnummer,
            String woonplaats,int postcode ,String gsmnummer, String gebdatum)
        {
            this.Emailadres = emailadres;
            this.Naam = naam;
            this.Voornaam = voornaam;
            this.Straat = straat;
            this.Woonplaats = woonplaats;
            this.Straatnummer = straatnummer;
            this.Gsmnummer = gsmnummer;
            this.Gebdatum = gebdatum;
            this.Postcode = postcode;
        }
    }
}
