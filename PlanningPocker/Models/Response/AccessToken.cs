﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanningPocker.Models.Response
{
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime ExpirationUtc { get; set; }
        public string Name { get; set; }
    }
}
