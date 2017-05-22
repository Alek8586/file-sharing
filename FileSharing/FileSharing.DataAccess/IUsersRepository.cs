using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileSharing.Model;

namespace FileSharing.DataAccess
{
    public interface IUsersRepository
    {
        User Add(string name, string email);
        void Delete(Guid userId);
        User Get(Guid userId);
    }
}
