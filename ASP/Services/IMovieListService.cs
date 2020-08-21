using ASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.Services
{
    public interface IMovieListRepository
    {
        IEnumerable<Movie> All { get; }
        void Add(Movie item);
        void Delete(string movieId);
        
    }
}
