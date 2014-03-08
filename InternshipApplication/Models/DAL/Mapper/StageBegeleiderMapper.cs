using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using InternshipApplication.Models.Domain;

namespace InternshipApplication.Models.DAL.Mapper
{
    public class StageBegeleiderMapper : EntityTypeConfiguration<Stagebegeleider>
    {
        public StageBegeleiderMapper()
        {
            //HasKey(s => s.Emailadres);
            //derest zullen we wel zien zeker
            ToTable("Stagebegeleider");
        }

    }
}