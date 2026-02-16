using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TorchUI.Validation.Mappers;

/// <summary>
/// Maps the <see cref="RequiredAttribute"/> requirements to HTML5 <c>data-val-*</c> attributes
/// </summary>
public class RequiredAttributeMapper : IValidationRuleMapper<RequiredAttribute>
{
	/// <inheritdoc />
	public void MapToHtmlAttributes(object attribute, Dictionary<string, object> htmlAttributes)
		=> MapToHtmlAttributes((RequiredAttribute)attribute, htmlAttributes);

	/// <inheritdoc />
	public void MapToHtmlAttributes(RequiredAttribute attribute, Dictionary<string, object> htmlAttributes)
	{
		htmlAttributes["data-val-required"] = attribute.ErrorMessage ?? "Field is required";
	}
}
