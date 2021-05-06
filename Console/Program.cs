using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using Data;
using Domain.Entities;

namespace Console
{
    class Program
    {
        static void Main(string[] args)
        {
            // Add Product
            using (var context = new MyFinanceContext())
            {
                var pr = new Category()
                {
                    Name = "Medicament1"
               
                };
                context.Categories.Add(pr);

                context.SaveChanges();
            }
        }
    }
}
