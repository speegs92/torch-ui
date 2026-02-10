// ReSharper disable once CheckNamespace
namespace TorchUI.Bootstrap.Components;

/// <summary>
/// Represents a Bootstrap <c>.navbar-text</c>
/// </summary>
public class NavbarText : TorchComponentBase
{
	/// <inheritdoc />
	protected override void SetupAttributes()
	{
		Tag ??= "span";
		CssBuilder.AddClass("navbar-text");
	}
}
