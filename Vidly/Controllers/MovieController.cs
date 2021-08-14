using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {

        private ApplicationDbContext _context;
        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var genre = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Genres = genre
            };

            return View("MovieForm", viewModel);
        }

        public ActionResult Edit(int id) 
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }

        public ActionResult Save(Movie movie) 
        {
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.Name = movie.Name;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Movie");
        }

        public ActionResult Index() 
        {
            var movies = _context.Movies.Include(m=>m.Genre).ToList();
            return View(movies);
        }

        public ActionResult Details(int id) 
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(x => x.Id == id);
            return View(movie);
        }        


        // GET: Movie
        public ActionResult Random()
        {
            var movie = new Movie { Name = "Shrek" };

            var customers = new List<Customer>()
            {
                new Customer{Name="John Smith"},
                new Customer{Name="Mary Williams"}
            };

            RandomMovieViewModel randomMovieViewModel = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers
            };

            return View(randomMovieViewModel);
        }

        //[Route("movie/edit/{id}")]
        //public ActionResult Edit(int id) 
        //{
        //    return Content("Id is: "+id);
        //}

        //[Route("movie/releasebydate/{year:regex(2012|2013)}/{month:regex(\\d{2}):range(1,12)}")]
        //public ActionResult ReleaseByDate(int year, int month) 
        //{
        //    return Content($"Year is {year} and month is {month} ");
        //}
    }
}