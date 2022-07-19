using WebApi.DbOprations;
using WebApi.Entities;

namespace WebApi.Application.BookOprations
{
    public class DeleteBook
    {
        
        private readonly BookStoreDbContext _dbContext;
      
        public int BlogID { get; set; }

    public DeleteBook(BookStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Handle()
    {
        var book = _dbContext.Books.SingleOrDefault(x => x.ID == BlogID);

        if(book == null)
        throw new InvalidOperationException("Kitap Bulunamadı ! ");

        _dbContext.Books.Remove(book);
        _dbContext.SaveChanges();
        
    }

    }

  
    
}
