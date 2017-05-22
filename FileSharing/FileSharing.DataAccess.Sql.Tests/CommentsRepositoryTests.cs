using System;
using System.Linq;
using System.Text;
using FileSharing.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FileSharing.DataAccess.Sql.Tests
{
    [TestClass]
    public class CommentsRepositoryTests
    {
        private const string ConnectionString = "Data Source=DESKTOP-HP;Initial Catalog=FileSharing;Integrated Security=true";
        private readonly IUsersRepository _usersRepository = new UsersRepository(ConnectionString);
        private readonly IFilesRepository _filesRepository;
        private readonly ICommentsRepository _commentsRepository;

        private User TestUser { get; set; }
        private File TestFile { get; set; }

        public CommentsRepositoryTests()
        {
            _filesRepository = new FilesRepository(ConnectionString, _usersRepository);
            _commentsRepository = new CommentsRepository(ConnectionString, _usersRepository, _filesRepository);
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
                foreach (var comment in _commentsRepository.GetFileComments(TestFile.Id))
                    _commentsRepository.Delete(comment.Id);
                _usersRepository.Delete(TestUser.Id);
                _filesRepository.Delete(TestFile.Id);
            }
        }

        [TestMethod]
        public void ShouldAddAndGetComment()
        {
            //arrange
            var comment = new Comment
            {
                FileId = TestFile,
                UserId = TestUser,
                Text = "test"
            };
            //act
            var newComment = _commentsRepository.Add(comment);
            var result = _commentsRepository.GetInfo(newComment.Id);
            //asserts
            Assert.AreEqual(comment.FileId.Id, result.FileId.Id);
            Assert.AreEqual(comment.UserId.Id, result.UserId.Id);
            Assert.AreEqual(comment.Text, result.Text);
        }
    }
}
