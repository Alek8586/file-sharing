using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using FileSharing.Model;

namespace FileSharing.DataAccess.Sql
{
    public class SharesRepository : ISharesRepository
    {
        private readonly string _connectionString;
        private readonly IUsersRepository _usersRepository;
        private readonly IFilesRepository _filesRepository;

        public SharesRepository(string connectionString, IUsersRepository usersRepository, IFilesRepository filesRepository)
        {
            _connectionString = connectionString;
            _usersRepository = usersRepository;
            _filesRepository = filesRepository;
        }

        public Share Add(Share share)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "insert into shares (fileid, userid) values (@fileid, @userid)";
                    command.Parameters.AddWithValue("@fileid", share.FileId);
                    command.Parameters.AddWithValue("@userid", share.UserId);
                    command.ExecuteNonQuery();
                    return share;
                }
            }
        }

        public IEnumerable<User> GetFileUsers(Guid fileId)
        {
            var result = new List<User>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "select userid from shares where fileid = @fileid";
                    command.Parameters.AddWithValue("@fileid", fileId);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(_usersRepository.Get(reader.GetGuid(reader.GetOrdinal("userid"))));
                        }
                    }
                    return result;
                }
            }
        }

        public void Delete(Share share)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "delete from shares where fileid = @fileid and userid = @userid";
                    command.Parameters.AddWithValue("@fileid", share.FileId);
                    command.Parameters.AddWithValue("@userid", share.UserId);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
