using Microsoft.AspNetCore.Components;

// ReSharper disable once CheckNamespace
namespace TorchUI.Bootstrap.Components;

/// <summary>
/// Represents a Bootstrap <c>.container</c>
/// </summary>
public class Container : TorchComponentBase
{
	/// <summary>
	/// The breakpoint at which the Bootstrap container stops being full-width. Corresponds to <c>.container-sm</c>, <c>.container-md</c>, etc.
	/// </summary>
	/// <remarks>
	/// If <see cref="Fluid"/> is <see langword="true"/>, this parameter has no effect.
	/// </remarks>
	[Parameter]
	public Breakpoint FullWidthUntil { get; set; } = Breakpoint.Xs;

	/// <summary>
	/// Whether the Bootstrap container should be fluid. Corresponds to <c>.container-fluid</c>
	/// </summary>
	/// <remarks>
	/// If <see cref="Fluid"/> is <see langword="true"/>, the <see cref="FullWidthUntil"/> parameter has no effect.
	/// </remarks>
	[Parameter]
	public bool Fluid { get; set; }

	/// <inheritdoc />
	protected override void SetupAttributes()
	{
		// If XS, only add "container"
		CssBuilder.AddClass(
			"container",
			!Fluid && FullWidthUntil == Breakpoint.Xs);

		// If >XS, only add "container-{breakpoint}"
		CssBuilder.AddClass(
			$"container-{FullWidthUntil.ToString().ToLowerInvariant()}",
			!Fluid && FullWidthUntil > Breakpoint.Xs);

		// If fluid, only add "container-fluid"
		CssBuilder.AddClass("container-fluid", Fluid);
	}
}
