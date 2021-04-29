using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
namespace coreCrudeMovies.Models.ViewModels
{
    public class MovieViewModel 
    {
           

        
        [Required , StringLength(250)]
        
        public string Title { get; set; }

        public int Year { get; set; }
        [Range(1,10)]
        public double? Rate { get; set; }

        public string StoryLine { get; set; }

        public string Poster { get; set; }
        [Display(Name ="Genre") ]
        public byte GenreId { get; set; }

        public IEnumerable<Genre> genres { get; set; }
    }
}
