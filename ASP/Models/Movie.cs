using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.Models
{
    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }

        public string Year { get; set; }

        public string imdbID { get; set; }


        public string Poster { get; set; }
        [Range(1,10)]
        public int? Rating { get; set; }


    }
}
