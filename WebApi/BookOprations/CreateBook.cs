using WebApi.DbOprations;
using WebApi.Entities;
using WepApi.Common;

namespace WebApi.BookOprations
{
    public class CreateBook
    {
        
        private readonly BookStoreDbContext _dbContext;
        public CreateBookModel Model {get; set;}

    public CreateBook(BookStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public void Handle()
    {
        var book = _dbContext.Books.SingleOrDefault(x => x.Title == Model.Title);

        if(book != null)
        throw new InvalidOperationException("Kitap zaten mevcut");

        book = new Book();
        book.Title = Model.Title;
        book.GenreId = Model.GenreId;
        book.PageCount = Model.PageCount;
        book.PublishDate = Model.PublisDate;
        
        _dbContext.Books.Add(book);
        _dbContext.SaveChanges();
        
    }

    }

    public class CreateBookModel
    {
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int PageCount { get; set; }
        public DateTime PublisDate { get; set; }

    }

}