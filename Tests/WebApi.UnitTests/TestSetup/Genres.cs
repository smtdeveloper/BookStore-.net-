using System;
using WebApi.DbOprations;
using WebApi.Entities;

namespace TestSetup 
{
    public static class Genres
    {
        public static void AddGenres(this BookStoreDbContext context)
        {
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
        }
    }
}