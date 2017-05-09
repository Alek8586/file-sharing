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
        IEnumerable<Share> GetUserFiles(Guid id);
        Share GetInfo(Guid userid);
    }
}
