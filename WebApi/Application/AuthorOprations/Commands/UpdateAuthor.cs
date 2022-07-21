using WebApi.DbOprations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOprations
{
    public class UpdateAuthor
    {
        
        private readonly IBookStoreDbContext _dbContext;
        public int AuthorID { get; set; } 
        public UpdateAuthorModel Model {get; set;}

    public UpdateAuthor(IBookStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Handle()
    {
        var author = _dbContext.Authors.SingleOrDefault(x => x.ID == AuthorID);

        if(author == null)
        throw new InvalidOperationException("Yazar Bulunamadı ! ");

       author.BookId =Model.BookId != default ? Model.BookId : author.BookId;
       author.Name =Model.Name != default ? Model.Name : author.Name;
       author.LastName =Model.LastName != default ? Model.LastName : author.LastName;
       
        _dbContext.SaveChanges();

    }


    }
    
    public class UpdateAuthorModel
    {
        public int BookId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        
    }
}