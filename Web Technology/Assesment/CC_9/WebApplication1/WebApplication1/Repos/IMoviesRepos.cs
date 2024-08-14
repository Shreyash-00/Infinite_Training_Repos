using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Repos
{
    public interface IMovieRepos
    {
        IEnumerable<Movie> GetAllMovies();
        Movie GetMovieById(int id);
        void InsertMovie(Movie movie);
        void UpdateMovie(Movie movie);
        void DeleteMovie(int id);
        void Save();
    }
}