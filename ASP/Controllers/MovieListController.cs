using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP.Models;
using ASP.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASP.Controllers
{
    [Authorize]
    public class MovieListController : Controller
    {
        
        private MovieDBContext _movieDB;
        private UserManager<AppUser> _userManager;

        public MovieListController( UserManager<AppUser> userManager, MovieDBContext movieDB)
        {
            _userManager = userManager;
            _movieDB = movieDB;
        }
        public IActionResult Index()
        {
            return View(_movieDB.Movies.Where(movie => movie.UserId ==_userManager.GetUserId(User)));
        }
        public async Task<IActionResult> Update(int score, string id)
        {
            Movie movie = await _movieDB.Movies.FirstOrDefaultAsync(m => m.Id == id);
            movie.Rating = score;
            _movieDB.Update(movie);
            await _movieDB.SaveChangesAsync();
            return RedirectToAction("Index");


        }
        public async Task<IActionResult> Delete(string id)
        {
            Movie movie = await _movieDB.Movies.FirstOrDefaultAsync(m => m.Id == id);
            _movieDB.Remove(movie);
            await _movieDB.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Add(MovieDTO movieDTO)
        {
            Movie movie = new Movie { imdbID = movieDTO.imdbID, Poster = movieDTO.Poster, Title = movieDTO.Title, UserId = _userManager.GetUserId(User), Year = movieDTO.Year, Rating = null };
            _movieDB.Add(movie);
            await _movieDB.SaveChangesAsync();
            return RedirectToAction("Index", "Search");
        }
    }
}
