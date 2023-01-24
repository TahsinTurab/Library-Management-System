using Library.Infrastructure.Repositories;

namespace Library.Infrastructure.UnitOfWorks
{
    public interface IApplicationUnitOfWork : IUnitOfWork
    {
        IBookRepository Books { get; }
        IBookDetailsRepository BookDetails { get; }
        //IApplicationUserRepository ApplicationUsers { get; }
        //IInvitationRepository Invitations { get; }
        //IReportRepository Reports { get; }
        //IActivityRepository Activities { get; }
    }
}
