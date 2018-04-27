using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AWSServerlessWebApi.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<CustomDay> CustomDay { get; set; }
        public virtual ICollection<NewTimesheetEntryExtensionBase> NewTimesheetEntryExtensionBase { get; set; }
    }
}
