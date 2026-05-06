using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace TorchUI.Bootstrap.Components;

/// <summary>
/// Represents a Bootstrap tab list
/// </summary>
public partial class TabList
{
	private readonly List<TabPane> _children = [];

	/// <summary>
	/// Registers a tab pane with the tab list
	/// </summary>
	/// <param name="pane">The tab pane to register</param>
	public void Register(TabPane pane)
	{
		_children.Add(pane);
		StateHasChanged();
	}

	/// <summary>
	/// Unregisters a tab pane with the tab list
	/// </summary>
	/// <param name="pane">The tab pane to unregister</param>
	public void Unregister(TabPane pane)
	{
		_children.Remove(pane);
		StateHasChanged();
	}
}

