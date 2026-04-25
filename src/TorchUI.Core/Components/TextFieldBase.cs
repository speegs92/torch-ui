using Microsoft.AspNetCore.Components;
using TorchUI.Validation;

// ReSharper disable once CheckNamespace
namespace TorchUI;

/// <summary>
/// Adds HTML5 <c>data-val-*</c> attributes to string inputs for client-side validation
/// </summary>
public class TextFieldBase : Microsoft.AspNetCore.Components.Forms.InputText
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
