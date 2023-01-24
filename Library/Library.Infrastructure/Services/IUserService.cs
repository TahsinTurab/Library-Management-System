using Library.Infrastructure.BusinessObjects;

namespace Library.Infrastructure.Services
{
    public interface IUserService
    {
        Task<Guid?> CreateUserAsync(User user);
        (IList<User> records, int total, int totalDisplay) GetUsers(int pageIndex,
         int pageSize, string searchText, string orderby, bool status);
    }
}
