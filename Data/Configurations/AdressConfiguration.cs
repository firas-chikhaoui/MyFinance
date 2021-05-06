using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Data.Configurations
{
    class AdressConfiguration : ComplexTypeConfiguration<Adress>
    {
        public AdressConfiguration()
        {
            this.Property(p => p.StreetAdress)
                .IsOptional()
                .HasMaxLength(50);

        }


    }
}
