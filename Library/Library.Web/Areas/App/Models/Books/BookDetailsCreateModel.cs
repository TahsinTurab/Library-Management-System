using Autofac;
using Library.Infrastructure.BusinessObjects;
using Library.Infrastructure.Services;

namespace Library.Web.Areas.App.Models.Books
{
    public class BookDetailsCreateModel
    {
        public List<int> BookDetailsId { get; set; }
        public Guid BookId { get; set; }
        public string BookTitle { get; set; }

        private IBookDetailsService _bookDetailsService;
        private ILifetimeScope _scope;

        public BookDetailsCreateModel()
        {

        }

        public BookDetailsCreateModel(IBookDetailsService bookDetailsService)
        {
            _bookDetailsService = bookDetailsService;
        }

        public void ResolveDependency(ILifetimeScope scope)
        {
            _scope = scope;
            _bookDetailsService = _scope.Resolve<IBookDetailsService>();
        }

        public async Task CreateBookDetailsAsync(Guid BookId)
        {
            foreach(var id in BookDetailsId)
            {
                if(id != null)
                {
                    var bookDetails = new BookDetails();
                    bookDetails.BookId = BookId;
                    bookDetails.IsBorrowed = false;

                    await _bookDetailsService.CreateBookDetailsAsync(bookDetails);
                }
            }
        }
    }
}