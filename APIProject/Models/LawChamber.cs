using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIProject.Models
{
    public class LawChamber:BaseEntity
    {
        public string ChamberName { get; set; }
        public Address Address { get; set; }
        public PackageSettings PackageSettings { get; set; }
        public Users ChamberHead { get; set; }
        public List<LawyerProfile> Associates { get; set; }
        public int AssociatesLimit { get; set; }
    }
}
