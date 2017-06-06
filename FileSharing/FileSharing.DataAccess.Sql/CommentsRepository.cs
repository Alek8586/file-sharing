using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using FileSharing.Model;

namespace FileSharing.DataAccess.Sql
{
    public class CommentsRepository : ICommentsRepository
    {
        private readonly string _connectionString;
        private readonly IUsersRepository _usersRepository;
        private readonly IFilesRepository _filesRepository;

        public CommentsRepository(string connectionString, IUsersRepository usersRepository, IFilesRepository filesRepository)
        {
            _connectionString = connectionString;
            _usersRepository = usersRepository;
            _filesRepository = filesRepository;
        }

        public Comment Add(Comment comment)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "insert into comments (id, userid, fileid, text) values (@id, @userid, @fileid, @text)";
                    var commentId = Guid.NewGuid();
                    command.Parameters.AddWithValue("@id", commentId);
                    command.Parameters.AddWithValue("@userid", comment.UserId);
                    command.Parameters.AddWithValue("@fileid", comment.FileId);
                    command.Parameters.AddWithValue("@text", comment.Text);
                    command.ExecuteNonQuery();
                    comment.Id = commentId;
                    return comment;
                }
            }
        }

        public void Delete(Guid id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "delete from comments where id = @id";
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public Comment GetInfo(Guid fileId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "select id, fileid, userid, text from comments where id = @id";
                    command.Parameters.AddWithValue("@id", fileId);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return new Comment
                            {
                                Id = reader.GetGuid(reader.GetOrdinal("id")),
                                FileId = reader.GetGuid(reader.GetOrdinal("fileid")),
                                UserId = reader.GetGuid(reader.GetOrdinal("userid")),
                                Text = reader.GetString(reader.GetOrdinal("text"))
                            };
                        }
                        throw new ArgumentException("comment not found");
                    }
                }
            }
        }

        public IEnumerable<Comment> GetFileComments(Guid id)
        {
            var result = new List<Comment>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "select id from comments where fileid = @fileid";
                    command.Parameters.AddWithValue("@fileid", id);
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
