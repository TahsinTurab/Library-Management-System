using AutoMapper;
using Library.Infrastructure.Exceptions;
using Library.Infrastructure.UnitOfWorks;
using BookBO = Library.Infrastructure.BusinessObjects.Book;
using BookEO = Library.Infrastructure.Entities.Book;

namespace Library.Infrastructure.Services
{
    public class BookService : IBookService
    {
        private readonly IApplicationUnitOfWork _applicationUnitOfWork;
        private readonly IMapper _mapper;

        public BookService(IApplicationUnitOfWork applicationUnitOfWork, IMapper mapper)
        {
            _applicationUnitOfWork = applicationUnitOfWork;
            _mapper = mapper;
        }

        public async Task<Guid?> CreateBookAsync(BookBO book)
        {
            var count = _applicationUnitOfWork.Books.GetCount(x => x.BookTitle == book.BookTitle);

            if (count > 0)
            {
                throw new DuplicateException("Book with same name already exists");
            }

            var entity = _mapper.Map<BookEO>(book);

            await _applicationUnitOfWork.Books.AddAsync(entity);
            await _applicationUnitOfWork.SaveAsync();

            return entity.Id;
        }

    }
}
