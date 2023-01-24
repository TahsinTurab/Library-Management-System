using Library.Infrastructure.Entities;

namespace Library.Infrastructure.Repositories
{
    public interface IUserRepository : IRepository<User, Guid>
    {
        (IList<User> records, int total, int totalDisplay) GetUsers(int pageIndex,
            int pageSize, string searchText, string orderby, bool status);
    }
}
