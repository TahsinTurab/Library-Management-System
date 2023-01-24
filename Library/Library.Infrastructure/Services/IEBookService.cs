using Library.Infrastructure.BusinessObjects;

namespace Library.Infrastructure.Services
{
    public interface IEBookService
    {
        Task CreateEBookAsync(EBook ebook);
    }
}
