using WebApi.DbOprations;
using WebApi.Entities;

namespace WebApi.Application.BookOprations
{
    public class UpdateBook
    {
        
        private readonly IBookStoreDbContext _dbContext;
        public int BlogID { get; set; } 
        public UpdateBookModel Model {get; set;}

    public UpdateBook(IBookStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Handle()
    {
        var book = _dbContext.Books.SingleOrDefault(x => x.ID == BlogID);

        if(book == null)
        throw new InvalidOperationException("Kitap Bulunamadı ! ");

       book.GenreId =Model.GenreID != default ? Model.GenreID : book.GenreId;
       book.Title =Model.Title != default ? Model.Title : book.Title;
       
        _dbContext.SaveChanges();

    }


    }
    
    public class UpdateBookModel
    {
        public int GenreID { get; set; }
        public string Title { get; set; }
        
    }
}