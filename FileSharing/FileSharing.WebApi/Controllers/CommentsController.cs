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
            try
            {
                return _commentsRepository.Add(comment);
            }
            catch (Exception ex)
            {
                Log.Logger.ServiceLog.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public Comment GetComment(Guid id)
        {
            try
            {
                return _commentsRepository.GetInfo(id);
            }
            catch (Exception ex)
            {
                Log.Logger.ServiceLog.Error(ex.Message);
                throw;
            }
        }

        [HttpDelete]
        public void DeleteComment(Guid id)
        {
            try
            {
                _commentsRepository.Delete(id);
                Log.Logger.ServiceLog.Info("Delete comment with id: {0}", id);
            }
            catch (Exception ex)
            {
                Log.Logger.ServiceLog.Error(ex.Message);
                throw;
            }
        }

    }
}
