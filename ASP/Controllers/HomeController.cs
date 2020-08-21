using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASP.Services;
using ASP.Models;
using Newtonsoft.Json;
using ASP.Models.ViewModels;

namespace ASP
{
    public class SearchController : Controller
    {
        private readonly IMovieServices movieServices;
        private readonly IMovieListRepository movieList;

        public SearchController(IMovieServices movieServices, IMovieListRepository movieList)
        {
            this.movieServices = movieServices;
            this.movieList = movieList;
        }
        public async Task<IActionResult> Index(string search, int page = 1)
        {
            SearchResult searchResult = new SearchResult();

            string json = await movieServices.SearchDataAsync(search, page);
            searchResult = JsonConvert.DeserializeObject<SearchResult>(json);
            PagingInfo paging = new PagingInfo(searchResult.totalResults, page);
            MovieViewModel viewModel = new MovieViewModel
            {
                pagingInfo = paging,
                movies = searchResult.Search,
                Query = search
            };
            return View(viewModel);
        }
      
        public IActionResult Add(Movie movie)
        {
            movieList.Add(movie);
            return RedirectToAction("Index");
        }
    }
}
