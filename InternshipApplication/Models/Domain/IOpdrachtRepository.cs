using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InternshipApplication.Models.Domain
{
    public interface IOpdrachtRepository
    {
        IQueryable<Opdracht> FindAllOpdrachtsFromBedrijf(int bedrijfId);
        IQueryable<Opdracht> FindAllOpdrachtenFromSpecialisatie(int specialId);
        IQueryable<Opdracht> FindAllOpdrachtenFromStudentId(int studentId);

    }
}