using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileSharing.Model;

namespace FileSharing.DataAccess
{
    public interface IFilesRepository
    {
        File Add(File file);
        byte[] GetContent(Guid fileId);
        File GetInfo(Guid fileId);
        void UpdateContent(Guid fileId, byte[] content);
        IEnumerable<File> GetUserFiles(Guid userId);
        void Delete(Guid fileId);
    }
}
