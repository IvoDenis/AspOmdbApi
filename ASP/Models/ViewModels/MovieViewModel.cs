using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.Models.ViewModels
{
    public class MovieViewModel
    {
        public PagingInfo pagingInfo;
        public IEnumerable<Movie> movies;
        public string Query;
    }
}
