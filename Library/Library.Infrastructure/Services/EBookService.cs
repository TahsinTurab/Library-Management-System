using AutoMapper;
using Library.Infrastructure.Exceptions;
using Library.Infrastructure.UnitOfWorks;
using EBookBO = Library.Infrastructure.BusinessObjects.EBook;
using EBookEO = Library.Infrastructure.Entities.EBook;

namespace Library.Infrastructure.Services
{
    public class EBookService : IEBookService
    {
        private readonly IApplicationUnitOfWork _applicationUnitOfWork;
        private readonly IMapper _mapper;

        public EBookService(IApplicationUnitOfWork applicationUnitOfWork, IMapper mapper)
        {
            _applicationUnitOfWork = applicationUnitOfWork;
            _mapper = mapper;
        }

        public async Task CreateEBookAsync(EBookBO ebook)
        {
            var count = _applicationUnitOfWork.Books.GetCount(x => x.BookTitle == ebook.BookTitle);

            if (count > 0)
            {
                throw new DuplicateException("Book with same name already exists");
            }

            var entity = _mapper.Map<EBookEO>(ebook);

            await _applicationUnitOfWork.EBooks.AddAsync(entity);
            await _applicationUnitOfWork.SaveAsync();
        }

    }
}
