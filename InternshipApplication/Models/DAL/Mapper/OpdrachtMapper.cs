using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using InternshipApplication.Models.Domain;

namespace InternshipApplication.Models.DAL.Mapper
{
    public class OpdrachtMapper : EntityTypeConfiguration<Opdracht>
    {
        public OpdrachtMapper()
        {
            HasKey(o => o.Id);
            Property(o => o.Title).IsRequired().HasMaxLength(100);
            Property(o => o.Omschrijving).IsRequired().HasMaxLength(500);
            HasRequired(o => o.Specialisatie).WithMany().Map(m => m.MapKey("specId"));
            ToTable("opdracht");
        }
        

    }
}