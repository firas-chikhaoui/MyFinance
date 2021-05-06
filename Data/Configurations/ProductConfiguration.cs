using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configuration
{
    class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        

        public ProductConfiguration()
        {
            this.HasMany<Provider>(p => p.Providers)
                .WithMany(c => c.Products)
                .Map(cs =>
                {
                    cs.MapLeftKey("Product");
                    cs.MapRightKey("Provider");
                    cs.ToTable("Providings");
                });

            this.HasRequired<Category>(c => c.Category)
                .WithMany(c => c.Products)
                .HasForeignKey<int?>(k => k.CategoryId)
                .WillCascadeOnDelete(false);

            this.Map<Biological>(c =>
            {
                c.Requires("IsBiological").HasValue(1);

            });
            this.Map<Chemical>(c =>
            {
                c.Requires("IsChemical").HasValue(0);

            });

            this.Property(p => p.Description)
                .IsOptional()
                .HasMaxLength(200);
        }
    }
}