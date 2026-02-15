using Microsoft.AspNetCore.Components;

// ReSharper disable once CheckNamespace
namespace TorchUI.Bootstrap.Components;

/// <summary>
/// Represents a Bootstrap <c>.page-item</c>
/// </summary>
public partial class PageItem
{
	/// <summary>
	/// The <c>href</c> attribute of the pagination link
	/// </summary>
	[Parameter]
	[EditorRequired]
	public string Href { get; set; }

	/// <summary>
	/// The <c>aria-label</c> attribute of the pagination link
	/// </summary>
	[Parameter]
	public string? Label { get; set; }

	/// <summary>
	/// Whether the page item is active
	/// </summary>
	[Parameter]
	public bool Active { get; set; }

	/// <summary>
	/// Whether the page item is disabled
	/// </summary>
	[Parameter]
	public bool Disabled { get; set; }

	/// <inheritdoc />
	protected override void SetupAttributes()
	{
		CssBuilder
			.AddClass("page-item")
			.AddClass("active", Active)
			.AddClass("disabled", Disabled);
	}
}
