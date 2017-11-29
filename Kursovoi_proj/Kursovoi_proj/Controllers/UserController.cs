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
    public class UserController: Controller
    {
        private readonly WebPortalContext context = new WebPortalContext();
        private readonly IUsersRepository userRepository;

        public UserController()
        {
            userRepository = new UserRepository(context);
        }
        public ActionResult Index()
        {
            IList<UserModel> model = new List<UserModel>();

            foreach (var item in userRepository.GetAll())
            {
                model.Add(
                    new UserModel
                    {
                        UsersID = item.UsersID,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        Email = item.Email,
                        Phone = item.Phone,
                    }
                );
            }

            return View("Index", model);
        }

        public ActionResult Details(int id)
        {
            UserModel model = new UserModel();

            var modelUser = userRepository.GetById(id);
            model.UsersID = modelUser.UsersID;
            model.FirstName = modelUser.FirstName;
            model.LastName = modelUser.LastName;
            model.Email = modelUser.Email;
            model.Phone = modelUser.Phone;
            
            return View("DetailsUser", model);
        }

        public ActionResult Add()
        {
            return View("AddUser");
        }

        [HttpPost]
        public ActionResult Add(UserModel user)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("AddUser", user);
                }
                var model = new User();
                model.LastName = user.LastName;
                model.FirstName = user.FirstName;
                model.Email = user.Email;
                model.Phone = user.Phone;
                userRepository.Add(model);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            UserModel model = new UserModel();

            var modelUser = userRepository.GetById(id);
            model.UsersID = modelUser.UsersID;
            model.LastName = modelUser.LastName;
            model.FirstName = modelUser.FirstName;
            model.Email = modelUser.Email;
            model.Phone = modelUser.Phone;

            return View("EditUser", model);
        }

        [HttpPost]
        public ActionResult Edit(UserModel userUpdate)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("EditUser", userUpdate);
                }

                var user = userRepository.GetById(userUpdate.UsersID);
                user.LastName = userUpdate.LastName;
                user.FirstName = userUpdate.FirstName;
                user.Email = userUpdate.Email;
                user.Phone = userUpdate.Phone;
                userRepository.Update(user);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            userRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}