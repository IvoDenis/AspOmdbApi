using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ASP.Models
{
    public class MovieFull
    {
        public string Title { get; set; }
        [JsonProperty]
        public string Year { get; set; }
        [JsonProperty]
        public string imdbID { get; set; }
        [JsonProperty]
        public string Type { get; set; }
        [JsonProperty]
        public string Poster { get; set; }
        public string Rated { get; set; }
        public string Released { get; set; }
        public string Runtime { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Writer { get; set;}
        public string Actors { get; set; }
        public string Plot { get; set; }
        public string Country { get; set; }
    }
}
