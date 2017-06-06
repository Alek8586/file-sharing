using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FileSharing.DataAccess;
using FileSharing.Model;
using FileSharing.DataAccess.Sql;
using System.Threading.Tasks;

namespace FileSharing.WebApi.Controllers
{
    public class FilesController : ApiController
    {
        private const string ConnectionString = "Data Source=DESKTOP-HP;Initial Catalog=FileSharing;Integrated Security=true";
        private readonly IUsersRepository _usersRepository = new UsersRepository(ConnectionString);
        private readonly IFilesRepository _filesRepository;
        private readonly ICommentsRepository _commentsRepository;
        private readonly ISharesRepository _sharesRepository;

        public FilesController()
        {
            _filesRepository = new FilesRepository(ConnectionString, _usersRepository);
            _commentsRepository = new CommentsRepository(ConnectionString, _usersRepository, _filesRepository);
            _sharesRepository = new SharesRepository(ConnectionString, _usersRepository, _filesRepository);
        }

        [HttpPost]
        public File CreateFile([FromBody]File file)
        {
            try
            {
                return _filesRepository.Add(file);
            }
            catch (Exception ex)
            {
                Log.Logger.ServiceLog.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public File GetFile(Guid id)
        {
            try
            {
                return _filesRepository.GetInfo(id);
            }
            catch (Exception ex)
            {
                Log.Logger.ServiceLog.Error(ex.Message);
                throw;
            }
        }

        [HttpDelete]
        public void DeleteFile(Guid id)
        {
            try
            {
                _filesRepository.Delete(id);
                Log.Logger.ServiceLog.Info("Delete file with id: {0}", id);
            }
            catch (Exception ex)
            {
                Log.Logger.ServiceLog.Error(ex.Message);
                throw;
            }
        }

        [HttpPut]
        [Route("api/files/{id}/content")]
        public async Task UpdateFileContent(Guid id)
        {
            try
            {
                var bytes = await Request.Content.ReadAsByteArrayAsync();
                _filesRepository.UpdateContent(id, bytes);
            }
            catch (Exception ex)
            {
                Log.Logger.ServiceLog.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        [Route("api/files/{id}/content")]
        public byte[] GetFileContent(Guid id)
        {
            try
            {
                return _filesRepository.GetContent(id);
            }
            catch (Exception ex)
            {
                Log.Logger.ServiceLog.Error(ex.Message);
                throw;
            }
        }

        [Route("api/files/comments")]
        [HttpGet]
        public IEnumerable<Comment> GetFileComments(Guid id)
        {
            try
            {
                return _commentsRepository.GetFileComments(id);
            }
            catch (Exception ex)
            {
                Log.Logger.ServiceLog.Error(ex.Message);
                throw;
            }
        }

        [Route("api/files/SharingFiles/")]
        [HttpPost]
        public Share CreateShare([FromBody]Share share)
        {
            try
            {
                return _sharesRepository.Add(share);
            }
            catch (Exception ex)
            {
                Log.Logger.ServiceLog.Error(ex.Message);
                throw;
            }
        }

        [Route("api/files/Sharing/{id}")]
        [HttpDelete]
        public void DeleteShare(Guid id)
        {
            try
            {
                _sharesRepository.Delete(id);
                Log.Logger.ServiceLog.Info("Delete share with id: {0}", id);
            }
            catch (Exception ex)
            {
                Log.Logger.ServiceLog.Error(ex.Message);
                throw;
            }
        }

        [Route("api/files/SharingFiles/")]
        [HttpGet]
        public IEnumerable<User> GetFileUsers(Guid id)
        {
            try
            {
                return _sharesRepository.GetFileUsers(id);
            }
            catch (Exception ex)
            {
                Log.Logger.ServiceLog.Error(ex.Message);
                throw;
            }
        }

        [Route("api/files/SharingFiles/")]
        [HttpGet]
        public Guid GetShareId(Guid fileId, Guid userId)
        {
            try
            {
                return _sharesRepository.GetShareId(fileId, userId);
            }
            catch (Exception ex)
            {
                Log.Logger.ServiceLog.Error(ex.Message);
                throw;
            }
        }

        [Route("api/files/filesh/")]
        [HttpGet]
        public IEnumerable<File> GetFilesSh(Guid id)
        {
            try
            {
                return _sharesRepository.GetFilesSh(id);
            }
            catch (Exception ex)
            {
                Log.Logger.ServiceLog.Error(ex.Message);
                throw;
            }
        }
    }
}
