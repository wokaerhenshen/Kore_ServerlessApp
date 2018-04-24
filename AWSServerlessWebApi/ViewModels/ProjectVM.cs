﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWSServerlessWebApi.ViewModels
{
    public class ProjectVM
    {
        public Guid ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string ProjectType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid ClientId { get; set; }

    //    public virtual ClientVM Client { get; set; }
    //    public virtual ICollection<WBIVM> WBIs { get; set; }
}
}
