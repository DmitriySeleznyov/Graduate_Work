using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kursovoi_proj;
using Kursovoi_proj.Controllers;
using WebPortal_Music.Contracts.Interfaces;
using Moq;
using WebPortal_Music.DAL.Repositories;
using WebPortal_Music.Contracts.DataContracts;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Web_PortalTest
{
    [TestClass]
    public class UserControllerTest
    {
        private Mock<IUsersRepository> mockUserRepository;
        private UserController controller;

        [TestInitialize]
        public void SetUp()
        {
            mockUserRepository = new Mock<IUsersRepository>();
            mockUserRepository.Setup(a => a.GetAll()).Returns(new List<Users>());
        }

        [TestMethod]
        public void Index()
        {
            // Arrange
            controller = new UserController(mockUserRepository.Object);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void UsersAreExist()
        {
            // Arrange
            controller = new UserController(mockUserRepository.Object);

            // Act
            var users = controller.GetAllUsers();

            // Assert
            Assert.IsNotNull(users);
        }
    }
}
