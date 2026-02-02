using Microsoft.AspNetCore.Components;

// ReSharper disable once CheckNamespace
namespace TorchUI.Bootstrap.Components;

/// <summary>
/// An activator button for a <see cref="TabPane"/>
/// </summary>
public class TabActivator : TorchComponentBase
{
	/// <summary>
	/// The activator's HTML ID
	/// </summary>
	[Parameter]
	[EditorRequired]
	public string Id { get; set; }

	/// <summary>
	/// The HTML ID of the tab pane the tab activator activates
	/// </summary>
	[Parameter]
	[EditorRequired]
	public string TabPaneId { get; set; }

	/// <summary>
	/// Whether the tab activator's tab is active
	/// </summary>
	[Parameter]
	public bool Active { get; set; }

	/// <summary>
	/// Whether the tab activator is disabled
	/// </summary>
	[Parameter]
	public bool Disabled { get; set; }

	/// <inheritdoc />
	protected override void SetupAttributes()
	{
		Tag = "button";

		CssBuilder.AddClass("nav-link");

		UserAttributes["type"] = "button";
		UserAttributes["role"] = "tab";
		UserAttributes["data-bs-toggle"] = "tab";
		UserAttributes["data-bs-target"] = $"#{TabPaneId}";
		UserAttributes["aria-controls"] = TabPaneId;

		if (Active)
		{
			CssBuilder.AddClass("active");
			UserAttributes["aria-selected"] = "true";
		}

		if (Disabled)
		{
			CssBuilder.AddClass("disabled");
			UserAttributes["disabled"] = "disabled";
		}
	}

	/// <summary>
	/// The parameters to provide to the <see cref="TabActivator"/> component
	/// </summary>
	public class TabActivatorParameters
	{
		/// <summary>
		/// The activator's HTML ID
		/// </summary>
		public required string ActivatorId { get; set; }

		/// <summary>
		/// The HTML ID of the tab pane the tab activator activates
		/// </summary>
		public required string TabPaneId { get; set; }

		/// <summary>
		/// Whether the tab activator's tab is active
		/// </summary>
		public bool Active { get; set; }

		/// <summary>
		/// Whether the tab activator is disabled
		/// </summary>
		public bool Disabled { get; set; }
	}
}
