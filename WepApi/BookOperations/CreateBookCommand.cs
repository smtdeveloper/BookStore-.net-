using WepApi.Common;
using WepApi.DBOperations;

namespace WepApi.BookOperations
{

    public class CreateBookCommand
    {
        public CreateBookModel model {get; set;}
        private readonly BookStoreDbContext _dbContext;

        public CreateBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = _dbContext;
        }
        
        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.Title == model.Title);
            if(book != null)
               throw new InvalidOperationException("Kitap zaten mevcut.");

               book = new Book();
               book.Title = model.Title;
               book.GenreID = model.GenreID;
               book.PublishDate = model.PublishDate;
               book.PageCount = model.PageCount;

            _dbContext.Books.Add(book);
            _dbContext.SaveChanges();
        }

       

    }
    
     public class CreateBookModel
        {
            public string Title { get; set; }
            public int GenreID { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }         

        }

    }