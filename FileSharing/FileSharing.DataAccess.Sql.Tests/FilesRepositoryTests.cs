﻿using System;
using System.Linq;
using System.Text;
using FileSharing.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FileSharing.DataAccess.Sql.Tests
{
    [TestClass]
    public class FilesRepositoryTests
    {
        private const string ConnectionString = "Data Source=DESKTOP-HP;Initial Catalog=FileSharing;Integrated Security=true";
        private readonly IUsersRepository _usersRepository = new UsersRepository(ConnectionString);
        private readonly IFilesRepository _filesRepository;

        private User TestUser { get; set; }

        public FilesRepositoryTests()
        {
            _filesRepository = new FilesRepository(ConnectionString, _usersRepository);
        }

        [TestInitialize]
        public void Init()
        {
            TestUser = _usersRepository.Add("test", "test@test.com");
        }

        [TestCleanup]
        public void Clean()
        {
            if (TestUser != null)
            {
                foreach (var file in _filesRepository.GetUserFiles(TestUser.Id))
                    _filesRepository.Delete(file.Id);
                _usersRepository.Delete(TestUser.Id);
            }
        }

        [TestMethod]
        public void ShouldCreateAndGetFile()
        {
            //arrange
            var file = new File
            {
                Name = "testFile",
                Owner = TestUser
            };
            //act
            var newFile = _filesRepository.Add(file);
            var result = _filesRepository.GetInfo(newFile.Id);
            //asserts
            Assert.AreEqual(file.Owner.Id, result.Owner.Id);
            Assert.AreEqual(file.Name, result.Name);
        }

        [TestMethod]
        public void ShouldUpdateFileContent()
        {
            //arrange
            var file = new File
            {
                Name = "file with content",
                Owner = TestUser
            };
            var content = Encoding.UTF8.GetBytes("Hello");
            var newFile = _filesRepository.Add(file);
            //act
            _filesRepository.UpdateContent(newFile.Id, content);
            var resultContent = _filesRepository.GetContent(newFile.Id);
            //asserts
            Assert.IsTrue(content.SequenceEqual(resultContent));
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod]
        public void ShouldGetAndDeleteFile()
        {
            //arrange
            var file = new File
            {
                Name = "file",
                Owner = TestUser
            };
            //act
            var newFile = _filesRepository.Add(file);
            var result = _filesRepository.GetInfo(newFile.Id);
            //asserts
            Assert.AreEqual(file.Owner.Id, result.Owner.Id);
            Assert.AreEqual(file.Name, result.Name);
            _filesRepository.Delete(newFile.Id);
            result = _filesRepository.GetInfo(newFile.Id);
        }
    }
}
