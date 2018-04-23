using System;
using System.Collections.Generic;

namespace AWSServerlessWebApi.Models
{
    public partial class NewProjectTypeExtensionBase
    {
        public Guid NewProjectTypeId { get; set; }
        public string NewName { get; set; }
    }
}
