namespace Library.Infrastructure.Entities
{
    public class Renew
    {
        public Guid Id { get; set; }
        public Guid BorrowId { get; set; }
        public string Status { get; set; }
    }
}
