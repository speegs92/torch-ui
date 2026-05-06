using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

// ReSharper disable once CheckNamespace
namespace TorchUI.Bootstrap.Components;

/// <summary>
/// Represents a Bootstrap <c>.nav-link</c>
/// </summary>
public class NavLink : TorchComponentBase
{
	/// <summary>
	/// The nav link matching requirements to be considered active
	/// </summary>
	[Parameter]
	public NavLinkMatch Match { get; set; } = NavLinkMatch.All;

	/// <summary>
	/// The destination of the nav link
	/// </summary>
	[Parameter]
	[EditorRequired]
	public string Href { get; set; }

	/// <summary>
	/// Whether the nav link should be disabled
	/// </summary>
	[Parameter]
	public bool Disabled { get; set; }

	[Inject]
	private NavigationManager NavManager { get; set; } = null!;

	/// <inheritdoc />
	protected override void SetupAttributes()
	{
		Tag = "a";
		var isActive = IsActive();

		CssBuilder
			.AddClass("nav-link")
			.AddClass("active", isActive);

		UserAttributes["href"] = Href;

		if (Disabled)
		{
			CssBuilder.AddClass("disabled");
			UserAttributes["aria-disabled"] = "true";
		}

		if (isActive)
		{
			UserAttributes["aria-current"] = "page";
		}
	}

	private bool IsActive()
	{
		var currentPage = NavManager.Uri;
		var targetPage = NavManager.ToAbsoluteUri(Href).AbsoluteUri;

		if (Match is NavLinkMatch.All && currentPage == targetPage)
		{
			return true;
		}

		if (Match is NavLinkMatch.Prefix && currentPage.StartsWith(targetPage))
		{
			return true;
		}

		return false;
	}
}
