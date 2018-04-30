using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWSServerlessWebApi.Models
{
    public class CustomDay_WBI
    {
        public Guid? NewChangeRequestId { get; set; }
        public string CustomDayId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public virtual NewChangeRequestExtensionBase WBI { get; set; }
        public virtual CustomDay CustomDay { get; set; }
    }
}
