using AutoMapper;
using WebApi.DbOprations;
using WebApi.Entities;

namespace WebApi.Application.BookOprations
{
    public class UpdateBook
    {
        
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        
        public int BookID { get; set; } 
        public UpdateBookModel Model {get; set;}

    public UpdateBook(IBookStoreDbContext dbContext , IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public void Handle()
    {
        var book = _dbContext.Books.SingleOrDefault(x => x.ID == BookID);

        if(book == null)
        throw new InvalidOperationException("Kitap Bulunamadı !");

        _mapper.Map<UpdateBookModel , Book>(Model , book);

        _dbContext.SaveChanges();

    }


    }
    
    public class UpdateBookModel
    {
        public int GenreID { get; set; }
        public string Title { get; set; }
        
    }
}