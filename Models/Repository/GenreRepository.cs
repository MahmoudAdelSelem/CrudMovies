using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreCrudeMovies.Models.Repository
{
    public class GenreRepository
    {
        public ApplicationDbContext db { get; set; }
        public GenreRepository(ApplicationDbContext db)
        {
            this.db = db;

        }
        public List<Genre> GetGenres()
        {
            return db.Genres.ToList();
        }
        public Genre GetById(int id)
        {
            return db.Genres.Where(n => n.id == id).FirstOrDefault();

        }

        public void Add(Genre G)
        {
            db.Genres.Add(G);
            db.SaveChanges();
        }
    }
}
