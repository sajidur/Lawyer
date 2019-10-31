using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIProject.Models
{
    public class ClientLawyerAssignment:BaseEntity
    {
        public int LawyerId { get; set; }

        public int ClientId { get; set; }
        public LawyerProfile LawyerProfile { get; set; }
        public ClientProfile ClientProfile { get; set; }
    }
}
