using Library.Infrastructure.DbContexts;
using Library.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.UnitOfWorks
{
    public class ApplicationUnitOfWork : UnitOfWork, IApplicationUnitOfWork
    {
        public IBookRepository Books { get; private set; }
        public IBookDetailsRepository BookDetails { get; private set; }
        public IEBookRepository EBooks { get; private set; }
        public IUserRepository Users { get; private set; }
        public ApplicationUnitOfWork(IApplicationDbContext dbContext, 
            IBookRepository books, 
            IBookDetailsRepository bookDetails,
            IEBookRepository eBook,
            IUserRepository users) : base((DbContext)dbContext)
        {
            Books = books;
            BookDetails = bookDetails;
            EBooks = eBook;
            Users = users;
        }
    }
}
