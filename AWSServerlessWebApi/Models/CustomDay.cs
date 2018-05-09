using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AWSServerlessWebApi.Models
{
    public class CustomDay
    {
        [Key]
        public string CustomDayId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<CustomDay_WBI> Timeslip_Templates { get; set; }
    }
}
