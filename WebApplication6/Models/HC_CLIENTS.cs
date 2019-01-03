//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication6.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class HC_CLIENTS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HC_CLIENTS()
        {
            this.hc_client_user = new HashSet<hc_client_user>();
        }
    
        public long RID { get; set; }
        public string ClientName { get; set; }
        public string ClientShortName { get; set; }
        public string Address { get; set; }
        public string AboutClient { get; set; }
        public long LocationID { get; set; }
        public string PhoneNo { get; set; }
        public string FaxNo { get; set; }
        public string WebSite { get; set; }
        public short Status { get; set; }
        public long ResumeTemplateID { get; set; }
        public short AttachmentType { get; set; }
        public byte[] Document { get; set; }
        public long CreatedUser { get; set; }
        public long ModifiedUser { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public string HotNotes { get; set; }
        public string Notes { get; set; }
        public short CustomerType { get; set; }
        public long StateID { get; set; }
        public long CountryID { get; set; }
        public string PIN { get; set; }
        public string ClientNumber { get; set; }
        public string Perfix { get; set; }
        public Nullable<long> LastNumber { get; set; }
        public string Suffix { get; set; }
        public long IndustryTypeID { get; set; }
        public byte[] ClientProfile { get; set; }
        public string AccountManagerData { get; set; }
        public string FileNameFormat { get; set; }
        public short AccessType { get; set; }
        public string AccountManagerQueryData { get; set; }
        public string ORG_ACCESS { get; set; }
        public string VERT_ACCESS { get; set; }
        public string USER_ACCESS { get; set; }
        public decimal OnAccountAmount { get; set; }
        public long BUserID { get; set; }
        public byte[] ClientLogo { get; set; }
        public string ClientLogoName { get; set; }
        public long ResFormatID { get; set; }
        public long ShortListMID { get; set; }
        public long InterviewerMID { get; set; }
        public long TrackerSheetID { get; set; }
        public short Probability { get; set; }
        public decimal ExpectedAnnualRevenue { get; set; }
        public Nullable<System.DateTime> ExpectedCloserDate { get; set; }
        public string SalesNotes { get; set; }
        public string PUserName { get; set; }
        public string PPassword { get; set; }
        public string PURL { get; set; }
        public long PRequester { get; set; }
        public short ApprovalStatus { get; set; }
        public long ApprovedUserID { get; set; }
        public string IndustryText { get; set; }
        public string SubIndustryText { get; set; }
        public string FunctionText { get; set; }
        public string SubFunctionText { get; set; }
        public string Client4Level { get; set; }
        public long V3JobsRID { get; set; }
        public Nullable<System.DateTime> SignupDate { get; set; }
        public short SalesStatus { get; set; }
        public int TargetNo { get; set; }
        public string NoPoachText { get; set; }
        public string BranchIDs { get; set; }
        public short EnableOfferStrictProcess { get; set; }
        public int CVSentDays { get; set; }
        public short CVRejectedDuration { get; set; }
        public long HolidayTemplateID { get; set; }
        public long ProfTaxTemplate { get; set; }
        public long OffListID { get; set; }
        public long LeaveTemplateID { get; set; }
        public int AttachmentCount { get; set; }
        public string STDCode { get; set; }
        public string ISDCode { get; set; }
        public long SubIndustryID { get; set; }
        public long NoPoachID { get; set; }
        public long ClientManagerID { get; set; }
        public Nullable<System.DateTime> EnquiryDate { get; set; }
        public short VendorSync { get; set; }
        public string VPUserName { get; set; }
        public string VPPassword { get; set; }
        public string VPURL { get; set; }
        public int VPTransRealInterval { get; set; }
        public int VPTransBatchSize { get; set; }
        public int VPResValidBatchSize { get; set; }
        public int VPResSubBatchSize { get; set; }
        public byte[] EncKey { get; set; }
        public byte[] EncVec { get; set; }
        public Nullable<System.DateTime> VPLastTimeStamp { get; set; }
        public long VSMUserID { get; set; }
        public string OfferLetterPrefix { get; set; }
        public string OfferLetterSuffix { get; set; }
        public long OfferLetterLastNo { get; set; }
        public short VSyncInterviewPanel { get; set; }
        public short VSyncInterviewDetails { get; set; }
        public byte[] ClientResumeFormat { get; set; }
        public long InterviewMID { get; set; }
        public long ProcessID { get; set; }
        public long RegionID { get; set; }
        public long VCClientID { get; set; }
        public long RequirementLayoutID { get; set; }
        public long TeamTemplateID { get; set; }
        public long Taxtype { get; set; }
        public long EconomicActivityID { get; set; }
        public short ISLFImport { get; set; }
        public short ModifiedUserType { get; set; }
        public short EnableBillPayDays { get; set; }
        public string VPValidStatusText { get; set; }
        public short TimeSheetType { get; set; }
        public short OTinDays { get; set; }
        public short BillingCycleDay { get; set; }
        public short MandatoryAttendence { get; set; }
        public short LeaveCalender { get; set; }
        public short EnableProratedLeaves { get; set; }
        public short EnableProbationProcess { get; set; }
        public string IndustryTypeIDs { get; set; }
        public string FunctionIDs { get; set; }
        public string SubFunctionIDs { get; set; }
        public long UserGroupID { get; set; }
        public long LeadRating { get; set; }
        public short ClientStatus { get; set; }
        public string L2Address { get; set; }
        public string L3Address { get; set; }
        public long TimeSheetID { get; set; }
        public long WorkOrderID { get; set; }
        public long ProcessTemplateID { get; set; }
        public long DefCVSentDateageDays { get; set; }
        public long DefCVSentDateagehrs { get; set; }
        public long InvoiceTemplate { get; set; }
        public long CTCTemplate { get; set; }
        public long OutGoingResumeFormat { get; set; }
        public decimal CreditLimit { get; set; }
        public long PRClientStatementID { get; set; }
        public long CheckListTemplateID { get; set; }
        public Nullable<System.DateTime> FinancialCalender { get; set; }
        public decimal WeeklyOffOT { get; set; }
        public decimal HolidayOT { get; set; }
        public decimal WorkdayOT { get; set; }
        public short PropMarginForCandidate { get; set; }
        public long OfferChecklistID { get; set; }
        public short MinWages { get; set; }
        public long PaySlipID { get; set; }
        public short ProbationPeriod { get; set; }
        public long InvoiceBuilderTemplateID { get; set; }
        public long CalculationTypeID { get; set; }
        public short ProbationPeriodType { get; set; }
        public short AdvanceFunding { get; set; }
        public short AccountType { get; set; }
        public short PANIndiaClient { get; set; }
        public short PaidLeavesEncashment { get; set; }
        public short LeaveEncashmentOn { get; set; }
        public long DeclarationUpdateDatesID { get; set; }
        public short EnableProjectAllowance { get; set; }
        public short ProjectAllowanceType { get; set; }
        public short ProjectAllowanceFlatType { get; set; }
        public short ActualDaysInPayroll { get; set; }
        public short PayCycleDay { get; set; }
        public short LdAWDaysForJoinInTS { get; set; }
        public short LdAWDaysForQuitInTS { get; set; }
        public short LdCalcTypeDaysAsActualDays { get; set; }
        public long PayRollInvoiceTemplateID { get; set; }
        public long MidMonthInvoiceTemplateID { get; set; }
        public long ReimbursementInvID { get; set; }
        public long InvBillingAddressID { get; set; }
        public long FAFSlipID { get; set; }
        public long GPIPDeductionTemplateID { get; set; }
        public short EnablePOTracking { get; set; }
        public long AttenConfigTemplateID { get; set; }
        public short ProcessType { get; set; }
        public long ClientSLAID { get; set; }
        public long SLAManagerID { get; set; }
        public short MandProjController { get; set; }
        public short ProjectController { get; set; }
        public short WeekOffIsBillable { get; set; }
        public short HolidayIsBillable { get; set; }
        public short LeaveIsBillable { get; set; }
        public short LOBAndBillableDaysInTS { get; set; }
        public short AdditionalBillableDaysInTS { get; set; }
        public short ReimburseWithMonthlyInv { get; set; }
        public short PartlyApprdTSCantBilled { get; set; }
        public short BillRatesshouldbeinHourly { get; set; }
        public short DontBillForRestrictHoliday { get; set; }
        public short EarnedLeaveBilling { get; set; }
        public short DefinedCalcTS { get; set; }
        public short OneTimePayforTSAttachment { get; set; }
        public short AppendPOandTSAttachment { get; set; }
        public short AlertforInvoicingForCodes { get; set; }
        public short NotifyIfAllActiveNotInBill { get; set; }
        public short CalcExcessOTHoursAsCO { get; set; }
        public short ExcludeWOandHolidayInWD { get; set; }
        public short InvDueDateCalcBasedOn { get; set; }
        public short PendInvSendDateBasedOn { get; set; }
        public short WeekStartDay { get; set; }
        public short BillingCutOffDate { get; set; }
        public short NoticePeriod { get; set; }
        public short MaxOThoursinMonth { get; set; }
        public short MandatorytocreateBranch { get; set; }
        public short ExcludeWOandHolidayInAD { get; set; }
        public short TimeSheetTypeID { get; set; }
        public long OfferCheckerUser { get; set; }
        public long OTRateType { get; set; }
        public long PortalTimeSheetView { get; set; }
        public long WelcomeEmailTemplate { get; set; }
        public long InvoiceApprover { get; set; }
        public long ERPerson { get; set; }
        public short WarrantyPeriodEligibility { get; set; }
        public long AuditMgrID { get; set; }
        public long ERRID { get; set; }
        public short BillRateValidateOnPOValue { get; set; }
        public short VMOFee { get; set; }
        public short VMOExtFee { get; set; }
        public short BillngRateValidateOnPOValue { get; set; }
        public short BillRateCalcBasedOnMarkup { get; set; }
        public short EnableVMOFee { get; set; }
        public short EnableExtndVMOFee { get; set; }
        public short NotifyIfInvBRGreaterConsBR { get; set; }
        public short EnableCompOff { get; set; }
        public short BuildCompOff { get; set; }
        public short CompOffEligibleDays { get; set; }
        public short ShiftView { get; set; }
        public short BillingRateValidationonPOValue { get; set; }
        public string ExNP { get; set; }
        public short IsOTApplicable { get; set; }
        public short EnableComplimentaryOff { get; set; }
        public decimal RHHolidayOT { get; set; }
        public string ExCTR { get; set; }
        public string ExTITS { get; set; }
        public string EXTSPS { get; set; }
        public string ExTITSPS { get; set; }
        public string ExNOFS { get; set; }
        public string ExITNOFS { get; set; }
        public long AuditMgrID2 { get; set; }
        public short HWIsBillable { get; set; }
        public string VMOVendorName { get; set; }
        public short IncludePOAndTimesheetInInvoice { get; set; }
        public string ExBillingCycle { get; set; }
        public decimal AllowedLeavesPerMonth { get; set; }
        public short ExtraHoursBillable { get; set; }
        public short ExtraHoursPayable { get; set; }
        public decimal WorkingHoursLimit { get; set; }
        public decimal WarrantyPeriodDays { get; set; }
        public string ExClienttype { get; set; }
        public short VMOType { get; set; }
        public short VMOSubType { get; set; }
        public short VMOExtType { get; set; }
        public short VMOExtSubType { get; set; }
        public string VMORate { get; set; }
        public string VMOExtRate { get; set; }
        public Nullable<short> IsPOWithBudget { get; set; }
        public Nullable<short> IsPODateApplicable { get; set; }
        public Nullable<short> IsPONoApplicable { get; set; }
        public string Excostcentre2 { get; set; }
        public string EXCNOL { get; set; }
        public short EnablePromptPayDiscount { get; set; }
        public short COUtilizedmnth { get; set; }
        public short IncOPHexWOinAD { get; set; }
        public short NegLeaveBalinTS { get; set; }
        public short RecTDSAmtCal { get; set; }
        public short EnableSanwhichLeavePol { get; set; }
        public short CalBAfrmavgBdays { get; set; }
        public Nullable<long> ExDM { get; set; }
        public long CoreHRManagerID { get; set; }
        public short BranchMandatoryinPO { get; set; }
        public long SkillSoftTemplate { get; set; }
        public long ExSH { get; set; }
        public Nullable<long> ExtClientCoreHR { get; set; }
        public string ExtJDClientAccess { get; set; }
        public string ExtTower { get; set; }
        public byte DPforPerunitval { get; set; }
        public byte AdjustCNinStaffing { get; set; }
        public byte AdjustInvBaseAmnt { get; set; }
        public string ExtLogInLogOutTimeSheet { get; set; }
        public long OperationMgrGrpID { get; set; }
        public long AuditMgrGrpID { get; set; }
        public string ExtTaxIDNo { get; set; }
        public string ExtBillingAddress { get; set; }
        public string ExtBillingContact { get; set; }
        public string ExtClientNameinInvoice { get; set; }
        public string ExtBillingContactPhone { get; set; }
        public string ExtBillingContactEmail { get; set; }
        public string ExtContactForAR { get; set; }
        public string ExtARPersonEmail { get; set; }
        public string ExtVatApplicable { get; set; }
        public string ExtPEZACertificate { get; set; }
        public byte InvBAtoConsBillRate { get; set; }
        public short ExcludeDaysfromDB { get; set; }
        public string ExtAuditVerified { get; set; }
        public long InductionEmailTemplate { get; set; }
        public string ExClientPANNumber { get; set; }
        public short ProcessVPWithClientPay { get; set; }
        public short VendorPaymentDueDays { get; set; }
        public long GroupCompanyID { get; set; }
        public short EnableShiftDetailsinTS { get; set; }
        public short EnableMinNDMins { get; set; }
        public short MinNDMins { get; set; }
        public short EnableMinOTMins { get; set; }
        public short MinOTMins { get; set; }
        public short EnableRoundOffOTMins { get; set; }
        public short RoundOffOTMins { get; set; }
        public short EnableWorkedHrsinTS { get; set; }
        public short EnableOTdHrsinTS { get; set; }
        public short EnableNDHrsinTS { get; set; }
        public short EnableNDOTHrsinTS { get; set; }
        public short EnableLateHrsinTS { get; set; }
        public string PANNo { get; set; }
        public short FixedBilling { get; set; }
        public short EnableFlatdays { get; set; }
        public decimal FlatdaysinYear { get; set; }
        public short TSReminertoAltEmail { get; set; }
        public decimal BGCheckCost { get; set; }
        public decimal SodexoCoupons { get; set; }
        public decimal TargetGPM { get; set; }
        public string Remarks { get; set; }
        public decimal Discount { get; set; }
        public Nullable<short> BillingCalculationMethod { get; set; }
        public string ExtCCategory { get; set; }
        public string ExtCCCategory { get; set; }
        public string ExClientLevelCountry { get; set; }
        public int BreakMins { get; set; }
        public int LateMins { get; set; }
        public short SplitHrCalc { get; set; }
        public string ExtClientOfferLetter { get; set; }
        public Nullable<long> ExLocationID { get; set; }
        public long InvoiceStateID { get; set; }
        public string ExtSalesAccountSpoc { get; set; }
        public short DeductLateMinAmt { get; set; }
        public short HalfMnthBillRate { get; set; }
        public long FTEOperationMgrGrpID { get; set; }
        public long FTEAuditMgrGrpID { get; set; }
        public long PermOperationMgrGrpID { get; set; }
        public long PermAuditMgrGrpID { get; set; }
        public short GracePeriod { get; set; }
        public short LeaveBalMonCalc { get; set; }
        public decimal NoHoursDay { get; set; }
        public string ExtAccountManager { get; set; }
        public short GenSepInvPrePay { get; set; }
        public short SkipPOValPrePay { get; set; }
        public short EnableStdHrsTS { get; set; }
        public string GSTNo { get; set; }
        public string LowerTDSNotes { get; set; }
        public string ExtOfferPackageCCMailId { get; set; }
        public string ExtOfferPackageBCCMailId { get; set; }
        public short EnableGSTNOValidationWhileInvoice { get; set; }
        public short POApplicableType { get; set; }
        public short ITInputTypeGPGPM { get; set; }
        public decimal ITCompValueGPGPM { get; set; }
        public short NonITRequirementGPGPM { get; set; }
        public short NonITInputTypeGPGPM { get; set; }
        public decimal NonITCompValueGPGPM { get; set; }
        public string ExtBGVApplicable1 { get; set; }
        public string ExtBGVClientPerformedBy1 { get; set; }
        public string ExtBGVPerformedBy1 { get; set; }
        public string ExtBGVOnBoarding1 { get; set; }
        public string ExtBGVStandardOrClient1 { get; set; }
        public Nullable<long> ExtBGVTypeCheck1 { get; set; }
        public string ExtPostOnBoardingDays1 { get; set; }
        public string ExtStandardCheckJoining1 { get; set; }
        public string ExtLOBWiseJoining1 { get; set; }
        public string ExtEndClientJoining1 { get; set; }
        public string ExtBGVApplicable { get; set; }
        public string ExtBGVClientPerformedBy { get; set; }
        public string ExtBGVPerformedBy { get; set; }
        public string ExtBGVOnBoarding { get; set; }
        public string ExtBGVStandardOrClient { get; set; }
        public string ExtBGVTypeCheck { get; set; }
        public string ExtPostOnBoardingDays { get; set; }
        public string ExtStandardCheckJoining { get; set; }
        public string ExtLOBWiseJoining { get; set; }
        public string ExtEndClientJoining { get; set; }
        public decimal OtherCostPerc { get; set; }
        public decimal NonITTargetGPM { get; set; }
        public decimal NonITOtherCostPerc { get; set; }
        public short BillRateCalcBasedOnMarkupNew { get; set; }
        public string ExClientregion { get; set; }
        public Nullable<long> V5RID { get; set; }
        public string ExtIsGratuityForGPGPM { get; set; }
        public Nullable<short> IsGratuityApplicableForGPGPM { get; set; }
        public string ExtContCharges { get; set; }
        public string ExtNatnlEmpPF { get; set; }
        public string ExtSkillDevCost { get; set; }
        public string ExtSignpNatnlEmp { get; set; }
        public string ExtNonSingpOtherCost { get; set; }
        public string ExtContractorsLoad { get; set; }
        public string ExtMalysianNtnlEmpLad { get; set; }
        public string ExtNonMalysianNtnlEmpLad { get; set; }
        public string ExtMalysianRelocationCost { get; set; }
        public string ExtEmpStatPayLoad { get; set; }
        public short EnableSaturdayandSunday { get; set; }
        public short RDHWintheTimeSheet { get; set; }
        public short selectShiftinTimeSheet { get; set; }
        public short Standardworkinghoursperyear { get; set; }
        public short ComputePremiumbilling { get; set; }
        public short ProcessOThoursamount { get; set; }
        public short EnableOTamountMarkup { get; set; }
        public short ComputeSOCSOamount { get; set; }
        public short separateExtendedBillRate { get; set; }
        public short ComputeWeekoffWorked { get; set; }
        public short EnableflatOTrateperhour { get; set; }
        public short VMO1chargeforShiftManager { get; set; }
        public short Enableflatstandbyratepermonth { get; set; }
        public short EnableSOCSOandEPFslab { get; set; }
        public short EnableEPFslab { get; set; }
        public decimal Standardworkinghours { get; set; }
        public decimal OTamountMarkup { get; set; }
        public decimal Averageworkingdaysinweek { get; set; }
        public decimal flatOTrateperhour { get; set; }
        public decimal flatstandbyratepermonth { get; set; }
        public short EnableCapOTRate { get; set; }
        public decimal CapOTRate { get; set; }
        public decimal CapOTMinRate { get; set; }
        public decimal CapOTMaxRate { get; set; }
        public short EnableAverageworkingdaysinweek { get; set; }
        public string ExtContPayLoad { get; set; }
        public string ExtEmpPayLoad { get; set; }
        public string ExtMalysianOtherCost { get; set; }
        public string ExtNonMalysianOtherCost { get; set; }
        public string CMS_temp_client_code { get; set; }
        public short InTSWorkedHrsandOTHrsinActTimeFormat { get; set; }
        public short EnableRestrictCarryForwardedLeavesUtilizationTillNextYear { get; set; }
        public string RestrictCarryForwardedLeavesUtilizationTillNextYearMonth { get; set; }
        public short EnablePayRollCutoff { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<hc_client_user> hc_client_user { get; set; }
    }
}
