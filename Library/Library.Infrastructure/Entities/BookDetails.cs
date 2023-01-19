namespace Library.Infrastructure.Entities
{
    public class BookDetails
    {
        public int Id { get; set; }
        public Guid BookId { get; set; }
        public bool IsBorrowed { get; set; }
        public Borrow BookBorrowed { get; set; }
    }
}
