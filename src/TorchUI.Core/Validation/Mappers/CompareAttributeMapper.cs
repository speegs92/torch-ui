using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TorchUI.Validation.Mappers;

/// <summary>
/// Maps the <see cref="CompareAttribute"/> requirements to HTML5 <c>data-val-*</c> attributes
/// </summary>
public class CompareAttributeMapper : IValidationRuleMapper<CompareAttribute>
{
	/// <inheritdoc />
	public void MapToHtmlAttributes(
		object attribute,
		Dictionary<string, object> htmlAttributes)
		=> MapToHtmlAttributes(
			(CompareAttribute)attribute,
			htmlAttributes);

	/// <inheritdoc />
	public void MapToHtmlAttributes(
		CompareAttribute attribute,
		Dictionary<string, object> htmlAttributes)
	{
		htmlAttributes["data-validation-compare"] = true;
		htmlAttributes["data-validation-compare-other-property"] = attribute.OtherProperty;
		htmlAttributes["data-validation-compare-error-message"] = attribute.ErrorMessage ?? $"Field must match the {attribute.OtherPropertyDisplayName ?? attribute.OtherProperty} field";

		if (!string.IsNullOrEmpty(attribute.OtherPropertyDisplayName))
		{
			htmlAttributes["data-validation-compare-other-property-display-name"] = attribute.OtherPropertyDisplayName;
		}
	}
}
