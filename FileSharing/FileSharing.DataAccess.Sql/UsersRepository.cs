using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using FileSharing.Model;

namespace FileSharing.DataAccess.Sql
{
    public class UsersRepository : IUsersRepository
    {
        private readonly string _connectionString;

        public UsersRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public User Add(string name, string email)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    var userId = Guid.NewGuid();
                    command.CommandText = "insert into users values (@id, @name, @email)";
                    command.Parameters.AddWithValue("@id", userId);
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@email", email);
                    command.ExecuteNonQuery();
                    return new User
                    {
                        Id = userId,
                        Email = email,
                        Name = name
                    };
                }
            }
        }

        public void Delete(Guid userId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "delete from users where id = @userid";
                    command.Parameters.AddWithValue("@userid", userId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public User Get(Guid userId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "select id, name, email from users where id = @userid";
                    command.Parameters.AddWithValue("@userid", userId);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return new User
                            {
                                Id = reader.GetGuid(reader.GetOrdinal("id")),
                                Name = reader.GetString(reader.GetOrdinal("name")),
                                Email = reader.GetString(reader.GetOrdinal("email"))
                            };
                        }
                        throw new ArgumentException("user not found");
                    }
                }
            }
        }
    }
}
