using Library.Infrastructure.Entities;

namespace Library.Infrastructure.Repositories
{
    public interface IEBookRepository : IRepository<EBook, Guid>
    {
        (IList<EBook> records, int total, int totalDisplay) GetBooks(int pageIndex,
            int pageSize, string searchText, string orderby);
    }
}
