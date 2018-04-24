using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWSServerlessWebApi.ViewModels
{
    public class TimeslipVM
    {
        public int TimeslipId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Remarks { get; set; }
        public int WBI_Id { get; set; }
        public int UserId { get; set; }
        public int DayId { get; set; }

     //   public virtual WBIVM WBI { get; set; }
     //   public virtual UserDetailVM UserDetail { get; set; }
     //   public virtual CustomDayVM CustomDay { get; set; }
    }
}
