using Microsoft.AspNetCore.Components;
using TorchUI.Bootstrap.Extensions;

// ReSharper disable once CheckNamespace
namespace TorchUI.Bootstrap.Components;

/// <summary>
/// Represents a Bootstrap <c>.pagination</c>
/// </summary>
public partial class Pagination
{
	/// <summary>
	/// The <c>aria-label</c> attribute of the pagination
	/// </summary>
	[Parameter]
	public string? Label { get; set; }

	/// <summary>
	/// The size of the pagination links
	/// </summary>
	/// <remarks>
	/// The only supported sizes are <see cref="Size.Small"/> and <see cref="Size.Large"/>. Other values are ignored because they have no effect.
	/// </remarks>
	[Parameter]
	public Size Size { get; set; } = Size.Medium;

	/// <inheritdoc />
	protected override void SetupAttributes()
	{
		Tag ??= "ul";
		CssBuilder
			.AddClass("pagination")
			.AddClass(Size.GetSizeClass("pagination"), Size is Size.Small or Size.Large);
	}
}
