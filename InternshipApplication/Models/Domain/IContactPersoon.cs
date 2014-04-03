using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipApplication.Models.Domain
{
    interface IContactPersoon
    {
        void RemoveContact(ContactPersoon contact);
        void SaveChanges();
    }
}
