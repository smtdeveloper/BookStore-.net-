using AutoMapper;
using WebApi.Application.AuthorOprations;
using WebApi.Application.AuthorOprations.Queries;
using WebApi.Application.BookOprations;
using WebApi.Application.GenreOperations.Queries;
using WebApi.Application.UserOperations.Commands;
using WebApi.Application.UserOperations.Queries;
using WebApi.Entities;

namespace WebApi.Common 
{

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateBookModel , Book>(); 

            CreateMap<Book, BookDetailModel>()
            .ForMember(dest => dest.Genre , opt=> opt.MapFrom(src =>src.Genre.Name));
             
           CreateMap<Book , BookViewModel>()
            .ForMember(dest => dest.Genre , opt=> opt.MapFrom(src =>src.Genre.Name));

            CreateMap<Genre , GenreViewModel>();

            CreateMap<Genre , GenreDetailViewModel>();

            CreateMap<Author , AuthorViewModel>();

            CreateMap<Author , AuthorDetailViewModel>()
            .ForMember(dest => dest.Book , opt=> opt.MapFrom(src => src.Book.Title));

            CreateMap<CreateAuthorModel, Author>();

            CreateMap<UpdateBookModel , Book >();

            // CreateMap<CreateUserModel, User>()
            // .ForMember(x => x.IsActive , mopt=> mopt.MapFrom(y => true));
            
            
            CreateMap<User , GetUsersQuery>();
            CreateMap<User , GetDetailUserQuery>();
            CreateMap<UpdateUserModel, User>();
            CreateMap<CreateBookModel , User>();
            

        }
    }


}