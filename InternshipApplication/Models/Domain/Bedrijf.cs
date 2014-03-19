using System;
using System.Collections.Generic;
using System.Security.Policy;
using Microsoft.SqlServer.Server;

namespace InternshipApplication.Models.Domain
{
    public class Bedrijf : User
    {


        public String Bedrijfsnaam { get; set; }
        public String Url { get; set; }
        public String Straat { get; set; }
        public int Straatnummer { get; set; }
        public String Woonplaats { get; set; }
        public String Telefoon { get; set; }
        public String Bereikbaarheid { get; set; }
        public String Activiteit { get; set; }

        public IList<ContactPersoon>ContactPersonen { get; private set; } 

        public Bedrijf()
        {
           ContactPersonen = new List<ContactPersoon>();             
        }

        public Bedrijf(String emailadres, String bedrijfsnaam, String url, String straat, int straatnummer, String woonplaats, String telefoon, 
            String bereikbaarheid, String activiteit,IList<ContactPersoon>cPersonen )
        {
            this.Emailadres = emailadres;

            this.Bedrijfsnaam = bedrijfsnaam;
            this.Url = url;
            this.Straat = straat;
            this.Woonplaats = woonplaats;
            this.Telefoon = telefoon;
            this.Bereikbaarheid = bereikbaarheid;
            this.Activiteit = activiteit;
            ContactPersonen = cPersonen;
        }

        public void AddContactPersoon(ContactPersoon persoon)
        {
            this.ContactPersonen.Add(persoon);
        }

        public void RemoveContactPersoon(ContactPersoon persoon)
        {
            this.ContactPersonen.Remove(persoon);
        }


    }
}
