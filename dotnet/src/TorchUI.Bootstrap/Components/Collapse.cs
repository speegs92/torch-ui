using Microsoft.AspNetCore.Components;

// ReSharper disable once CheckNamespace
namespace TorchUI.Bootstrap;

/// <summary>
/// Represents a Bootstrap <c>.collapse</c>
/// </summary>
public class Collapse : TorchComponentBase
{
	/// <summary>
	/// Whether the collapse should be open by default
	/// </summary>
	[Parameter]
	public bool Show { get; set; }

	/// <summary>
	/// Whether the collapse should open horizontally
	/// </summary>
	[Parameter]
	public bool Horizontal { get; set; }

	/// <inheritdoc />
	protected override void SetupAttributes()
	{
		CssBuilder
			.AddClass("collapse")
			.AddClass("show", Show)
			.AddClass("collapse-horizontal", Horizontal);
	}
}
