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

            context.Users.AddRange(
                    new User 
                    {
                       Name = "Samet",
                       LastName = "Akca",
                       Email = "smtakca@gmail.com",
                       Password = "123456"
                    }

                );


            

                context.Authors.AddRange(
                    new Author 
                    {
                        Name = "Samet",
                        LastName = "Akca",
                        DateOfBirth = new DateTime(1999,06,07),
                        BookId = 1

                    
                    },
                    new Author 
                    {
                        Name = "Rumeysa",
                        LastName = "Çaglar",
                        DateOfBirth = new DateTime(1999,11,24),
                        BookId = 2
                        
                    },
                    new Author 
                    {
                        Name = "Burak",
                        LastName = "Demirkıran",
                        DateOfBirth = new DateTime(1999,10,24),
                        BookId = 3
                        
                    }

                );

                context.Genres.AddRange(
                    new Genre
                    {
                        Name = "Backend "
                    },
                    new Genre
                    {
                        Name = "Frontend "
                    },
                    new Genre
                    {
                        Name = "DataBase"
                    }
                );

                context.Books.AddRange(

                    new Book{
                        // ID = 1,
                        Title = "Lean .net core 6",
                        GenreId = 1,
                        PageCount = 300,
                        PublishDate = new DateTime(2022,07,07),
                        IsActive = true
                    },
                       new Book{
                        // ID = 2,
                        Title = "Lean Js",
                        GenreId = 2,
                        PageCount = 150,
                        PublishDate = new DateTime(2021,06,11),
                        IsActive = true
                    },
                       new Book{
                        // ID = 3,
                        Title = "Lean .TSQL",
                        GenreId = 3,
                        PageCount = 50,
                        PublishDate = new DateTime(2020,05,010),
                        IsActive = true
                    } 

                    );

                    context.SaveChanges();
                    
            }
        }
    }

 }