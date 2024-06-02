﻿using Solid.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank_api_project.Models
{
    public class OfficialBankPostModel
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public int Salary { get; set; }
        public Degree Role { get; set; }
    }
}