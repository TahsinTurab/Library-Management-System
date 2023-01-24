namespace Library.Infrastructure.Entities
{
    public class User: IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string StudentId { get; set; }
        public string Email { get; set; }
        public string? Mobile { get; set; }
        public bool IsApproved { get; set; }
        public string? UserRole { get; set; }
        public List<Borrow> BorrowedBook { get; set; }
    }
}
