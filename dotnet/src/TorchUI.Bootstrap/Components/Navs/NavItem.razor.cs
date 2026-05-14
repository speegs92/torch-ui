using Microsoft.AspNetCore.Components;

// ReSharper disable once CheckNamespace
namespace TorchUI.Bootstrap.Components;

/// <summary>
/// Represents a Bootstrap <c>.nav-item</c>
/// </summary>
public partial class NavItem
{
	/// <summary>
	/// The destination of the nav item
	/// </summary>
	/// <remarks>
	/// If this is <see langword="null"/>, the <c>NavItem</c> is rendered without an inner <c>&lt;a&gt;</c>. If you wish to customize the <c>&lt;a&gt;</c> markup or styling, omit this parameter and supply your own.
	/// </remarks>
	[Parameter]
	public string? Href { get; set; }

	/// <summary>
	/// 
	/// </summary>
	[Parameter]
	public bool Disabled { get; set; }

	/// <inheritdoc />
	protected override void SetupAttributes()
	{
		Tag ??= "li";
		CssBuilder.AddClass("nav-item");
	}
}
