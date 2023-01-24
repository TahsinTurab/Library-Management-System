using Library.Infrastructure.Repositories;

namespace Library.Infrastructure.UnitOfWorks
{
    public interface IApplicationUnitOfWork : IUnitOfWork
    {
        IBookRepository Books { get; }
        IEBookRepository EBooks { get; }
        IBookDetailsRepository BookDetails { get; }

        IUserRepository Users { get; }
        //IApplicationUserRepository ApplicationUsers { get; }
        //IInvitationRepository Invitations { get; }
        //IReportRepository Reports { get; }
        //IActivityRepository Activities { get; }
    }
}
