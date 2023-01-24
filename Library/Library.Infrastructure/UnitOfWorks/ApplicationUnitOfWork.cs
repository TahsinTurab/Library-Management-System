using Library.Infrastructure.DbContexts;
using Library.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.UnitOfWorks
{
    public class ApplicationUnitOfWork : UnitOfWork, IApplicationUnitOfWork
    {
        public IBookRepository Books { get; private set; }
        public IBookDetailsRepository BookDetails { get; private set; }
        public ApplicationUnitOfWork(IApplicationDbContext dbContext, 
            IBookRepository books, 
            IBookDetailsRepository bookDetails) : base((DbContext)dbContext)
        {
            Books = books;
            BookDetails = bookDetails;
        }
    }
}
