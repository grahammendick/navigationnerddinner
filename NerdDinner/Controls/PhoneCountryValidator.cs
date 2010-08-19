using System;
using System.Web.UI.WebControls;
using NerdDinner.Helpers;

namespace NerdDinner.Controls
{
	public class PhoneCountryValidator : BaseValidator
	{
		public string CountryID
		{
			get;
			set;
		}

		protected override bool EvaluateIsValid()
		{
			string phoneValue = GetControlValidationValue(ControlToValidate);
			string countryValue = GetControlValidationValue(CountryID);
			if (!string.IsNullOrEmpty(phoneValue) && !string.IsNullOrEmpty(countryValue))
			{
				return PhoneValidator.IsValidNumber(phoneValue, countryValue);
			}
			return true;
		}
	}
}
