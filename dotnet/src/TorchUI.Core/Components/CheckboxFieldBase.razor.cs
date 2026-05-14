using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using TorchUI.Forms;

// ReSharper disable once CheckNamespace
namespace TorchUI;

/// <summary>
/// A base checkbox field which communicates with <see cref="InputCheckboxGroup{TValue}"/> via <see cref="CheckboxGroupContext{TValue}"/>
/// </summary>
/// <typeparam name="TValue">The type of the value</typeparam>
public partial class CheckboxFieldBase<TValue>
{
	/// <summary>
	/// The <code>value</code> attribute of the checkbox
	/// </summary>
	[Parameter]
	[EditorRequired]
	public TValue Value { get; set; }

	/// <summary>
	/// Captures additional HTML attributes supplied by the developer
	/// </summary>
	[Parameter(CaptureUnmatchedValues = true)]
	public Dictionary<string, object> UserAttributes { get; set; } = new();

	[CascadingParameter]
	private CheckboxGroupContext<TValue> Context { get; set; } = null!;
}

