using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        private readonly IMovieRepository _repository;

        public MoviesController()
        {
            _repository = new MovieRepository();
        }

        public ActionResult Index()
        {
            var movies = _repository.GetAll();
            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movie = _repository.Get(id);
            return View(movie);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(movie);
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var movie = _repository.Get(id);
            return View(movie);
        }

        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(movie);
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        public ActionResult Delete(int id)
        {
            var movie = _repository.Get(id);
            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult MoviesByYear(int year)
        {
            var movies = _repository.GetMoviesByYear(year);
            return View(movies);
        }
    }
}