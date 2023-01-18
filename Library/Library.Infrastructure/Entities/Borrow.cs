namespace Library.Infrastructure.Entities
{
    public class Borrow
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid BookDetailsId { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
