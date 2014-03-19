using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using InternshipApplication.Models.Domain;

namespace InternshipApplication.Models.DAL.Mapper
{
    public class UserMapper : EntityTypeConfiguration<User>
    {
        public UserMapper()
        {
            HasKey(u => u.Id);
            Property(u => u.Emailadres).IsRequired();
            ToTable("User");
        }
        

    }
}