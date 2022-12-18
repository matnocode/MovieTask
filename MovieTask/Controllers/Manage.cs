using Microsoft.AspNetCore.Mvc;
using MovieTask.Data;
using MovieTask.Models;
using System.Collections.Generic;

namespace MovieTask.Controllers
{
    public class Manage : Controller
    {
        readonly MovieDbContext _context;
        public string SearchValue;
        public DateTime Released;
        public bool Comedy;
        public bool Drama;
        public bool Action;
        public Manage(MovieDbContext context)
        {
            _context = context;
        }
        public IActionResult Add()
        {
            return View(new ManageMovieModel());
        }

        public IActionResult OnAdd(ManageMovieModel movie)
        {
            var mv = movie.GetMovie();
            //ADD to db
            if (!String.IsNullOrWhiteSpace(mv.Title) && !String.IsNullOrWhiteSpace(mv.Description))
            {
                if (string.IsNullOrEmpty(mv.Poster))
                    mv.Poster = "https://motivatevalmorgan.com/wp-content/uploads/2016/06/default-movie-768x1129.jpg";
                _context.Add(mv);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return StatusCode(501, movie.Title == null);
            }
        }
        public IActionResult Edit(int id)
        {
            var movie = _context.movies.Find(id);
            return View("Edit", movie);
        }
        [HttpPost]
        public IActionResult OnEdit(MovieModel movie)
        {
            _context.movies.Remove(_context.movies.Find(movie.Id));
            _context.movies.Add(movie);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult DeleteEntry(int id)
        {
            // return StatusCode(500, new MovieModel() { Id = id });
            try
            {
                _context.Remove(new MovieModel() { Id = id });
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return StatusCode(500);
            }
        }
        public IActionResult Search()
        {
            return View("Search");
        }

        public IActionResult OnSearch(SearchMovieModel searchMovie)
        {
            //search for movies
            List<MovieModel> allMovies = _context.movies.ToList();
            List<MovieModel> foundMovies = new List<MovieModel>();
            bool match = false;
            bool year = false;
            //return StatusCode(500, string.IsNullOrWhiteSpace(searchMovie.Year) + "<--- year");
            //year is not specified
            if (string.IsNullOrWhiteSpace(searchMovie.Year))
                year = true;

            foreach (var movie in allMovies)
            {
                //implement similar matches 
                if (!String.IsNullOrEmpty(searchMovie.SearchTitle))
                {
                    if (movie.Title.ToLower() == searchMovie.SearchTitle.ToLower())
                        foundMovies.Add(movie);

                }


                if (movie.Released.Year.ToString() == searchMovie.Year)
                    year = true;


                //must contain genre specified to be rendered
                if (!String.IsNullOrEmpty(searchMovie.Genre))
                {
                    foreach (var dbmovieGenre in movie.Genre.Split(','))
                    {

                        //return StatusCode(500, dbmovieGenre + "<--- dbmovieGenres");
                        foreach (var searchMovieGenre in searchMovie.Genre.Split(','))
                        {
                            if (dbmovieGenre.ToLower() == searchMovieGenre.ToLower())
                            {
                                match = true;
                            }
                        }
                    }
                }

                if (year && match && foundMovies.Contains(movie) == false)
                    foundMovies.Add(movie);

                match = false;
                //need to check for year again
                if (!string.IsNullOrWhiteSpace(searchMovie.Year))
                    year = false;

            }   
            return View("SearchResults", foundMovies);
        }

    }
}
