using Microsoft.AspNetCore.Components;
using TorchUI.Bootstrap.Extensions;

// ReSharper disable once CheckNamespace
namespace TorchUI.Bootstrap.Components;

/// <summary>
/// Represents a Bootstrap <c>.list-group-item</c>
/// </summary>
public abstract class ListGroupItemBase : TorchComponentBase
{
	/// <summary>
	/// The theme color with which to render the list group item
	/// </summary>
	[Parameter]
	public ThemeColor? Color { get; set; }

	/// <summary>
	/// Whether the list group item is active
	/// </summary>
	[Parameter]
	public bool Active { get; set; }

	/// <summary>
	/// The theme color inherited from the parent <see cref="ListGroup"/>
	/// </summary>
	[CascadingParameter(Name = nameof(InheritedColor))]
	public ThemeColor? InheritedColor { get; set; }

	/// <summary>
	/// Whether the list group items should be equal width
	/// </summary>
	[CascadingParameter(Name = nameof(EqualWidth))]
	public bool EqualWidth { get; set; }

	/// <inheritdoc />
	protected override void SetupAttributes()
	{
		CssBuilder
			.AddClass("list-group-item")
			.AddClass("list-group-item-action", Tag is "a" or "button")
			.AddClass("flex-fill", EqualWidth);

		var color = Color ?? InheritedColor;
		if (color.HasValue)
		{
			CssBuilder.AddClass(color.Value.GetThemeColorClass("list-group-item"));
		}

		if (Active)
		{
			CssBuilder.AddClass("active");
			UserAttributes["aria-current"] = "true";
		}

		if (UserAttributes.ContainsKey("disabled"))
		{
			CssBuilder.AddClass("disabled");
			UserAttributes["aria-disabled"] = "true";
		}
	}
}
