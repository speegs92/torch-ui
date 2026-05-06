using System;
using Microsoft.AspNetCore.Components;
using TorchUI.Bootstrap.Extensions;

// ReSharper disable once CheckNamespace
namespace TorchUI.Bootstrap.Components;

/// <summary>
/// Represents a Bootstrap <c>.offcanvas</c>
/// </summary>
public partial class Offcanvas
{
	private readonly string _fallbackTitleId = Guid
		.NewGuid()
		.ToString();

	/// <summary>
	/// The placement of the offcanvas on the page
	/// </summary>
	[Parameter]
	[EditorRequired]
	public Placement Placement { get; set; }

	/// <summary>
	/// The breakpoint at which the offcanvas should be hidden by default
	/// </summary>
	[Parameter]
	public Breakpoint HideOn { get; set; } = Breakpoint.Xs;

	/// <summary>
	/// The HTML ID of the offcanvas element
	/// </summary>
	/// <remarks>
	/// This parameter is required because offcanvases cannot be triggered without an ID.
	/// </remarks>
	[Parameter]
	[EditorRequired]
	public string Id { get; set; }

	/// <summary>
	/// The ID of the offcanvas title element
	/// </summary>
	/// <remarks>
	/// Using an ID for the offcanvas title is highly recommended for assistive technologies, but it is not generally required for functionality. For this reason, a default ID will be generated and used if this parameter is not supplied. You should probably only provide an ID if you need to access the title via JavaScript.
	/// </remarks>
	[Parameter]
	public string? TitleId { get; set; }

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
	/// Whether the document body should be scrollable while the offcanvas is open
	/// </summary>
	[Parameter]
	public bool EnableBodyScrolling { get; set; }

	/// <summary>
	/// Whether to disable the backdrop covering the document body while the offcanvas is open
	/// </summary>
	[Parameter]
	public bool DisableBackdrop { get; set; }

	/// <summary>
	/// Whether the backdrop should prevent the offcanvas from exiting when clicked
	/// </summary>
	[Parameter]
	public bool Static { get; set; }

	/// <inheritdoc />
	protected override void SetupAttributes()
	{
		CssBuilder
			.AddClass("offcanvas", HideOn is Breakpoint.Xs)
			.AddClass(HideOn.GetBreakpointClass("offcanvas"), HideOn is not Breakpoint.Xs)
			.AddClass(Placement.GetPlacementClass("offcanvas"));

		UserAttributes["id"] = Id;
		UserAttributes["tabindex"] = "-1";
		UserAttributes["aria-labelledby"] = TitleId ?? _fallbackTitleId;

		if (EnableBodyScrolling)
		{
			UserAttributes["data-bs-scroll"] = "true";
		}

		if (DisableBackdrop)
		{
			UserAttributes["data-bs-backdrop"] = "false";
		}

		if (Static)
		{
			UserAttributes["data-bs-backdrop"] = "static";
		}
	}
}
