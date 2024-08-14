using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Repos
{
    public interface IMovieRepos
    {
        IEnumerable<Movie> GetAll();
        Movie Get(int id);
        void Add(Movie movie);
        void Update(Movie movie);
        void Delete(int id);
        IEnumerable<Movie> GetMoviesByYear(int year);
    }
}