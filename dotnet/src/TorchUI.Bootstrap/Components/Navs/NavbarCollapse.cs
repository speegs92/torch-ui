using Microsoft.AspNetCore.Components;

// ReSharper disable once CheckNamespace
namespace TorchUI.Bootstrap.Components;

/// <summary>
/// Represents a Bootstrap <c>.navbar-collapse</c>
/// </summary>
public class NavbarCollapse : Collapse
{
	/// <summary>
	/// The fallback ID of the navbar collapse
	/// </summary>
	[CascadingParameter(Name = Navbar.NavbarCollapseId)]
	public string FallbackId { get; set; } = string.Empty;

	/// <inheritdoc />
	protected override void SetupAttributes()
	{
		CssBuilder.AddClass("navbar-collapse");
		GetOrSetAttribute("id", FallbackId);
		base.SetupAttributes();
	}
}
