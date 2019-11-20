using APIProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIProject.Request
{
    public class LawyerProfileRequest
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public List<Education> Education { get; set; }
        public Address Address { get; set; }
        public List<BIO> Bio { get; set; }
        public int BioCharLimit { get; set; }
        public string WorkingArea { get; set; }
        public List<Experience> Experience { get; set; }
        public FileAttachment ProfilePic { get; set; }
        public PackageSettings PackageSettings { get; set; }
    }
}
