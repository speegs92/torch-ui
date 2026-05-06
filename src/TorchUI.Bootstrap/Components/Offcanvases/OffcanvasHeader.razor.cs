using Microsoft.AspNetCore.Components;

// ReSharper disable once CheckNamespace
namespace TorchUI.Bootstrap.Components;

/// <summary>
/// Represents a Bootstrap <c>.offcanvas-header</c>
/// </summary>
public partial class OffcanvasHeader
{
	/// <summary>
	/// The title of the offcanvas
	/// </summary>
	[Parameter]
	public string? Title { get; set; }

	/// <summary>
	/// The HTML tag name of the title element
	/// </summary>
	[Parameter]
	public string? TitleTag { get; set; }

	/// <summary>
	/// Whether the offcanvas close button should be omitted
	/// </summary>
	[Parameter]
	public bool OmitCloseButton { get; set; }

	/// <inheritdoc />
	protected override void SetupAttributes()
	{
		CssBuilder.AddClass("offcanvas-header");
	}
}
