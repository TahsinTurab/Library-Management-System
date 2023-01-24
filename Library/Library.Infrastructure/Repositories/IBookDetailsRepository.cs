using Library.Infrastructure.Entities;

namespace Library.Infrastructure.Repositories
{
    public interface IBookDetailsRepository : IRepository<BookDetails, Guid>
    {
        (IList<BookDetails> records, int total, int totalDisplay) GetBooks(int pageIndex,
            int pageSize, string searchText, string orderby);
    }
}
