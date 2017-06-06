using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileSharing.Model;

namespace FileSharing.DataAccess
{
    public interface ISharesRepository
    {
        Share Add(Share share);
        IEnumerable<User> GetFileUsers(Guid fileId);
        void Delete(Guid shareId);
        Guid GetShareId(Guid userId, Guid fileId);
        IEnumerable<File> GetFilesSh(Guid userId);
    }
}
