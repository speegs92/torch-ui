// ReSharper disable once CheckNamespace
namespace TorchUI.Bootstrap.Components;

/// <summary>
/// Represents a Bootstrap <c>.nav</c>
/// </summary>
public class Nav : NavBase
{
	/// <inheritdoc />
	protected override void SetupAttributes()
	{
		CssBuilder.AddClass("nav");
		base.SetupAttributes();
	}
}
