namespace Library.Infrastructure.Entities
{
    public class Book : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string BookTitle { get; set; }
        public string Author { get; set; }
        public List<BookDetails> BookDetails { get; set; }
    }
}
