using Microsoft.AspNetCore.Components;

// ReSharper disable once CheckNamespace
namespace TorchUI.Bootstrap.Components;

/// <summary>
/// Represents a Bootstrap <c>.navbar-nav</c>
/// </summary>
public class NavbarNav : NavBase
{
	/// <summary>
	/// Whether the nav should be scrollable
	/// </summary>
	/// <remarks>
	/// It is up to the developer to provide the appropriate scroll height. No component parameter exists because we don't want the added complexity of merging multiple <c>style</c> attributes, which Blazor does not do automatically. The Bootstrap docs recommend providing this via the <c>--bs-scroll-height</c> CSS variable.
	/// </remarks>
	[Parameter]
	public bool Scrollable { get; set; }

	/// <inheritdoc />
	protected override void SetupAttributes()
	{
		CssBuilder
			.AddClass("navbar-nav")
			.AddClass("navbar-nav-scrollable", Scrollable);
		base.SetupAttributes();
	}
}
