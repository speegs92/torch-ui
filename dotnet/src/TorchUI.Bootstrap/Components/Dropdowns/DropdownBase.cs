using Microsoft.AspNetCore.Components;

// ReSharper disable once CheckNamespace
namespace TorchUI.Bootstrap.Components;

/// <summary>
/// A base Bootstrap dropdown
/// </summary>
public abstract class DropdownBase : TorchComponentBase
{
	/// <summary>
	/// The button text
	/// </summary>
	/// <remarks>
	/// If not supplied, it is expected that the developer is supplying the activator button.
	/// </remarks>
	[Parameter]
	public string? Text { get; set; }

	/// <summary>
	/// Whether the dropdown menu should be centered
	/// </summary>
	[Parameter]
	public bool Center { get; set; }

	/// <summary>
	/// The activator button color
	/// </summary>
	[Parameter]
	public ThemeColor? Color { get; set; }

	/// <summary>
	/// The activator button size
	/// </summary>
	[Parameter]
	public Size Size { get; set; } = Size.Medium;

	[Parameter]
	public Placement Placement { get; set; } = Placement.Bottom;

	/// <inheritdoc />
	protected override void SetupAttributes()
	{
		CssBuilder
			.AddClass("dropdown")
			.AddClass("dropdown-center", Center && Placement is Placement.Bottom)
			.AddClass(
				"dropup-center",
				Center && Placement is Placement.Top)
			.AddClass("dropup", Placement is Placement.Top)
			.AddClass(
				$"drop{Placement.ToString().ToLowerInvariant()}",
				Placement is Placement.Start or Placement.End);
	}
}
