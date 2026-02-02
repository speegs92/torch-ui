using System;
using Microsoft.AspNetCore.Components;

// ReSharper disable once CheckNamespace
namespace TorchUI.Bootstrap.Components;

/// <summary>
/// Represents a Bootstrap <c>.tab-pane</c>
/// </summary>
public partial class TabPane : IDisposable
{
	private string _tabPaneId = string.Empty;
	private readonly string _fallbackId = Guid
		.NewGuid()
		.ToString();

	/// <summary>
	/// The activator button's ID
	/// </summary>
	[Parameter]
	public string ActivatorId { get; set; } = Guid
		.NewGuid()
		.ToString();

	/// <summary>
	/// The tab pane's activator text
	/// </summary>
	[Parameter]
	public string? Title { get; set; }

	/// <summary>
	/// The tab's activator button
	/// </summary>
	[Parameter]
	public RenderFragment<TabActivator.TabActivatorParameters>? Activator { get; set; }

	/// <summary>
	/// Whether the tab pane should be rendered as active
	/// </summary>
	[Parameter]
	public bool Active { get; set; }

	/// <summary>
	/// Whether the tab pane should fade on transition
	/// </summary>
	[Parameter]
	public bool Fade { get; set; }

	/// <summary>
	/// Whether the tab pane should be disabled
	/// </summary>
	[Parameter]
	public bool Disabled { get; set; }

	/// <summary>
	/// The containing tab list
	/// </summary>
	[CascadingParameter]
	public TabList? Parent { get; set; }

	/// <inheritdoc />
	protected override void OnInitialized()
	{
		Parent?.Register(this);
	}

	/// <inheritdoc />
	protected override void SetupAttributes()
	{
		CssBuilder
			.AddClass("tab-pane")
			.AddClass("active", Active)
			.AddClass("fade", Fade);

		_tabPaneId = GetOrSetAttribute("id", _fallbackId);
	}

	/// <inheritdoc />
	public void Dispose()
	{
		Parent?.Unregister(this);
		GC.SuppressFinalize(this);
	}
}
