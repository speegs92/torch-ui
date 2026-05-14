using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TorchUI.Validation.Mappers;

/// <summary>
/// Maps the <see cref="FileExtensionsAttribute"/> requirements to HTML5 <c>data-val-*</c> attributes
/// </summary>
public class FileExtensionsAttributeMapper : IValidationRuleMapper<FileExtensionsAttribute>
{
	/// <inheritdoc />
	public void MapToHtmlAttributes(
		object attribute,
		Dictionary<string, object> htmlAttributes)
		=> MapToHtmlAttributes(
			(FileExtensionsAttribute)attribute,
			htmlAttributes);

	/// <inheritdoc />
	public void MapToHtmlAttributes(
		FileExtensionsAttribute attribute,
		Dictionary<string, object> htmlAttributes)
	{
		htmlAttributes["data-validation-file-extensions"] = true;
		htmlAttributes["data-validation-file-extensions-extensions"] = attribute.Extensions;
		htmlAttributes["data-validation-file-extensions-error-message"] = attribute.ErrorMessage ?? $"Uploaded file extension must be one of {attribute.Extensions}";
	}
}
