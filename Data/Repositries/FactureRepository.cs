using Data.Infrastructure;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositries
{
    class FactureRepository : RepositoryBase<Facture>
    {
        private DatabaseFactory _db = new DatabaseFactory();

        public FactureRepository(DatabaseFactory db)
            :base(db)
        
            {
            _db = db;
        }
    }
}
