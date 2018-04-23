using System;
using System.Collections.Generic;

namespace AWSServerlessWebApi.Models
{
    public partial class NewTimesheetEntryExtensionBase
    {
        public Guid NewTimesheetEntryId { get; set; }
        public string NewId { get; set; }
        public DateTime? NewStartTask { get; set; }
        public DateTime? NewEndTask { get; set; }
        public int? NewDuration { get; set; }
        public int? NewEntryNo { get; set; }
        public string NewRemarks { get; set; }
        public Guid? NewProjectId { get; set; }
        public bool? NewOutofScope { get; set; }
        public string NewInternalRemarks { get; set; }
        public double? NewDurationHours { get; set; }
        public int? NewTaskType { get; set; }
        public string NewRequestedBy { get; set; }
        public Guid? NewChangeRequestId { get; set; }
        public Guid? NewIssueId { get; set; }
        public bool? NewIsBatched { get; set; }
        public bool? NewApprovedForBilling { get; set; }
        public bool? NewCredit { get; set; }
        public Guid? NewTimesheetbatchid { get; set; }
    }
}
