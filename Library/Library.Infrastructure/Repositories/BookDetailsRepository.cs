using Library.Infrastructure.DbContexts;
using Library.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories
{
    public class BookDetailsRepository : Repository<BookDetails, Guid>, IBookDetailsRepository
    {
        public BookDetailsRepository(IApplicationDbContext context) : base((DbContext)context)
        {

        }

        public (IList<BookDetails> records, int total, int totalDisplay) GetBooks(int pageIndex,
            int pageSize, string searchText, string orderby)
        {
            (IList<BookDetails> records, int total, int totalDisplay) results = GetDynamic(
                 x => x.BookCode.ToString().Contains(searchText), orderby,
                "", pageIndex, pageSize, true);

            return results;
        }
    }
}
