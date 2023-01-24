namespace Library.Infrastructure.Entities
{
    public interface IEntity<G>
    {
        G Id { get; set; }
    }
}
