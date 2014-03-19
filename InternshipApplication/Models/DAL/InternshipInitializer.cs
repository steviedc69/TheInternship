﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Web;
using System.Web.Security;
using InternshipApplication.Models.Domain;
using MySql.Data.MySqlClient;
using WebMatrix.WebData;

namespace InternshipApplication.Models.DAL
{
    public class InternshipInitializer : DropCreateDatabaseAlways<InternshipContext>
    {
        private Student s1;
        protected override void Seed(InternshipContext context)
        {
            
            try
            {
                s1 = new Student()
                {
                    Naam = "TestStudent",
                    Voornaam = "jantje",
                    Emailadres = "testStudent@hogent.be",
                    Straat = "studentstraat",
                    Straatnummer = 34,
                    Gebdatum = "30-12-1999",
                    Woonplaats = "Aalst",
        
                };

                context.Studenten.Add(s1);

                Bedrijf b1 = new Bedrijf()
                {
                    Emailadres = "testBedrijf@bedrijf.be",
                    Bedrijfsnaam = "TestBedrijf1",
                    Activiteit = "testing",
                    Bereikbaarheid = "nee",
                    Straat = "bedrijfstraat",
                    Straatnummer = 23,
                    //clientside validation op het telefoonnummer!! 
                    Telefoon = "000/000000",
                    //clientside validation op de url!!
                    Url = "www.bedrijf1.be",
                    Woonplaats = "Aalst"

                };
                ContactPersoon c1 = new ContactPersoon()
                {
                    Naam = "Doe",
                    Voornaam = "John",
                    ContactEmail = "John.Doe@bedrijf.be",
                    ContactTelNr = "000/000000",
                    Functie = "Senior Java Developper"
                };
                b1.AddContactPersoon(c1);
                ContactPersoon c2 = new ContactPersoon()
                {
                    Naam = "Doe",
                    Voornaam = "John",
                    ContactEmail = "John.Doe@bedrijf.be",
                    ContactTelNr = "000/000000",
                    Functie = "Senior Java Developper"
                };
                b1.AddContactPersoon(c2);
                context.Bedrijven.Add(b1);

                Bedrijf b2 = new Bedrijf()
                {
                    Emailadres = "testBedrijf2@bedrijf.be",
                    Bedrijfsnaam = "TestBedrijf2",
                    Activiteit = "testing",
                    Bereikbaarheid = "nee",

                    Straat = "bedrijfstraat",
                    Straatnummer = 24,
                    //clientside validation op het telefoonnummer!! 
                    Telefoon = "000/000001",
                    //clientside validation op de url!!
                    Url = "www.bedrijf2.be",
                    Woonplaats = "Aalst"

                };

                context.Bedrijven.Add(b2);
                context.SaveChanges();
                //SeedMembership();
                
            }
            catch (DbEntityValidationException e)
            {
                string s = "Fout creatie database ";
                foreach (var eve in e.EntityValidationErrors)
                {
                    s += String.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                         eve.Entry.Entity.GetType().Name, eve.Entry.GetValidationResult());
                    foreach (var ve in eve.ValidationErrors)
                    {
                        s += String.Format("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw new Exception(s);
            }
        }
        private void SeedMembership()
        {
            WebSecurity.InitializeDatabaseConnection("internshipdb", "User", "Id", "emailadres",
                autoCreateTables: true);
            //var roles = (MysqlrSimpleRoleProvider)Roles.Provider;
            var membership = (SimpleMembershipProvider)Membership.Provider;

            //roles.CreateRole("admin");
            //roles.CreateRole("customer");
            
                membership.CreateAccount(s1.Emailadres,"password123");
                //roles.AddUsersToRoles(new string[] { "student" + i }, new string[] { "customer" });
         
        }
   
}

}
