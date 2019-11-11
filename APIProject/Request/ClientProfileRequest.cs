﻿using APIProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIProject.Request
{
    public class CustomerProfileRequest
    {
        public string Name { get; set; }
        public string Mobile { get; set; }
        public Address Address { get; set; }
    }
}
