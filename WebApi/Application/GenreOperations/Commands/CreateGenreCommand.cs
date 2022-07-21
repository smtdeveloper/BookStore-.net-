using WebApi.DbOprations;
using WebApi.Entities;

namespace WebApi.Application.GenreOperations.Commands
{
    public class CreateGenreCommand
    {
        public CreateGenreModel Model {get; set;}
        private readonly IBookStoreDbContext _context;

        public CreateGenreCommand(IBookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.Name == Model.Name);
            if(genre != null) 
            {
                throw new InvalidOperationException("Kiptap türü zaten mevcut");
            }

            genre = new Genre();
            genre.Name = Model.Name;
            _context.Genres.Add(genre);
            _context.SaveChanges();
            
        }

    }

    public class CreateGenreModel
    {
        public string Name { get; set; }
    }

}