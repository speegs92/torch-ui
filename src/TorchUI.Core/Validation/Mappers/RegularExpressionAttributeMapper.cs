using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TorchUI.Validation.Mappers;

/// <summary>
/// Maps the <see cref="RegularExpressionAttribute"/> requirements to HTML5 <c>data-val-*</c> attributes
/// </summary>
public class RegularExpressionAttributeMapper : IValidationRuleMapper<RegularExpressionAttribute>
{
	/// <inheritdoc />
	public void MapToHtmlAttributes(
		object attribute,
		Dictionary<string, object> htmlAttributes)
		=> MapToHtmlAttributes(
			(RegularExpressionAttribute)attribute,
			htmlAttributes);

	/// <inheritdoc />
	public void MapToHtmlAttributes(
		RegularExpressionAttribute attribute,
		Dictionary<string, object> htmlAttributes)
	{
		htmlAttributes["data-validation-regular-expression"] = true;
		htmlAttributes["data-validation-regular-expression-pattern"] = attribute.Pattern;
		htmlAttributes["data-validation-regular-expression-error-message"] = attribute.ErrorMessage ?? $"Field does not match the custom regular expression pattern";
	}
}
