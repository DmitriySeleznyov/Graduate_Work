using Kursovoi_proj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebPortal_Music.Contracts.DataContracts;
using WebPortal_Music.Contracts.Interfaces;
using WebPortal_Music.DAL.DataBase;
using WebPortal_Music.DAL.Repositories;

namespace Kursovoi_proj.Controllers
{
    public class GenreController : Controller
    {
        private readonly WebPortalContext context = new WebPortalContext();
        private readonly IGenreRepository genreRepository;

        public GenreController()
        {
            genreRepository = new GenreRepository(context);
        }
        public ActionResult Index()
        {
            IList<GenreModel> model = new List<GenreModel>();

            foreach (var item in genreRepository.GetAll())
            {
                model.Add(
                    new GenreModel
                    {
                        Genre_Id = item.Genre_Id,
                        Name_Genre = item.Name_Genre,
                    }
                );
            }

            return View("Index", model);
        }

        public ActionResult Details(int id)
        {
            GenreModel model = new GenreModel();

            var modelGenre = genreRepository.GetById(id);
            model.Genre_Id = modelGenre.Genre_Id;
            model.Name_Genre = modelGenre.Name_Genre;

            return View("DetailsGenre", model);
        }

        public ActionResult Add()
        {
            return View("AddGenre");
        }

        [HttpPost]
        public ActionResult Add(GenreModel genre)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("AddGenre", genre);
                }
                var model = new Genre();
                model.Genre_Id = genre.Genre_Id;
                model.Name_Genre = genre.Name_Genre;
                genreRepository.Add(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            GenreModel model = new GenreModel();

            var modelGenre = genreRepository.GetById(id);
            model.Genre_Id = modelGenre.Genre_Id;
            model.Name_Genre = modelGenre.Name_Genre;

            return View("EditGenre", model);
        }

        [HttpPost]
        public ActionResult Edit(GenreModel genreUpdate)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("EditGenre", genreUpdate);
                }

                var genre = genreRepository.GetById(genreUpdate.Genre_Id);
                genre.Genre_Id = genreUpdate.Genre_Id;
                genre.Name_Genre = genreUpdate.Name_Genre;
                genreRepository.Update(genre);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            genreRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}