using AWSServerlessWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWSServerlessWebApi.ViewModels
{
    public class TimeslipWithWBINameVM
    {
        public string TimeslipId { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Remarks { get; set; }
        public string WBI_Id { get; set; }
        public string WBIName { get; set; }
    }
}
