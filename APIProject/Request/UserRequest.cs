using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIProject.Request
{
    public class UserRequest
    {
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public int UserType { get; set; }
    }
}
