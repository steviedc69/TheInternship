using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InternshipApplication.Models.Domain
{
    public interface IBedrijfRepository
    {
        IQueryable<Bedrijf> FindAll();
        Bedrijf FindByEmail(string email);
        Bedrijf FindById(int id);
        Bedrijf FindByName(string bedrijfsnaam);
        IQueryable<Bedrijf> FindByPlace(string gemeente);
        void Add(Bedrijf bedrijf);
        void SaveChanges();

    }
}