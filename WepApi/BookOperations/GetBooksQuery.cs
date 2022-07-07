using WepApi.Common;
using WepApi.DBOperations;

namespace WepApi.BookOperations
{

    public class GetBooksQuery
    {
        private readonly BookStoreDbContext _dbContext;
        public int BlogID { get; set; }
        public GetBooksQuery(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<BooksViewModel> Handle()
        {
             var bookList = _dbContext.Books.OrderBy(x => x.ID).ToList<Book>();
             List<BooksViewModel> model = new List<BooksViewModel>();
             foreach (var book in bookList)
             {
                model.Add(new BooksViewModel(){
                    Title = book.Title,
                    Genre = ((GenreEnum)book.GenreID).ToString(),
                    PageCount = book.PageCount,
                    PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy"),

                });
             }
            return model;
        }

    }

    public class BooksViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
        

    }

}