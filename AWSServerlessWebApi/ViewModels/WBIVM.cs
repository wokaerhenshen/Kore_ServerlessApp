using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWSServerlessWebApi.ViewModels
{
    public class WBIVM
    {
        public string WBI_Id { get; set; }
        public string Description { get; set; }
        public int EstimatedHours { get; set; }
        public int ActualHours { get; set; }
        public string ProjectId { get; set; }
    }
}
