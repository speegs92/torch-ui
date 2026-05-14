using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

// ReSharper disable once CheckNamespace
namespace TorchUI.Bootstrap.Components;

/// <summary>
/// Represents a Bootstrap checkbox field group
/// </summary>
/// <typeparam name="TValue">The type of the value</typeparam>
[CascadingTypeParameter(nameof(TValue))]
public partial class CheckboxFieldGroup<TValue>
{
	/// <summary>
	/// The available options
	/// </summary>
	[Parameter]
	public IEnumerable<TValue>? Options { get; set; }

	/// <summary>
	/// A template for rendering checkboxes
	/// </summary>
	[Parameter]
	public RenderFragment<TValue>? CheckboxTemplate { get; set; }
}
