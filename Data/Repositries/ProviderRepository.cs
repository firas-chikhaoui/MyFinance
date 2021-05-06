using Data.Infrastructure;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositries
{
    class ProviderRepository : RepositoryBase<Provider>
    {
        private DatabaseFactory _db = new DatabaseFactory();

        public ProviderRepository(DatabaseFactory db)
            :base(db)
        
            {
            _db = db;
        }
    }
}
