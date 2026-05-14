// ReSharper disable once CheckNamespace
namespace TorchUI.Bootstrap.Components;

/// <summary>
/// Represents a Bootstrap radio button
/// </summary>
/// <typeparam name="TValue">The type of the value</typeparam>
public partial class RadioField<TValue>
{
	/// <inheritdoc />
	protected override void SetupAttributes()
	{
		CssBuilder.AddClass("form-check");
	}
}

