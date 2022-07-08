using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DbOprations
 {

    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if(context.Books.Any())
                {
                    return;
                }

                context.Books.AddRange(

                    new Book{
                        // ID = 1,
                        Title = "Lean .net core 6",
                        GenreId = 1,
                        PageCount = 300,
                        PublishDate = new DateTime(2022,07,07)
                    },
                       new Book{
                        // ID = 1,
                        Title = "Lean Js",
                        GenreId = 2,
                        PageCount = 150,
                        PublishDate = new DateTime(2021,06,11)
                    },
                       new Book{
                        // ID = 1,
                        Title = "Lean .TSQL",
                        GenreId = 3,
                        PageCount = 50,
                        PublishDate = new DateTime(2020,05,010)
                    } 

                    );

                    context.SaveChanges();
                    
            }
        }
    }

 }