namespace Library.Infrastructure.BusinessObjects
{
    public class Role
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string UserRole { get; set; }
        public User User { get; set; }
    }
}
