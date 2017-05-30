using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FileSharing.DataAccess;
using FileSharing.DataAccess.Sql;
using FileSharing.Model;

namespace FileSharing.WebApi.Controllers
{
    public class CommentsController : ApiController
    {
        private const string ConnectionString = "Data Source=DESKTOP-HP;Initial Catalog=FileSharing;Integrated Security=true";
        private readonly IUsersRepository _usersRepository = new UsersRepository(ConnectionString);
        private readonly IFilesRepository _filesRepository;
        private readonly ICommentsRepository _commentsRepository;

        public CommentsController()
        {
            _filesRepository = new FilesRepository(ConnectionString, _usersRepository);
            _commentsRepository = new CommentsRepository(ConnectionString, _usersRepository, _filesRepository);
        }

        [HttpPost]
        public Comment CreateComment(Comment comment)
        {
            return _commentsRepository.Add(comment);
        }

        [HttpGet]
        public Comment GetComment(Guid id)
        {
            return _commentsRepository.GetInfo(id);
        }

        [HttpDelete]
        public void DeleteComment(Guid id)
        {
            _commentsRepository.Delete(id);
        }

    }
}
