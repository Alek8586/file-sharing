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
                    command.Parameters.AddWithValue("@fileid", share.FileId.Id);
                    command.Parameters.AddWithValue("@userid", share.UserId.Id);
                    command.ExecuteNonQuery();
                    return share;
                }
            }
        }

        public Share GetInfo(Guid userid)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "select fileid, userid from shares where userid = @userid";
                    command.Parameters.AddWithValue("@usserid", userid);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return new Share
                            {
                                UserId = _usersRepository.Get(reader.GetGuid(reader.GetOrdinal("userid")))
                            };
                        }
                        throw new ArgumentException("file not found");
                    }
                }
            }
        }

        public IEnumerable<Share> GetUserFiles(Guid id)
        {
            var result = new List<Share>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "select filesid from share where userid = @userid";
                    command.Parameters.AddWithValue("@userid", id);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(GetInfo(reader.GetGuid(reader.GetOrdinal("id"))));
                        }
                    }
                    return result;
                }
            }
        }
    }
}
