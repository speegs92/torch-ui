using Microsoft.AspNetCore.Components.Rendering;

// ReSharper disable once CheckNamespace
namespace TorchUI.Bootstrap.Components;

/// <summary>
/// Represents a Bootstrap <c>.dropdown-divider</c>
/// </summary>
public class DropdownDivider : TorchComponentBase
{
	/// <inheritdoc />
	protected override void SetupAttributes()
	{
		Tag = "li";
		ChildContent = DefaultContent;
	}

	private static void DefaultContent(RenderTreeBuilder rtb)
	{
		rtb.OpenElement(0, "hr");
		rtb.AddAttribute(1, "class", "dropdown-divider");
		rtb.CloseElement();
	}
}
