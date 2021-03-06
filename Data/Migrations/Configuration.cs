namespace Data.Migrations
{
    using Domain.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.MyFinanceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Data.MyFinanceContext";
        }

        protected override void Seed(Data.MyFinanceContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
                        context.Categories.AddOrUpdate(
                p => p.Name,
            new Category { Name = "MEUBLES" },
            new Category { Name = "Vetements" },
            new Category { Name = "Foods" }

                );
        }
    }
}
