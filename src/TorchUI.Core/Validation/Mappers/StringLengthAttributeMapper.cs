using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TorchUI.Validation.Mappers;

/// <summary>
/// Maps the <see cref="StringLengthAttribute"/> requirements to HTML5 <c>data-val-*</c> attributes
/// </summary>
public class StringLengthAttributeMapper : IValidationRuleMapper<StringLengthAttribute>
{
	/// <inheritdoc />
	public void MapToHtmlAttributes(
		object attribute,
		Dictionary<string, object> htmlAttributes)
		=> MapToHtmlAttributes(
			(StringLengthAttribute)attribute,
			htmlAttributes);

	/// <inheritdoc />
	public void MapToHtmlAttributes(
		StringLengthAttribute attribute,
		Dictionary<string, object> htmlAttributes)
	{
		htmlAttributes["data-validation-string-length"] = true;
		htmlAttributes["data-validation-string-length-mininum-length"] = attribute.MinimumLength;
		htmlAttributes["data-validation-string-length-maximum-length"] = attribute.MaximumLength;
		htmlAttributes["data-validation-string-length-error-message"] = attribute.ErrorMessage ?? $"Field must be a string between {attribute.MinimumLength} and {attribute.MaximumLength} characters";
	}
}
