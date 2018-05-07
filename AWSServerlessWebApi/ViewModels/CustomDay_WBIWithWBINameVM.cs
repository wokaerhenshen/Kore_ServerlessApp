using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWSServerlessWebApi.ViewModels
{
    public class CustomDay_WBIWithWBINameVM
    {
        public string TimeslipTemplateId { get; set; }
        public Guid? NewChangeRequestId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Remarks { get; set; }
        public string WBIName { get; set; }
    }
}
