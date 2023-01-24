namespace Library.Infrastructure.Entities
{
    public class Role : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string UserRole { get; set; }
        public User User { get; set; }
    }
}
