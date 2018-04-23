using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWSServerlessWebApi.ViewModels
{
    public class UserDetailVM
    {
        public string UserDetailId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }

        public virtual ICollection<TimeslipVM> Timeslips { get; set; }

    }
}
