using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIProject.Models
{
    public class LawyerProfile:BaseEntity
    {
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
    }
}
