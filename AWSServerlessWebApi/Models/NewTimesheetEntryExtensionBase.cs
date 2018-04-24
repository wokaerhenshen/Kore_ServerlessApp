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


        // the columns below and getten from a similar table
        public DateTime? CreatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public Guid? ModifiedBy { get; set; }
        public Guid? OwningUser { get; set; }
        public Guid? OwningBusinessUnit { get; set; }
        public int StateCode { get; set; }
        public int? StatusCode { get; set; }
        public int? DeletionStateCode { get; set; }
        public DateTime? VersionNumber { get; set; }
        public int? ImportSequenceNumber { get; set; }
        public DateTime? OverriddenCreatedOn { get; set; }





        public virtual ICollection<CustomDayTimeSlip> CustomDayTimeSlips { get; set; }

    }
}
