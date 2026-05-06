using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TorchUI.Validation.Mappers;

/// <summary>
/// Maps the <see cref="UrlAttribute"/> requirements to HTML5 <c>data-val-*</c> attributes
/// </summary>
public class UrlAttributeMapper : IValidationRuleMapper<UrlAttribute>
{
	/// <inheritdoc />
	public void MapToHtmlAttributes(
		object attribute,
		Dictionary<string, object> htmlAttributes)
		=> MapToHtmlAttributes(
			(UrlAttribute)attribute,
			htmlAttributes);

	/// <inheritdoc />
	public void MapToHtmlAttributes(
		UrlAttribute attribute,
		Dictionary<string, object> htmlAttributes)
	{
		htmlAttributes["data-validation-url"] = true;
		htmlAttributes["data-validation-url-error-message"] = attribute.ErrorMessage ?? "Field must be a valid URL";
	}
}
