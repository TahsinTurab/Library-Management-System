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
            IMapper mapper, IHttpContextAccessor? httpContextAccessor)
        {
            _userService = userService;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public void ResolveDependency(ILifetimeScope scope)
        {
            _scope = scope;
            _userService = _scope.Resolve<IUserService>();
            _mapper = _scope.Resolve<IMapper>();
            _httpContextAccessor = _scope.Resolve<IHttpContextAccessor>();
        }

        
    }
}
