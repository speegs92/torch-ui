using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TorchUI.Validation.Mappers;

/// <summary>
/// Maps the <see cref="MinLengthAttribute"/> requirements to HTML5 <c>data-val-*</c> attributes
/// </summary>
public class MinLengthAttributeMapper : IValidationRuleMapper<MinLengthAttribute>
{
	/// <inheritdoc />
	public void MapToHtmlAttributes(
		object attribute,
		Dictionary<string, object> htmlAttributes)
		=> MapToHtmlAttributes(
			(MinLengthAttribute)attribute,
			htmlAttributes);

	/// <inheritdoc />
	public void MapToHtmlAttributes(
		MinLengthAttribute attribute,
		Dictionary<string, object> htmlAttributes)
	{
		var pluralIdentifier = attribute.Length is 0 or >1 ? "s" : string.Empty;

		htmlAttributes["data-validation-min-length"] = true;
		htmlAttributes["data-validation-min-length-length"] = attribute.Length;
		htmlAttributes["data-validation-min-length-error-message"] = attribute.ErrorMessage ?? $"Field length must be an array with at least {attribute.Length} item{pluralIdentifier} selected, or a string with at least {attribute.Length} character{pluralIdentifier}";
	}
}
