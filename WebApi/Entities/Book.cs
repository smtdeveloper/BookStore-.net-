using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Entities
{

    public class Book{
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Title { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
        public bool IsActive { get; set; } = true;

        public Author Author {get; set;}

    }

}