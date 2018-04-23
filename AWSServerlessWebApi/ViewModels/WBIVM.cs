using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWSServerlessWebApi.ViewModels
{
    public class WBIVM
    {
        public int WBI_Id { get; set; }
        public string Description { get; set; }
        public int EstimatedHours { get; set; }
        public int ActualHours { get; set; }
        public int ProjectId { get; set; }

        public virtual ProjectVM Project { get; set; }
        public virtual ICollection<TimeslipVM> Timeslips { get; set; }

    }
}
