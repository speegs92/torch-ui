// ReSharper disable once CheckNamespace
namespace TorchUI.Bootstrap.Components;

/// <summary>
/// Represents a Bootstrap <c>.dropdown-menu</c>
/// </summary>
public class DropdownMenu : TorchComponentBase
{
	/// <inheritdoc />
	protected override void SetupAttributes()
	{
		Tag = "ul";
		CssBuilder.AddClass("dropdown-menu");
	}
}
