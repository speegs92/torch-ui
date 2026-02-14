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
	public Direction Direction { get; set; } = Direction.Down;

	/// <inheritdoc />
	protected override void SetupAttributes()
	{
		CssBuilder
			.AddClass("dropdown")
			.AddClass("dropdown-center", Center && Direction is Direction.Down)
			.AddClass(
				"dropup-center",
				Center && Direction is Direction.Up)
			.AddClass(
				$"drop{Direction.ToString().ToLowerInvariant()}",
				Direction is not Direction.Down);
	}
}
