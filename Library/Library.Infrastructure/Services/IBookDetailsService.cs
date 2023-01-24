using Library.Infrastructure.BusinessObjects;

namespace Library.Infrastructure.Services
{
    public interface IBookDetailsService
    {
        Task CreateBookDetailsAsync(BookDetails book);
    }
}
