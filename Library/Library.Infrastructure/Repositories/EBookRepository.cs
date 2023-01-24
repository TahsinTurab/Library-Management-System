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

        public (IList<EBook> records, int total, int totalDisplay) GetBooks(int pageIndex,
            int pageSize, string searchText, string orderby)
        {
            (IList<EBook> records, int total, int totalDisplay) results = GetDynamic(
                 x => x.Title.Contains(searchText), orderby,
                "", pageIndex, pageSize, true);

            return results;
        }

    }
}
