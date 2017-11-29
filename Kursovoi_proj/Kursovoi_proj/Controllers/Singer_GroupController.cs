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
    public class Singer_GroupController: Controller
    {

        private readonly WebPortalContext context = new WebPortalContext();
        private readonly ISinger_GroupRepository singer_groupRepository;

        public Singer_GroupController()
        {
            singer_groupRepository = new Singer_GroupRepository(context);
        }
        public ActionResult Index()
        {
            IList<Singer_GroupModel> model = new List<Singer_GroupModel>();

            foreach (var item in singer_groupRepository.GetAll())
            {
                model.Add(
                    new Singer_GroupModel
                    {
                        Singer_id = item.Singer_id,
                        Name_Singer = item.Name_Singer,
                        Genre = item.Genre,
                        Year_Create = item.Year_Create,
                    }
                );
            }

            return View("Index", model);
        }

        public ActionResult Details(int id)
        {
            Singer_GroupModel model = new Singer_GroupModel();

            var modelSinger_Group = singer_groupRepository.GetById(id);
            model.Singer_id = modelSinger_Group.Singer_id;
            model.Name_Singer = modelSinger_Group.Name_Singer;
            model.Genre = modelSinger_Group.Genre;
            model.Year_Create = modelSinger_Group.Year_Create;

            return View("DetailsSinger_Group", model);
        }

        public ActionResult Add()
        {
            return View("AddSinger_Group");
        }

        [HttpPost]
        public ActionResult Add(Singer_GroupModel singer_group)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("AddSinger_Group", singer_group);
                }
                var model = new Singer_Group();
                model.Singer_id = singer_group.Singer_id;
                model.Name_Singer = singer_group.Name_Singer;
                model.Genre = singer_group.Genre;
                model.Year_Create = singer_group.Year_Create;
                singer_groupRepository.Add(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            Singer_GroupModel model = new Singer_GroupModel();

            var modelSinger_Group = singer_groupRepository.GetById(id);
            model.Singer_id = modelSinger_Group.Singer_id;
            model.Name_Singer = modelSinger_Group.Name_Singer;
            model.Genre = modelSinger_Group.Genre;
            model.Year_Create = modelSinger_Group.Year_Create;

            return View("EditSinger_Group", model);
        }

        [HttpPost]
        public ActionResult Edit(Singer_GroupModel singer_groupUpdate)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("EditSinger_Group", singer_groupUpdate);
                }

                var singer_group = singer_groupRepository.GetById(singer_groupUpdate.Singer_id);
                singer_group.Singer_id = singer_groupUpdate.Singer_id;
                singer_group.Name_Singer = singer_groupUpdate.Name_Singer;
                singer_group.Genre = singer_groupUpdate.Genre;
                singer_group.Year_Create = singer_groupUpdate.Year_Create;
                singer_groupRepository.Update(singer_group);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            singer_groupRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
