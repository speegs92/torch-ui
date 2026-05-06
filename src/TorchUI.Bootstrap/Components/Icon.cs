using Microsoft.AspNetCore.Components;
using TorchUI.Bootstrap.Extensions;

// ReSharper disable once CheckNamespace
namespace TorchUI.Bootstrap;

/// <summary>
/// Represents a Bootstrap icon
/// </summary>
public class Icon : TorchComponentBase
{
	/// <summary>
	/// The name of the icon to render
	/// </summary>
	[Parameter]
	public required string Name { get; set; }

	/// <summary>
	/// The color of the icon
	/// </summary>
	[Parameter]
	public ThemeColor? Color { get; set; }

	/// <summary>
	/// The ARIA label to describe the icon, if any
	/// </summary>
	[Parameter]
	public string? Label { get; set; }

	/// <inheritdoc />
	protected override void SetupAttributes()
	{
		Tag = "i";

		CssBuilder
			.AddClass("bi")
			.AddClass($"bi-{Name}");

		if (Color.HasValue)
		{
			CssBuilder.AddClass(Color.Value.GetTextColorClass());
		}

		if (!string.IsNullOrEmpty(Label))
		{
			UserAttributes["aria-label"] = Label;
		}
		else
		{
			UserAttributes["aria-hidden"] = "true";
		}
	}
}
