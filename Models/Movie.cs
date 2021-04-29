using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreCrudeMovies.Models
{
    public class Movie
    {
        public int id { get; set; }
        public string Title { get; set; }

        public int Year { get; set; }

        public double? Rate { get; set; }
        
        public string StoryLine { get; set; }

        public string Poster { get; set; }

        public byte GenreId { get; set; }

        public virtual Genre Genre { get; set; }
    }
}
