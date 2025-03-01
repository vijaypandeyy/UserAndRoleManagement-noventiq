using Application.Models.Common;
using Application.Models.Requests;
using Application.Repositories;
using Application.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Application.Services
{
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly UserService _userService;
        public UserServiceTests()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _userService = new UserService(_userRepositoryMock.Object);
        }

        [Fact]

        public void AddUserAsync_WhenCalled_ReturnsSuccessResult()
        {
            //Arrange
            var user = new AddUserRequestModel
            {
                Email = ""
            };


        }
    }
}
