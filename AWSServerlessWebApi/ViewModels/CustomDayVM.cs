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
        public string Name { get; set; }
        public string Description { get; set; }
        public List<TimeslipVM> TimeSlip { get; set; }

    //  public virtual ICollection<TimeslipVM> Timeslips { get; set; }
    }

}
