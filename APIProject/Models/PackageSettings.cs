﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIProject.Models
{
    public class PackageSettings:BaseEntity
    {
        public PackageEnum Package { get; set; }
    }
}
