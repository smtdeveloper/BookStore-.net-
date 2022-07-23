using System;
using WebApi.DbOprations;
using WebApi.Entities;

namespace TestSetup 
{
    public static class Books
    {
        public static void AddBooks(this BookStoreDbContext context)
        {
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
        }
    }
}