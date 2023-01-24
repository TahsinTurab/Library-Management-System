namespace Library.Infrastructure.Entities
{
    public class BookDetails: IEntity<Guid>
    {
        public Guid Id { get; set; }
        public int BookCode { get; set; }
        public Guid BookId { get; set; }
        public bool IsBorrowed { get; set; }
        public Book Book { get; set; }
        public Borrow BookBorrowed { get; set; }
    }
}
