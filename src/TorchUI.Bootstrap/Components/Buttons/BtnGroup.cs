using Microsoft.AspNetCore.Components;
using TorchUI.Bootstrap.Extensions;

// ReSharper disable once CheckNamespace
namespace TorchUI.Bootstrap.Components;

/// <summary>
/// Represents a Bootstrap <c>.btn-group</c>
/// </summary>
public class BtnGroup : TorchComponentBase
{
	/// <summary>
	/// The ARIA label to describe the button group
	/// </summary>
	/// <remarks>
	/// This value will not override an existing <c>aria-label</c> attribute.
	/// </remarks>
	[Parameter]
	public string? Label { get; set; }

	/// <summary>
	/// The Bootstrap size of the button group
	/// </summary>
	[Parameter]
	public Size Size { get; set; } = Size.Medium;

	/// <summary>
	/// Whether the button group should be vertical
	/// </summary>
	[Parameter]
	public bool Vertical { get; set; }

	/// <inheritdoc />
	protected override void SetupAttributes()
	{
		CssBuilder.AddClass("btn-group", !Vertical);
		CssBuilder.AddClass("btn-group-vertical", Vertical);
		GetOrSetAttribute("role", "group");

		if (Size is not Size.Medium)
		{
			CssBuilder.AddClass(Size.GetSizeClass("btn-group"));
		}

		if (!string.IsNullOrEmpty(Label))
		{
			GetOrSetAttribute("aria-label", Label);
		}
	}
}