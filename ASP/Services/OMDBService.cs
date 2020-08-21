using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

namespace ASP.Services
{
    public class OMDBService:IMovieServices
    {
        private string baseURL = "http://www.omdbapi.com/";
        private string apiKey = "&apikey=5bf9c6b8";

        public async Task<string> GetByIDAsync(string IMDBid)
        {
            string resultJSON;
            string queryUrl = baseURL + "?i=" + IMDBid +"&plot = full" + apiKey;
            using (HttpClient httpClient = new HttpClient())
            {
                resultJSON = await httpClient.GetStringAsync(queryUrl);
            }
            return resultJSON;
        }

        public async Task<string> SearchDataAsync(string query,int page)
        {
            string resultJSON;
            string queryUrl = baseURL + "?s=" + query+$"&page={page}" + apiKey;
            using (HttpClient httpClient = new HttpClient())
            {
                resultJSON =  await httpClient.GetStringAsync(queryUrl);
            }
            return resultJSON;
        }

    }
}
