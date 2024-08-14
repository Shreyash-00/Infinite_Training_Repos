using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Repos;

namespace WebApplication1.Controllers
{
    public class MoviesController : Controller
    {
        public IMovieRepos movieRepository;

        public MoviesController()
        {
            this.movieRepository = new MovieRepos(new MoviesContext());
        }


        public ActionResult Index()
        {
            var movies = movieRepository.GetAllMovies();
            return View(movies);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Mid,MovieName,DateOfRelease")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                movieRepository.InsertMovie(movie);
                movieRepository.Save();
                return RedirectToAction("Index");
            }

            return View(movie);
        }


        public ActionResult Edit(int id)
        {
            Movie movie = movieRepository.GetMovieById(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Mid,MovieName,DateOfRelease")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                movieRepository.UpdateMovie(movie);
                movieRepository.Save();
                return RedirectToAction("Index");
            }
            return View(movie);
        }


        public ActionResult Delete(int id)
        {
            Movie movie = movieRepository.GetMovieById(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete_Confirmation(int id)
        {
            movieRepository.DeleteMovie(id);
            movieRepository.Save();
            return RedirectToAction("Index");
        }


        public ActionResult ReleasedYear(int year)
        {
            var movies = movieRepository.GetAllMovies()
                                         .Where(m => m.DateOfRelease.Year == year)
                                         .ToList();
            return View(movies);
        }
    }
}