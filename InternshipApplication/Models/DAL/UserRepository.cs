using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using InternshipApplication.Models.Domain;

namespace InternshipApplication.Models.DAL
{
    public class UserRepository : IUserRepository
    {
        private DbSet<User> users;
        private InternshipContext context;
       
        public UserRepository(InternshipContext context)
        {
            this.context = context;
            this.users = context.Users;

        }


        public IQueryable<User> GetAllUsers()
        {
            return users.OrderBy(u => u.Emailadres);
        }

        public User FindUser(string email)
        {
            return users.SingleOrDefault(u => u.Emailadres.Equals(email));
        }
    }
}