using WepApi.Common;
using WepApi.DBOperations;

namespace WepApi.BookOperations
{
    public class UpdateBookCommand
    {

        private readonly BookStoreDbContext _dbContext;
        public UpdateBookModel model {get; set;}
        public int BlogID { get; set; }


    public UpdateBookCommand(BookStoreDbContext dbContext)
    {
        _dbContext = dbContext;

    }
   
    public void Handle()
    {
         var book = _dbContext.Books.SingleOrDefault(x => x.ID == BlogID); 
            if(book == null)
               throw new InvalidOperationException("Kitap mevcut değil.");
               
               book.Title = model.Title != default ? model.Title : book.Title;
               book.GenreID = model.GenreID != default ? model.GenreID : book.GenreID;
               
               _dbContext.SaveChanges();
            
    }

    }

     public class UpdateBookModel
        {
            public int GenreID { get; set; }
            public string Title { get; set; }
        
        }
   
    
    
}