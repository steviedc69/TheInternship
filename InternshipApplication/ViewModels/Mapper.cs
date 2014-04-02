using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetOpenAuth.OpenId.Extensions.AttributeExchange;
using InternshipApplication.Models.Domain;

namespace InternshipApplication.ViewModels
{
    public static class Mapper
    { //extension methods
               
               public static ContactCreateModel ConvertToContactCreateModel(this ContactPersoon contact, int bedrijfId)
               {
                   //teruggeven van contactCreateModel
                   return new ContactCreateModel()
                   {
                       //opvullen van viewmodel
                       idBedrijf = bedrijfId,
                       id = contact.Id,
                       Naam = contact.Naam,
                       Voornaam = contact.Voornaam,
                       Functie = contact.Functie,
                       ContactEmail = contact.ContactEmail,
                       ContactTelNr = contact.ContactTelNr,
                       GsmNummer = contact.GsmNummer
                   };
               }

               public static void UpdateContact(this ContactPersoon contactToEdit, ContactCreateModel contact)
               {
                   //updaten van attributen in contact in bedrijf
                   contactToEdit.Naam = contact.Naam;
                   contactToEdit.Voornaam = contact.Voornaam;
                   contactToEdit.ContactEmail = contact.ContactEmail;
                   contactToEdit.ContactTelNr = contact.ContactTelNr;
                   contactToEdit.Functie = contact.Functie;
                   contactToEdit.GsmNummer = contact.GsmNummer;
               }
    }
}