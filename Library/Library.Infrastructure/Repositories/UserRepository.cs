using Library.Infrastructure.DbContexts;
using Library.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories
{
    public class UserRepository : Repository<User, Guid>, IUserRepository
    {
        public UserRepository(IApplicationDbContext context) : base((DbContext)context)
        {
            
        }
        public (IList<User> records, int total, int totalDisplay) GetUsers(int pageIndex,
            int pageSize, string searchText, string orderby, bool status)
        {
            (IList<User> records, int total, int totalDisplay) results = GetDynamic(
                 x => x.Name.Contains(searchText) && x.IsApproved == status, 
                 orderby,
                "", pageIndex, pageSize, true);

            return results;
        }

    }
}
