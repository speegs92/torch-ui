using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

// ReSharper disable once CheckNamespace
namespace TorchUI.Bootstrap.Components;

/// <summary>
/// Represents a Bootstrap select field
/// </summary>
/// <typeparam name="TValue">The type of the value</typeparam>
public partial class SelectField<TValue>
{
	/// <summary>
	/// The available options
	/// </summary>
	[Parameter]
	public IEnumerable<TValue>? Options { get; set; }

	/// <summary>
	/// A template for rendering options
	/// </summary>
	[Parameter]
	public RenderFragment<TValue>? OptionTemplate { get; set; }

	/// <summary>
	/// Whether to show an unselectable null option as the first dropdown option
	/// </summary>
	[Parameter]
	public bool ShowNullOption { get; set; }

	/// <summary>
	/// The text to show in the unselectable null option
	/// </summary>
	[Parameter]
	public string? NullOptionText { get; set; } = "Please select an option";
}