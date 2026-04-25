using Microsoft.AspNetCore.Components;
using TorchUI.Validation;

// ReSharper disable once CheckNamespace
namespace TorchUI;

/// <summary>
/// Adds HTML5 <c>data-val-*</c> attributes to selects for client-side validation
/// </summary>
/// <typeparam name="TValue">The type of the value</typeparam>
public class SelectFieldBase<TValue> : Microsoft.AspNetCore.Components.Forms.InputSelect<TValue>
{
	[Inject]
	private IValidationAttributeGenerator ValidationAttributeGenerator { get; set; } = null!;

	/// <inheritdoc />
	protected override void OnParametersSet()
	{
		var attr = ValidationAttributeGenerator.Generate(ValueExpression!);

		if (AdditionalAttributes is not null)
		{
			foreach (var kvp in AdditionalAttributes)
			{
				attr.Add(kvp.Key, kvp.Value);
			}
		}

		AdditionalAttributes = attr;
	}
}