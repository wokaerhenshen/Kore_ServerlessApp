using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWSServerlessWebApi.ViewModels
{
    public class TimeslipVM
    {
        public string TimeslipId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Remarks { get; set; }
        public string WBI_Id { get; set; }
        public string UserId { get; set; }
        public string DayId { get; set; }

        //public virtual WBIVM WBI { get; set; }
        //public virtual UserDetailVM UserDetail { get; set; }
        //public virtual CustomDayVM CustomDay { get; set; }
    }
}
