using Library.Infrastructure.BusinessObjects;

namespace Library.Infrastructure.Services
{
    public interface IBookService
    {
        Task<Guid?> CreateBookAsync(Book book);
    }
}
