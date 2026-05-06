using System.Collections.Generic;

namespace TorchUI.Validation.Mappers;

/// <summary>
/// An interface for mapping a specific .NET validation attribute rule into <c>data-*</c> attributes for use by JavaScript on the client
/// </summary>
/// <typeparam name="T">The type of the validation attribute</typeparam>
// ReSharper disable once TypeParameterCanBeVariant
public interface IValidationRuleMapper<T> : IValidationRuleMapper
{
	/// <summary>
	/// Maps validation attribute rules to a Blazor attribute-splatting dictionary
	/// </summary>
	/// <param name="attribute">The attribute instance to map</param>
	/// <param name="htmlAttributes">The HTML attribute dictionary to which to amp</param>
	void MapToHtmlAttributes(
		T attribute,
		Dictionary<string, object> htmlAttributes);
}

/// <summary>
/// An interface for mapping a specific .NET validation attribute rule into <c>data-*</c> attributes for use by JavaScript on the client
/// </summary>
public interface IValidationRuleMapper
{
	/// <summary>
	/// Maps validation attribute rules to a Blazor attribute-splatting dictionary
	/// </summary>
	/// <param name="attribute">The attribute instance to map</param>
	/// <param name="htmlAttributes">The HTML attribute dictionary to which to amp</param>
	void MapToHtmlAttributes(
		object attribute,
		Dictionary<string, object> htmlAttributes);
}
