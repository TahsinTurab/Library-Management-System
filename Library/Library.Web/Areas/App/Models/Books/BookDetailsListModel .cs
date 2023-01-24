using Autofac;
using AutoMapper;
using Library.Infrastructure.BusinessObjects;
using Library.Infrastructure.Services;
using Library.Web.Models;

namespace Library.Web.Areas.App.Models.Books
{
    public class BookDetailsListModel
    {
        public string BookTitle { get; set; }
        public string Author { get; set; }


        private IBookDetailsService _bookDetailsService;
        private IMapper _mapper;
        private ILifetimeScope _scope;
        private IHttpContextAccessor? _httpContextAccessor;
        //private IApplicationUserService _applicationUserService;

        public BookDetailsListModel()
        {

        }

        public BookDetailsListModel(IBookDetailsService bookDetailsService, 
            IMapper mapper, IHttpContextAccessor? httpContextAccessor)
        {
            _bookDetailsService = bookDetailsService;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            //_applicationUserService = applicationUserService;
        }

        public void ResolveDependency(ILifetimeScope scope)
        {
            _scope = scope;
            _bookDetailsService = _scope.Resolve<IBookDetailsService>();
            _mapper = _scope.Resolve<IMapper>();
            _httpContextAccessor = _scope.Resolve<IHttpContextAccessor>();
        }

        public object? GetPagedBooks(DataTablesAjaxRequestModel model, Guid BookId)
        {
            //var currentUserId = Guid.Parse(_httpContextAccessor.HttpContext.
            //    User.Claims.FirstOrDefault().Value);

            var data = _bookDetailsService.GetBooks(
                model.PageIndex,
                model.PageSize,
                model.SearchText,
                model.GetSortText(new string[] { "BookCode" }),
                BookId);

            return new
            {
                recordsTotal = data.records.Count,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                                record.BookCode.ToString(),
                                //record.BookDetails.Count().ToString(),
                                record.IsBorrowed.ToString(),
                                record.Id.ToString()
                        }
                    ).ToArray()
            };
        }

        
        //public async Task<List<TeamMember>> GetTeamMembersAsync(Guid projectId)
        //{
        //    var currentUserId = Guid.Parse(_httpContextAccessor.HttpContext.
        //        User.Claims.FirstOrDefault().Value);

        //    var team = await _projectService.GetTeamMembersAsync(projectId);
        //    var records = new List<TeamMember>();

        //    foreach (var projectUser in team)
        //    {
        //        var userId = Guid.Parse(projectUser.ApplicationUserId.ToString());
        //        var user = await _applicationUserService.GetByUserIdAsync(userId);
        //        var member = _mapper.Map<TeamMember>(user);
        //        member.Role = projectUser.Role.ToString();
        //        member.MemberId = userId;
        //        records.Add(member);
        //    }

        //    var teamMemberDetails = new List<TeamMember>();
        //    foreach(var record in records)
        //    {
        //        teamMemberDetails.Add(record);
        //        if(record.MemberId == currentUserId && record.Role == "Worker")
        //        {
        //            teamMemberDetails.Clear();
        //            teamMemberDetails.Add(record);
        //            break;
        //        }
        //    }

        //    return teamMemberDetails;
        //}
    }
}
