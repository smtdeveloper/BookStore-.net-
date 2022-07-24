using WebApi.DbOprations;
using WebApi.Entities;

namespace WebApi.Application.BookOprations
{
    public class DeleteBook
    {
        
        private readonly IBookStoreDbContext _dbContext;
      
        public int BookID { get; set; }

    public DeleteBook(IBookStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Handle()
    {
        var book = _dbContext.Books.SingleOrDefault(x => x.ID == BookID);

        if(book == null)
        throw new InvalidOperationException("Kitap Bulunamadı !");

        _dbContext.Books.Remove(book);
        _dbContext.SaveChanges();
        
    }

    }

  
    
}
