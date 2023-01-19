using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Library.Infrastructure.Entities;

namespace Library.Infrastructure.DbContexts
{
    public interface IApplicationDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<Book> Books { get; set; }
        DbSet<BookDetails> BookDatails { get; set; }
        DbSet<Borrow> Borrows { get; set; }
        DbSet<Renew> Renews { get; set; }
        DbSet<EBook> EBooks { get; set; }
        DbSet<Course> Courses { get; set; }
        DbSet<Note> Notes { get; set; }
    }
}