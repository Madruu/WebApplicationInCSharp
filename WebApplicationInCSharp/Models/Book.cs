using System;

namespace WebApplicationInCSharp.Models
{
    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; } = null!; //Not gonna be null at runtime
        public string Author { get; set; } = null!; //Not gonna be null at runtime
        public int YearPublished { get; set; }
    }
}
