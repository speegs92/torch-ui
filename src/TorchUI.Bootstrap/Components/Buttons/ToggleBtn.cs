using Microsoft.AspNetCore.Components;

// ReSharper disable once CheckNamespace
namespace TorchUI.Bootstrap.Components;

/// <summary>
/// Represents a Bootstrap <c>.btn</c> with a <c>data-bs-toggle</c> attribute
/// </summary>
public class ToggleBtn : BtnBase
{
	/// <summary>
	/// The toggle action of the button
	/// </summary>
	[Parameter]
	public Toggle Toggle { get; set; }

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

	/// <inheritdoc />
	protected override void SetupAttributes()
	{
		UserAttributes.Add(
			"data-bs-toggle",
			Toggle.ToString().ToLowerInvariant());

		if (!string.IsNullOrEmpty(Target))
		{
			UserAttributes.Add("data-bs-target", Target);

			if (Target.StartsWith('#'))
			{
				UserAttributes.Add("aria-controls", Target);
			}
		}

		switch (Toggle)
		{
			case Toggle.Button:
				CssBuilder.AddClass("active", Active);
				UserAttributes.Add("aria-pressed", Active ? "true" : "false");
				break;
			case Toggle.Collapse:
				UserAttributes.Add("aria-expanded", Active ? "true" : "false");
				break;
			case Toggle.Dropdown:
				CssBuilder.AddClass("dropdown-toggle");
				UserAttributes.Add("aria-expanded", Active ? "true" : "false");
				break;
		}

		base.SetupAttributes();
	}
}
