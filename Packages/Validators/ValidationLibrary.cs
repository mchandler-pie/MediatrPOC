using System;
using System.Text.RegularExpressions;

namespace Packages.Validators
{
	public static class ValidationLibrary
	{
		public const string
			AtLeastOneRequired = "must specify at least one property",
			BooleanError = "must be either true or false",
			RequiredError = "required",
			ValidDateError = "must be in ISO 8601 format yyyy-MM-dd",
			ValidPhoneError = "must be a valid 10-digit phone number",
			EnumError = "must be a valid member of the enum",
			ByteError = "must be a valid byte number",
			Uint16Error = "must be a valid ushort number",
			DecimalError = "must be a valid decimal number",
			ValidationLegalEntityOneElement = "Exactly one LegalEntity is required",
			ValidationStateOneElement = "Exactly one State is required.",
			ValidationSingleNonExposure = "One a single location may have no exposure and must be the first address provided (used for a off-site primary mailing address)",
			ValidationModificationFactorError = "modification factor must be between 0.1 and 9.99",
			ValidationYearStartedError = "year started must be between 1800 and the current year",
			ValidationEffectiveDate = "policy start state must be 1-45 days from today",
			ValidationExpirationDate = "policy expiration needs to be exactly one year from the effective date",
			ValidationMoneyValue = "dollar amount needs to be >= 0 and no more than two digits after the decimal point",
			ValidationPositiveMoneyValue = "dollar amount needs to be > 0 and no more than two digits after the decimal point",
			ValidationPriorCarrierEffectiveDate = "effective date needs to be in the past",
			ValidationPriorCarrierPolicyTerm = "prior carrier policy 'ExpirationDate' needs to be a year or less from the 'EffectiveDate'",
			ValidationTaxId = "tax id must be a 9 digit number and not a restricted taxId",
			ValidationSicCode = "sic code needs to be a 4-digit number",
			ValidationNaicsCode = "naics code needs to be a 6-digit number",
			ValidationUrl = "website needs to be a valid URL",
			ValidateStatesAreSupported = "All states must be supported by Pie Insurance",
			Uint32Error = "must be a valid uint32 number",
			ClassCodeError = "must be between 1-4 numbers",
			ClassCodeForStateError = "not a valid class code for the current state",
			ClassCodesMissingForStateError = "missing class codes for the current state",
			PayrollError = "must be between $0 and $1 billion",
			ZeroPayrollError = "must be between $1 and $1 billion",
			UniqueError = "must be unique",
			SpecificWaiverIfAnyError = "not allowed on if/any classes",
			ValidZipError = "must be a valid zip code",
			StateMismatchError = "State in address must match address in parent QuoteState object",
			ZipCodeNotInStateError = "The zip code is NOT located in the specified state",
			ValidTaxIdError = "must be a valid tax id",
			WaiverPayrollError = "sum of waivers cannot exceed class payroll",
			NotSupportedStateError = "state is not supported currently by PieInsurance",
			InvalidEmailError = "Must be a valid email address",
			UianRequiredForThisState = "Uian is required for this state",
			DrugFreeProgramForThisState = "Drug Free Program is not supported in this state",
			ManagedCareProgramForThisState = "Managed Care Program is not supported in this state",
			BlanketWaiverFlatChargeForThisState = "Blanket Waiver Flat Charge is not supported in this state",
			BlanketWaiverMutualExclusion = "Blanket Waiver and Blanket Flat Charge can NOT both be listed",
			SpecificWaiverMutualExclusion = "Blanket Waiver and Specific Waiver can NOT both be listed",
			MeritRatingPlanForThisState = "Merit Rating Plan is not supported in this state",
			MeritRatingPlanForValue = "Merit Rating Plan value is not valid for this state",
			MeritRatingPlanExposureModification = "Merit Rating Plan and ExposureModification can NOT both be used on a single state object",
			SmallDeductibleForThisState = "Small Deductible is not supported in this state",
			SmallDeductibleForValue = "Small Deductible Plan value is not valid for this state",
			ExperienceModificationDateRequired = "Experience Mofication Date required if type is actual",
			ExperienceModificationRiskIdRequired = "Experience Mofication riskId required if type is actual",
			MatchingLiabilityLimits = "Liability Limits must be equal for eachEmployee and eachAccident",
			PolicyLiabilityLimitsLargest = "Liability Limits must be set so Policy Limit is the largest",
			QuoteOfficerClassCodeNotInExposure = "Officer class code must be present in the states exposures",
			LiabilityLimitsNotAvailable = "Liability Limits you selected are not available for the given state.",
			ZipOrState = "Must specify either Zip or State",
			NotSupportedInput = "Input not currently supported",
			DisallowedAmountPaid = "Amount Paid cannot be greater than zero if NonZeroClaimCount is zero",
			DisallowedAmountReserved = "Amount Reserved cannot be greater than zero if NonZeroClaimCount is zero",
			ExcludedOnly = "Currently only excluded officers are supported.",
			BlanketWaiverNotSupportedError = "No blanket waivers are available in this state",
			SpecificWaiverNotSupportedError = "No specific waivers are available in this state",
			TotalPayrollError = "The submitted total payroll is less than the minimum ($5,000).";

        public static bool IsPhoneNumber(this string value)
		{
			var result = Regex.IsMatch(value, @"^((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}$", RegexOptions.IgnoreCase);
			if (!result)
				result = Regex.IsMatch(value, @"^[0-9]{10}$", RegexOptions.IgnoreCase);
			return result;
		}

        public static bool IsEnum(this string value, Type enumType) =>
			Enum.IsDefined(enumType, value);

	}
}
