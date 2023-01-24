using Library.Infrastructure.BusinessObjects;

namespace Library.Infrastructure.Services
{
    public interface IEBookService
    {
        Task CreateEBookAsync(EBook ebook);
        (IList<EBook> records, int total, int totalDisplay) GetBooks(int pageIndex,
         int pageSize, string searchText, string orderby);
    }
}
