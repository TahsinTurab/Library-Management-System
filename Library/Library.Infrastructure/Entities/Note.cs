namespace Library.Infrastructure.Entities
{
    public class Note
    {
        public Guid Id { get; set; }
        public string NoteTitle { get; set; }
        public string Session { get; set; }
        public string NoteLink { get; set; }
    }
}
