using AutoMapper;
using WebApi.DbOprations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOprations
{
    public class CreateAuthor
    {
        
        private readonly IBookStoreDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateAuthorModel Model {get; set;}

    public CreateAuthor(IBookStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        
    }


    public void Handle()
    {
        var author = _dbContext.Authors.SingleOrDefault(x => x.Name == Model.Name);

        if(author != null)
        throw new InvalidOperationException("Yazar zaten mevcut");

        author = _mapper.Map<Author>(Model);
        
        _dbContext.Authors.Add(author);
        _dbContext.SaveChanges();
        
    }

    }

    public class CreateAuthorModel
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime PublisDate { get; set; }

    }

}