using Microsoft.AspNetCore.Components;

// ReSharper disable once CheckNamespace
namespace TorchUI.Bootstrap.Components;

/// <summary>
/// Represents a Bootstrap <c>.dropdown-item</c> rendered as a link
/// </summary>
public partial class DropdownItemLink
{
	/// <summary>
	/// The target of the dropdown link
	/// </summary>
	[Parameter]
	[EditorRequired]
	public string Href { get; set; }

	/// <inheritdoc />
	protected override void SetupAttributes()
	{
		Tag = "a";
		CssBuilder.AddClass("disabled", Disabled);
		UserAttributes["href"] = Href;
		base.SetupAttributes();
	}
}
