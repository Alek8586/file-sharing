using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSharing.Model
{
    public class Comment
    {
        public Guid Id { get; set; }
        public Guid FileId { get; set; }
        public Guid UserId { get; set; }
        public string Text { get; set; }
    }
}
