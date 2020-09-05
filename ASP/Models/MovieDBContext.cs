using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.Models
{
    public class MovieDBContext:DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public MovieDBContext(DbContextOptions<MovieDBContext> options):base(options)
        {
            Database.EnsureCreated();
        }
    }
}
