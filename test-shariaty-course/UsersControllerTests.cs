using Microsoft.AspNetCore.Mvc;
using Moq;
using shariaty_course.Controllers;
using shariaty_course.Models;

namespace test_shariaty_course
{
    public class UsersControllerTests
    {
        private readonly Mock<IUserService> _mockUserService = new Mock<IUserService>();
        private readonly UsersController _controller;

        public UsersControllerTests()
        {
            _controller = new UsersController(_mockUserService.Object);
        }

        [Fact]
        public void GetUser_WithValidId_ReturnsOkResult_WithMatchingUser()
        {
            var userId = 1;
            var expectedUser = new User
            {
                Id = 1,
                Username = "Icy Data",
                Password = "1379A",
                Email = "icydata@gmail.com",
                IsAdmin = true,
            };
            _mockUserService.Setup(service => service.GetUser(userId)).Returns(expectedUser);

            var result = _controller.GetUserById(userId);

            var okResult = Assert.IsType<OkObjectResult>(result);
            var user = Assert.IsAssignableFrom<User>(okResult.Value);
            Assert.Equal(expectedUser.Id, user.Id);
            Assert.Equal(expectedUser.Username, user.Username);
            Assert.Equal(expectedUser.Password, user.Password);
            Assert.Equal(expectedUser.Email, user.Email);
            Assert.Equal(expectedUser.IsAdmin, user.IsAdmin);
        }

        [Fact]
        public void GetUser_WithInvalidId_ReturnsNotFoundResult()
        {
            var userId = 4;
            _mockUserService.Setup(service => service.GetUser(userId)).Returns((User)null);

            var result = _controller.GetUserById(userId);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void CreateUser_ValidUser_ReturnsCreatedAtActionResult_WithNewUser()
        {
            var newUser = new User
            {
                Username = "Icy Data",
                Password = "1379A",
                Email = "icydata@gmail.com",
            };

            var expectedUser = new User
            {
                Id = 3,
                Username = "Icy Data",
                Password = "1379A",
                Email = "icydata@gmail.com",
                IsAdmin = true,
            };

            _mockUserService.Setup(service => service.AddUser(newUser)).Returns(expectedUser);

            var result = _controller.CreateUser(newUser);

            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            var user = Assert.IsAssignableFrom<User>(createdAtActionResult.Value);
            Assert.Equal(expectedUser.Id, user.Id);
            Assert.Equal(expectedUser.Username, user.Username);
            Assert.Equal(expectedUser.Password, user.Password);
            Assert.Equal(expectedUser.Email, user.Email);
            Assert.Equal(expectedUser.IsAdmin, user.IsAdmin);
        }

    }
}