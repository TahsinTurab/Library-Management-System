using Library.Infrastructure.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Library.Infrastructure.DbContexts
{
    public class ApplicationDbContext : IdentityDbContext, IApplicationDbContext
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public ApplicationDbContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString,
                    b => b.MigrationsAssembly(_migrationAssemblyName)
                );
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                .HasMany(a => a.BorrowedBook)
                .WithOne(n => n.User)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<Book>()
                .HasMany(a => a.BookDetails)
                .WithOne(n => n.Book)
                .HasForeignKey(x => x.BookId);

            modelBuilder.Entity<BookDetails>()
                .HasOne(n => n.BookBorrowed)
                .WithOne(a => a.BookDetails)
                .HasForeignKey<Borrow>(x => x.BookDetailsId);

            modelBuilder.Entity<Borrow>()
                .HasMany(a => a.Renews)
                .WithOne(n => n.Borrow)
                .HasForeignKey(x => x.BorrowId);

            modelBuilder.Entity<Course>()
                .HasMany(a => a.Notes)
                .WithOne(n => n.Course)
                .HasForeignKey(x => x.CourseId);

            base.OnModelCreating(modelBuilder);
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookDetails> BookDatails { get; set; }
        public DbSet<Borrow> Borrows { get; set; }
        public DbSet<Renew> Renews { get; set; }
        public DbSet<EBook> EBooks { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Note> Notes { get; set; }
    }
}