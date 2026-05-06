using Microsoft.AspNetCore.Components;

// ReSharper disable once CheckNamespace
namespace TorchUI.Bootstrap.Components;

/// <summary>
/// Represents a Bootstrap <c>.btn</c> with a <c>data-bs-dismiss</c> attribute
/// </summary>
public class DismissBtn : BtnBase
{
	/// <summary>
	/// The dismiss action of the button
	/// </summary>
	[Parameter]
	public Toggle Dismiss { get; set; }

	/// <inheritdoc />
	protected override void SetupAttributes()
	{
		UserAttributes.Add(
			"data-bs-dismiss",
			Dismiss.ToString().ToLowerInvariant());
		base.SetupAttributes();
	}
}
