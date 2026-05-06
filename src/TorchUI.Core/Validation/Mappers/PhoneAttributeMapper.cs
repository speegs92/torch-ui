using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TorchUI.Validation.Mappers;

/// <summary>
/// Maps the <see cref="PhoneAttribute"/> requirements to HTML5 <c>data-val-*</c> attributes
/// </summary>
public class PhoneAttributeMapper : IValidationRuleMapper<PhoneAttribute>
{
	/// <inheritdoc />
	public void MapToHtmlAttributes(
		object attribute,
		Dictionary<string, object> htmlAttributes)
		=> MapToHtmlAttributes(
			(PhoneAttribute)attribute,
			htmlAttributes);

	/// <inheritdoc />
	public void MapToHtmlAttributes(
		PhoneAttribute attribute,
		Dictionary<string, object> htmlAttributes)
	{
		htmlAttributes["data-validation-phone"] = true;
		htmlAttributes["data-validation-phone-error-message"] = attribute.ErrorMessage ?? "Field must be a valid phone number";
	}
}
