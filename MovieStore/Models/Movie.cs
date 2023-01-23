using System;

namespace MovieStore.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string MovieName { get; set; }
        public string ProductionName { get; set; }
       
        public DateTime ReleaseDate { get; set; }

        //Navigation
        public Genre Genre { get; set; }

        //ForeignKey
        public int GenreId { get; set; }
    }
}
