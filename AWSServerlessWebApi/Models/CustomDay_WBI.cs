using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AWSServerlessWebApi.Models
{
    public class CustomDay_WBI
    {
        [Key]
        public string TimeslipTemplateId { get; set; }
        public Guid? NewChangeRequestId { get; set; }
        public string CustomDayId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Remarks { get; set; }

        public virtual NewChangeRequestExtensionBase WBI { get; set; }
        public virtual CustomDay CustomDay { get; set; }
    }
}
