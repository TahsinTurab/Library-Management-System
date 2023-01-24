using Library.Infrastructure.BusinessObjects;

namespace Library.Infrastructure.BusinessObjects
{
    public class Book
    {
        public Guid Id { get; set; }
        public string BookTitle { get; set; }
        public string Author { get; set; }
        public List<BookDetails> ProjectApplicationUsers { get; set; }
    }
}
