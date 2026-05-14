using Microsoft.AspNetCore.Components;

// ReSharper disable once CheckNamespace
namespace TorchUI.Bootstrap.Components;

/// <summary>
/// Represents a split Bootstrap <c>.dropdown</c>
/// </summary>
public partial class SplitDropdown
{
	/// <summary>
	/// The non-activator button's <c>href</c> attribute, if any
	/// </summary>
	/// <remarks>
	/// If you supply this parameter, the non-activator button will be rendered as an HTML link with the supplied value as its <c>href</c> attribute.
	/// 
	/// It is recommended that you supply either an <see cref="Href"/> or a <see cref="ButtonId"/> to your <c>&lt;SplitDropdown&gt;</c>, as these are the most straightforward way of supplying functionality to the non-activator button. If you merely want the design of a split button without functionally using the non-activator button, leave both fields blank.
	/// </remarks>
	[Parameter]
	public string? Href { get; set; }

	/// <summary>
	/// The non-activator button ID, if any
	/// </summary>
	/// <remarks>
	/// If you supply this parameter, the non-activator button will be rendered with the supplied value as its <c>id</c> attribute, allowing you to target the non-activator button with JavaScript.
	/// 
	/// It is recommended that you supply either an <see cref="Href"/> or a <see cref="ButtonId"/> to your <c>&lt;SplitDropdown&gt;</c>, as these are the most straightforward way of supplying functionality to the non-activator button. If you merely want the design of a split button without functionally using the non-activator button, leave both fields blank.
	/// </remarks>
	[Parameter]
	public string? ButtonId { get; set; }

	/// <inheritdoc />
	protected override void SetupAttributes()
	{
		CssBuilder.AddClass("btn-group");
		base.SetupAttributes();
	}
}