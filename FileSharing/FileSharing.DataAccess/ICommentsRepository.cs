using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileSharing.Model;

namespace FileSharing.DataAccess
{
    public interface ICommentsRepository
    {
        Comment Add(Comment comment);
        void Delete(Guid commentId);
        IEnumerable<Comment> GetFileComments(Guid fileId);
        Comment GetInfo(Guid fileId);
    }
}
