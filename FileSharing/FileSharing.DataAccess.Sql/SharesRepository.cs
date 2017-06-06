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
                    try
                    {
                        command.CommandText = "insert into shares (id, fileid, userid) values (@id, @fileid, @userid)";
                        var shareId = Guid.NewGuid();
                        command.Parameters.AddWithValue("@id", shareId);
                        command.Parameters.AddWithValue("@fileid", share.FileId);
                        command.Parameters.AddWithValue("@userid", share.UserId);
                        command.ExecuteNonQuery();
                        share.id = shareId;
                        return share;
                    }
                    catch
                    {
                        throw new ArgumentException("share not add");
                    }
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

        public void Delete(Guid shareId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "delete from shares where id = @shareid";
                    command.Parameters.AddWithValue("@shareId", shareId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public Guid GetShareId(Guid fileId, Guid userId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "select id from shares where userid = @userid and fileid = @fileid";
                    command.Parameters.AddWithValue("@userid", userId);
                    command.Parameters.AddWithValue("@fileid", fileId);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return reader.GetGuid(reader.GetOrdinal("id"));
                        }
                        throw new ArgumentException("share not found");
                    }
                }
            }
        }

        public IEnumerable<File> GetFilesSh(Guid userId)
        {
            var result = new List<File>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "select fileid from shares where userid = @userid";
                    command.Parameters.AddWithValue("@userid", userId);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(_filesRepository.GetInfo(reader.GetGuid(reader.GetOrdinal("fileid"))));
                        }
                    }
                    return result;
                }
            }
        }
    }
}
