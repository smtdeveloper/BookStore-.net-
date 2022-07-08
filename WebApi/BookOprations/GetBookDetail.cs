using WebApi.DbOprations;
using WebApi.Entities;
using WepApi.Common;

namespace WebApi.BookOprations
{
    public class GetBookDetail
    {
        
        public int BlogID { get; set; }
        public BookDetailModel Model {get; set;}

        private readonly BookStoreDbContext _dbContext;

    public GetBookDetail(BookStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public BookDetailModel Handle()
    {
        var book = _dbContext.Books.SingleOrDefault(x => x.ID == BlogID);

        if(book == null)
        throw new InvalidOperationException("Kitap Bulunamadı ! ");

        BookDetailModel model = new BookDetailModel();
        model.Title = book.Title;
        model.PageCount = book.PageCount;
        model.PublishDate = book.PublishDate.Date.ToString("dd/MM/yyyy");
        model.Genre = ((GenreEnum)book.GenreId).ToString();

        return model;

    }

    }

    public class BookDetailModel
    {
        public string Genre { get; set; }
        public string  Title { get; set; }  
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        
    }
}