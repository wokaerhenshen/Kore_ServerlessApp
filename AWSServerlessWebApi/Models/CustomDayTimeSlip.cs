using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AWSServerlessWebApi.Models
{
    public class CustomDayTimeSlip
    {
        [Key, Column(Order = 0)]
        public int CustomDayId { get; set; }

        [Key, Column(Order = 1)]
        public Guid TimeSlipId { get; set; }

        public virtual CustomDay CustomDay { get; set; }
        public virtual NewTimesheetEntryExtensionBase GetNewTimesheetEntryExtensionBase { get; set; }
    }
}
