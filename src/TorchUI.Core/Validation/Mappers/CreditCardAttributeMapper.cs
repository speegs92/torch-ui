using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TorchUI.Validation.Mappers;

/// <summary>
/// Maps the <see cref="CreditCardAttribute"/> requirements to HTML5 <c>data-val-*</c> attributes
/// </summary>
public class CreditCardAttributeMapper : IValidationRuleMapper<CreditCardAttribute>
{
	/// <inheritdoc />
	public void MapToHtmlAttributes(
		object attribute,
		Dictionary<string, object> htmlAttributes)
		=> MapToHtmlAttributes(
			(CreditCardAttribute)attribute,
			htmlAttributes);

	/// <inheritdoc />
	public void MapToHtmlAttributes(
		CreditCardAttribute attribute,
		Dictionary<string, object> htmlAttributes)
	{
		htmlAttributes["data-validation-credit-card"] = true;
		htmlAttributes["data-validation-credit-card-error-message"] = attribute.ErrorMessage ?? "Field must be a valid credit card number";
	}
}
