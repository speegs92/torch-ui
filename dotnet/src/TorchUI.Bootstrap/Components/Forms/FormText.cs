// ReSharper disable once CheckNamespace
namespace TorchUI.Bootstrap.Components;

/// <summary>
/// Represents a Bootstrap <c>.form-text</c>
/// </summary>
public class FormText : TorchComponentBase
{
	/// <inheritdoc />
	protected override void SetupAttributes()
	{
		CssBuilder.AddClass("form-text");
	}
}
