using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Service 
{
    public class FactureService : EntityService<Facture>
    {
        
        public FactureService() : base()
        {

        }


        public override IEnumerable<Facture> GetAll()
        {
            return this.unitofwork.DataContext.Factures.Include(f => f.Client).Include(f => f.Product).ToList();

        }

        public Facture GetFactureById(int Productid, int ClientId, DateTime Dateachat)
        {
            return this.unitofwork.GetRepository<Facture>().GetAll().Where(a => a.ProductId == Productid && a.ClientId == ClientId && a.DateAchat == Dateachat).FirstOrDefault();
        }
    }
}
