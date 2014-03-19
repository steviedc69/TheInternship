using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using InternshipApplication.Models.DAL.Mapper;
using InternshipApplication.Models.Domain;
using MySql.Data.Entity;

namespace InternshipApplication.Models.DAL
{
    //hier zullen waarschijnlijk nog dingen moeten aangevuld worden
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class InternshipContext : DbContext
    {
        public InternshipContext() : base("internshipdb")
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Bedrijf> Bedrijven { get; set; }
        public DbSet<Student> Studenten { get; set; }
        public DbSet<Stagebegeleider> Stagebegeleiders { get; set; }
        //public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Opdracht>Opdrachten { get; set; } 
        public DbSet<Specialisatie> Specialisaties { get; set; }
        public DbSet<ContactPersoon> ContactPersonen { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new UserMapper());
            modelBuilder.Configurations.Add(new BedrijfMapper());
            modelBuilder.Configurations.Add(new StudentMapper());
            modelBuilder.Configurations.Add(new ContactPersoonMapper());
            modelBuilder.Configurations.Add(new StageBegeleiderMapper());
            modelBuilder.Configurations.Add(new OpdrachtMapper());
            modelBuilder.Configurations.Add(new SpecialisatieMapper());
        }
    }
}