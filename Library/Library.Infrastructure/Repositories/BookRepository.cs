using Library.Infrastructure.DbContexts;
using Library.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories
{
    public class BookRepository : Repository<Book, Guid>, IBookRepository
    {
        public BookRepository(IApplicationDbContext context) : base((DbContext)context)
        {
            
        }
        public (IList<Book> records, int total, int totalDisplay) GetBooks(int pageIndex,
            int pageSize, string searchText, string orderby)
        {
            (IList<Book> records, int total, int totalDisplay) results = GetDynamic(
                 x => x.BookTitle.Contains(searchText), orderby,
                "BookDetails", pageIndex, pageSize, true);

            return results;
        }

    }
}
