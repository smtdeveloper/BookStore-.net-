using WebApi.DbOprations;
using WebApi.Entities;
using WepApi.Common;

namespace WebApi.BookOprations.GetBookQuery
{
    public class GetBookQuery
    {
        
        private readonly BookStoreDbContext _dbContext;

    public GetBookQuery(BookStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public List<BookViewModel> Handle()
    {
        var bookList = _dbContext.Books.OrderBy(x => x.ID).ToList<Book>();
        List<BookViewModel> model = new List<BookViewModel>();
        foreach (var book in bookList)
        {
            model.Add(new BookViewModel()
            {
                Title = book.Title,
                Genre = ((GenreEnum)book.GenreId).ToString(),
                PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy"),
                PageCount = book.PageCount,
                Id = book.ID
            }
            );
        } 
        return model;
    }

    }


    public class BookViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } 
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
    }

 
}