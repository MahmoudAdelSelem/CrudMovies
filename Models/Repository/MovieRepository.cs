using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace coreCrudeMovies.Models.Repository
{
    public class MovieRepository 
    {
        public ApplicationDbContext db {get;set; }
        public MovieRepository(ApplicationDbContext db)
        {
            this.db = db;
           
        }

        public List<Movie> GetMovies()
        {
            return db.Movies.ToList();
        }
        public Movie GetById(int id)
        {
            return db.Movies.Where(n=>n.id==id).FirstOrDefault();

        }

        public void Add(Movie M)
        {
            db.Movies.Add(M);
            db.SaveChanges();
        }
        
        public void Delete(int id)
        {
            Movie m = db.Movies.Where(m => m.id == id).FirstOrDefault();
            db.Movies.Remove(m);
            db.SaveChanges();
        }

        public void Edit(Movie M)
        {   
            db.Movies.Update(M);
            db.SaveChanges();
        }
        

    }
}
