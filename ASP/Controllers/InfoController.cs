using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASP.Services;
using Newtonsoft.Json;
using ASP.Models;
using ASP.Models.ViewModels;
using Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Net.Mail;
using Microsoft.AspNetCore.Authorization;

namespace ASP.Controllers
{
    public class InfoController : Controller
    {
        IMovieServices movieServices;
        MovieDBContext _moviedb;
        UserManager<AppUser> _userManager;
        public InfoController(IMovieServices movieServices, MovieDBContext moviedb, UserManager<AppUser> userManager)
        {
            this.movieServices = movieServices;
            _moviedb = moviedb;
            _userManager = userManager;
        }
        [Authorize]
        public async Task<IActionResult> PostComment(string commentText, string id)
        {
            Comment userComment = new Comment { MovieImdbApi = id, Text = commentText, UserId = _userManager.GetUserId(User) };
            _moviedb.Add(userComment);
            await _moviedb.SaveChangesAsync();
            return RedirectToAction("Index", "Info", new { @id = id });

        }
        public async Task<IActionResult> Index(string id)
        {

            var json = await movieServices.GetByIDAsync(id);
            MovieFull movieFull = JsonConvert.DeserializeObject<MovieFull>(json);
            var commentsForMovie = _moviedb.Comments.Where(comment => comment.MovieImdbApi == id);
            List<AppUser> users = new List<AppUser>();
            foreach (var comment in commentsForMovie)
            {
                var user = await _userManager.FindByIdAsync(comment.UserId);
                users.Add(user);
            }

            MovieInfoViewModel viewModel = new MovieInfoViewModel { Movie = movieFull, comments = commentsForMovie, userEmails = users };
            return View(viewModel);
        }
    }
}
