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
    public class CommentController : Controller
    {
        private readonly WebPortalContext context = new WebPortalContext();
        private readonly ICommentsRepository commentRepository;

        public CommentController()
        {
            commentRepository = new CommentRepository(context);
        }
        public ActionResult Index()
        {
            IList<CommentModel> model = new List<CommentModel>();

            foreach (var item in commentRepository.GetAll())
            {
                model.Add(
                    new CommentModel
                    {
                        Comment_Id = item.Comment_Id,
                        Comment_Description = item.Comment_Description,
                        Date_Time = item.Date_Time,
                    }
                );
            }

            return View("Index", model);
        }

        public ActionResult Details(int id)
        {
            CommentModel model = new CommentModel();

            var modelComment = commentRepository.GetById(id);
            model.Comment_Id = modelComment.Comment_Id;
            model.Comment_Description = modelComment.Comment_Description;
            model.Date_Time = modelComment.Date_Time;

            return View("DetailsComment", model);
        }

        public ActionResult Add()
        {
            return View("AddComment");
        }

        [HttpPost]
        public ActionResult Add(CommentModel comment)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("AddComment", comment);
                }
                var model = new Comment();
                model.Comment_Id = comment.Comment_Id;
                model.Comment_Description = comment.Comment_Description;
                model.Date_Time = comment.Date_Time;
                commentRepository.Add(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            CommentModel model = new CommentModel();

            var modelComment = commentRepository.GetById(id);
            model.Comment_Id = modelComment.Comment_Id;
            model.Comment_Description = modelComment.Comment_Description;
            model.Date_Time = modelComment.Date_Time;

            return View("EditComment", model);
        }

        [HttpPost]
        public ActionResult Edit(CommentModel commentUpdate)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("EditGenre", commentUpdate);
                }

                var comment = commentRepository.GetById(commentUpdate.Comment_Id);
                comment.Comment_Id = commentUpdate.Comment_Id;
                comment.Comment_Description = commentUpdate.Comment_Description;
                comment.Date_Time = commentUpdate.Date_Time;
                commentRepository.Update(comment);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            commentRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}