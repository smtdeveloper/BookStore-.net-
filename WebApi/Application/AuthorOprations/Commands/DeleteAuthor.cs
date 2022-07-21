using WebApi.DbOprations;
using WebApi.Entities;

namespace WebApi.Application.AuthorOprations
{
    public class DeleteAuthor
    {
        
        private readonly IBookStoreDbContext _dbContext;
      
        public int AuthorID { get; set; }

    public DeleteAuthor(IBookStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void Handle()
    {
        var author = _dbContext.Authors.SingleOrDefault(x => x.ID == AuthorID);

        if(author == null)
        throw new InvalidOperationException("Yazar Bulunamadı ! ");

        _dbContext.Authors.Remove(author);
        _dbContext.SaveChanges();
        
    }

    }

  
    
}
