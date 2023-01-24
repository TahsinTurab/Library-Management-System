using AutoMapper;
using Library.Infrastructure.BusinessObjects;
using Library.Web.Areas.App.Models.Books;

namespace Library.Web.Profiles
{
    public class WebProfile : Profile
    {
        public WebProfile()
        {
            CreateMap<BookCreateModel, Book>()
                .ReverseMap();

            CreateMap<EBookCreateModel, EBook>()
                .ReverseMap();
        }
    }
}
