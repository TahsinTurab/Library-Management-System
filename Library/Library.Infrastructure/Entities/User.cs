namespace Library.Infrastructure.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string StudentId { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public bool IsApproved { get; set; }
        public Role UserRole { get; set; }
        public List<Borrow> BorrowedBook { get; set; }
    }
}
