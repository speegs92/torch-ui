using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

// ReSharper disable once CheckNamespace
namespace TorchUI.Bootstrap.Components;

/// <summary>
/// Represents a Bootstrap date field
/// </summary>
/// <typeparam name="TValue">The type of the value</typeparam>
public partial class DateField<TValue>
{
	/// <summary>
	/// The type of the HTML input to be rendered
	/// </summary>
	[Parameter]
	public InputDateType Type { get; set; }

	/// <summary>
	/// The error message used when displaying a parsing error
	/// </summary>
	[Parameter]
	public string ParsingErrorMessage { get; set; } = string.Empty;

}
