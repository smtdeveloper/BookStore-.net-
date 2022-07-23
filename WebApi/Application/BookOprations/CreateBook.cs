using AutoMapper;
using WebApi.DbOprations;
using WebApi.Entities;

namespace WebApi.Application.BookOprations
{
    public class CreateBook
    {
        
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateBookModel Model {get; set;}

    public CreateBook(IBookStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        
    }


    public void Handle()
    {
        var book = _dbContext.Books.SingleOrDefault(x => x.Title == Model.Title);

        if(book != null)
        throw new InvalidOperationException("Kitap zaten mevcut.");

        book = _mapper.Map<Book>(Model);
        
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