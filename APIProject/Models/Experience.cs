using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIProject.Models
{
    public class Experience:BaseEntity
    {
        public string JobTitle { get; set; }
        public string ExperienceArea { get; set; }
        public long FromDate { get; set; }
        public long ToDate { get; set; }
        public string Organization { get; set; }
        public string Details { get; set; }

    }
}
