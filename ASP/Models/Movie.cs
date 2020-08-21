using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ASP.Models
{
    public class Movie
    {
        [JsonProperty]
        public string Title { get; set; }
        [JsonProperty]
        public string Year { get; set; }
        [JsonProperty]
        public string imdbID { get; set; }

        [JsonProperty]
        public string Poster { get; set; }

    }
}
