using WebApi.DbOprations;
using WebApi.Entities;

namespace WebApi.Application.GenreOperations.Commands
{
    public class UpdateGenreCommand
    {
        public int GenreId { get; set; }
        public UpdateGenreModel Model {get; set;}
        private readonly IBookStoreDbContext _context;

        public UpdateGenreCommand(IBookStoreDbContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var genre = _context.Genres.SingleOrDefault(x => x.ID == GenreId);

            if(genre == null) 
            {
                throw new InvalidOperationException("Kiptap türü Bulunamadı");
            }
            if(_context.Genres.Any(x => x.Name.ToLower() == Model.Name.ToLower() && x.ID != GenreId ))
            {
                throw new InvalidOperationException("Aynı isimde bir kitap türü mevcut");
            }

             genre.Name = string.IsNullOrEmpty(Model.Name.Trim()) ? genre.Name : Model.Name;
             genre.IsActive = Model.IsActive;

            _context.SaveChanges();
            
        }

    }

    public class UpdateGenreModel
    {
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;
    }

}