// ReSharper disable once CheckNamespace
namespace TorchUI.Bootstrap.Components;

/// <summary>
/// Represents a Bootstrap checkbox
/// </summary>
/// <typeparam name="TValue">The type of the value</typeparam>
public partial class CheckboxField<TValue>
{
	/// <inheritdoc />
	protected override void SetupAttributes()
	{
		CssBuilder.AddClass("form-check");
	}
}

