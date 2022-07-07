using WepApi.Common;
using WepApi.DBOperations;

namespace WepApi.BookOperations
{
     public class GetBookDetailQuery
    {
        private readonly BookStoreDbContext _dbContext;
        public int BlogID { get; set; }

        public GetBookDetailQuery(BookStoreDbContext dbContext)
        {
            _dbContext =  dbContext;
        }

        public BookDetailViewModel Handle() 
        {

          var book = _dbContext.Books.Where(book => book.ID == BlogID).SingleOrDefault();

            if(book == null)
             throw new InvalidOperationException(" Kitap Bulunamadı ! ");

             BookDetailViewModel model = new BookDetailViewModel();
             model.Title = book.Title;
             model.PageCount = book.PageCount;
             model.Genre = ((GenreEnum)book.GenreID).ToString();
             model.PublishDate =book.PublishDate.Date.ToString("dd/MM/yyyy");
             

            return model;  
        }


    }

    public class BookDetailViewModel
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }

    }

}