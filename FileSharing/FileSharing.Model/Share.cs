using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSharing.Model
{
    public class Share
    {
        public File FileId { get; set; }
        public User UserId { get; set; }
    }
}
