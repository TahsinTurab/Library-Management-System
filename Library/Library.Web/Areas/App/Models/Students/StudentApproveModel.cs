using Autofac;
using AutoMapper;
using Library.Infrastructure.BusinessObjects;
using Library.Infrastructure.Services;
using Library.Web.Models;

namespace Library.Web.Areas.App.Models.Students
{
    public class StudentApproveModel
    {
        private IUserService _userService;
        private IMapper _mapper;
        private ILifetimeScope _scope;
        private IHttpContextAccessor? _httpContextAccessor;

        public StudentApproveModel()
        {

        }

        public StudentApproveModel(IUserService userService, 
            IMapper mapper, IHttpContextAccessor? httpContextAccessor,
            ILifetimeScope scope)
        {
            _userService = userService;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _scope = scope;
            _scope.Resolve<IMapper>();
        }

        public async Task StudentApprove(Guid id, bool isApprove)
        {
            await _userService.UserApprove(id, isApprove);
        }
    }
}
