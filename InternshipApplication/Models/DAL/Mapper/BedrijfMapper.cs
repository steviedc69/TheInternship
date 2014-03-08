using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using InternshipApplication.Models.Domain;

namespace InternshipApplication.Models.DAL.Mapper
{
    public class BedrijfMapper : EntityTypeConfiguration<Bedrijf>
    {
        public BedrijfMapper()
        {
            
            Property(b => b.Bedrijfsnaam).IsRequired();
            Property(b => b.Telefoon).IsRequired();

            ToTable("Bedrijf");
        }

    }
}