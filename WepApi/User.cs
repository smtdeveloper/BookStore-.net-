using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WepApi
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID {get; set;}
        public string Name {get; set;}
        public string department {get; set;}
        public string City {get; set;}


    }
}