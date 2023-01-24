namespace Library.Infrastructure.Entities
{
    public class EBook: IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string BookLink { get; set; }
    }
}
