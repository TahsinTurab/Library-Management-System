using Library.Infrastructure.BusinessObjects;

namespace Library.Infrastructure.Services
{
    public interface IBookDetailsService
    {
        Task CreateBookDetailsAsync(BookDetails book);
        (IList<BookDetails> records, int total, int totalDisplay) GetBooks(int pageIndex,
         int pageSize, string searchText, string orderby, Guid BookId);
    }
}
