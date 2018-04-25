using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AWSServerlessWebApi.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountBase",
                columns: table => new
                {
                    AccountId = table.Column<Guid>(nullable: false),
                    AccountCategoryCode = table.Column<int>(nullable: true),
                    AccountClassificationCode = table.Column<int>(nullable: true),
                    AccountNumber = table.Column<string>(maxLength: 20, nullable: true),
                    AccountRatingCode = table.Column<int>(nullable: true),
                    Aging30 = table.Column<decimal>(type: "money", nullable: true),
                    Aging30_Base = table.Column<decimal>(type: "money", nullable: true),
                    Aging60 = table.Column<decimal>(type: "money", nullable: true),
                    Aging60_Base = table.Column<decimal>(type: "money", nullable: true),
                    Aging90 = table.Column<decimal>(type: "money", nullable: true),
                    Aging90_Base = table.Column<decimal>(type: "money", nullable: true),
                    BusinessTypeCode = table.Column<int>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreditLimit = table.Column<decimal>(type: "money", nullable: true),
                    CreditLimit_Base = table.Column<decimal>(type: "money", nullable: true),
                    CreditOnHold = table.Column<bool>(nullable: true),
                    CustomerSizeCode = table.Column<int>(nullable: true),
                    CustomerTypeCode = table.Column<int>(nullable: true),
                    DefaultPriceLevelId = table.Column<Guid>(nullable: true),
                    DeletionStateCode = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    DoNotBulkEMail = table.Column<bool>(nullable: true),
                    DoNotBulkPostalMail = table.Column<bool>(nullable: true),
                    DoNotEMail = table.Column<bool>(nullable: true),
                    DoNotFax = table.Column<bool>(nullable: true),
                    DoNotPhone = table.Column<bool>(nullable: true),
                    DoNotPostalMail = table.Column<bool>(nullable: true),
                    DoNotSendMM = table.Column<bool>(nullable: true),
                    EMailAddress1 = table.Column<string>(maxLength: 100, nullable: true),
                    EMailAddress2 = table.Column<string>(maxLength: 100, nullable: true),
                    EMailAddress3 = table.Column<string>(maxLength: 100, nullable: true),
                    ExchangeRate = table.Column<decimal>(type: "decimal(23, 10)", nullable: true),
                    Fax = table.Column<string>(maxLength: 50, nullable: true),
                    FtpSiteURL = table.Column<string>(maxLength: 200, nullable: true),
                    ImportSequenceNumber = table.Column<int>(nullable: true),
                    IndustryCode = table.Column<int>(nullable: true),
                    IsPrivate = table.Column<bool>(nullable: true),
                    LastUsedInCampaign = table.Column<DateTime>(type: "datetime", nullable: true),
                    MarketCap = table.Column<decimal>(type: "money", nullable: true),
                    MarketCap_Base = table.Column<decimal>(type: "money", nullable: true),
                    MasterId = table.Column<Guid>(nullable: true),
                    Merged = table.Column<bool>(nullable: true),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    Name = table.Column<string>(maxLength: 160, nullable: true),
                    NumberOfEmployees = table.Column<int>(nullable: true),
                    OriginatingLeadId = table.Column<Guid>(nullable: true),
                    OverriddenCreatedOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    OwnershipCode = table.Column<int>(nullable: true),
                    OwningBusinessUnit = table.Column<Guid>(nullable: true),
                    OwningTeam = table.Column<Guid>(nullable: true),
                    OwningUser = table.Column<Guid>(nullable: true),
                    ParentAccountId = table.Column<Guid>(nullable: true),
                    ParticipatesInWorkflow = table.Column<bool>(nullable: true),
                    PaymentTermsCode = table.Column<int>(nullable: true),
                    PreferredAppointmentDayCode = table.Column<int>(nullable: true),
                    PreferredAppointmentTimeCode = table.Column<int>(nullable: true),
                    PreferredContactMethodCode = table.Column<int>(nullable: true),
                    PreferredEquipmentId = table.Column<Guid>(nullable: true),
                    PreferredServiceId = table.Column<Guid>(nullable: true),
                    PreferredSystemUserId = table.Column<Guid>(nullable: true),
                    PrimaryContactId = table.Column<Guid>(nullable: true),
                    Revenue = table.Column<decimal>(type: "money", nullable: true),
                    Revenue_Base = table.Column<decimal>(type: "money", nullable: true),
                    SharesOutstanding = table.Column<int>(nullable: true),
                    ShippingMethodCode = table.Column<int>(nullable: true),
                    SIC = table.Column<string>(maxLength: 20, nullable: true),
                    StateCode = table.Column<int>(nullable: false),
                    StatusCode = table.Column<int>(nullable: true),
                    StockExchange = table.Column<string>(maxLength: 20, nullable: true),
                    Telephone1 = table.Column<string>(maxLength: 50, nullable: true),
                    Telephone2 = table.Column<string>(maxLength: 50, nullable: true),
                    Telephone3 = table.Column<string>(maxLength: 50, nullable: true),
                    TerritoryCode = table.Column<int>(nullable: true),
                    TerritoryId = table.Column<Guid>(nullable: true),
                    TickerSymbol = table.Column<string>(maxLength: 10, nullable: true),
                    TimeZoneRuleVersionNumber = table.Column<int>(nullable: true),
                    TransactionCurrencyId = table.Column<Guid>(nullable: true),
                    UTCConversionTimeZoneCode = table.Column<int>(nullable: true),
                    VersionNumber = table.Column<byte[]>(rowVersion: true, nullable: true),
                    WebSiteURL = table.Column<string>(maxLength: 200, nullable: true),
                    YomiName = table.Column<string>(maxLength: 160, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountBase", x => x.AccountId);
                    table.ForeignKey(
                        name: "account_master_account",
                        column: x => x.MasterId,
                        principalTable: "AccountBase",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "account_parent_account",
                        column: x => x.ParentAccountId,
                        principalTable: "AccountBase",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Custom_Day",
                columns: table => new
                {
                    CustomDayId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Custom_Day", x => x.CustomDayId);
                });

            migrationBuilder.CreateTable(
                name: "New_ChangeRequestExtensionBase",
                columns: table => new
                {
                    New_ChangeRequestId = table.Column<Guid>(nullable: false),
                    New_ActionType = table.Column<int>(nullable: true),
                    New_ActualHours = table.Column<int>(nullable: true),
                    New_AnalysisDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    New_Analyst = table.Column<string>(maxLength: 100, nullable: true),
                    New_ApprovedBy = table.Column<string>(maxLength: 100, nullable: true),
                    New_ChangePriority = table.Column<int>(nullable: true),
                    New_ChangeRequestNo = table.Column<int>(nullable: true),
                    New_ChangeTitle = table.Column<string>(maxLength: 60, nullable: true),
                    New_ClientActionRequired = table.Column<bool>(nullable: true),
                    new_clientcreatorid = table.Column<Guid>(nullable: true),
                    New_CompletionDeadline = table.Column<DateTime>(type: "datetime", nullable: true),
                    New_CreatePBI = table.Column<bool>(nullable: true),
                    New_CRMEntityChecklist = table.Column<bool>(nullable: true),
                    New_CRMFormDesignChecklist = table.Column<bool>(nullable: true),
                    New_CRMViewsChecklist = table.Column<bool>(nullable: true),
                    New_DateClosed = table.Column<DateTime>(type: "datetime", nullable: true),
                    New_DateOpened = table.Column<DateTime>(type: "datetime", nullable: true),
                    New_DebugInformation = table.Column<string>(nullable: true),
                    New_Disposition = table.Column<int>(nullable: true),
                    New_EnablePMOnlyTimeslips = table.Column<bool>(nullable: true),
                    New_EstimatedHours = table.Column<double>(nullable: true),
                    New_FullEstimateHours = table.Column<int>(nullable: true),
                    New_HidefromWeeklyStatus = table.Column<bool>(nullable: true),
                    New_HideonPortal = table.Column<bool>(nullable: true),
                    New_ImplementationDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    New_Implementer = table.Column<string>(maxLength: 100, nullable: true),
                    New_IssueDescription = table.Column<string>(maxLength: 3000, nullable: true),
                    New_Locked = table.Column<bool>(nullable: true),
                    New_name = table.Column<string>(maxLength: 100, nullable: true),
                    New_NewFeature = table.Column<int>(nullable: true),
                    New_NextMonday = table.Column<DateTime>(type: "datetime", nullable: true),
                    New_OLDGUID = table.Column<string>(maxLength: 40, nullable: true),
                    New_ProjectId = table.Column<Guid>(nullable: true),
                    New_RecurringWBITitleMonthly = table.Column<string>(maxLength: 200, nullable: true),
                    New_RelatedReleaseId = table.Column<Guid>(nullable: true),
                    New_Remarks = table.Column<string>(nullable: true),
                    New_ReportChecklist = table.Column<bool>(nullable: true),
                    New_RequestedBy = table.Column<string>(maxLength: 100, nullable: true),
                    New_SpecialDeploymentRequirements = table.Column<string>(nullable: true),
                    New_StatusLastChanged = table.Column<DateTime>(type: "datetime", nullable: true),
                    New_StatusResolutionRemark = table.Column<string>(nullable: true),
                    New_SystemDataChecklist = table.Column<bool>(nullable: true),
                    New_SystemModule = table.Column<string>(maxLength: 100, nullable: true),
                    New_SystemModuleDropDown = table.Column<int>(nullable: true),
                    New_TestPlan = table.Column<string>(nullable: true),
                    New_TestedBy = table.Column<string>(maxLength: 500, nullable: true),
                    new_testedbyid = table.Column<Guid>(nullable: true),
                    New_ThisChangeis = table.Column<int>(nullable: true),
                    New_totalhoursbilled = table.Column<double>(nullable: true),
                    New_UserSetupChecklist = table.Column<bool>(nullable: true),
                    New_WeeklyWBITitle = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_New_ChangeRequestExtensionBase", x => x.New_ChangeRequestId);
                });

            migrationBuilder.CreateTable(
                name: "New_ProjectTypeExtensionBase",
                columns: table => new
                {
                    New_ProjectTypeId = table.Column<Guid>(nullable: false),
                    New_name = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_New_ProjectTypeExtensionBase", x => x.New_ProjectTypeId);
                });

            migrationBuilder.CreateTable(
                name: "StringMap",
                columns: table => new
                {
                    StringMapId = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    AttributeName = table.Column<string>(maxLength: 100, nullable: false),
                    AttributeValue = table.Column<int>(nullable: false),
                    DisplayOrder = table.Column<int>(nullable: true),
                    LangId = table.Column<int>(nullable: false),
                    ObjectTypeCode = table.Column<int>(nullable: false),
                    OrganizationId = table.Column<Guid>(nullable: false),
                    rowguid = table.Column<Guid>(nullable: false, defaultValueSql: "(newid())"),
                    Value = table.Column<string>(maxLength: 255, nullable: true),
                    VersionNumber = table.Column<byte[]>(rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StringMap", x => x.StringMapId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "New_ProjectExtensionBase",
                columns: table => new
                {
                    New_ProjectId = table.Column<Guid>(nullable: false),
                    New_AccountId = table.Column<Guid>(nullable: true),
                    New_ActualChangeRequestHours = table.Column<double>(nullable: true),
                    New_ActualHours = table.Column<double>(nullable: true),
                    New_ActualWarrantyHours = table.Column<double>(nullable: true),
                    New_ActualWorkHours = table.Column<double>(nullable: true),
                    New_BillingRemarks = table.Column<string>(nullable: true),
                    New_BillingSchedule = table.Column<int>(nullable: true),
                    New_BudgetType = table.Column<int>(nullable: true),
                    New_BudgetVariance = table.Column<double>(nullable: true),
                    New_BudgettedHours = table.Column<double>(nullable: true),
                    New_changerequesthours = table.Column<double>(nullable: true),
                    New_commissionable = table.Column<bool>(nullable: true),
                    New_Description = table.Column<string>(nullable: true),
                    New_EndDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    New_FullNameofProject = table.Column<string>(maxLength: 100, nullable: true),
                    New_issuehours = table.Column<double>(nullable: true),
                    New_name = table.Column<string>(maxLength: 100, nullable: true),
                    New_ProjectManager = table.Column<int>(nullable: true),
                    New_ProjectNo = table.Column<int>(nullable: true),
                    New_ProjectPhase = table.Column<int>(nullable: true),
                    New_ProjectTypeId = table.Column<Guid>(nullable: true),
                    New_PSSAccountId = table.Column<Guid>(nullable: true),
                    New_RateOveride = table.Column<decimal>(type: "money", nullable: true),
                    new_rateoveride_Base = table.Column<decimal>(type: "money", nullable: true),
                    New_rateoveride_use = table.Column<decimal>(type: "decimal(23, 10)", nullable: true),
                    New_StartDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    New_StatusRemarks = table.Column<string>(nullable: true),
                    New_SystemModules = table.Column<string>(nullable: true),
                    New_TenroxStatus = table.Column<string>(maxLength: 500, nullable: true),
                    New_UnderReleaseMgmt = table.Column<bool>(nullable: true),
                    New_warrantyhours = table.Column<double>(nullable: true),
                    New_workhours = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_New_ProjectExtensionBase", x => x.New_ProjectId);
                    table.ForeignKey(
                        name: "Account_New_Projects",
                        column: x => x.New_AccountId,
                        principalTable: "AccountBase",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "new_pssaccount_new_project",
                        column: x => x.New_PSSAccountId,
                        principalTable: "AccountBase",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "New_TimesheetEntryExtensionBase",
                columns: table => new
                {
                    New_TimesheetEntryId = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    DeletionStateCode = table.Column<int>(nullable: true),
                    ImportSequenceNumber = table.Column<int>(nullable: true),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    New_ApprovedForBilling = table.Column<bool>(nullable: true),
                    New_ChangeRequestId = table.Column<Guid>(nullable: true),
                    New_Credit = table.Column<bool>(nullable: true),
                    New_Duration = table.Column<int>(nullable: true),
                    New_DurationHours = table.Column<double>(nullable: true),
                    New_EndTask = table.Column<DateTime>(type: "datetime", nullable: true),
                    New_EntryNo = table.Column<int>(nullable: true),
                    New_ID = table.Column<string>(maxLength: 100, nullable: true),
                    New_InternalRemarks = table.Column<string>(nullable: true),
                    New_IsBatched = table.Column<bool>(nullable: true),
                    New_IssueId = table.Column<Guid>(nullable: true),
                    New_OutofScope = table.Column<bool>(nullable: true),
                    New_ProjectId = table.Column<Guid>(nullable: true),
                    New_Remarks = table.Column<string>(nullable: true),
                    New_RequestedBy = table.Column<string>(maxLength: 50, nullable: true),
                    New_StartTask = table.Column<DateTime>(type: "datetime", nullable: true),
                    New_TaskType = table.Column<int>(nullable: true),
                    new_timesheetbatchid = table.Column<Guid>(nullable: true),
                    OverriddenCreatedOn = table.Column<DateTime>(nullable: true),
                    OwningBusinessUnit = table.Column<Guid>(nullable: true),
                    OwningUser = table.Column<Guid>(nullable: true),
                    StateCode = table.Column<int>(nullable: false),
                    StatusCode = table.Column<int>(nullable: true),
                    VersionNumber = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_New_TimesheetEntryExtensionBase", x => x.New_TimesheetEntryId);
                    table.ForeignKey(
                        name: "FK_New_TimesheetEntryExtensionBase_Users_OwningUser",
                        column: x => x.OwningUser,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomDayTimeSlips",
                columns: table => new
                {
                    TimeSlip_Id = table.Column<Guid>(nullable: false),
                    CustomDay_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomDayTimeSlips", x => x.TimeSlip_Id);
                    table.UniqueConstraint("AK_CustomDayTimeSlips_CustomDay_Id", x => x.CustomDay_Id);
                    table.UniqueConstraint("AK_CustomDayTimeSlips_CustomDay_Id_TimeSlip_Id", x => new { x.CustomDay_Id, x.TimeSlip_Id });
                    table.ForeignKey(
                        name: "FK_CustomDayTimeSlips_Custom_Day_CustomDay_Id",
                        column: x => x.CustomDay_Id,
                        principalTable: "Custom_Day",
                        principalColumn: "CustomDayId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomDayTimeSlips_New_TimesheetEntryExtensionBase_TimeSlip_Id",
                        column: x => x.TimeSlip_Id,
                        principalTable: "New_TimesheetEntryExtensionBase",
                        principalColumn: "New_TimesheetEntryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountBase_MasterId",
                table: "AccountBase",
                column: "MasterId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountBase_ParentAccountId",
                table: "AccountBase",
                column: "ParentAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_New_ProjectExtensionBase_New_AccountId",
                table: "New_ProjectExtensionBase",
                column: "New_AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_New_ProjectExtensionBase_New_PSSAccountId",
                table: "New_ProjectExtensionBase",
                column: "New_PSSAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_New_TimesheetEntryExtensionBase_OwningUser",
                table: "New_TimesheetEntryExtensionBase",
                column: "OwningUser");

            migrationBuilder.CreateIndex(
                name: "UQ_StringMap",
                table: "StringMap",
                columns: new[] { "ObjectTypeCode", "AttributeName", "AttributeValue", "LangId", "OrganizationId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomDayTimeSlips");

            migrationBuilder.DropTable(
                name: "New_ChangeRequestExtensionBase");

            migrationBuilder.DropTable(
                name: "New_ProjectExtensionBase");

            migrationBuilder.DropTable(
                name: "New_ProjectTypeExtensionBase");

            migrationBuilder.DropTable(
                name: "StringMap");

            migrationBuilder.DropTable(
                name: "Custom_Day");

            migrationBuilder.DropTable(
                name: "New_TimesheetEntryExtensionBase");

            migrationBuilder.DropTable(
                name: "AccountBase");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
