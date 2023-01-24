using Autofac;
using AutoMapper;
using Library.Infrastructure.BusinessObjects;
using Library.Infrastructure.Services;
using Library.Web.Models;

namespace Library.Web.Areas.App.Models.Students
{
    public class StudentListModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string StudentId { get; set; }
        public bool IsApproved { get; set; }


        private IUserService _userService;
        private IMapper _mapper;
        private ILifetimeScope _scope;
        private IHttpContextAccessor? _httpContextAccessor;
        //private IApplicationUserService _applicationUserService;

        public StudentListModel()
        {

        }

        public StudentListModel(IUserService userService, 
            IMapper mapper, IHttpContextAccessor? httpContextAccessor)
        {
            _userService = userService;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            //_applicationUserService = applicationUserService;
        }

        public void ResolveDependency(ILifetimeScope scope)
        {
            _scope = scope;
            _userService = _scope.Resolve<IUserService>();
            _mapper = _scope.Resolve<IMapper>();
            _httpContextAccessor = _scope.Resolve<IHttpContextAccessor>();
        }

        public object? GetPagedUsers(DataTablesAjaxRequestModel model, bool status)
        {
                var data = _userService.GetUsers(
                model.PageIndex,
                model.PageSize,
                model.SearchText,
                model.GetSortText(new string[] { "Name" }),
                status);

            return new
            {
                recordsTotal = data.records.Count,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                                record.Name,
                                record.StudentId,
                                record.Email,
                                record.IsApproved.ToString(),
                                record.Id.ToString()
                        }
                    ).ToArray()
            };
        }
    }
}
