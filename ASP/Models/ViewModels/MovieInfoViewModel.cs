using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.Models.ViewModels
{
    public class MovieInfoViewModel
    {
        public MovieFull Movie { get; set; }
        public IEnumerable<Comment> comments { get; set; }
        public IEnumerable<AppUser> userEmails { get; set; }

    }
}
