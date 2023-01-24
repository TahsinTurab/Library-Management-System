using Autofac;
using AutoMapper;
using Library.Infrastructure.BusinessObjects;
using Library.Infrastructure.Services;
using System.ComponentModel.DataAnnotations;

namespace Library.Web.Areas.App.Models.Books
{
    public class EBookCreateModel
    {
        [Required(ErrorMessage = "Title must be provided")]
        public string BookTitle { get; set; }

        [Required(ErrorMessage = "Author Name must be provided")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Author Name must be provided")]
        public string BookLink { get; set; }

        private IEBookService _ebookService;
        private IMapper _mapper;
        private ILifetimeScope _scope;
        private IHttpContextAccessor? _httpContextAccessor;

        public EBookCreateModel()
        {

        }

        public EBookCreateModel(IEBookService ebookService, IMapper mapper,
            IHttpContextAccessor httpContextAccessor)
        {
            _ebookService = ebookService;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public void ResolveDependency(ILifetimeScope scope)
        {
            _scope = scope;
            _ebookService = _scope.Resolve<IEBookService>();
            _mapper = _scope.Resolve<IMapper>();
            _httpContextAccessor = _scope.Resolve<IHttpContextAccessor>();
        }

        public async Task CreateAsync()
        {
            var ebook = _mapper.Map<EBook>(this);

            await _ebookService.CreateEBookAsync(ebook);
        }
    }
}
