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
    public class MusicController : Controller
    {
        private readonly WebPortalContext context = new WebPortalContext();
        private readonly IMusicRepository musicRepository;

        public MusicController()
        {
            musicRepository = new MusicRepository(context);
        }
        public ActionResult Index()
        {
            IList<MusicModel> model = new List<MusicModel>();

            foreach (var item in musicRepository.GetAll())
            {
                model.Add(
                    new MusicModel
                    {
                        Song_Id = item.Song_Id,
                        Name_Song = item.Name_Song,
                        Singer = item.Singer,
                        Time = item.Time,
                    }
                );
            }

            return View("Index", model);
        }

        public ActionResult Details(int id)
        {
            MusicModel model = new MusicModel();

            var modelMusic = musicRepository.GetById(id);
            model.Song_Id = modelMusic.Song_Id;
            model.Name_Song = modelMusic.Name_Song;
            model.Singer = modelMusic.Singer;
            model.Time = modelMusic.Time;

            return View("DetailsMusic", model);
        }

        public ActionResult Add()
        {
            return View("AddMusic");
        }

        [HttpPost]
        public ActionResult Add(MusicModel music)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("AddMusic", music);
                }
                var model = new Music();
                model.Song_Id = music.Song_Id;
                model.Name_Song = music.Name_Song;
                model.Singer = music.Singer;
                model.Time = music.Time;
                musicRepository.Add(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            MusicModel model = new MusicModel();

            var modelMusic = musicRepository.GetById(id);
            model.Song_Id = modelMusic.Song_Id;
            model.Name_Song = modelMusic.Name_Song;
            model.Singer = modelMusic.Singer;
            model.Time = modelMusic.Time;

            return View("EditMusic", model);
        }

        [HttpPost]
        public ActionResult Edit(MusicModel musicUpdate)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("EditMusic", musicUpdate);
                }

                var music = musicRepository.GetById(musicUpdate.Song_Id);
                music.Song_Id = musicUpdate.Song_Id;
                music.Name_Song = musicUpdate.Name_Song;
                music.Singer = musicUpdate.Singer;
                music.Time = musicUpdate.Time;
                musicRepository.Update(music);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            musicRepository.Delete(id);
            return RedirectToAction("Index");
        }

    }
}