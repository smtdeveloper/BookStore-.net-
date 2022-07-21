using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOprations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOprations.Queries 
{
    public class GetAuthorDetailQuery
    {
        public AuthorDetailViewModel Model;
        public int AuthorId { get; set; }
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetAuthorDetailQuery(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public AuthorDetailViewModel Handle()
        {
            var author = _context.Authors.Include(x=> x.Book)
            .SingleOrDefault(x => x.ID == AuthorId);
            
            if(author == null)
            throw new InvalidOperationException("Yazar Bulunamadı !");

            AuthorDetailViewModel model = _mapper.Map<AuthorDetailViewModel>(author); 
            return model;

        }


    }

    public class AuthorDetailViewModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string Book { get; set; }

    }

}