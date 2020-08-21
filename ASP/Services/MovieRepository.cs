using ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.Services
{
    public class MovieRepository : IMovieListRepository
    {
        private List<Movie> _toWatchList = new List<Movie>();
        public IEnumerable<Movie> All => _toWatchList;

        public void Add(Movie item)
        {
            if (_toWatchList.Any(p=>p.imdbID==item.imdbID)==false)
            _toWatchList.Add(item) ;
        }

        public void Delete(string movieId)
        {
            _toWatchList.Remove(_toWatchList.First(p => p.imdbID == movieId));
        }
    }
}
