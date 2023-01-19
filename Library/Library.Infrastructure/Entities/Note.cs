namespace Library.Infrastructure.Entities
{
    public class Note
    {
        public Guid Id { get; set; }
        public Guid CourseId { get; set; }
        public string NoteTitle { get; set; }
        public string Session { get; set; }
        public string NoteLink { get; set; }
        public Course Course { get; set; }
    }
}
