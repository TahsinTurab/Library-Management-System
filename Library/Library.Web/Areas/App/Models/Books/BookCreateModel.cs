using Autofac;
using AutoMapper;
using Library.Infrastructure.BusinessObjects;
using Library.Infrastructure.Services;
using System.ComponentModel.DataAnnotations;

namespace Library.Web.Areas.App.Models.Books
{
    public class BookCreateModel
    {
        [Required(ErrorMessage = "Title must be provided")]
        public string BookTitle { get; set; }

        [Required(ErrorMessage = "Author Name must be provided")]
        public string Author { get; set; }

        private IBookService _bookService;
        private IMapper _mapper;
        private ILifetimeScope _scope;
        private IHttpContextAccessor? _httpContextAccessor;

        public BookCreateModel()
        {

        }

        public BookCreateModel(IBookService bookService, IMapper mapper,
            IHttpContextAccessor httpContextAccessor)
        {
            _bookService = bookService;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public void ResolveDependency(ILifetimeScope scope)
        {
            _scope = scope;
            _bookService = _scope.Resolve<IBookService>();
            _mapper = _scope.Resolve<IMapper>();
            _httpContextAccessor = _scope.Resolve<IHttpContextAccessor>();
        }

        public async Task<Guid?> CreateAsync()
        {
            var book = _mapper.Map<Book>(this);

            return await _bookService.CreateBookAsync(book);
        }
    }
}
