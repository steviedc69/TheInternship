using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InternshipApplication.Models.Domain
{
    public interface IUserRepository
    {
        IQueryable<User> GetAllUsers();
        User FindUser(String email);
    }
}