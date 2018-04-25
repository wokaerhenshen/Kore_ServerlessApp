using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AWSServerlessWebApi.Models
{
    public partial class KORE_Interactive_MSCRMContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<AccountBase> AccountBase { get; set; }
        public virtual DbSet<NewChangeRequestExtensionBase> NewChangeRequestExtensionBase { get; set; }
        public virtual DbSet<NewProjectExtensionBase> NewProjectExtensionBase { get; set; }
        public virtual DbSet<NewProjectTypeExtensionBase> NewProjectTypeExtensionBase { get; set; }
        public virtual DbSet<NewTimesheetEntryExtensionBase> NewTimesheetEntryExtensionBase { get; set; }
        
        public virtual DbSet<StringMap> StringMap { get; set; }
        public virtual DbSet<CustomDay> CustomDays { get; set; }
        public virtual DbSet<CustomDayTimeSlip> CustomDayTimeSlips { get; set; }

        // this is not auto generated
        public KORE_Interactive_MSCRMContext(DbContextOptions<KORE_Interactive_MSCRMContext> options)
    : base(options)
        {
        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer(@"Server=KARL;Database=KORE_Interactive_MSCRM;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId);
                entity.Property(e => e.UserId).ValueGeneratedNever();

            });


            modelBuilder.Entity<AccountBase>(entity =>
            {
                entity.HasKey(e => e.AccountId);

                entity.Property(e => e.AccountId).ValueGeneratedNever();

                entity.Property(e => e.AccountNumber).HasMaxLength(20);

                entity.Property(e => e.Aging30).HasColumnType("money");

                entity.Property(e => e.Aging30Base)
                    .HasColumnName("Aging30_Base")
                    .HasColumnType("money");

                entity.Property(e => e.Aging60).HasColumnType("money");

                entity.Property(e => e.Aging60Base)
                    .HasColumnName("Aging60_Base")
                    .HasColumnType("money");

                entity.Property(e => e.Aging90).HasColumnType("money");

                entity.Property(e => e.Aging90Base)
                    .HasColumnName("Aging90_Base")
                    .HasColumnType("money");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreditLimit).HasColumnType("money");

                entity.Property(e => e.CreditLimitBase)
                    .HasColumnName("CreditLimit_Base")
                    .HasColumnType("money");

                entity.Property(e => e.DoNotBulkEmail).HasColumnName("DoNotBulkEMail");

                entity.Property(e => e.DoNotEmail).HasColumnName("DoNotEMail");

                entity.Property(e => e.DoNotSendMm).HasColumnName("DoNotSendMM");

                entity.Property(e => e.EmailAddress1)
                    .HasColumnName("EMailAddress1")
                    .HasMaxLength(100);

                entity.Property(e => e.EmailAddress2)
                    .HasColumnName("EMailAddress2")
                    .HasMaxLength(100);

                entity.Property(e => e.EmailAddress3)
                    .HasColumnName("EMailAddress3")
                    .HasMaxLength(100);

                entity.Property(e => e.ExchangeRate).HasColumnType("decimal(23, 10)");

                entity.Property(e => e.Fax).HasMaxLength(50);

                entity.Property(e => e.FtpSiteUrl)
                    .HasColumnName("FtpSiteURL")
                    .HasMaxLength(200);

                entity.Property(e => e.LastUsedInCampaign).HasColumnType("datetime");

                entity.Property(e => e.MarketCap).HasColumnType("money");

                entity.Property(e => e.MarketCapBase)
                    .HasColumnName("MarketCap_Base")
                    .HasColumnType("money");

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(160);

                entity.Property(e => e.OverriddenCreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Revenue).HasColumnType("money");

                entity.Property(e => e.RevenueBase)
                    .HasColumnName("Revenue_Base")
                    .HasColumnType("money");

                entity.Property(e => e.Sic)
                    .HasColumnName("SIC")
                    .HasMaxLength(20);

                entity.Property(e => e.StockExchange).HasMaxLength(20);

                entity.Property(e => e.Telephone1).HasMaxLength(50);

                entity.Property(e => e.Telephone2).HasMaxLength(50);

                entity.Property(e => e.Telephone3).HasMaxLength(50);

                entity.Property(e => e.TickerSymbol).HasMaxLength(10);

                entity.Property(e => e.UtcconversionTimeZoneCode).HasColumnName("UTCConversionTimeZoneCode");

                entity.Property(e => e.VersionNumber).IsRowVersion();

                entity.Property(e => e.WebSiteUrl)
                    .HasColumnName("WebSiteURL")
                    .HasMaxLength(200);

                entity.Property(e => e.YomiName).HasMaxLength(160);

                entity.HasOne(d => d.Master)
                    .WithMany(p => p.InverseMaster)
                    .HasForeignKey(d => d.MasterId)
                    .HasConstraintName("account_master_account");

                entity.HasOne(d => d.ParentAccount)
                    .WithMany(p => p.InverseParentAccount)
                    .HasForeignKey(d => d.ParentAccountId)
                    .HasConstraintName("account_parent_account");
            });

            modelBuilder.Entity<NewChangeRequestExtensionBase>(entity =>
            {
                entity.HasKey(e => e.NewChangeRequestId);

                entity.ToTable("New_ChangeRequestExtensionBase");

                entity.Property(e => e.NewChangeRequestId)
                    .HasColumnName("New_ChangeRequestId")
                    .ValueGeneratedNever();

                entity.Property(e => e.NewActionType).HasColumnName("New_ActionType");

                entity.Property(e => e.NewActualHours).HasColumnName("New_ActualHours");

                entity.Property(e => e.NewAnalysisDate)
                    .HasColumnName("New_AnalysisDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.NewAnalyst)
                    .HasColumnName("New_Analyst")
                    .HasMaxLength(100);

                entity.Property(e => e.NewApprovedBy)
                    .HasColumnName("New_ApprovedBy")
                    .HasMaxLength(100);

                entity.Property(e => e.NewChangePriority).HasColumnName("New_ChangePriority");

                entity.Property(e => e.NewChangeRequestNo).HasColumnName("New_ChangeRequestNo");

                entity.Property(e => e.NewChangeTitle)
                    .HasColumnName("New_ChangeTitle")
                    .HasMaxLength(60);

                entity.Property(e => e.NewClientActionRequired).HasColumnName("New_ClientActionRequired");

                entity.Property(e => e.NewClientcreatorid).HasColumnName("new_clientcreatorid");

                entity.Property(e => e.NewCompletionDeadline)
                    .HasColumnName("New_CompletionDeadline")
                    .HasColumnType("datetime");

                entity.Property(e => e.NewCreatePbi).HasColumnName("New_CreatePBI");

                entity.Property(e => e.NewCrmentityChecklist).HasColumnName("New_CRMEntityChecklist");

                entity.Property(e => e.NewCrmformDesignChecklist).HasColumnName("New_CRMFormDesignChecklist");

                entity.Property(e => e.NewCrmviewsChecklist).HasColumnName("New_CRMViewsChecklist");

                entity.Property(e => e.NewDateClosed)
                    .HasColumnName("New_DateClosed")
                    .HasColumnType("datetime");

                entity.Property(e => e.NewDateOpened)
                    .HasColumnName("New_DateOpened")
                    .HasColumnType("datetime");

                entity.Property(e => e.NewDebugInformation).HasColumnName("New_DebugInformation");

                entity.Property(e => e.NewDisposition).HasColumnName("New_Disposition");

                entity.Property(e => e.NewEnablePmonlyTimeslips).HasColumnName("New_EnablePMOnlyTimeslips");

                entity.Property(e => e.NewEstimatedHours).HasColumnName("New_EstimatedHours");

                entity.Property(e => e.NewFullEstimateHours).HasColumnName("New_FullEstimateHours");

                entity.Property(e => e.NewHidefromWeeklyStatus).HasColumnName("New_HidefromWeeklyStatus");

                entity.Property(e => e.NewHideonPortal).HasColumnName("New_HideonPortal");

                entity.Property(e => e.NewImplementationDate)
                    .HasColumnName("New_ImplementationDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.NewImplementer)
                    .HasColumnName("New_Implementer")
                    .HasMaxLength(100);

                entity.Property(e => e.NewIssueDescription)
                    .HasColumnName("New_IssueDescription")
                    .HasMaxLength(3000);

                entity.Property(e => e.NewLocked).HasColumnName("New_Locked");

                entity.Property(e => e.NewName)
                    .HasColumnName("New_name")
                    .HasMaxLength(100);

                entity.Property(e => e.NewNewFeature).HasColumnName("New_NewFeature");

                entity.Property(e => e.NewNextMonday)
                    .HasColumnName("New_NextMonday")
                    .HasColumnType("datetime");

                entity.Property(e => e.NewOldguid)
                    .HasColumnName("New_OLDGUID")
                    .HasMaxLength(40);

                entity.Property(e => e.NewProjectId).HasColumnName("New_ProjectId");

                entity.Property(e => e.NewRecurringWbititleMonthly)
                    .HasColumnName("New_RecurringWBITitleMonthly")
                    .HasMaxLength(200);

                entity.Property(e => e.NewRelatedReleaseId).HasColumnName("New_RelatedReleaseId");

                entity.Property(e => e.NewRemarks).HasColumnName("New_Remarks");

                entity.Property(e => e.NewReportChecklist).HasColumnName("New_ReportChecklist");

                entity.Property(e => e.NewRequestedBy)
                    .HasColumnName("New_RequestedBy")
                    .HasMaxLength(100);

                entity.Property(e => e.NewSpecialDeploymentRequirements).HasColumnName("New_SpecialDeploymentRequirements");

                entity.Property(e => e.NewStatusLastChanged)
                    .HasColumnName("New_StatusLastChanged")
                    .HasColumnType("datetime");

                entity.Property(e => e.NewStatusResolutionRemark).HasColumnName("New_StatusResolutionRemark");

                entity.Property(e => e.NewSystemDataChecklist).HasColumnName("New_SystemDataChecklist");

                entity.Property(e => e.NewSystemModule)
                    .HasColumnName("New_SystemModule")
                    .HasMaxLength(100);

                entity.Property(e => e.NewSystemModuleDropDown).HasColumnName("New_SystemModuleDropDown");

                entity.Property(e => e.NewTestPlan).HasColumnName("New_TestPlan");

                entity.Property(e => e.NewTestedBy)
                    .HasColumnName("New_TestedBy")
                    .HasMaxLength(500);

                entity.Property(e => e.NewTestedbyid).HasColumnName("new_testedbyid");

                entity.Property(e => e.NewThisChangeis).HasColumnName("New_ThisChangeis");

                entity.Property(e => e.NewTotalhoursbilled).HasColumnName("New_totalhoursbilled");

                entity.Property(e => e.NewUserSetupChecklist).HasColumnName("New_UserSetupChecklist");

                entity.Property(e => e.NewWeeklyWbititle)
                    .HasColumnName("New_WeeklyWBITitle")
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<NewProjectExtensionBase>(entity =>
            {
                entity.HasKey(e => e.NewProjectId);

                entity.ToTable("New_ProjectExtensionBase");

                entity.Property(e => e.NewProjectId)
                    .HasColumnName("New_ProjectId")
                    .ValueGeneratedNever();

                entity.Property(e => e.NewAccountId).HasColumnName("New_AccountId");

                entity.Property(e => e.NewActualChangeRequestHours).HasColumnName("New_ActualChangeRequestHours");

                entity.Property(e => e.NewActualHours).HasColumnName("New_ActualHours");

                entity.Property(e => e.NewActualWarrantyHours).HasColumnName("New_ActualWarrantyHours");

                entity.Property(e => e.NewActualWorkHours).HasColumnName("New_ActualWorkHours");

                entity.Property(e => e.NewBillingRemarks).HasColumnName("New_BillingRemarks");

                entity.Property(e => e.NewBillingSchedule).HasColumnName("New_BillingSchedule");

                entity.Property(e => e.NewBudgetType).HasColumnName("New_BudgetType");

                entity.Property(e => e.NewBudgetVariance).HasColumnName("New_BudgetVariance");

                entity.Property(e => e.NewBudgettedHours).HasColumnName("New_BudgettedHours");

                entity.Property(e => e.NewChangerequesthours).HasColumnName("New_changerequesthours");

                entity.Property(e => e.NewCommissionable).HasColumnName("New_commissionable");

                entity.Property(e => e.NewDescription).HasColumnName("New_Description");

                entity.Property(e => e.NewEndDate)
                    .HasColumnName("New_EndDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.NewFullNameofProject)
                    .HasColumnName("New_FullNameofProject")
                    .HasMaxLength(100);

                entity.Property(e => e.NewIssuehours).HasColumnName("New_issuehours");

                entity.Property(e => e.NewName)
                    .HasColumnName("New_name")
                    .HasMaxLength(100);

                entity.Property(e => e.NewProjectManager).HasColumnName("New_ProjectManager");

                entity.Property(e => e.NewProjectNo).HasColumnName("New_ProjectNo");

                entity.Property(e => e.NewProjectPhase).HasColumnName("New_ProjectPhase");

                entity.Property(e => e.NewProjectTypeId).HasColumnName("New_ProjectTypeId");

                entity.Property(e => e.NewPssaccountId).HasColumnName("New_PSSAccountId");

                entity.Property(e => e.NewRateOveride)
                    .HasColumnName("New_RateOveride")
                    .HasColumnType("money");

                entity.Property(e => e.NewRateoverideBase)
                    .HasColumnName("new_rateoveride_Base")
                    .HasColumnType("money");

                entity.Property(e => e.NewRateoverideUse)
                    .HasColumnName("New_rateoveride_use")
                    .HasColumnType("decimal(23, 10)");

                entity.Property(e => e.NewStartDate)
                    .HasColumnName("New_StartDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.NewStatusRemarks).HasColumnName("New_StatusRemarks");

                entity.Property(e => e.NewSystemModules).HasColumnName("New_SystemModules");

                entity.Property(e => e.NewTenroxStatus)
                    .HasColumnName("New_TenroxStatus")
                    .HasMaxLength(500);

                entity.Property(e => e.NewUnderReleaseMgmt).HasColumnName("New_UnderReleaseMgmt");

                entity.Property(e => e.NewWarrantyhours).HasColumnName("New_warrantyhours");

                entity.Property(e => e.NewWorkhours).HasColumnName("New_workhours");

                entity.HasOne(d => d.NewAccount)
                    .WithMany(p => p.NewProjectExtensionBaseNewAccount)
                    .HasForeignKey(d => d.NewAccountId)
                    .HasConstraintName("Account_New_Projects");

                entity.HasOne(d => d.NewPssaccount)
                    .WithMany(p => p.NewProjectExtensionBaseNewPssaccount)
                    .HasForeignKey(d => d.NewPssaccountId)
                    .HasConstraintName("new_pssaccount_new_project");
            });

            modelBuilder.Entity<NewProjectTypeExtensionBase>(entity =>
            {
                entity.HasKey(e => e.NewProjectTypeId);

                entity.ToTable("New_ProjectTypeExtensionBase");

                entity.Property(e => e.NewProjectTypeId)
                    .HasColumnName("New_ProjectTypeId")
                    .ValueGeneratedNever();

                entity.Property(e => e.NewName)
                    .HasColumnName("New_name")
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<NewTimesheetEntryExtensionBase>(entity =>
            {
                entity.HasKey(e => e.NewTimesheetEntryId);

                entity.ToTable("New_TimesheetEntryExtensionBase");

                entity.Property(e => e.NewTimesheetEntryId)
                    .HasColumnName("New_TimesheetEntryId")
                    .ValueGeneratedNever();

                entity.Property(e => e.NewApprovedForBilling).HasColumnName("New_ApprovedForBilling");

                entity.Property(e => e.NewChangeRequestId).HasColumnName("New_ChangeRequestId");

                entity.Property(e => e.NewCredit).HasColumnName("New_Credit");

                entity.Property(e => e.NewDuration).HasColumnName("New_Duration");

                entity.Property(e => e.NewDurationHours).HasColumnName("New_DurationHours");

                entity.Property(e => e.NewEndTask)
                    .HasColumnName("New_EndTask")
                    .HasColumnType("datetime");

                entity.Property(e => e.NewEntryNo).HasColumnName("New_EntryNo");

                entity.Property(e => e.NewId)
                    .HasColumnName("New_ID")
                    .HasMaxLength(100);

                entity.Property(e => e.NewInternalRemarks).HasColumnName("New_InternalRemarks");

                entity.Property(e => e.NewIsBatched).HasColumnName("New_IsBatched");

                entity.Property(e => e.NewIssueId).HasColumnName("New_IssueId");

                entity.Property(e => e.NewOutofScope).HasColumnName("New_OutofScope");

                entity.Property(e => e.NewProjectId).HasColumnName("New_ProjectId");

                entity.Property(e => e.NewRemarks).HasColumnName("New_Remarks");

                entity.Property(e => e.NewRequestedBy)
                    .HasColumnName("New_RequestedBy")
                    .HasMaxLength(50);

                entity.Property(e => e.NewStartTask)
                    .HasColumnName("New_StartTask")
                    .HasColumnType("datetime");

                entity.Property(e => e.NewTaskType).HasColumnName("New_TaskType");

                entity.Property(e => e.NewTimesheetbatchid).HasColumnName("new_timesheetbatchid");


                // the properties below and hard coded :
                // nothing actually
                entity.HasOne(e => e.User)
                    .WithMany(p => p.NewTimesheetEntryExtensionBase)
                    .HasForeignKey(d => d.OwningUser)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<StringMap>(entity =>
            {

                entity.HasKey(e => e.StringMapId);

                entity.ToTable("String_Map");

                entity.Property(e => e.AttributeName).HasColumnName("Attribute_Name");

                entity.HasIndex(e => new { e.ObjectTypeCode, e.AttributeName, e.AttributeValue, e.LangId, e.OrganizationId })
                    .HasName("UQ_StringMap")
                    .IsUnique();

                //entity.Property(e => e.StringMapId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.AttributeName)
                    .IsRequired()
                    .HasMaxLength(100);

                //entity.Property(e => e.Rowguid)
                //    .HasColumnName("rowguid")
                //    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Value).HasMaxLength(255);

                entity.Property(e => e.VersionNumber).IsRowVersion();
            });

            modelBuilder.Entity<CustomDay>(entity =>
            {

                entity.HasKey(e => e.CustomDayId);

                entity.ToTable("Custom_Day");

                entity.Property(e => e.CustomDayId)
                .HasColumnName("CustomDayId")
                .ValueGeneratedNever();

                entity.Property(e => e.Name).HasColumnName("Name");

                entity.Property(e => e.Description).HasColumnName("Description");

            });

            modelBuilder.Entity<CustomDayTimeSlip>(entity =>
            {
                entity.HasKey(e => e.CustomDayId);
                entity.HasKey(e => e.TimeSlipId);

                entity.Property(e => e.CustomDayId)
                .HasColumnName("CustomDay_Id")
                .ValueGeneratedNever();


                entity.Property(e => e.TimeSlipId)
                .HasColumnName("TimeSlip_Id")
                .ValueGeneratedNever();

                entity.HasOne(e => e.CustomDay)
                    .WithMany(p => p.CustomDayTimeSlips)
                    .HasForeignKey(d => d.CustomDayId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.GetNewTimesheetEntryExtensionBase)
                .WithMany(e => e.CustomDayTimeSlips)
                .HasForeignKey(e=> e.TimeSlipId)
                .OnDelete(DeleteBehavior.Restrict);

            });



            // base.OnModelCreating(entity);

        }
    }
}
