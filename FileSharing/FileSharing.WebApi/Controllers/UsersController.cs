using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FileSharing.DataAccess;
using FileSharing.Model;
using FileSharing.DataAccess.Sql;

namespace FileSharing.WebApi.Controllers
{
    public class UsersController : ApiController
    {
        private const string ConnectionString = "Data Source=DESKTOP-HP;Initial Catalog=FileSharing;Integrated Security=true";
        private readonly IUsersRepository _usersRepository = new UsersRepository(ConnectionString);
        private readonly IFilesRepository _filesRepository;

        public UsersController()
        {
            _filesRepository = new FilesRepository(ConnectionString, _usersRepository);
        }

        ///<summary>
        ///Create user
        ///</summary>
        ///<param name="user"></param>
        ///<returns></returns>

        [HttpPost]
        public void CreateUser([FromBody]User user)
        {
            _usersRepository.Add(user.Name, user.Email);
        }

        [HttpGet]
        public User GetUser(Guid id)
        {

            return _usersRepository.Get(id);
        }

        [HttpDelete]
        public void DeleteUser(Guid id)
        {
            _usersRepository.Delete(id);
        }

        [Route("api/users/{id}/files")]
        [HttpGet]
        public IEnumerable<File> GetUserFiles(Guid id)
        {
            return _filesRepository.GetUserFiles(id);
        }
    }
}
