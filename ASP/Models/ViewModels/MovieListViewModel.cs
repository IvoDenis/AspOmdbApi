using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.Models.ViewModels
{
    public class MovieListItemViewModel
    {
        public Movie movie { get; set; }
        public bool canAdd { get; set; }
        public bool canUpdate { get; set; }

    }
}
