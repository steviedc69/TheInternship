using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using InternshipApplication.Models.Domain;
using WebGrease.Css.Extensions;

namespace InternshipApplication.Models.DAL
{
    public class BedrijfRepository : IBedrijfRepository
    {
        // Context en DbSet
        private InternshipContext context;
        private DbSet<Bedrijf> bedrijven;
        private DbSet<Opdracht> opdrachten;
        private DbSet<ContactPersoon> contactpersonen;

        // Constructor
        public BedrijfRepository(InternshipContext context)
        {
            this.context = context;
            bedrijven = context.Bedrijven;
            opdrachten = context.Opdrachten;
            contactpersonen = context.ContactPersonen;
        }

        public IQueryable<Bedrijf> FindAll()
        {
            return bedrijven.OrderBy(b => b.Bedrijfsnaam);
        }

        public Bedrijf FindByEmail(string email)
        {
            return bedrijven.SingleOrDefault(b => b.Emailadres.Equals(email));
        }

        public Bedrijf FindById(int id)
        {
            return bedrijven.Find(id);
        }

        public void RemoveContact(ContactPersoon contact)
        {
            contactpersonen.Remove(contact);
        }

        public Bedrijf FindByName(string bedrijfsnaam)
        {
            return bedrijven.FirstOrDefault(b => b.Bedrijfsnaam == bedrijfsnaam);
        }

        public IQueryable<Bedrijf> FindByPlace(string gemeente)
        {
            return bedrijven.Where(b => b.Woonplaats == gemeente);
        }

        public void Add(Bedrijf bedrijf)
        {
            bedrijven.Add(bedrijf);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

    }
}