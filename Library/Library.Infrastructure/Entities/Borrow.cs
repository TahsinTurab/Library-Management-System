namespace Library.Infrastructure.Entities
{
    public class Borrow: IEntity<Guid>
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid BookDetailsId { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int RenewedTimes { get; set; }
        public List<Renew> Renews { get; set; }
        public BookDetails BookDetails { get; set; }
        public User User { get; set; }
    }
}
