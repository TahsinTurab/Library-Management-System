using Library.Infrastructure.BusinessObjects;

namespace Library.Infrastructure.Services
{
    public interface IBookService
    {
        Task<Guid?> CreateBookAsync(Book book);
        (IList<Book> records, int total, int totalDisplay) GetBooks(int pageIndex,
         int pageSize, string searchText, string orderby);
    }
}
