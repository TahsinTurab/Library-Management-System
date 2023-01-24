using Library.Infrastructure.Entities;

namespace Library.Infrastructure.Repositories
{
    public interface IBookRepository : IRepository<Book, Guid>
    {
        (IList<Book> records, int total, int totalDisplay) GetBooks(int pageIndex,
            int pageSize, string searchText, string orderby);
    }
}
