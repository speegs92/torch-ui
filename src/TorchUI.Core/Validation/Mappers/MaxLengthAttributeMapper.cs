using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TorchUI.Validation.Mappers;

/// <summary>
/// Maps the <see cref="MaxLengthAttribute"/> requirements to HTML5 <c>data-val-*</c> attributes
/// </summary>
public class MaxLengthAttributeMapper : IValidationRuleMapper<MaxLengthAttribute>
{
	/// <inheritdoc />
	public void MapToHtmlAttributes(
		object attribute,
		Dictionary<string, object> htmlAttributes)
		=> MapToHtmlAttributes(
			(MaxLengthAttribute)attribute,
			htmlAttributes);

	/// <inheritdoc />
	public void MapToHtmlAttributes(
		MaxLengthAttribute attribute,
		Dictionary<string, object> htmlAttributes)
	{
		var pluralIdentifier = attribute.Length is 0 or >1 ? "s" : string.Empty;

		htmlAttributes["data-validation-max-length"] = true;
		htmlAttributes["data-validation-max-length-length"] = attribute.Length;
		htmlAttributes["data-validation-max-length-error-message"] = attribute.ErrorMessage ?? $"Field length must be an array with at most {attribute.Length} item{pluralIdentifier} selected, or a string with at most {attribute.Length} character{pluralIdentifier}";
	}
}
