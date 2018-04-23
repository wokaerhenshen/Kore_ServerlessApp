using System;
using System.Collections.Generic;

namespace AWSServerlessWebApi.Models
{
    public partial class AccountBase
    {
        public AccountBase()
        {
            InverseMaster = new HashSet<AccountBase>();
            InverseParentAccount = new HashSet<AccountBase>();
            NewProjectExtensionBaseNewAccount = new HashSet<NewProjectExtensionBase>();
            NewProjectExtensionBaseNewPssaccount = new HashSet<NewProjectExtensionBase>();
        }

        public Guid AccountId { get; set; }
        public int? AccountCategoryCode { get; set; }
        public Guid? TerritoryId { get; set; }
        public Guid? DefaultPriceLevelId { get; set; }
        public int? CustomerSizeCode { get; set; }
        public int? PreferredContactMethodCode { get; set; }
        public int? CustomerTypeCode { get; set; }
        public int? AccountRatingCode { get; set; }
        public int? IndustryCode { get; set; }
        public int? TerritoryCode { get; set; }
        public int? AccountClassificationCode { get; set; }
        public int DeletionStateCode { get; set; }
        public int? BusinessTypeCode { get; set; }
        public Guid? OwningBusinessUnit { get; set; }
        public Guid? OwningTeam { get; set; }
        public Guid? OwningUser { get; set; }
        public Guid? OriginatingLeadId { get; set; }
        public int? PaymentTermsCode { get; set; }
        public int? ShippingMethodCode { get; set; }
        public Guid? PrimaryContactId { get; set; }
        public bool? ParticipatesInWorkflow { get; set; }
        public string Name { get; set; }
        public string AccountNumber { get; set; }
        public decimal? Revenue { get; set; }
        public int? NumberOfEmployees { get; set; }
        public string Description { get; set; }
        public string Sic { get; set; }
        public int? OwnershipCode { get; set; }
        public decimal? MarketCap { get; set; }
        public int? SharesOutstanding { get; set; }
        public string TickerSymbol { get; set; }
        public string StockExchange { get; set; }
        public string WebSiteUrl { get; set; }
        public string FtpSiteUrl { get; set; }
        public string EmailAddress1 { get; set; }
        public string EmailAddress2 { get; set; }
        public string EmailAddress3 { get; set; }
        public bool? DoNotPhone { get; set; }
        public bool? DoNotFax { get; set; }
        public string Telephone1 { get; set; }
        public bool? DoNotEmail { get; set; }
        public string Telephone2 { get; set; }
        public string Fax { get; set; }
        public string Telephone3 { get; set; }
        public bool? DoNotPostalMail { get; set; }
        public bool? DoNotBulkEmail { get; set; }
        public bool? DoNotBulkPostalMail { get; set; }
        public decimal? CreditLimit { get; set; }
        public bool? CreditOnHold { get; set; }
        public bool? IsPrivate { get; set; }
        public DateTime? CreatedOn { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public Guid? ModifiedBy { get; set; }
        public byte[] VersionNumber { get; set; }
        public Guid? ParentAccountId { get; set; }
        public decimal? Aging30 { get; set; }
        public int StateCode { get; set; }
        public decimal? Aging60 { get; set; }
        public int? StatusCode { get; set; }
        public decimal? Aging90 { get; set; }
        public int? PreferredAppointmentDayCode { get; set; }
        public int? PreferredAppointmentTimeCode { get; set; }
        public Guid? PreferredServiceId { get; set; }
        public Guid? MasterId { get; set; }
        public bool? Merged { get; set; }
        public DateTime? LastUsedInCampaign { get; set; }
        public bool? DoNotSendMm { get; set; }
        public Guid? PreferredSystemUserId { get; set; }
        public Guid? PreferredEquipmentId { get; set; }
        public decimal? ExchangeRate { get; set; }
        public int? UtcconversionTimeZoneCode { get; set; }
        public DateTime? OverriddenCreatedOn { get; set; }
        public int? TimeZoneRuleVersionNumber { get; set; }
        public int? ImportSequenceNumber { get; set; }
        public Guid? TransactionCurrencyId { get; set; }
        public decimal? CreditLimitBase { get; set; }
        public decimal? Aging30Base { get; set; }
        public decimal? RevenueBase { get; set; }
        public decimal? Aging90Base { get; set; }
        public decimal? MarketCapBase { get; set; }
        public decimal? Aging60Base { get; set; }
        public string YomiName { get; set; }

        public AccountBase Master { get; set; }
        public AccountBase ParentAccount { get; set; }
        public ICollection<AccountBase> InverseMaster { get; set; }
        public ICollection<AccountBase> InverseParentAccount { get; set; }
        public ICollection<NewProjectExtensionBase> NewProjectExtensionBaseNewAccount { get; set; }
        public ICollection<NewProjectExtensionBase> NewProjectExtensionBaseNewPssaccount { get; set; }
    }
}
