using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class MoviesContext : DbContext
    {
        public MoviesContext() : base("name=MoviesDB") // Name matches the connection string
        {
        }

        public DbSet<Movie> Movies { get; set; }
    }
}