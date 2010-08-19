using System;
using System.Web.UI.WebControls;
using System.Globalization;

namespace NerdDinner.Controls
{
	public class DateTimeValidator : BaseValidator
	{
		protected override bool EvaluateIsValid()
		{
			string controlValidationValue = GetControlValidationValue(ControlToValidate);
			if (!string.IsNullOrEmpty(controlValidationValue))
			{
				try
				{
					DateTime.Parse(controlValidationValue, DateTimeFormatInfo.CurrentInfo);
				}
				catch (FormatException)
				{
					return false;
				}
			}
			return true;
		}
 	}
}
