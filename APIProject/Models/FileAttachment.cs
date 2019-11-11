using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIProject.Models
{
    public class FileAttachment:BaseEntity
    {
        public int UploadType { get; set; }
        public string FileContent { get; set; }
        public string FileType { get; set; }
        public string FileName { get; set; }
    }
}
