// ReSharper disable once CheckNamespace
namespace TorchUI.Bootstrap.Components;

/// <summary>
/// Represents a Bootstrap <c>.offcanvas-body</c>
/// </summary>
public class OffcanvasBody : TorchComponentBase
{
	/// <inheritdoc />
	protected override void SetupAttributes()
	{
		CssBuilder.AddClass("offcanvas-body");
	}
}
