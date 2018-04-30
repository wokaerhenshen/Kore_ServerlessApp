using System;
using System.Collections.Generic;

namespace AWSServerlessWebApi.Models
{
    public partial class NewChangeRequestExtensionBase
    {
        
        public Guid NewChangeRequestId { get; set; }
        public string NewName { get; set; }
        public string NewChangeTitle { get; set; }
        public string NewRemarks { get; set; }
        public Guid? NewProjectId { get; set; }
        public int? NewChangeRequestNo { get; set; }
        public DateTime? NewDateOpened { get; set; }
        public DateTime? NewCompletionDeadline { get; set; }
        public DateTime? NewDateClosed { get; set; }
        public double? NewEstimatedHours { get; set; }
        public int? NewChangePriority { get; set; }
        public int? NewThisChangeis { get; set; }
        public string NewAnalyst { get; set; }
        public DateTime? NewAnalysisDate { get; set; }
        public int? NewDisposition { get; set; }
        public string NewImplementer { get; set; }
        public DateTime? NewImplementationDate { get; set; }
        public int? NewActualHours { get; set; }
        public string NewStatusResolutionRemark { get; set; }
        public string NewSystemModule { get; set; }
        public int? NewActionType { get; set; }
        public string NewOldguid { get; set; }
        public Guid? NewRelatedReleaseId { get; set; }
        public Guid? NewClientcreatorid { get; set; }
        public int? NewSystemModuleDropDown { get; set; }
        public DateTime? NewStatusLastChanged { get; set; }
        public double? NewTotalhoursbilled { get; set; }
        public string NewApprovedBy { get; set; }
        public string NewRequestedBy { get; set; }
        public int? NewNewFeature { get; set; }
        public bool? NewReportChecklist { get; set; }
        public bool? NewCrmentityChecklist { get; set; }
        public bool? NewCrmformDesignChecklist { get; set; }
        public bool? NewCrmviewsChecklist { get; set; }
        public bool? NewSystemDataChecklist { get; set; }
        public bool? NewUserSetupChecklist { get; set; }
        public string NewIssueDescription { get; set; }
        public string NewTestedBy { get; set; }
        public Guid? NewTestedbyid { get; set; }
        public bool? NewLocked { get; set; }
        public bool? NewHideonPortal { get; set; }
        public bool? NewClientActionRequired { get; set; }
        public string NewSpecialDeploymentRequirements { get; set; }
        public bool? NewHidefromWeeklyStatus { get; set; }
        public DateTime? NewNextMonday { get; set; }
        public string NewDebugInformation { get; set; }
        public bool? NewEnablePmonlyTimeslips { get; set; }
        public string NewTestPlan { get; set; }
        public int? NewFullEstimateHours { get; set; }
        public bool? NewCreatePbi { get; set; }
        public string NewWeeklyWbititle { get; set; }
        public string NewRecurringWbititleMonthly { get; set; }

        public virtual ICollection<CustomDay_WBI> Timeslip_Templates { get; set; }
    }
}
