using Microsoft.EntityFrameworkCore;

namespace WepApi.DBOperations
{
    public class DataGenerator
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new BookStoreDbContext(
        serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
        {
            // Look for any book.
            if (context.Books.Any())
            {
                return;   // Data was already seeded
            }

            context.Books.AddRange(
               new Book()
               {
                   Title = "Lean C#",
                   GenreID = 1, // Backend
                   PageCount = 250,
                   PublishDate = new DateTime(2022, 07, 01)
               },
                new Book()
               {
                   Title = "Lean JavaScript",
                   GenreID = 2, //Frontend
                   PageCount = 180,
                   PublishDate = new DateTime(2022, 06, 12)
               },
               new Book()
               {
                   Title = "Lean TSQL",
                   GenreID = 3, // DataBase
                   PageCount = 45,
                   PublishDate = new DateTime(2022, 05, 10)
               }
               
               
               );

               context.Users.AddRange(
               new User()
               {
                  Name = "Rumeysa Cağlar",
                  department = "Frontend Developer",
                  City = "Sivas"
               },
                new User()
               {
                  Name = "Samet Akca",
                  department = "Backend Developer",
                  City = "Ankara"
               },
               new User()
               {
                  Name = "Burak Demirkıran",
                  department = "Muhasebe",
                  City = "Aydın"
               }
               
               
               );

            context.SaveChanges();
        }
    }
}

}