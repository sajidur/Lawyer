using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIProject.Models
{
    public class Education:BaseEntity
    {
        public string DegreeName { get; set; }
        public string Passyear { get; set; }
        public string InstituteName { get; set; }
        public string Order { get; set; }

    }
}
