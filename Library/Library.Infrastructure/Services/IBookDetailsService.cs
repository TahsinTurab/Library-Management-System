using Library.Infrastructure.BusinessObjects;

namespace Library.Infrastructure.Services
{
    public interface IBookDetailsService
    {
        Task CreateBookDetailsAsync(BookDetails book);
        //Task<Book> GetProjectAsync(Guid id);
        //Task<IList<Book>> GetAllProjectsAsync();
        //Task<IList<Book>> GetUserProjectsAsync(Guid id);
        //(IList<Book> records, int total, int totalDisplay) GetProjects(int pageIndex,
        // int pageSize, string searchText, string orderby, bool status, Guid userid);

        //Task<bool> IsProjectOwner(Guid projectId, Guid userId);
        //Task EditProject(Book project);
        //Task ProjectArchive(Guid id, bool isArchived);
        //Task CreateProjectUserAsync(Book project, Guid userId);
        //Task<IList<BookDetails>> GetTeamMembersAsync(Guid projectId);
        //Task<string> RemoveTeamMemberAsync(Guid projectId, Guid userId);
    }
}
