using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using InternshipApplication.Models.Domain;

namespace InternshipApplication.Models.DAL
{
    public class OpdrachtenRepository : IOpdrachtRepository
    {
        private InternshipContext Context;
        private DbSet<Opdracht> opdrachten; 

        public OpdrachtenRepository(InternshipContext context)
        {
            this.Context = context;
            this.opdrachten = context.Opdrachten;
        }

        public IQueryable<Opdracht> FindAllOpdrachtsFromBedrijf(int bedrijfId)
        {
           // return opdrachten.Where(o => o.Bedrijf.Id == bedrijfId);
            throw new NotImplementedException();
        }

        public IQueryable<Opdracht> FindAllOpdrachtenFromSpecialisatie(int specialId)
        {
            //return opdrachten.Where(o => o.Specialisatie.Id == specialId);
            throw new NotImplementedException();
        }

        public IQueryable<Opdracht> FindAllOpdrachtenFromStudentId(int studentId)
        {
            //not implemented yet
            throw new NotImplementedException();
        }
    }
}