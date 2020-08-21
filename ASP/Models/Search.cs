using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ASP.Models
{
    public class SearchResult
    {
        [JsonProperty]
        public List<Movie> Search { get; set; }
        [JsonProperty]
        public int totalResults { get; set; }
        [JsonProperty]
        public string Response { get; set; }

    }
}
