using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Repos
{
    public class MovieRepos : IMovieRepos
    {
        private readonly MoviesContext _context;

        public MovieRepository()
        {
            _context = new MoviesContext();
        }

        public IEnumerable<Movie> GetAll()
        {
            return _context.Movies.ToList();
        }

        public Movie Get(int id)
        {
            return _context.Movies.Find(id);
        }

        public void Add(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
        }

        public void Update(Movie movie)
        {
            _context.Entry(movie).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Movie> GetMoviesByYear(int year)
        {
            return _context.Movies.Where(m => m.DateOfRelease.Year == year).ToList();
        }
    }
}