using Application.Models.Common;
using Application.Repositories;
using Core;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FluentAssertions;

namespace UnitTests.Repositories
{
    public class UserRepositoryTests : IDisposable
    {
        private readonly AppDbContext _context;
        private readonly UserRepository _userRepository;
        public UserRepositoryTests()
        {

            var options = new DbContextOptionsBuilder<AppDbContext>()
           .UseInMemoryDatabase(databaseName: "TestDb")
           .Options;
            _context = new AppDbContext(options);
            _userRepository = new UserRepository(_context);
        }

        [Fact]
        public async Task AddAsync_ShouldReturn()
        {
            var user = FakeDataGenerator.GenerateFakeUser();
           await _userRepository.AddAsync(user);

            var result = _context.Find<User>(user.Id);

            result.Username.Should().Be(user.Username);
            result.Email.Should().Be(user.Email);

        }
        [Fact]
        public async Task DeleteAsync()
        {
            var user = FakeDataGenerator.GenerateFakeUser();
            _context.Add<User>(user);
            var dbRes = _context.Find<User>(user.Id);

            await _userRepository.DeleteAsync(user.Id);
           var dbres= _context.Find<User>(user.Id);
            dbres.Should().BeNull();


        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [Fact]
        public async Task GetByIdAsync()
        {
            var user = FakeDataGenerator.GenerateFakeUser();
            _context.Add<User>(user);
            var dbRes = _context.Find<User>(user.Id);

            var result = await _userRepository.GetByIdAsync(user.Id);
            result.Username.Should().Be(user.Username);
        }


        [Fact]
        public async Task UpdateAsync()
        {//Arrange
            var user = FakeDataGenerator.GenerateFakeUser();
            _context.Add<User>(user);
            var dbRes = _context.Find<User>(user.Id);
            user.Username = "newUsername";
            user.Email = "newEmail";


            //Act
             await _userRepository.UpdateAsync(user);

            //Assert
            var result = _context.Find<User>(user.Id);
            result.Username.Should().Be(user.Username);
            result.Email.Should().Be(user.Email);
            result.Id.Should().Be(user.Id);


        }


    }
}
