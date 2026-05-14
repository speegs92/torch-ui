using System;
using Microsoft.AspNetCore.Components;

// ReSharper disable once CheckNamespace
namespace TorchUI.Bootstrap.Components;

/// <summary>
/// Represents a Bootstrap <c>.list-group</c>
/// </summary>
public partial class ListGroup
{
	/// <summary>
	/// The breakpoint at which the list group should be horizontal, if any
	/// </summary>
	[Parameter]
	public Breakpoint? HorizontalAt { get; set; }

	/// <summary>
	/// The theme color with which to render list group items
	/// </summary>
	[Parameter]
	public ThemeColor? Color { get; set; }

	/// <summary>
	/// Whether the list group should be flush with its container
	/// </summary>
	[Parameter]
	public bool Flush { get; set; }

	/// <summary>
	/// Whether the list group should be numbered
	/// </summary>
	[Parameter]
	public bool Numbered { get; set; }

	/// <summary>
	/// Whether the list group should render its horizontal items with equal width
	/// </summary>
	/// <remarks>
	/// If <see cref="HorizontalAt"/> doesn't have a value, this parameter has no effect.
	/// </remarks>
	[Parameter]
	public bool EqualWidth { get; set; }

	/// <inheritdoc />
	protected override void SetupAttributes()
	{
		if (HorizontalAt.HasValue && Flush)
		{
			throw new InvalidOperationException("Bootstrap 5.3 does not support horizontal flush lists.");
		}

		CssBuilder
			.AddClass("list-group")
			.AddClass("list-group-flush", Flush)
			.AddClass("list-group-numbered", Numbered)
			.AddClass($"list-group-horizontal", HorizontalAt is Breakpoint.Xs)
			.AddClass($"list-group-horizontal-{HorizontalAt?.ToString().ToLowerInvariant()}", HorizontalAt is >Breakpoint.Xs);
	}
}
