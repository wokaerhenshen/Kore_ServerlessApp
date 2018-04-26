using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWSServerlessWebApi.ViewModels
{
    public class TimeslipVM
    {
        public string TimeslipId { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Remarks { get; set; }
        public string WBI_Id { get; set; }
        public string UserId { get; set; }
        public string DayId { get; set; }
    }
}
