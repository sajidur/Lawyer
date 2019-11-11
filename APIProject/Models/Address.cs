using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIProject.Models
{
    public class Address:BaseEntity
    {
        public string Division { get; set; }
        public string District { get; set; }
        public string Thana { get; set; }
        public string FullAddress { get; set; }
    }
}
