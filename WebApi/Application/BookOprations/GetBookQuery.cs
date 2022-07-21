using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DbOprations;
using WebApi.Entities;

namespace WebApi.Application.BookOprations
{
    public class GetBookQuery
    {
        
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;

    public GetBookQuery(IBookStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }


    public List<BookViewModel> Handle()
    {
        var bookList = _dbContext.Books.Include(x=> x.Genre)
        .Where(x=> x.IsActive == true).OrderBy(x => x.ID).ToList<Book>();
        
        List<BookViewModel> model = _mapper.Map<List<BookViewModel>>(bookList);
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