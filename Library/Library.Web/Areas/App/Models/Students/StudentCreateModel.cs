using Autofac;
using AutoMapper;
using Library.Infrastructure.BusinessObjects;
using Library.Infrastructure.Services;
using System.ComponentModel.DataAnnotations;

namespace Library.Web.Areas.App.Models.Books
{
    public class StudentCreateModel
    {
        [Required(ErrorMessage = "Name must be provided")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Id must be provided")]
        public string StudentId { get; set; }

        [Required(ErrorMessage = "Email must be provided")]
        public string Email { get; set; }

        private IUserService _userService;
        private IMapper _mapper;
        private ILifetimeScope _scope;
        private IHttpContextAccessor? _httpContextAccessor;

        public StudentCreateModel()
        {

        }

        public StudentCreateModel(IUserService userService, IMapper mapper,
            IHttpContextAccessor httpContextAccessor)
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

        public async Task<Guid?> CreateAsync()
        {
            var user = _mapper.Map<User>(this);
            user.IsApproved = false;

            return await _userService.CreateUserAsync(user);
        }
    }
}
