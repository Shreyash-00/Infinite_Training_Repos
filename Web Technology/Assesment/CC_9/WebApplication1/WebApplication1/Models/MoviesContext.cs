using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class MoviesContext : DbContext
    {
        public MoviesContext() : base("name=MoviesDB")
        {
        }

        public DbSet<Movie> Movies { get; set; }
    }
}