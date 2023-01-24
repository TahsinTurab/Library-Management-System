using Library.Infrastructure.DbContexts;
using Library.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories
{
    public class BookDetailsRepository : Repository<BookDetails, int>, IBookDetailsRepository
    {
        public BookDetailsRepository(IApplicationDbContext context) : base((DbContext)context)
        {
        }
    }
}
