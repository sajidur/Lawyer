using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIProject.Response
{
    public class ResponseClass
    {
        public ResponseClass()
        {
            status = false;
            data = null;
        }
        public bool status { get; set; }
        public object data { get; set; }
    }
}
