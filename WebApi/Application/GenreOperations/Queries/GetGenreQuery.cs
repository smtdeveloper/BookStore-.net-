using AutoMapper;
using WebApi.DbOprations;

namespace WebApi.Application.GenreOperations.Queries
{
    public class GetGenreQuery
    {
        private readonly IBookStoreDbContext _context;

        public readonly IMapper _mapper;
        public GetGenreQuery(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GenreViewModel> Handle()
        {
            var genres = _context.Genres.Where(x => x.IsActive == true).OrderBy(x => x.ID);
            List<GenreViewModel> values = _mapper.Map<List<GenreViewModel>>(genres);
            return values;
            
        }
    }

    public class GenreViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}