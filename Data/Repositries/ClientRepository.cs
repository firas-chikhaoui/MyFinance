﻿using Data.Infrastructure;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositries
{
    public class ClientRepository : RepositoryBase<Client>
    {
        private DatabaseFactory _db = new DatabaseFactory();

        public ClientRepository(DatabaseFactory db)
            :base(db)
        
            {
            _db = db;
        }
    }
}

