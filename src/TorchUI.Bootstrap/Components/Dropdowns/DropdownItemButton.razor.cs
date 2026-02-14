// ReSharper disable once CheckNamespace
namespace TorchUI.Bootstrap.Components;

/// <summary>
/// Represents a Bootstrap <c>.dropdown-item</c> rendered as a button
/// </summary>
public partial class DropdownItemButton
{
	/// <inheritdoc />
	protected override void SetupAttributes()
	{
		Tag = "button";
		UserAttributes["type"] = "button";

		if (Disabled)
		{
			UserAttributes["disabled"] = "disabled";
		}

		base.SetupAttributes();
	}
}
