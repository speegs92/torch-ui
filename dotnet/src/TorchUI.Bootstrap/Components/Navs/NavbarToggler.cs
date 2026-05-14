using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

// ReSharper disable once CheckNamespace
namespace TorchUI.Bootstrap.Components;

/// <summary>
/// A bootstrap <c>.navbar-toggler</c>
/// </summary>
public class NavbarToggler : TorchComponentBase
{
	/// <summary>
	/// The ID of the collapsible nav menu
	/// </summary>
	[Parameter]
	public string? Target { get; set; }

	/// <summary>
	/// The ARIA label for the toggler
	/// </summary>
	[Parameter]
	public string Label { get; set; } = "Toggle navigation";

	/// <summary>
	/// The fallback ID of the collapsible nav menu, supplied by the <see cref="Navbar"/>
	/// </summary>
	[CascadingParameter(Name = Navbar.NavbarCollapseId)]
	public string FallbackTarget { get; set; } = string.Empty;

	/// <inheritdoc />
	protected override void SetupAttributes()
	{
		Tag = "button";
		ChildContent ??= DefaultContent;

		CssBuilder.AddClass("navbar-toggler");

		var target = Target ?? $"#{FallbackTarget}";

		UserAttributes["type"] = "button";
		UserAttributes["data-bs-toggle"] = "collapse";
		UserAttributes["data-bs-target"] = target;
		UserAttributes["aria-controls"] = target[1..];
		UserAttributes["aria-expanded"] = "false";
		UserAttributes["aria-label"] = Label;
	}

	private static void DefaultContent(RenderTreeBuilder rtb)
	{
		rtb.OpenElement(0, "span");
		rtb.AddAttribute(1, "class", "navbar-toggler-icon");
		rtb.CloseElement();
	}
}
