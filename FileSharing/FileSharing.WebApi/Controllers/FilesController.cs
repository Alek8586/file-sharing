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
            return _filesRepository.Add(file);
        }

        [HttpGet]
        public File GetFile(Guid id)
        {

            return _filesRepository.GetInfo(id);
        }

        [HttpDelete]
        public void DeleteFile(Guid id)
        {
            _filesRepository.Delete(id);
        }

        [HttpPut]
        [Route("api/files/{id}/content")]
        public async Task UpdateFileContent(Guid id)
        {
            var bytes = await Request.Content.ReadAsByteArrayAsync();
            _filesRepository.UpdateContent(id, bytes);
        }

        [HttpGet]
        [Route("api/files/{id}/content")]
        public byte[] GetFileContent(Guid id)
        {
            return _filesRepository.GetContent(id);
        }

        [Route("api/files/{id}/comments")]
        [HttpGet]
        public IEnumerable<Comment> GetFileComments([FromBody]Guid id)
        {
            return _commentsRepository.GetFileComments(id);
        }

        [Route("api/files/SharingFiles")]

        [HttpPost]
        public Share CreateShare([FromBody]Share share)
        {
            return _sharesRepository.Add(share);
        }

        [Route("api/files/SharingFiles")]
        [HttpDelete]
        public void DeleteShare(Share share)
        {
            _sharesRepository.Delete(share);
        }

        [Route("api/files/SharingFiles")]
        [HttpGet]
        public IEnumerable<User> GetFileUsers(Guid id)
        {
            return _sharesRepository.GetFileUsers(id);
        }
    }
}
