using Microsoft.AspNetCore.Components;
using TorchUI.Bootstrap.Extensions;

// ReSharper disable once CheckNamespace
namespace TorchUI.Bootstrap.Components;

/// <summary>
/// A base button with shared functionality
/// </summary>
public abstract class BtnBase : TorchComponentBase
{
	/// <summary>
	/// The Bootstrap theme color of the button
	/// </summary>
	[Parameter]
	public ThemeColor? Color { get; set; }

	/// <summary>
	/// The Bootstrap size of the button
	/// </summary>
	[Parameter]
	public Size Size { get; set; } = Size.Medium;

	/// <summary>
	/// Whether the button should be outlined
	/// </summary>
	/// <remarks>
	/// Only has an effect if the <see cref="Color"/> parameter has a value because Bootstrap doesn't define a <c>.btn-outline</c> class
	/// </remarks>
	[Parameter]
	public bool Outlined { get; set; }

	/// <inheritdoc />
	protected override void SetupAttributes()
	{
		// Need to support button-styled links and inputs
		Tag ??= "button";

		// Buttons should default to <c>type="button"</c>
		if (Tag == "button")
		{
			GetOrSetAttribute("type", "button");
		}

		CssBuilder.AddClass("btn");

		if (Color is not null)
		{
			var outlinedInfix = Outlined ? "-outline" : string.Empty;
			CssBuilder.AddClass(Color.Value.GetThemeColorClass($"btn{outlinedInfix}"));
		}

		if (Size is not Size.Medium)
		{
			CssBuilder.AddClass(Size.GetSizeClass("btn"));
		}
	}
}
