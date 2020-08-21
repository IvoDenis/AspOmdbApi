using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.Services;
using Microsoft.AspNetCore.Mvc;

namespace ASP.Controllers
{
    public class MovieListController : Controller
    {
        private readonly IMovieListRepository movieList;

        public MovieListController(IMovieListRepository movieList)
        {
            this.movieList = movieList;
        }
        public IActionResult Index()
        {
            return View(movieList.All);
        }
        public IActionResult Delete(string id)
        {
            movieList.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
