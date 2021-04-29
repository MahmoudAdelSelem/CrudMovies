using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace coreCrudeMovies.Models
{
    public class Genre
    {
        
        public byte id { get; set; }
       
        public string Name { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
