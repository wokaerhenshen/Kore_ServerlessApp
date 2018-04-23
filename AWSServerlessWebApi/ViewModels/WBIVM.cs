using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWSServerlessWebApi.ViewModels
{
    public class WBIVM
    {
        public Guid WBI_Id { get; set; }
        public string Description { get; set; }
        public int EstimatedHours { get; set; }
        public int ActualHours { get; set; }
        public Guid ProjectId { get; set; }

        public virtual ProjectVM Project { get; set; }
        public virtual ICollection<TimeslipVM> Timeslips { get; set; }

    }
}
