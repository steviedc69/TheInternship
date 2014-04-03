using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using InternshipApplication.Models.Domain;

namespace InternshipApplication.Models.DAL
{
    public class ContactPersoonRepository : IContactPersoon
    {

        private DbSet<ContactPersoon> contactpersonen;

        public void RemoveContact(ContactPersoon contact)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}