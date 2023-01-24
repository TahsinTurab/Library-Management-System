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
            var count = _applicationUnitOfWork.EBooks.GetCount(x => x.Title == ebook.Title);

            if (count > 0)
            {
                throw new DuplicateException("Book with same name already exists");
            }

            var entity = _mapper.Map<EBookEO>(ebook);

            await _applicationUnitOfWork.EBooks.AddAsync(entity);
            await _applicationUnitOfWork.SaveAsync();
        }

        public (IList<EBookBO> records, int total, int totalDisplay) GetBooks(int pageIndex,
            int pageSize, string searchText, string orderby)
        {
            (IList<EBookEO> records, int total, int totalDisplay) results = _applicationUnitOfWork
                .EBooks.GetBooks(pageIndex, pageSize, searchText, orderby);

            IList<EBookBO> books = new List<EBookBO>();

            foreach (var item in results.records)
            {
                books.Add(_mapper.Map<EBookBO>(item));
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
