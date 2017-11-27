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
        private readonly IUsersRepository userRepository;

        public UserController(IUsersRepository userRepository)
        {
            this.userRepository = userRepository;
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

            var modelClient = userRepository.GetById(id);
            model.UsersID = modelClient.UsersID;
            model.FirstName = modelClient.FirstName;
            model.LastName = modelClient.LastName;
            model.Email = modelClient.Email;
            model.Phone = modelClient.Phone;
            
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
                var model = new Users();
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

            var modelClient = userRepository.GetById(id);
            model.UsersID = modelClient.UsersID;
            model.LastName = modelClient.LastName;
            model.FirstName = modelClient.FirstName;
            model.Email = modelClient.Email;
            model.Phone = modelClient.Phone;

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

        public IEnumerable<Users> GetAllUsers()
        {
            return userRepository.GetAll();
        }
    }
}