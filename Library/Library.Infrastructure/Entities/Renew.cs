namespace Library.Infrastructure.Entities
{
    public class Renew: IEntity<Guid>
    {
        public Guid Id { get; set; }
        public Guid BorrowId { get; set; }
        public string Status { get; set; }
        public Borrow Borrow { get; set; }
    }
}
