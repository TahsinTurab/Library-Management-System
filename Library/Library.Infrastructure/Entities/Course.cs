namespace Library.Infrastructure.Entities
{
    public class Course
    {
        public Guid Id { get; set; }
        public string CourseCode { get; set; }
        public string CourseTitle { get; set; }
        public List<Note> Notes { get; set; }
    }
}
