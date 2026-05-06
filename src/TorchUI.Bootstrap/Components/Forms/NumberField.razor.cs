using Microsoft.AspNetCore.Components;

// ReSharper disable once CheckNamespace
namespace TorchUI.Bootstrap.Components;

/// <summary>
/// Represents a Bootstrap number field
/// </summary>
/// <typeparam name="TValue">The type of the value</typeparam>
public partial class NumberField<TValue>
{
	/// <summary>
	/// The error message used when displaying a parsing error
	/// </summary>
	[Parameter]
	public string ParsingErrorMessage { get; set; } = "The {0} field must be a number.";
}
