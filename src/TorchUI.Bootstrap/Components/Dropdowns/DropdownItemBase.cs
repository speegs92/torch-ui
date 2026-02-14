using Microsoft.AspNetCore.Components;

// ReSharper disable once CheckNamespace
namespace TorchUI.Bootstrap.Components;

/// <summary>
/// A base Bootstrap dropdown item
/// </summary>
public class DropdownItemBase : TorchComponentBase
{
	/// <summary>
	/// Additional CSS classes to add to the <c>&lt;</c> wrapping the dropdown item
	/// </summary>
	[Parameter]
	public string? WrapperClasses { get; set; }

	/// <summary>
	/// Whether the dropdown item is active
	/// </summary>
	[Parameter]
	public bool Active { get; set; }

	/// <summary>
	/// Whether the dropdown item is disabled
	/// </summary>
	[Parameter]
	public bool Disabled { get; set; }

	/// <inheritdoc />
	protected override void SetupAttributes()
	{
		CssBuilder
			.AddClass("dropdown-item")
			.AddClass(WrapperClasses)
			.AddClass("active", Active);
	}
}
