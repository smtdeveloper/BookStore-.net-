using AutoMapper;
using WebApi.DbOprations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOprations.Queries 
{
    public class GetAuthorQuery
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GetAuthorQuery(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<AuthorViewModel> Handle()
        {
            var authors = _context.Authors.OrderBy(x => x.ID).ToList();
            List<AuthorViewModel> values = _mapper.Map<List<AuthorViewModel>>(authors); 
            return values;

        }


    }

    public class AuthorViewModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

    }

}