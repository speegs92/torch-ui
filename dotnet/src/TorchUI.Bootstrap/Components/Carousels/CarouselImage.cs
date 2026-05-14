using Microsoft.AspNetCore.Components;

// ReSharper disable once CheckNamespace
namespace TorchUI.Bootstrap.Components;

/// <summary>
/// Represents a full-width, block-rendered <c>&lt;img&gt;</c> for use inside Bootstrap carousels
/// </summary>
public class CarouselImage : TorchComponentBase
{
	/// <summary>
	/// The image's <c>src</c> attribute value. Required
	/// </summary>
	[Parameter]
	public required string Src { get; set; }

	/// <summary>
	/// The image's <c>alt</c> attribute value. Required
	/// </summary>
	[Parameter]
	public required string Alt { get; set; }

	/// <inheritdoc />
	protected override void SetupAttributes()
	{
		Tag = "img";
		CssBuilder.AddClass("d-block w-100");
		UserAttributes["src"] = Src;
		UserAttributes["alt"] = Alt;
	}
}
