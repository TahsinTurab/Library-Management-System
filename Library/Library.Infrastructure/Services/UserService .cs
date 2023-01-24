using AutoMapper;
using Library.Infrastructure.Exceptions;
using Library.Infrastructure.UnitOfWorks;
using UserBO = Library.Infrastructure.BusinessObjects.User;
using UserEO = Library.Infrastructure.Entities.User;

namespace Library.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IApplicationUnitOfWork _applicationUnitOfWork;
        private readonly IMapper _mapper;

        public UserService(IApplicationUnitOfWork applicationUnitOfWork, IMapper mapper)
        {
            _applicationUnitOfWork = applicationUnitOfWork;
            _mapper = mapper;
        }

        public async Task<Guid?> CreateUserAsync(UserBO user)
        {
            var count = _applicationUnitOfWork.Users.GetCount(x => x.Email == user.Email);

            if (count > 0)
            {
                throw new DuplicateException("Book with same name already exists");
            }

            var entity = _mapper.Map<UserEO>(user);

            await _applicationUnitOfWork.Users.AddAsync(entity);
            await _applicationUnitOfWork.SaveAsync();

            return entity.Id;
        }

        public (IList<UserBO> records, int total, int totalDisplay) GetUsers(int pageIndex,
            int pageSize, string searchText, string orderby, bool status)
        {
            (IList<UserEO> records, int total, int totalDisplay) results = _applicationUnitOfWork
                .Users.GetUsers(pageIndex, pageSize, searchText, orderby, status);

            IList<UserBO> users = new List<UserBO>();

            foreach (var item in results.records)
            {
                users.Add(_mapper.Map<UserBO>(item));
                
            }

            return (users, results.total, results.totalDisplay);
        }

        public async Task UserApprove(Guid id, bool isApprove)
        {
            var userEntity = await _applicationUnitOfWork.Users.GetByIdAsync(id);
            if (userEntity != null)
            {
                userEntity.IsApproved= isApprove;

                await _applicationUnitOfWork.SaveAsync();
            }
            else
                throw new InvalidOperationException("not found!");
        }

        public async Task RemoveUserAsync(Guid userId)
        {
            var userEOList = await _applicationUnitOfWork.Users
                .GetAsync(x => x.Id.Equals(userId), "");

            var userEO = userEOList.FirstOrDefault();

            if (userEO != null)
            {
                _applicationUnitOfWork.Users.Remove(userEO);
                //userEO.Remove(userEOList.First(u => u.Id == userId));

                await _applicationUnitOfWork.SaveAsync();
            }
            else
                throw new InvalidOperationException("User was not found");

            
        }

    }
}
