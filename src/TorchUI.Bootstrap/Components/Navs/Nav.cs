using Microsoft.AspNetCore.Components;

// ReSharper disable once CheckNamespace
namespace TorchUI.Bootstrap.Components;

/// <summary>
/// Represents a Bootstrap <c>.nav</c>
/// </summary>
public class Nav : TorchComponentBase
{
	/// <summary>
	/// Whether the nav's content should unevenly fill the available space
	/// </summary>
	[Parameter]
	public bool Fill { get; set; }

	/// <summary>
	/// Whether the nav's content should evenly fill the available space
	/// </summary>
	[Parameter]
	public bool Justified { get; set; }

	/// <summary>
	/// Whether the nav should be rendered in pill style
	/// </summary>
	[Parameter]
	public bool Pills { get; set; }

	/// <summary>
	/// Whether the nav should be rendered in tab style
	/// </summary>
	[Parameter]
	public bool Tabs { get; set; }

	/// <summary>
	/// Whether the nav should be rendered in underline style
	/// </summary>
	[Parameter]
	public bool Underline { get; set; }

	/// <inheritdoc />
	protected override void SetupAttributes()
	{
		Tag ??= "ul";
		CssBuilder.AddClass("nav");

		if (Fill)
		{
			CssBuilder.AddClass("nav-fill");
		}
		else if (Justified)
		{
			CssBuilder.AddClass("nav-justified");
		}

		if (Pills)
		{
			CssBuilder.AddClass("nav-pills");
		}
		else if (Tabs)
		{
			CssBuilder.AddClass("nav-tabs");
		}
		else if (Underline)
		{
			CssBuilder.AddClass("nav-underline");
		}
	}
}
