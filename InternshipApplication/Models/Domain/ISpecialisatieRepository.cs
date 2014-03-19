using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace InternshipApplication.Models.Domain
{
    public interface ISpecialisatieRepository
    {
        IQueryable<Specialisatie> FindAllSpecialisaties();
        Specialisatie FindSpecialisatie(int id);
    }
}