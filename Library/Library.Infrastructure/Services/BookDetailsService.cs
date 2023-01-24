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

    }
}
