using System;
using System.Linq;
using System.Text;
using FileSharing.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FileSharing.DataAccess.Sql.Tests
{
    [TestClass]
    public class UsersRepositoryTests
    {
        private const string ConnectionString = "Data Source=DESKTOP-HP;Initial Catalog=FileSharing;Integrated Security=true";
        private readonly IUsersRepository _usersRepository;

        public UsersRepositoryTests()
        {
            _usersRepository = new UsersRepository(ConnectionString);
        }

        [TestInitialize]


        [TestCleanup]
        public void Clean()
        {

        }

        [TestMethod]
        public void ShouldAddGetDeleteUser()
        {
            //arrange
            string name = "test";
            string email = "test@test.com";
            //act
            var newUser = _usersRepository.Add(name, email);
            var result = _usersRepository.Get(newUser.Id);
            //asserts
            Assert.AreEqual(newUser.Name, result.Name);
            Assert.AreEqual(newUser.Email, result.Email);
            _usersRepository.Delete(newUser.Id);
        }
    }
}

