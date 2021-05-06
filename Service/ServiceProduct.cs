using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceProduct : EntityService<Product>
    {

        public ServiceProduct() : base()
        {

        }


        public IEnumerable<Product> GetProductByName(string Name)
        {
            return unitofwork.GetRepository<Product>().GetAll().Where(m => m.Name.ToString().ToLower().Contains(Name.ToLower()));
        }
    }
}
