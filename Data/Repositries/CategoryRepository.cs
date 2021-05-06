using Data.Infrastructure;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Reposetries
{
    public class CategoryRepository : RepositoryBase<Category>
    {
        private DatabaseFactory _db = new DatabaseFactory();

        public CategoryRepository(DatabaseFactory db)
            :base(db)
        
            {
                _db = db;
            }
        }
    }

