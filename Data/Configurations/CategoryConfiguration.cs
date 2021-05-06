using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    public class CategoryConfiguration: EntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {
            this.ToTable("MyCategories");
            this.HasKey(s => s.CategoryId);
            this.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
