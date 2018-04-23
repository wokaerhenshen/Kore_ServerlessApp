using System;
using System.Collections.Generic;

namespace AWSServerlessWebApi.Models
{
    public partial class NewProjectExtensionBase
    {
        public Guid NewProjectId { get; set; }
        public string NewName { get; set; }
        public string NewDescription { get; set; }
        public Guid? NewAccountId { get; set; }
        public string NewFullNameofProject { get; set; }
        public DateTime? NewStartDate { get; set; }
        public DateTime? NewEndDate { get; set; }
        public int? NewBudgetType { get; set; }
        public int? NewBillingSchedule { get; set; }
        public string NewStatusRemarks { get; set; }
        public int? NewProjectNo { get; set; }
        public double? NewBudgetVariance { get; set; }
        public double? NewBudgettedHours { get; set; }
        public Guid? NewProjectTypeId { get; set; }
        public int? NewProjectManager { get; set; }
        public string NewSystemModules { get; set; }
        public bool? NewUnderReleaseMgmt { get; set; }
        public double? NewIssuehours { get; set; }
        public double? NewWarrantyhours { get; set; }
        public double? NewWorkhours { get; set; }
        public double? NewChangerequesthours { get; set; }
        public double? NewActualChangeRequestHours { get; set; }
        public double? NewActualWarrantyHours { get; set; }
        public double? NewActualWorkHours { get; set; }
        public double? NewActualHours { get; set; }
        public bool? NewCommissionable { get; set; }
        public decimal? NewRateOveride { get; set; }
        public decimal? NewRateoverideBase { get; set; }
        public decimal? NewRateoverideUse { get; set; }
        public string NewTenroxStatus { get; set; }
        public string NewBillingRemarks { get; set; }
        public Guid? NewPssaccountId { get; set; }
        public int? NewProjectPhase { get; set; }

        public AccountBase NewAccount { get; set; }
        public AccountBase NewPssaccount { get; set; }
    }
}
