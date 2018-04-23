﻿// <auto-generated />
using AWSServerlessWebApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace AWSServerlessWebApi.Migrations
{
    [DbContext(typeof(KORE_Interactive_MSCRMContext))]
    [Migration("20180423174540_karl")]
    partial class karl
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AWSServerlessWebApi.Models.AccountBase", b =>
                {
                    b.Property<Guid>("AccountId");

                    b.Property<int?>("AccountCategoryCode");

                    b.Property<int?>("AccountClassificationCode");

                    b.Property<string>("AccountNumber")
                        .HasMaxLength(20);

                    b.Property<int?>("AccountRatingCode");

                    b.Property<decimal?>("Aging30")
                        .HasColumnType("money");

                    b.Property<decimal?>("Aging30Base")
                        .HasColumnName("Aging30_Base")
                        .HasColumnType("money");

                    b.Property<decimal?>("Aging60")
                        .HasColumnType("money");

                    b.Property<decimal?>("Aging60Base")
                        .HasColumnName("Aging60_Base")
                        .HasColumnType("money");

                    b.Property<decimal?>("Aging90")
                        .HasColumnType("money");

                    b.Property<decimal?>("Aging90Base")
                        .HasColumnName("Aging90_Base")
                        .HasColumnType("money");

                    b.Property<int?>("BusinessTypeCode");

                    b.Property<Guid?>("CreatedBy");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime");

                    b.Property<decimal?>("CreditLimit")
                        .HasColumnType("money");

                    b.Property<decimal?>("CreditLimitBase")
                        .HasColumnName("CreditLimit_Base")
                        .HasColumnType("money");

                    b.Property<bool?>("CreditOnHold");

                    b.Property<int?>("CustomerSizeCode");

                    b.Property<int?>("CustomerTypeCode");

                    b.Property<Guid?>("DefaultPriceLevelId");

                    b.Property<int>("DeletionStateCode");

                    b.Property<string>("Description");

                    b.Property<bool?>("DoNotBulkEmail")
                        .HasColumnName("DoNotBulkEMail");

                    b.Property<bool?>("DoNotBulkPostalMail");

                    b.Property<bool?>("DoNotEmail")
                        .HasColumnName("DoNotEMail");

                    b.Property<bool?>("DoNotFax");

                    b.Property<bool?>("DoNotPhone");

                    b.Property<bool?>("DoNotPostalMail");

                    b.Property<bool?>("DoNotSendMm")
                        .HasColumnName("DoNotSendMM");

                    b.Property<string>("EmailAddress1")
                        .HasColumnName("EMailAddress1")
                        .HasMaxLength(100);

                    b.Property<string>("EmailAddress2")
                        .HasColumnName("EMailAddress2")
                        .HasMaxLength(100);

                    b.Property<string>("EmailAddress3")
                        .HasColumnName("EMailAddress3")
                        .HasMaxLength(100);

                    b.Property<decimal?>("ExchangeRate")
                        .HasColumnType("decimal(23, 10)");

                    b.Property<string>("Fax")
                        .HasMaxLength(50);

                    b.Property<string>("FtpSiteUrl")
                        .HasColumnName("FtpSiteURL")
                        .HasMaxLength(200);

                    b.Property<int?>("ImportSequenceNumber");

                    b.Property<int?>("IndustryCode");

                    b.Property<bool?>("IsPrivate");

                    b.Property<DateTime?>("LastUsedInCampaign")
                        .HasColumnType("datetime");

                    b.Property<decimal?>("MarketCap")
                        .HasColumnType("money");

                    b.Property<decimal?>("MarketCapBase")
                        .HasColumnName("MarketCap_Base")
                        .HasColumnType("money");

                    b.Property<Guid?>("MasterId");

                    b.Property<bool?>("Merged");

                    b.Property<Guid?>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .HasMaxLength(160);

                    b.Property<int?>("NumberOfEmployees");

                    b.Property<Guid?>("OriginatingLeadId");

                    b.Property<DateTime?>("OverriddenCreatedOn")
                        .HasColumnType("datetime");

                    b.Property<int?>("OwnershipCode");

                    b.Property<Guid?>("OwningBusinessUnit");

                    b.Property<Guid?>("OwningTeam");

                    b.Property<Guid?>("OwningUser");

                    b.Property<Guid?>("ParentAccountId");

                    b.Property<bool?>("ParticipatesInWorkflow");

                    b.Property<int?>("PaymentTermsCode");

                    b.Property<int?>("PreferredAppointmentDayCode");

                    b.Property<int?>("PreferredAppointmentTimeCode");

                    b.Property<int?>("PreferredContactMethodCode");

                    b.Property<Guid?>("PreferredEquipmentId");

                    b.Property<Guid?>("PreferredServiceId");

                    b.Property<Guid?>("PreferredSystemUserId");

                    b.Property<Guid?>("PrimaryContactId");

                    b.Property<decimal?>("Revenue")
                        .HasColumnType("money");

                    b.Property<decimal?>("RevenueBase")
                        .HasColumnName("Revenue_Base")
                        .HasColumnType("money");

                    b.Property<int?>("SharesOutstanding");

                    b.Property<int?>("ShippingMethodCode");

                    b.Property<string>("Sic")
                        .HasColumnName("SIC")
                        .HasMaxLength(20);

                    b.Property<int>("StateCode");

                    b.Property<int?>("StatusCode");

                    b.Property<string>("StockExchange")
                        .HasMaxLength(20);

                    b.Property<string>("Telephone1")
                        .HasMaxLength(50);

                    b.Property<string>("Telephone2")
                        .HasMaxLength(50);

                    b.Property<string>("Telephone3")
                        .HasMaxLength(50);

                    b.Property<int?>("TerritoryCode");

                    b.Property<Guid?>("TerritoryId");

                    b.Property<string>("TickerSymbol")
                        .HasMaxLength(10);

                    b.Property<int?>("TimeZoneRuleVersionNumber");

                    b.Property<Guid?>("TransactionCurrencyId");

                    b.Property<int?>("UtcconversionTimeZoneCode")
                        .HasColumnName("UTCConversionTimeZoneCode");

                    b.Property<byte[]>("VersionNumber")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("WebSiteUrl")
                        .HasColumnName("WebSiteURL")
                        .HasMaxLength(200);

                    b.Property<string>("YomiName")
                        .HasMaxLength(160);

                    b.HasKey("AccountId");

                    b.HasIndex("MasterId");

                    b.HasIndex("ParentAccountId");

                    b.ToTable("AccountBase");
                });

            modelBuilder.Entity("AWSServerlessWebApi.Models.NewChangeRequestExtensionBase", b =>
                {
                    b.Property<Guid>("NewChangeRequestId")
                        .HasColumnName("New_ChangeRequestId");

                    b.Property<int?>("NewActionType")
                        .HasColumnName("New_ActionType");

                    b.Property<int?>("NewActualHours")
                        .HasColumnName("New_ActualHours");

                    b.Property<DateTime?>("NewAnalysisDate")
                        .HasColumnName("New_AnalysisDate")
                        .HasColumnType("datetime");

                    b.Property<string>("NewAnalyst")
                        .HasColumnName("New_Analyst")
                        .HasMaxLength(100);

                    b.Property<string>("NewApprovedBy")
                        .HasColumnName("New_ApprovedBy")
                        .HasMaxLength(100);

                    b.Property<int?>("NewChangePriority")
                        .HasColumnName("New_ChangePriority");

                    b.Property<int?>("NewChangeRequestNo")
                        .HasColumnName("New_ChangeRequestNo");

                    b.Property<string>("NewChangeTitle")
                        .HasColumnName("New_ChangeTitle")
                        .HasMaxLength(60);

                    b.Property<bool?>("NewClientActionRequired")
                        .HasColumnName("New_ClientActionRequired");

                    b.Property<Guid?>("NewClientcreatorid")
                        .HasColumnName("new_clientcreatorid");

                    b.Property<DateTime?>("NewCompletionDeadline")
                        .HasColumnName("New_CompletionDeadline")
                        .HasColumnType("datetime");

                    b.Property<bool?>("NewCreatePbi")
                        .HasColumnName("New_CreatePBI");

                    b.Property<bool?>("NewCrmentityChecklist")
                        .HasColumnName("New_CRMEntityChecklist");

                    b.Property<bool?>("NewCrmformDesignChecklist")
                        .HasColumnName("New_CRMFormDesignChecklist");

                    b.Property<bool?>("NewCrmviewsChecklist")
                        .HasColumnName("New_CRMViewsChecklist");

                    b.Property<DateTime?>("NewDateClosed")
                        .HasColumnName("New_DateClosed")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("NewDateOpened")
                        .HasColumnName("New_DateOpened")
                        .HasColumnType("datetime");

                    b.Property<string>("NewDebugInformation")
                        .HasColumnName("New_DebugInformation");

                    b.Property<int?>("NewDisposition")
                        .HasColumnName("New_Disposition");

                    b.Property<bool?>("NewEnablePmonlyTimeslips")
                        .HasColumnName("New_EnablePMOnlyTimeslips");

                    b.Property<double?>("NewEstimatedHours")
                        .HasColumnName("New_EstimatedHours");

                    b.Property<int?>("NewFullEstimateHours")
                        .HasColumnName("New_FullEstimateHours");

                    b.Property<bool?>("NewHidefromWeeklyStatus")
                        .HasColumnName("New_HidefromWeeklyStatus");

                    b.Property<bool?>("NewHideonPortal")
                        .HasColumnName("New_HideonPortal");

                    b.Property<DateTime?>("NewImplementationDate")
                        .HasColumnName("New_ImplementationDate")
                        .HasColumnType("datetime");

                    b.Property<string>("NewImplementer")
                        .HasColumnName("New_Implementer")
                        .HasMaxLength(100);

                    b.Property<string>("NewIssueDescription")
                        .HasColumnName("New_IssueDescription")
                        .HasMaxLength(3000);

                    b.Property<bool?>("NewLocked")
                        .HasColumnName("New_Locked");

                    b.Property<string>("NewName")
                        .HasColumnName("New_name")
                        .HasMaxLength(100);

                    b.Property<int?>("NewNewFeature")
                        .HasColumnName("New_NewFeature");

                    b.Property<DateTime?>("NewNextMonday")
                        .HasColumnName("New_NextMonday")
                        .HasColumnType("datetime");

                    b.Property<string>("NewOldguid")
                        .HasColumnName("New_OLDGUID")
                        .HasMaxLength(40);

                    b.Property<Guid?>("NewProjectId")
                        .HasColumnName("New_ProjectId");

                    b.Property<string>("NewRecurringWbititleMonthly")
                        .HasColumnName("New_RecurringWBITitleMonthly")
                        .HasMaxLength(200);

                    b.Property<Guid?>("NewRelatedReleaseId")
                        .HasColumnName("New_RelatedReleaseId");

                    b.Property<string>("NewRemarks")
                        .HasColumnName("New_Remarks");

                    b.Property<bool?>("NewReportChecklist")
                        .HasColumnName("New_ReportChecklist");

                    b.Property<string>("NewRequestedBy")
                        .HasColumnName("New_RequestedBy")
                        .HasMaxLength(100);

                    b.Property<string>("NewSpecialDeploymentRequirements")
                        .HasColumnName("New_SpecialDeploymentRequirements");

                    b.Property<DateTime?>("NewStatusLastChanged")
                        .HasColumnName("New_StatusLastChanged")
                        .HasColumnType("datetime");

                    b.Property<string>("NewStatusResolutionRemark")
                        .HasColumnName("New_StatusResolutionRemark");

                    b.Property<bool?>("NewSystemDataChecklist")
                        .HasColumnName("New_SystemDataChecklist");

                    b.Property<string>("NewSystemModule")
                        .HasColumnName("New_SystemModule")
                        .HasMaxLength(100);

                    b.Property<int?>("NewSystemModuleDropDown")
                        .HasColumnName("New_SystemModuleDropDown");

                    b.Property<string>("NewTestPlan")
                        .HasColumnName("New_TestPlan");

                    b.Property<string>("NewTestedBy")
                        .HasColumnName("New_TestedBy")
                        .HasMaxLength(500);

                    b.Property<Guid?>("NewTestedbyid")
                        .HasColumnName("new_testedbyid");

                    b.Property<int?>("NewThisChangeis")
                        .HasColumnName("New_ThisChangeis");

                    b.Property<double?>("NewTotalhoursbilled")
                        .HasColumnName("New_totalhoursbilled");

                    b.Property<bool?>("NewUserSetupChecklist")
                        .HasColumnName("New_UserSetupChecklist");

                    b.Property<string>("NewWeeklyWbititle")
                        .HasColumnName("New_WeeklyWBITitle")
                        .HasMaxLength(200);

                    b.HasKey("NewChangeRequestId");

                    b.ToTable("New_ChangeRequestExtensionBase");
                });

            modelBuilder.Entity("AWSServerlessWebApi.Models.NewProjectExtensionBase", b =>
                {
                    b.Property<Guid>("NewProjectId")
                        .HasColumnName("New_ProjectId");

                    b.Property<Guid?>("NewAccountId")
                        .HasColumnName("New_AccountId");

                    b.Property<double?>("NewActualChangeRequestHours")
                        .HasColumnName("New_ActualChangeRequestHours");

                    b.Property<double?>("NewActualHours")
                        .HasColumnName("New_ActualHours");

                    b.Property<double?>("NewActualWarrantyHours")
                        .HasColumnName("New_ActualWarrantyHours");

                    b.Property<double?>("NewActualWorkHours")
                        .HasColumnName("New_ActualWorkHours");

                    b.Property<string>("NewBillingRemarks")
                        .HasColumnName("New_BillingRemarks");

                    b.Property<int?>("NewBillingSchedule")
                        .HasColumnName("New_BillingSchedule");

                    b.Property<int?>("NewBudgetType")
                        .HasColumnName("New_BudgetType");

                    b.Property<double?>("NewBudgetVariance")
                        .HasColumnName("New_BudgetVariance");

                    b.Property<double?>("NewBudgettedHours")
                        .HasColumnName("New_BudgettedHours");

                    b.Property<double?>("NewChangerequesthours")
                        .HasColumnName("New_changerequesthours");

                    b.Property<bool?>("NewCommissionable")
                        .HasColumnName("New_commissionable");

                    b.Property<string>("NewDescription")
                        .HasColumnName("New_Description");

                    b.Property<DateTime?>("NewEndDate")
                        .HasColumnName("New_EndDate")
                        .HasColumnType("datetime");

                    b.Property<string>("NewFullNameofProject")
                        .HasColumnName("New_FullNameofProject")
                        .HasMaxLength(100);

                    b.Property<double?>("NewIssuehours")
                        .HasColumnName("New_issuehours");

                    b.Property<string>("NewName")
                        .HasColumnName("New_name")
                        .HasMaxLength(100);

                    b.Property<int?>("NewProjectManager")
                        .HasColumnName("New_ProjectManager");

                    b.Property<int?>("NewProjectNo")
                        .HasColumnName("New_ProjectNo");

                    b.Property<int?>("NewProjectPhase")
                        .HasColumnName("New_ProjectPhase");

                    b.Property<Guid?>("NewProjectTypeId")
                        .HasColumnName("New_ProjectTypeId");

                    b.Property<Guid?>("NewPssaccountId")
                        .HasColumnName("New_PSSAccountId");

                    b.Property<decimal?>("NewRateOveride")
                        .HasColumnName("New_RateOveride")
                        .HasColumnType("money");

                    b.Property<decimal?>("NewRateoverideBase")
                        .HasColumnName("new_rateoveride_Base")
                        .HasColumnType("money");

                    b.Property<decimal?>("NewRateoverideUse")
                        .HasColumnName("New_rateoveride_use")
                        .HasColumnType("decimal(23, 10)");

                    b.Property<DateTime?>("NewStartDate")
                        .HasColumnName("New_StartDate")
                        .HasColumnType("datetime");

                    b.Property<string>("NewStatusRemarks")
                        .HasColumnName("New_StatusRemarks");

                    b.Property<string>("NewSystemModules")
                        .HasColumnName("New_SystemModules");

                    b.Property<string>("NewTenroxStatus")
                        .HasColumnName("New_TenroxStatus")
                        .HasMaxLength(500);

                    b.Property<bool?>("NewUnderReleaseMgmt")
                        .HasColumnName("New_UnderReleaseMgmt");

                    b.Property<double?>("NewWarrantyhours")
                        .HasColumnName("New_warrantyhours");

                    b.Property<double?>("NewWorkhours")
                        .HasColumnName("New_workhours");

                    b.HasKey("NewProjectId");

                    b.HasIndex("NewAccountId");

                    b.HasIndex("NewPssaccountId");

                    b.ToTable("New_ProjectExtensionBase");
                });

            modelBuilder.Entity("AWSServerlessWebApi.Models.NewProjectTypeExtensionBase", b =>
                {
                    b.Property<Guid>("NewProjectTypeId")
                        .HasColumnName("New_ProjectTypeId");

                    b.Property<string>("NewName")
                        .HasColumnName("New_name")
                        .HasMaxLength(100);

                    b.HasKey("NewProjectTypeId");

                    b.ToTable("New_ProjectTypeExtensionBase");
                });

            modelBuilder.Entity("AWSServerlessWebApi.Models.NewTimesheetEntryExtensionBase", b =>
                {
                    b.Property<Guid>("NewTimesheetEntryId")
                        .HasColumnName("New_TimesheetEntryId");

                    b.Property<bool?>("NewApprovedForBilling")
                        .HasColumnName("New_ApprovedForBilling");

                    b.Property<Guid?>("NewChangeRequestId")
                        .HasColumnName("New_ChangeRequestId");

                    b.Property<bool?>("NewCredit")
                        .HasColumnName("New_Credit");

                    b.Property<int?>("NewDuration")
                        .HasColumnName("New_Duration");

                    b.Property<double?>("NewDurationHours")
                        .HasColumnName("New_DurationHours");

                    b.Property<DateTime?>("NewEndTask")
                        .HasColumnName("New_EndTask")
                        .HasColumnType("datetime");

                    b.Property<int?>("NewEntryNo")
                        .HasColumnName("New_EntryNo");

                    b.Property<string>("NewId")
                        .HasColumnName("New_ID")
                        .HasMaxLength(100);

                    b.Property<string>("NewInternalRemarks")
                        .HasColumnName("New_InternalRemarks");

                    b.Property<bool?>("NewIsBatched")
                        .HasColumnName("New_IsBatched");

                    b.Property<Guid?>("NewIssueId")
                        .HasColumnName("New_IssueId");

                    b.Property<bool?>("NewOutofScope")
                        .HasColumnName("New_OutofScope");

                    b.Property<Guid?>("NewProjectId")
                        .HasColumnName("New_ProjectId");

                    b.Property<string>("NewRemarks")
                        .HasColumnName("New_Remarks");

                    b.Property<string>("NewRequestedBy")
                        .HasColumnName("New_RequestedBy")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("NewStartTask")
                        .HasColumnName("New_StartTask")
                        .HasColumnType("datetime");

                    b.Property<int?>("NewTaskType")
                        .HasColumnName("New_TaskType");

                    b.Property<Guid?>("NewTimesheetbatchid")
                        .HasColumnName("new_timesheetbatchid");

                    b.HasKey("NewTimesheetEntryId");

                    b.ToTable("New_TimesheetEntryExtensionBase");
                });

            modelBuilder.Entity("AWSServerlessWebApi.Models.StringMap", b =>
                {
                    b.Property<Guid>("StringMapId")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("AttributeName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("AttributeValue");

                    b.Property<int?>("DisplayOrder");

                    b.Property<int>("LangId");

                    b.Property<int>("ObjectTypeCode");

                    b.Property<Guid>("OrganizationId");

                    b.Property<Guid>("Rowguid")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("rowguid")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("Value")
                        .HasMaxLength(255);

                    b.Property<byte[]>("VersionNumber")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("StringMapId");

                    b.HasIndex("ObjectTypeCode", "AttributeName", "AttributeValue", "LangId", "OrganizationId")
                        .IsUnique()
                        .HasName("UQ_StringMap");

                    b.ToTable("StringMap");
                });

            modelBuilder.Entity("AWSServerlessWebApi.Models.AccountBase", b =>
                {
                    b.HasOne("AWSServerlessWebApi.Models.AccountBase", "Master")
                        .WithMany("InverseMaster")
                        .HasForeignKey("MasterId")
                        .HasConstraintName("account_master_account");

                    b.HasOne("AWSServerlessWebApi.Models.AccountBase", "ParentAccount")
                        .WithMany("InverseParentAccount")
                        .HasForeignKey("ParentAccountId")
                        .HasConstraintName("account_parent_account");
                });

            modelBuilder.Entity("AWSServerlessWebApi.Models.NewProjectExtensionBase", b =>
                {
                    b.HasOne("AWSServerlessWebApi.Models.AccountBase", "NewAccount")
                        .WithMany("NewProjectExtensionBaseNewAccount")
                        .HasForeignKey("NewAccountId")
                        .HasConstraintName("Account_New_Projects");

                    b.HasOne("AWSServerlessWebApi.Models.AccountBase", "NewPssaccount")
                        .WithMany("NewProjectExtensionBaseNewPssaccount")
                        .HasForeignKey("NewPssaccountId")
                        .HasConstraintName("new_pssaccount_new_project");
                });
#pragma warning restore 612, 618
        }
    }
}
