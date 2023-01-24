using Library.Infrastructure.DbContexts;
using Library.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories
{
    public class EBookRepository : Repository<EBook, Guid>, IEBookRepository
    {
        public EBookRepository(IApplicationDbContext context) : base((DbContext)context)
        {
        }

    }
}
