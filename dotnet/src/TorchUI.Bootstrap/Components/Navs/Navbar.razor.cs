using System;
using Microsoft.AspNetCore.Components;
using TorchUI.Bootstrap.Extensions;

// ReSharper disable once CheckNamespace
namespace TorchUI.Bootstrap.Components;

/// <summary>
/// Represents a Bootstrap <c>.navbar</c>
/// </summary>
public partial class Navbar
{
	private readonly string _fallbackNavId = Guid
		.NewGuid()
		.ToString();

	/// <summary>
	/// The name of the <c>.navbar-collapse</c> HTML ID cascading parameter
	/// </summary>
	public const string NavbarCollapseId = nameof(NavbarCollapseId);

	/// <summary>
	/// The breakpoint at which the navbar should be expanded
	/// </summary>
	[Parameter]
	public Breakpoint ExpandOn { get; set; }

	/// <inheritdoc />
	protected override void SetupAttributes()
	{
		Tag ??= "nav";

		CssBuilder
			.AddClass("navbar")
			.AddClass(
				ExpandOn.GetBreakpointClass("navbar-expand"),
				ExpandOn is not Breakpoint.Xs);
	}
}

