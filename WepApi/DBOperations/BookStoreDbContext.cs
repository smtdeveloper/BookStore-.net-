using Microsoft.EntityFrameworkCore;

namespace WepApi.DBOperations{

public class BookStoreDbContext : DbContext
{
    public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
    {
        
    }
    public DbSet<Book> Books { get; set; }
    public DbSet<User> Users {get; set;}
  
}

}
