using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIProject.Request
{
    public class ClientLawyerAssignmentRequest
    {
        public int LawyerId { get; set; }

        public int ClientId { get; set; }
    }
}
