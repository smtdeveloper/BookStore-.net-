using WebApi.DbOprations;
using WebApi.Entities;

namespace WebApi.Application.GenreOperations.Commands
{
    public class DeleteGenreCommand
    {
        public int GenreId {get; set;}
        private readonly IBookStoreDbContext _context;

        public DeleteGenreCommand(IBookStoreDbContext context)
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
        
             _context.Genres.Remove(genre);
             _context.SaveChanges();
        


        }

    }

    

}