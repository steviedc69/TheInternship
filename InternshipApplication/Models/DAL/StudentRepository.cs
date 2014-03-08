using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using InternshipApplication.Models.Domain;

namespace InternshipApplication.Models.DAL
{
    public class StudentRepository : IStudentRepository
    {
        // Context en DbSet
        private InternshipContext context;
        private DbSet<Student> studenten;

        // Constructor
        public StudentRepository(InternshipContext context)
        {
            this.context = context;
            studenten = context.Studenten;
        }

        public IQueryable<Student> FindAll()
        {
            return studenten.OrderBy(s => s.Naam);
        }

        public Student FindByEmail(string email)
        {
            return studenten.SingleOrDefault(s => s.Emailadres.Equals(email));
        }

        public Student FindById(int id)
        {
            return studenten.Find(id);
        }


        public IQueryable<Student> FindByName(string naam)
        {
            return studenten.Where(s => s.Naam == naam || s.Voornaam == naam);
        }

        public IQueryable<Student> FindByPlace(string gemeente)
        {
            return studenten.Where(s => s.Woonplaats == gemeente);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}