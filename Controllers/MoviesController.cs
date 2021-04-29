using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreCrudeMovies.Models.Repository;
using coreCrudeMovies.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using coreCrudeMovies.Models;

namespace coreCrudeMovies.Controllers
{
    
    public class MoviesController : Controller
    {
       public MovieRepository movieRepository { get; set; }
       public GenreRepository genreRepository { get; set; }
       public MovieViewModel movieView { get; set; }
        public MovieEditView movieEditView { get; set; }
       private IWebHostEnvironment _hostEnvironment;

        public MoviesController( MovieRepository m, GenreRepository  g ,MovieViewModel mv , IWebHostEnvironment environment ,MovieEditView movieEdit)
        {
            this.movieRepository = m;
            this.genreRepository = g;
            this.movieView = mv;
            this._hostEnvironment = environment;
            this.movieEditView = movieEdit;
        }
        public IActionResult Index()
        {
            
            return View(movieRepository.GetMovies());
        }
        [HttpGet]
        public IActionResult Create()
        {
            movieView.genres = genreRepository.GetGenres().OrderBy(n=>n.Name);

            return View(movieView);
        }
        [HttpPost()]
        public IActionResult Create(MovieViewModel mv,Models.Movie m, IFormFile img)
        {
            m.Title = mv.Title;
            m.Year = mv.Year;
            m.StoryLine = mv.StoryLine;
            m.Rate = mv.Rate;
            string filepath = Path.Combine($"{_hostEnvironment.WebRootPath}/images", img.FileName);
            var stream = new FileStream(filepath, FileMode.Create);
            m.Poster = img.FileName;
            movieRepository.Add(m);
            return RedirectToAction("index");
        }

        public IActionResult Delete(int id)
        {
            movieRepository.Delete(id);
            ViewBag.removed = true;
            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult Edit(int id )
        {
            movieEditView.movie = movieRepository.GetById(id);
            movieEditView.genres = genreRepository.GetGenres();
            return View(movieEditView);
        }
        [HttpPost]
        public IActionResult Edit(MovieEditView me, IFormFile img , Models.Movie m)
        {
            
            m = me.movie;
            if (img.FileName.Length > 0)
            {
                m.Poster = img.FileName;
            }            
            movieRepository.Edit(m);

            return RedirectToAction("index");

        }
    }
}
