using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternshipApplication.Models.Domain
{
    public interface IStudentRepository
    {
        IQueryable<Student> FindAll();
        Student FindByEmail(string email);
        Student FindById(int id);
        IQueryable<Student> FindByName(string naam);
        IQueryable<Student> FindByPlace(string gemeente);
        void SaveChanges();
    }
}
