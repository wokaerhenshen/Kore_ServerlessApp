using AWSServerlessWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWSServerlessWebApi.ViewModels
{
    public class TimeslipWithWBINameVM
    {
        public string newTimesheetEntryId { get; set; }
        public string newStartTask { get; set; }
        public string newEndTask { get; set; }
        public string newRemarks { get; set; }
        public string newChangeRequestId { get; set; }
        public string WBIName { get; set; }
    }
}
