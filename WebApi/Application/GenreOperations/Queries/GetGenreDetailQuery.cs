using AutoMapper;
using WebApi.DbOprations;

namespace WebApi.Application.GenreOperations.Queries
{
    public class GetGenreDetailQuery
    {
        public int GenreId {get; set;}
        private readonly IBookStoreDbContext _context;
        public readonly IMapper _mapper;
        public GetGenreDetailQuery(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GenreDetailViewModel Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.IsActive == true && x.ID == GenreId);
           
            if(genre == null)
            throw new InvalidOperationException("Kitap türü bulunamadı");
            
           GenreDetailViewModel value = _mapper.Map<GenreDetailViewModel>(genre);
           return value;
            
        }
    }

    public class GenreDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}