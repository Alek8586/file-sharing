using System;
using System.Linq;
using System.Text;
using FileSharing.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace FileSharing.DataAccess.Sql.Tests
{
    [TestClass]
    public class SharesRepositoryTests
    {
        private const string ConnectionString = "Data Source=DESKTOP-HP;Initial Catalog=FileSharing;Integrated Security=true";
        private readonly IUsersRepository _usersRepository = new UsersRepository(ConnectionString);
        private readonly IFilesRepository _filesRepository;
        private readonly ISharesRepository _sharesRepository;

        private User TestUser { get; set; }
        private File TestFile { get; set; }

        public SharesRepositoryTests()
        {
            _filesRepository = new FilesRepository(ConnectionString, _usersRepository);
            _sharesRepository = new SharesRepository(ConnectionString, _usersRepository, _filesRepository);
        }

        [TestInitialize]
        public void Init()
        {
            TestUser = _usersRepository.Add("test", "test@test.com");
            var file = new File
            {
                Name = "testFile",
                Owner = TestUser
            };
            TestFile = _filesRepository.Add(file);
        }

        [TestCleanup]
        public void Clean()
        {
            if (TestUser != null)
            {
                _usersRepository.Delete(TestUser.Id);
                _filesRepository.Delete(TestFile.Id);
            }
        }

        [TestMethod]
        public void ShouldAddAndGetShares()
        {
            //arrange
            List<Share> shares = new List<Share>();
            var share = new Share
            {
                FileId = TestFile.Id,
                UserId = TestUser.Id
            };
            shares.Add(share);
            //act
            var newShare = _sharesRepository.Add(share);
            var result = _sharesRepository.GetFileUsers(TestFile.Id);
            //asserts
            foreach (var res in result)
            {
                Assert.AreEqual(res.Id, share.UserId);
            }
            _sharesRepository.Delete(newShare);
        }
    }
}
