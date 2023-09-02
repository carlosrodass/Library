
using Library.Application.Contracts.Persistence;
using Library.Domain;
using Library.Persistence.DataBaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Persistence.Repositories
{
    public class KeyPointRepository : GenericRepository<KeyPoint>, IKeyPointRepository
    {

        public KeyPointRepository(LibraryDatabaseContext context) : base(context)
        {

        }

    }
}
