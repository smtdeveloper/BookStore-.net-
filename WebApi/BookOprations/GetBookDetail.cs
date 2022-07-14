using AutoMapper;
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
        private readonly IMapper _mapper;

    public GetBookDetail(BookStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public BookDetailModel Handle()
    {
        var book = _dbContext.Books.SingleOrDefault(x => x.ID == BlogID);

        if(book == null)
        throw new InvalidOperationException("Kitap Bulunamadı ! ");

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