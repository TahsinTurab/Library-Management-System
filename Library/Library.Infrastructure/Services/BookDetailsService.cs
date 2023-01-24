using AutoMapper;
using Library.Infrastructure.UnitOfWorks;
using BookDetailsBO = Library.Infrastructure.BusinessObjects.BookDetails;
using BookDetailsEO = Library.Infrastructure.Entities.BookDetails;

namespace Library.Infrastructure.Services
{
    public class BookDetailsService : IBookDetailsService
    {
        private readonly IApplicationUnitOfWork _applicationUnitOfWork;
        private readonly IMapper _mapper;

        public BookDetailsService(IApplicationUnitOfWork applicationUnitOfWork, IMapper mapper)
        {
            _applicationUnitOfWork = applicationUnitOfWork;
            _mapper = mapper;
        }

        public async Task CreateBookDetailsAsync(BookDetailsBO bookDetails)
        {
            var entity = _mapper.Map<BookDetailsEO>(bookDetails);

            await _applicationUnitOfWork.BookDetails.AddAsync(entity);
            await _applicationUnitOfWork.SaveAsync();
        }

        public (IList<BookDetailsBO> records, int total, int totalDisplay) GetBooks(int pageIndex,
            int pageSize, string searchText, string orderby, Guid BookId)
        {
            (IList<BookDetailsEO> records, int total, int totalDisplay) results = _applicationUnitOfWork
                .BookDetails.GetBooks(pageIndex, pageSize, searchText, orderby);

            IList<BookDetailsBO> books = new List<BookDetailsBO>();

            foreach (var item in results.records)
            {
                if(item.BookId == BookId)
                    books.Add(_mapper.Map<BookDetailsBO>(item));
                //foreach (var user in item.ProjectApplicationUsers)
                //{
                //    if (user.ApplicationUserId == userid)
                //    {
                //        projects.Add(_mapper.Map<ProjectBO>(item));
                //    }
                //}
            }

            return (books, results.total, results.totalDisplay);
        }
    }
}
