using System;
using System.Security.Policy;
using Microsoft.SqlServer.Server;

namespace InternshipApplication.Models.Domain
{
    public class Bedrijf : User
    {
        /*o	Bedrijfsnaam – adres – url - e-mail – telefoon – bereikbaarheid (wagen – openbaar vervoer – georganiseerde vervoer door bedrijf) – 
         * soort bedrijfsactiviteiten (bank – software ontwikkelaar – openbare diensten ….)*/
        private String bedrijfsnaam;
        private String url;
        private String straat;
        private int straatnummer;
        private String woonplaats;
        private String telefoon;
        private String bereikbaarheid; //Wagen, openbaar vervoer, georganiseerd vervoer door bedrijf
        private String activiteit; //Bank, softwaredevelopment, openbare dienst, ...
       // private String emailAdres;
        //private String paswoord;

        public String Bedrijfsnaam { get; set; }
        public String Url { get; set; }
        public String Straat { get; set; }
        public int Straatnummer { get; set; }
        public String Woonplaats { get; set; }
        public String Telefoon { get; set; }
        public String Bereikbaarheid { get; set; }
        public String Activiteit { get; set; }
       // public String EmailAdres { get; set; }
       // public String Paswoord { get; set; }

        public Bedrijf()
        {
                        
        }

        public Bedrijf(String emailadres, String password, String bedrijfsnaam, String url, String straat, int straatnummer, String woonplaats, String telefoon, 
            String bereikbaarheid, String activiteit)
        {
            this.Emailadres = emailadres;
            this.Password = password;
            this.Bedrijfsnaam = bedrijfsnaam;
            this.Url = url;
            this.Straat = straat;
            this.Woonplaats = woonplaats;
            this.Telefoon = telefoon;
            this.Bereikbaarheid = bereikbaarheid;
            this.Activiteit = activiteit;
        }

    }
}
