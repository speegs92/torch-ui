// ReSharper disable once CheckNamespace
namespace TorchUI.Bootstrap.Components;

/// <summary>
/// Represents a Bootstrap <c>.dropdown-item-text</c>
/// </summary>
public partial class DropdownItemText
{
	/// <inheritdoc />
	protected override void SetupAttributes()
	{
		Tag ??= "span";
		CssBuilder.AddClass("dropdown-item-text");
	}
}
