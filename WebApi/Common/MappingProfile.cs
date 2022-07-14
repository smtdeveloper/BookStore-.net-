using AutoMapper;
using WebApi.BookOprations;
using WebApi.BookOprations.GetBookQuery;
using WebApi.Entities;
using WepApi.Common;

namespace WebApi.Common 
{

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel , Book>(); 

            CreateMap<  Book, BookDetailModel>()
            .ForMember(dest => dest.Genre , opt=> opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));
             
           CreateMap<Book , BookViewModel>()
            .ForMember(dest => dest.Genre , opt=> opt.MapFrom(src => ((GenreEnum)src.GenreId).ToString()));

        }
    }


}