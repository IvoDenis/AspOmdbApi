using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.Services
{
    public interface IMovieServices
    {
        Task<string> SearchDataAsync(string Query,int page);
        Task<string> GetByIDAsync(string IMDBid);
    }
}
