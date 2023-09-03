using MyLibrary.Application.Contracts.Persistence;
using MyLibrary.Domain.Models;
using MyLibrary.Persistence.DataBaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary.Persistence.Repositories
{
    public class KeyPointRepository : GenericRepository<KeyPoint>, IKeyPointRepository
    {

        public KeyPointRepository(LibraryDatabaseContext context) : base(context)
        {

        }

    }
}
