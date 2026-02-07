using Microsoft.AspNetCore.Components;
using TorchUI.Bootstrap.Extensions;

// ReSharper disable once CheckNamespace
namespace TorchUI.Bootstrap.Components;

/// <summary>
/// Represents a Bootstrap <c>.btn</c>
/// </summary>
/// <remarks>
/// <para>
/// Because Bootstrap button classes are valid on different types of markup, this component attempts to infer which type of markup should be rendered based on the supplied attributes. If an <c>href</c> is supplied, the component renders as an <c>&lt;a&gt;</c> tag. If a <c>value</c> is supplied, the component renders as an <c>&lt;input type="button"&gt;</c>. If neither value is supplied, the component renders as a <c>&lt;button&gt;</c>.
/// </para>
/// <para>
/// If the component receives <c>href="#"</c>, it not only renders as an <c>&lt;a&gt;</c>, but it also adds <c>role="button"</c> because an anchor tag with <c>href="#"</c> is probably being used as a trigger for in-page content.
/// </para> 
/// </remarks>
public class Btn : TorchComponentBase
{
	/// <summary>
	/// The Bootstrap theme color of the button
	/// </summary>
	[Parameter]
	public ThemeColor? Color { get; set; }

	/// <summary>
	/// The Bootstrap size of the button
	/// </summary>
	[Parameter]
	public Size Size { get; set; } = Size.Medium;

	/// <summary>
	/// The toggle action of the button
	/// </summary>
	[Parameter]
	public Toggle? Toggle { get; set; }

	/// <summary>
	/// The dismiss action of the button
	/// </summary>
	[Parameter]
	public Toggle? Dismiss { get; set; }

	/// <summary>
	/// The target of the toggle action
	/// </summary>
	[Parameter]
	public string? Target { get; set; }

	/// <summary>
	/// Whether the control the button controls is active
	/// </summary>
	/// <remarks>
	/// If the button is a toggle button, this refers to the button itself - i.e., if the button is in the "on" state, <see cref="Active"/> should be <see langword="true"/>. If the button is a different type of Bootstrap toggle, such as a modal toggle, this refers to the external control's active state - i.e., if the button's <see cref="Target"/> modal is open, <see cref="Active"/> should be <see langword="true"/>.
	/// </remarks>
	[Parameter]
	public bool Active { get; set; }

	/// <summary>
	/// Whether the button should be outlined
	/// </summary>
	/// <remarks>
	/// Only has an effect if the <see cref="Color"/> parameter has a value because Bootstrap doesn't define a <c>.btn-outline</c> class
	/// </remarks>
	[Parameter]
	public bool Outlined { get; set; }

	protected override void SetupAttributes()
	{
		// Anchor tags don't need a type attribute
		var omitType = false;

		if (UserAttributes.TryGetValue("href", out var href))
		{
			// If there's an href, this should be a link
			Tag = "a";
			omitType = true;

			// If the href equals "#", the anchor is a trigger for in-page functionality
			if (href.ToString() == "#")
			{
				UserAttributes.Add("role", "button");
			}
		}
		else if (UserAttributes.ContainsKey("value"))
		{
			Tag = "input";
		}
		else
		{
			Tag = "button";
		}

		if (!omitType && !UserAttributes.TryGetValue("type", out _))
		{
			UserAttributes.Add("type", "button");
		}

		CssBuilder.AddClass("btn");

		if (Color is not null)
		{
			var outlinedInfix = Outlined ? "-outline" : string.Empty;
			CssBuilder.AddClass(Color.Value.GetThemeColorClass($"btn{outlinedInfix}"));
		}

		if (Size is not Size.Medium)
		{
			CssBuilder.AddClass(Size.GetSizeClass("btn"));
		}

		if (Dismiss.HasValue)
		{
			UserAttributes.Add(
				"data-bs-dismiss",
				Dismiss.Value.ToString().ToLowerInvariant());
		}

		if (Toggle.HasValue)
		{
			MakeToggleButton();
		}
	}

	private void MakeToggleButton()
	{
		var value = Toggle!.Value;

		UserAttributes.Add(
			"data-bs-toggle",
			value.ToString().ToLowerInvariant());

		if (!string.IsNullOrEmpty(Target))
		{
			UserAttributes.Add("data-bs-target", Target);

			if (Target.StartsWith('#'))
			{
				UserAttributes.Add("aria-controls", Target);
			}
		}

		switch (value)
		{
			case Bootstrap.Toggle.Button:
				CssBuilder.AddClass("active", Active);
				UserAttributes.Add("aria-pressed", Active ? "true" : "false");
				break;
			case Bootstrap.Toggle.Collapse:;
				UserAttributes.Add("aria-expanded", Active ? "true" : "false");
				break;
		}
	}
}