using Microsoft.AspNetCore.Components.Rendering;

// ReSharper disable once CheckNamespace
namespace TorchUI.Bootstrap.Components;

/// <summary>
/// Represents a Bootstrap <c>.dropdown-toggle-split</c>
/// </summary>
public class DropdownToggleSplitBtn : ToggleBtn
{
	/// <summary>
	/// Creates a new instance of <c>DropdownToggleSplitBtn</c> with its <see cref="Toggle"/> parameter set to <see cref="Toggle.Dropdown"/>
	/// </summary>
	public DropdownToggleSplitBtn() => Toggle = Toggle.Dropdown;

	/// <inheritdoc />
	protected override void SetupAttributes()
	{
		CssBuilder.AddClass("dropdown-toggle-split");
		ChildContent ??= DefaultContent;
		base.SetupAttributes();
	}

	private static void DefaultContent(RenderTreeBuilder rtb)
	{
		rtb.OpenElement(0, "span");
		rtb.AddAttribute(1, "class", "visually-hidden");
		rtb.AddContent(2, "Toggle dropdown");
		rtb.CloseElement();
	}
}
