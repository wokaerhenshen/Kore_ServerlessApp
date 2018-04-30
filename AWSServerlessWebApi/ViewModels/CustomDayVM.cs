using AWSServerlessWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWSServerlessWebApi.ViewModels
{
    public class CustomDayVM
    {
        public string CustomDayId { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<CustomDay_WBIVM> TimeSlip_Templates { get; set; }
    }
}
