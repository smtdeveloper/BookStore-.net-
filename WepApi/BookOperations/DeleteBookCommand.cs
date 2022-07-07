using WepApi.Common;
using WepApi.DBOperations;

namespace WepApi.BookOperations
{
    public class DeleteBookCommand
    {
        private readonly BookStoreDbContext _dbContext;
        public int BlogID { get; set; }
        public DeleteBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public void Handle()
        {
            var book =  _dbContext.Books.SingleOrDefault(x => x.ID == BlogID);
            if(book == null) 
            throw new InvalidOperationException("Kitap mevcut değil.");
            
            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();

        }

        
    }

}