using Library.Application.Contracts.Persistence;
using Library.Domain;
using Library.Persistence.DataBaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Persistence.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {

        public BookRepository(LibraryDatabaseContext context) : base(context)
        {

        }

    }
}
