using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Repos
{
    public class MovieRepos : IMovieRepos
    {
        private MoviesContext context;

        public MovieRepos(MoviesContext context)
        {
            this.context = context;
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            return context.Movies.ToList();
        }

        public Movie GetMovieById(int id)
        {
            return context.Movies.Find(id);
        }

        public void InsertMovie(Movie movie)
        {
            context.Movies.Add(movie);
        }

        public void UpdateMovie(Movie movie)
        {
            context.Entry(movie).State = EntityState.Modified;
        }

        public void DeleteMovie(int id)
        {
            Movie movie = context.Movies.Find(id);
            if (movie != null)
            {
                context.Movies.Remove(movie);
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}