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

        [HttpPost]
        public User CreateUser([FromBody]User user)
        {
            try
            {
                return _usersRepository.Add(user.Name, user.Email);
            }
            catch (Exception ex)
            {
                Log.Logger.ServiceLog.Error(ex.Message);
                throw;
            }
        }

        [HttpGet]
        public User GetUser(Guid id)
        {
            try
            {
                return _usersRepository.Get(id);
            }
            catch (Exception ex)
            {
                Log.Logger.ServiceLog.Error(ex.Message);
                throw;
            }
        }

        [HttpDelete]
        public void DeleteUser(Guid id)
        {
            try
            {
                _usersRepository.Delete(id);
                Log.Logger.ServiceLog.Info("Delete user with id: {0}", id);
            }
            catch (Exception ex)
            {
                Log.Logger.ServiceLog.Error(ex.Message);
                throw;
            }
        }

        [Route("api/users/{id}/files")]
        [HttpGet]
        public IEnumerable<File> GetUserFiles(Guid id)
        {
            try
            {
                return _filesRepository.GetUserFiles(id);
            }
            catch (Exception ex)
            {
                Log.Logger.ServiceLog.Error(ex.Message);
                throw;
            }
        }

        [Route("api/users/all")]
        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            try
            {
                return _usersRepository.GetUsers();
            }
            catch (Exception ex)
            {
                Log.Logger.ServiceLog.Error(ex.Message);
                throw;
            }
        }
    }
}
