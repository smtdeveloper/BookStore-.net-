using AutoMapper;
using WebApi.Application.BookOprations;
using WebApi.Application.GenreOperations.Queries;
using WebApi.Entities;

namespace WebApi.Common 
{

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel , Book>(); 

            CreateMap<  Book, BookDetailModel>()
            .ForMember(dest => dest.Genre , opt=> opt.MapFrom(src =>src.Genre.Name));
             
           CreateMap<Book , BookViewModel>()
            .ForMember(dest => dest.Genre , opt=> opt.MapFrom(src => (src.Genre.Name)));

            CreateMap<Genre , GenreViewModel>();

            CreateMap<Genre , GenreDetailViewModel>();

        }
    }


}