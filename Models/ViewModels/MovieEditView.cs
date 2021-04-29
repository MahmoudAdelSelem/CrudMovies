using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreCrudeMovies.Models.ViewModels
{
   
   
    public class MovieEditView
    {
        public Movie movie { get; set; }
        public IEnumerable<Genre> genres { get; set; }
        public MovieEditView()
        {

        }

        public MovieEditView(Movie m, IEnumerable<Genre> genres)
        {
            this.movie = m;
            this.genres = genres;
        }
    }
}
