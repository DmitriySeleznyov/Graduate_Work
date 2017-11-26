using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kursovoi_proj.Controllers;
using WebPortal_Music.Contracts.Interfaces;

namespace Web_PortalTest
{
    [TestClass]
    public class UserControllerTest
    {
        [TestInitialize]
        public void SetUp()
        {
            mockRoleRepository = new Mock <IUsersRepository>();
            mockRoleRepository.Setup(a => a.Get()).Returns(new List<Role>());
            mockUserRepository = new Mock<IGenericRepository<User>>();
            mockUserRepository.Setup(a => a.Get()).Returns(new List<User>());
        }

        [TestMethod]
        public void Index()
        {
            // Arrange
            controller = new UserController(mockRoleRepository.Object, mockUserRepository.Object);

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void RolesAreExist()
        {
            // Arrange
            controller = new HomeController(mockRoleRepository.Object, mockUserRepository.Object);

            // Act
            var roles = controller.GetAllRoles();

            // Assert
            Assert.IsNotNull(roles);
        }
    }
}
