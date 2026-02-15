using Microsoft.AspNetCore.Components;

// ReSharper disable once CheckNamespace
namespace TorchUI.Bootstrap.Components;

/// <summary>
/// Represents a Bootstrap <c>.offcanvas-title</c>
/// </summary>
/// <remarks>
/// This should ideally be rendered as one of <c>&lt;h1&gt;</c>-<c>&lt;h6&gt;</c>. Because an offcanvas is probably structurally unrelated from the main content in a document, this components renders as an <c>&lt;h2&gt;</c> by default.
/// </remarks>
public class OffcanvasTitle : TorchComponentBase
{
	/// <summary>
	/// The ID of the offcanvas title, supplied by the root <see cref="Offcanvas"/> component
	/// </summary>
	[CascadingParameter(Name = nameof(TitleId))]
	public string TitleId { get; set; } = string.Empty;

	/// <inheritdoc />
	protected override void SetupAttributes()
	{
		Tag ??= "h2";
		CssBuilder.AddClass("offcanvas-title");
		UserAttributes["id"] = TitleId;
	}
}
