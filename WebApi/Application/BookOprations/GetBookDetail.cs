using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOprations;
using WebApi.Entities;

namespace WebApi.Application.BookOprations
{
    public class GetBookDetail
    {
        
        public int BookID { get; set; }
        public BookDetailModel Model {get; set;}

        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

    public GetBookDetail(IBookStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public BookDetailModel Handle()
    {
        var book = _dbContext.Books.Include(x=> x.Genre)
        .SingleOrDefault(x => x.ID == BookID && x.IsActive == true);

        if(book == null)
        throw new InvalidOperationException("Kitap Bulunamadı !");

        BookDetailModel model = _mapper.Map<BookDetailModel>(book);      

        return model;

    }

        public override bool Equals(object? obj)
        {
            return obj is GetBookDetail detail &&
                   EqualityComparer<IMapper>.Default.Equals(_mapper, detail._mapper);
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