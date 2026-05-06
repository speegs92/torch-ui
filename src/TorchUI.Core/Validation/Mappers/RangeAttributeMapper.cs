using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TorchUI.Validation.Mappers;

/// <summary>
/// Maps the <see cref="RangeAttribute"/> requirements to HTML5 <c>data-val-*</c> attributes
/// </summary>
public class RangeAttributeMapper : IValidationRuleMapper<RangeAttribute>
{
	/// <inheritdoc />
	public void MapToHtmlAttributes(
		object attribute,
		Dictionary<string, object> htmlAttributes)
		=> MapToHtmlAttributes(
			(RangeAttribute)attribute,
			htmlAttributes);

	/// <inheritdoc />
	public void MapToHtmlAttributes(
		RangeAttribute attribute,
		Dictionary<string, object> htmlAttributes)
	{
		htmlAttributes["data-validation-range"] = true;
		htmlAttributes["data-validation-range-minimum"] = attribute.Minimum;
		htmlAttributes["data-validation-range-maximum"] = attribute.Maximum;

		if (attribute.MinimumIsExclusive)
		{
			htmlAttributes["data-validation-range-minimum-exclusive"] = true;
		}

		if (attribute.MaximumIsExclusive)
		{
			htmlAttributes["data-validation-range-maximum-exclusive"] = true;
		}

		var minExclusiveDescriptor = attribute.MinimumIsExclusive ? "exclusive" : "inclusive";
		var maxExclusiveDescriptor = attribute.MaximumIsExclusive ? "exclusive" : "inclusive";

		htmlAttributes["data-validation-range-error-message"] = attribute.ErrorMessage ?? $"Value must be between {attribute.Minimum} ({minExclusiveDescriptor}) and {attribute.Maximum} ({maxExclusiveDescriptor})";
	}
}
