﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWSServerlessWebApi.ViewModels
{
    public class ClientVM
    {
        public string ClientId { get; set; }
        public string ClientName { get; set; }
        public int DeletionStateCode { get; set; }
        public int StateCode { get; set; }
    }
}
