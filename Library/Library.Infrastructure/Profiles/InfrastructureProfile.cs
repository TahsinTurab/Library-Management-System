﻿using AutoMapper;
using BookBO = Library.Infrastructure.BusinessObjects.Book;
using BookEO = Library.Infrastructure.Entities.Book;
using EBookBO = Library.Infrastructure.BusinessObjects.EBook;
using EBookEO = Library.Infrastructure.Entities.EBook;
using BookDetailsBO = Library.Infrastructure.BusinessObjects.BookDetails;
using BookDetailsEO = Library.Infrastructure.Entities.BookDetails;

namespace Library.Infrastructure.Profiles
{
    public class InfrastructureProfile : Profile
    {
        public InfrastructureProfile()
        {
            //CreateMap<ProjectBO, ProjectEO>()
            //    .ReverseMap().ForMember(x => x.ProjectApplicationUsers, y => y.
            //    MapFrom(x => x.ProjectApplicationUsers));

            CreateMap<BookBO, BookEO>().ReverseMap();
            CreateMap<EBookBO, EBookEO>().ReverseMap();
            CreateMap<BookDetailsBO, BookDetailsEO>().ReverseMap();
        }
    }
}
