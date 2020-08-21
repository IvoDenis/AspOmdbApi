using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASP.Services;
using Newtonsoft.Json;
using ASP.Models;

namespace ASP.Controllers
{
    public class InfoController : Controller
    {
        IMovieServices movieServices;

        public InfoController(IMovieServices movieServices)
        {
            this.movieServices = movieServices;
        }
        public async Task<IActionResult> Index(string id)
        {
           
            var json = await movieServices.GetByIDAsync(id);
            MovieFull movieFull = JsonConvert.DeserializeObject<MovieFull>(json);
            return View(movieFull);
        }
    }
}
