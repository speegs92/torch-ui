using Microsoft.AspNetCore.Components;

// ReSharper disable once CheckNamespace
namespace TorchUI.Bootstrap.Components;

/// <summary>
/// Represents a Bootstrap <c>.dropdown-header</c>
/// </summary>
public partial class DropdownHeader
{
	/// <summary>
	/// Additional CSS classes to add to the <c>&lt;</c> wrapping the dropdown header
	/// </summary>
	[Parameter]
	public string? WrapperClasses { get; set; }

	/// <inheritdoc />
	protected override void SetupAttributes()
	{
		Tag ??= "span";
		CssBuilder.AddClass("dropdown-header");
	}
}

