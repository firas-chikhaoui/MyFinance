using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using Domain.Entities;
//using Data.Migrations;
using Data.Configurations;
using Data.Configuration;
using Data.CustomConvention;

namespace Data
{
    public class MyFinanceContext : DbContext
    {
        public MyFinanceContext(): base("Name=MyFinanceCtx")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<MyFinanceContext,Configuration>());
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Client> Client { get; set; }

        public DbSet<Facture> Factures { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Configurations.Add(new CategoryConfiguration());
            //modelBuilder.Configurations.Add(new ProductConfiguration());
            //modelBuilder.Configurations.Add(new AdressConfiguration());
            //modelBuilder.Conventions.Add(new DataTime2Convention());

        }
    }
}
