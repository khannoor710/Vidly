using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;

namespace Vidly.Controllers
{
    public class MovieController : Controller
    {


        public ActionResult Index() 
        {
            var movies = GetMovies();
            return View(movies);
        }

        private IEnumerable<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie{Id = 1, Name = "Shrek"},
                new Movie{Id = 2, Name = "Wall-e"}
            };
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