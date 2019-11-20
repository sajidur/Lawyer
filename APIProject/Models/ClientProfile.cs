﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIProject.Models
{
    public class ClientProfile: BaseEntity
    {
        public string Name { get; set; }
        public string Mobile { get; set; }
        public Address Address { get; set; }
        public Users Users { get; set; }

    }
}
